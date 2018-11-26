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
        //ISecurityRepository _SecurityRepository;
        //IMarketsAndNewsRepository _MarketsAndNewsRepository;
        MailRoomContext _Context;

        public DatabaseInitializer(MailRoomContext context, IStagingClaimRepository stagingClaimRepo
            //ISecurityRepository securityRepo, IMarketsAndNewsRepository marketsRepo
            )
        {
            _Context = context;
            _StagingClaimRepository = stagingClaimRepo;
            //_SecurityRepository = securityRepo;
            //_MarketsAndNewsRepository = marketsRepo;
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
                    await InsertSampleData();
                }
            }
            else
            {
                await InsertSampleData();
            }
        }

        public async Task InsertSampleData()
        {
            await Task.Run(async () =>
            {
                /*
                 * Removing so the app works with Sqlite
                 * 
                var deleteSecuritiesExchanges = @"
                    CREATE PROCEDURE dbo.DeleteSecuritiesAndExchanges

                    AS
	                    BEGIN
	 
	 		                    BEGIN TRANSACTION
		                    BEGIN TRY
			                    DELETE FROM Positions;   
			                    DELETE FROM Stocks;
			                    DELETE FROM MutualFunds;
			                    DELETE FROM Exchanges; 
			                    DELETE FROM MarketIndexes;
			                    COMMIT TRANSACTION
			                    SELECT 0				
		                    END TRY
		                    BEGIN CATCH
			                    ROLLBACK TRANSACTION
			                    SELECT -1		
		                    END CATCH
	
	                    END
                    ";

                var deleteStagingClaims = @"
                    CREATE PROCEDURE dbo.DeleteStagingClaims

                    AS
	                    BEGIN

		                    BEGIN TRANSACTION
			                    BEGIN TRY
				                    DELETE FROM Orders;                                              
				                    DELETE FROM StagingClaim;
				                    DELETE FROM Customers;					
				                    COMMIT TRANSACTION
				                    SELECT 0				
			                    END TRY
			                    BEGIN CATCH
				                    ROLLBACK TRANSACTION
				                    SELECT -1		
			                    END CATCH
	                    END	
	                ";
                */

                using (var connection = _Context.Database.GetDbConnection())
                {
                    connection.Open();

                    /*
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = deleteSecuritiesExchanges;
                        command.ExecuteNonQuery();

                        command.CommandText = deleteStagingClaims;
                        command.ExecuteNonQuery();
                    }
                    */

                    //await _SecurityRepository.InsertSecurityDataAsync();
                    //await _MarketsAndNewsRepository.InsertMarketDataAsync();
                    //await _StagingClaimRepository.CreateCustomerAsync();
                    await _StagingClaimRepository.CreateStagingClaimAsync();
                }
            });
        }
    }
}
