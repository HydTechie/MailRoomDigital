using System;
using System.IO;
using MailRoom.ParserLib;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace MailRoomCoreEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            Console.WriteLine(configuration.GetConnectionString("MailRoom"));
            Console.WriteLine(configuration.GetConnectionString("ConfidenceLevelThreshold"));
            Console.WriteLine();

            Mapper.Initialize(config =>
            {
                config.CreateMap<Cms15001, StagingClaimCms1500>();

                config.CreateMap<Cms15002, StagingClaimCms1500Detail>();

            });

            //#1 Read Top 10 records from sql database
            Cache localCache = new Cache();

            //localCache.Add(new Row { Id = 1, PatientAge = 65, PatientName = "Patient-1-65", Type = 1 });
            //localCache.Add(new Row { Id = 2, PatientAge = 89 , PatientName ="Patient-2-89", Type =2});
            //localCache.Add(new Row { Id = 3, PatientAge = 55 , PatientName ="Patient-3-55", Type =3});
             

            // start the parser
            ParserQueue parserQueue = new ParserQueue();

            parserQueue.OnParsingCompleted += () =>
            {
                Console.WriteLine("Main Parser Completed @ " + DateTime.Now.ToLongDateString());
                Console.WriteLine("Checking database for more data ");
                // Pause 5secs.. for getting data
                // if there is data, 
            };

            parserQueue.OnRowParsed += (row) =>
            {
                // TODO: we dont need all the details of the row, just primary key and its errors to update the database!!
                Console.WriteLine("The row processed " 
                    + row.Key + ", status " + row.ExecStatus + " error:" + row.Errors.Count);
                // TODO: Need a Dirty row to be inserted as is with great status 
                Cms15001 claimsRow = (Cms15001)row;
                using (mailroomContext context = new mailroomContext(configuration.GetConnectionString("MailRoom")))
                {
                    StagingClaimCms1500 targetRow = Mapper.Map<StagingClaimCms1500>(claimsRow);
 
                    foreach (var item in claimsRow.Cms15002)
                    {
                        // convert soure to target type via Mapper
                        var stagingClaimCms1500Detail = Mapper.Map<StagingClaimCms1500Detail>(claimsRow.Cms15002);
                     
                        if (stagingClaimCms1500Detail.Id == 0) // insert
                        {
                            stagingClaimCms1500Detail.CreatedDate = DateTime.Now;
                            context.Entry(stagingClaimCms1500Detail).State = EntityState.Added;
                        }
                        else// update
                        {
                            stagingClaimCms1500Detail.ModifiedDate = DateTime.Now;
                            context.Entry(stagingClaimCms1500Detail).State = EntityState.Modified;
                        }
                           
                    }
                    // TODO:revisit for Hardcoded values
                    targetRow.CreatedDate = DateTime.Now;
                    targetRow.ReviewerId = "reviewerid1";
                    targetRow.ReviewStatus = 0; //Default not reviewed
                    targetRow.ParserErrorCsv = row.ParserErrorCsv;
                    targetRow.ConfidenceLevel = 90;
   
                    context.StagingClaimCms1500.Add(targetRow);
                    // context.Entry(claim).State = EntityState.Modified;
                    context.SaveChanges();
                   // if ( claim != null)
                   //{
                   //     claim.ParserErrorCsv = String.Join(",", row.Errors.Select(x => x.ToString()).ToArray());
                   //    // claim.ModifiedDate = DateTime.Now;
                        
                   // }
                };
            };

            EngineConfiguration engineConfig = new EngineConfiguration
            { 
                ConfidenceLevelThreshold = Convert.ToInt16(configuration.GetConnectionString("ConfidenceLevelThreshold"))
            }; 
            

          
            List<Cms15001> top10Records = new List<Cms15001>(); 
            using (mailroomContext context = new mailroomContext(configuration.GetConnectionString("MailRoom")))
            {
                // TODO: where condition is A MUST FOR DEMO - Where(c => c.ModifiedDate <= DateTime.Now).
                top10Records = context.Cms15001.Take(10).ToList();
            };
                StagingClaimCms1500 stagingClaimCms1500 = new StagingClaimCms1500();
                //TODO: decision to decide which parser this row should go with!
                //if (row.Type == 1) // ClaimType1 or ClaimType2 

                //if (row.Type == 2)// ClaimType1 or ClaimType2 
                //    parserQueue.Enqueue(new Claims2Processor(row));
                foreach(var claim in top10Records)
                { 
                    parserQueue.Enqueue(new ClaimCMS1500Processor(claim, engineConfig));
                }

                parserQueue.Process();
            

            //FileStyleUriParser
            Console.ReadLine();
        }
    }
}
