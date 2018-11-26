using System;
using System.IO;
using MailRoom.ParserLib;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

                using (mailroomContext context = new mailroomContext(configuration.GetConnectionString("MailRoom")))
                {
                   var claim = context.StagingClaimCms1500.FirstOrDefault(x => x.ClaimId == row.Key);
                   if ( claim != null)
                   {
                        claim.ParserErrorCsv = String.Join(",", row.Errors.Select(x => x.ToString()).ToArray());
                        claim.ModifiedDate = DateTime.Now;
                        context.Entry(claim).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                };
            };

            EngineConfiguration engineConfig = new EngineConfiguration
            { 
                ConfidenceLevelThreshold = Convert.ToInt16(configuration.GetConnectionString("ConfidenceLevelThreshold"))
            }; 
            

          
            List<StagingClaimCms1500> top10Records = new List<StagingClaimCms1500>(); 
            using (mailroomContext context = new mailroomContext(configuration.GetConnectionString("MailRoom")))
            {
                top10Records = context.StagingClaimCms1500 .Where(c => c.ModifiedDate <= DateTime.Now).Take(10).ToList();
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
