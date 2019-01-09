using System;
using System.IO;
using MailRoom.ParserLib;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MailRoom.Model;
using MailRoom.Repository;
using System.Timers;
using System.Reactive.Linq;
using MailRoom.Model.Constants;

namespace MailRoomCoreEngine
{
    class Program
    {
        private static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            Console.WriteLine("Database Details: " + configuration.GetConnectionString("MailRoom"));
            Console.WriteLine("Confidence Level Threshold: " + configuration.GetConnectionString("ConfidenceLevelThreshold"));

            Console.WriteLine("DataFetchFrequency set for minutes:" + configuration.GetConnectionString("DataFetchFrequency"));
            Console.WriteLine("NumberOfRecords per fetch:" + configuration.GetConnectionString("NumberOfRecords"));

            int numRecords = Int32.Parse(configuration.GetConnectionString("NumberOfRecords"));

            Mapper.Initialize(config =>
            {
                config.CreateMap<Cms15001, StagingClaimCms1500>();

                config.CreateMap<Cms15002, StagingClaimCms1500Detail>();

            });

            IObservable<long> timer =
     Observable
         .Defer(() =>
         {

             //var now = DateTimeOffset.Now;
             var afterMinutes = Int32.Parse(configuration.GetConnectionString("DataFetchFrequency"));
             //var result = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Offset);
             //result = result.AddMinutes(((now.Minute / afterMinutes) + 1) * afterMinutes);
             // starts immediatley, runs after every 'afterminutes'
             return Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromMinutes(afterMinutes));
         });

            timer.Subscribe(x =>
            {
                /* Your code here that run on the scheduled minute . */
                RunEngine();
            });

            Console.ReadLine();
        }



        private static void RunEngine()
        {

            //#1 Read Top 10 records from sql database
            List<Cms15001> top10Records = new List<Cms15001>();
            // start the parser
            ParserQueue parserQueue = new ParserQueue();

            //This event raised after all rows in the ParserQueue are parsed
            parserQueue.OnParsingCompleted += () =>
            {
                Console.WriteLine("Main Parser Completed @ " + DateTime.Now.ToLocalTime());
                Console.WriteLine("--------------------------------------------------");
                // updating the dirty claims as completed 
                using (MailRoomContext context = new MailRoomContext(configuration.GetConnectionString("MailRoom")))
                {
                    var top10Records2 = context.Cms15001  // 24column records
             .Where(claim => top10Records.Contains(claim))
                              .ToList();
                    // TODO: Modified Date??
                    top10Records2.ForEach(claim => { claim.Status = 2; }); //set in progress state
                    context.SaveChanges();
                }
                Console.WriteLine("Runs again after # minutes:  " + Int32.Parse(configuration.GetConnectionString("DataFetchFrequency")));

            };
            // This event raised after each row parsed
            parserQueue.OnRowParsed += (row) =>
            {

                Console.WriteLine("The row processed at " + DateTime.Now.ToLocalTime() + " Key: "
                    + row.Key + ", status " + row.ExecutionStatus + " error:" + row.Errors.Count);
                Console.WriteLine("Errors " + row.ParserErrorCsv);
                Console.WriteLine("*****");
                //make sure derived row for DB updation
                Cms15001 claimsRow = (Cms15001)row;
                using (MailRoomContext context = new MailRoomContext(configuration.GetConnectionString("MailRoom")))
                {
                    StagingClaimCms1500 targetRow = Mapper.Map<StagingClaimCms1500>(claimsRow);

                    foreach (var item in claimsRow.Cms15002)
                    {
                        // convert soure to target type via Mapper
                        var stagingClaimCms1500Detail = Mapper.Map<StagingClaimCms1500Detail>(item);
                        stagingClaimCms1500Detail.CreatedDate = DateTime.Now;
                        stagingClaimCms1500Detail.Id = 0; // Ignore as ChildId carried out, for insert
                        context.Entry(stagingClaimCms1500Detail).State = EntityState.Added;

                    }

                    targetRow.CreatedDate = DateTime.Now;
                    targetRow.ReviewerId = "reviewerid1";
                    // set status in engine
                    targetRow.ReviewStatus = ConstantStore.PENDING_STRING;

                    targetRow.ParserStatus = row.ExecutionStatus;
                    targetRow.ParserErrorCsv = row.ParserErrorCsv;
                    if (claimsRow.Cms15001Conf != null)
                        targetRow.ConfidenceLevel = Convert.ToInt32(claimsRow.Cms15001Conf.OverallTableConfidence);
                    else
                        targetRow.ConfidenceLevel = -1;

                    context.StagingClaimCms1500.Add(targetRow);
                    // context.Entry(claim).State = EntityState.Modified;
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null)
                            Console.WriteLine("Eror occured " + e.InnerException.Message);
                    }
                    // if ( claim != null)
                    //{
                    //     claim.ParserErrorCsv = String.Join(",", row.Errors.Select(x => x.ToString()).ToArray());
                    //    // claim.ModifiedDate = DateTime.Now;

                    // }
                };
            };

            EngineConfiguration engineConfig = new EngineConfiguration
            (
                Convert.ToInt16(configuration.GetConnectionString("ConfidenceLevelThreshold")),
                 Convert.ToInt16(configuration.GetConnectionString("DataFetchFrequency")),
                 Convert.ToInt16(configuration.GetConnectionString("NumberOfRecords"))
           );




            using (MailRoomContext context = new MailRoomContext(configuration.GetConnectionString("MailRoom")))
            {

                // TODO: where condition is A MUST FOR DEMO - Where(c => c.ModifiedDate <= DateTime.Now).
                // including their children records
                top10Records = context.Cms15001.Include(claim => claim.Cms15002) // 24column records
                    .Where(claim => claim.Status == 0)
                                    .Include(claim => claim.Cms15001Conf) //1500_1 row's confidence records
                        .Take(engineConfig.NumberOfRecords).ToList();

                top10Records.ForEach(claim => claim.Status = 1); //set in progress state
                context.SaveChanges();
            };
            Console.WriteLine("Trying to process # records: " + top10Records.Count);
            StagingClaimCms1500 stagingClaimCms1500 = new StagingClaimCms1500();
            //TODO: decision to decide which parser this row should go with!
            //if (row.Type == 1) // ClaimType1 or ClaimType2 

            //if (row.Type == 2)// ClaimType1 or ClaimType2 
            //    parserQueue.Enqueue(new Claims2Processor(row));
            foreach (var claim in top10Records)
            {
                parserQueue.Enqueue(new ClaimCMS1500Processor(claim, engineConfig));
            }

            parserQueue.Process();




        }
    }
}
