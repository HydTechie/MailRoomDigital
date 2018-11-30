using MailRoom.Repository.Interfaces;
using MailRoom.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MailRoom.Repository.Seeding
{
    public class DatabaseInitializer
    {
        IStagingClaimRepository _StagingClaimRepository;
       
        MailRoomContext _Context;

        public DatabaseInitializer(MailRoomContext context, IStagingClaimRepository stagingClaimRepo
          
            )
        {
            _Context = context;
            _StagingClaimRepository = stagingClaimRepo;
           
        }

        public async Task SeedAsync()
        {
            var db = _Context.Database;
            // db.EnsureCreated();
            // await InsertSampleData();
            if (db != null)
            {
                if (await db.EnsureCreatedAsync())
                {
                    //await InsertSampleData();
                }
            }
            else
            {
                //await InsertSampleData();
            }
        }

        //public async Task InsertSampleData()
        //{
        //    await Task.Run(async () =>
        //    {
               
        //        //await _StagingClaimRepository.CreateStagingClaimAsync();
        //    });
        //}
    }
}
