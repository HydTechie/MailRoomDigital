using MailRoom.Model;
using MailRoom.Repository.Constants;
using MailRoom.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MailRoom.Processors;

namespace MailRoom.Repository
{

    public class StagingClaimRepository : RepositoryBase<MailRoomContext>, IStagingClaimRepository
    {

        //ISecurityRepository _SecurityRepository;

        public StagingClaimRepository(

            MailRoomContext context) : base(context)
        {

        }



        public async Task<OperationStatus> UpdatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500)
        {
            try
            {
                // 01/01/2019 validation start 
                var isModelValid = true;

                // Convert staging to dirty to enable processing
                Cms15001 cms15001 = Mapper.Map<Cms15001>(stagingClaimCms1500);
                cms15001.Cms15002 = new List<Cms15002>();
                foreach (var child in stagingClaimCms1500.StagingClaimCms1500Detail)
                {
                    var cmsChild = Mapper.Map<Cms15002>(child);
                    cms15001.Cms15002.Add(cmsChild);
                }
                IProcessor processor = new ClaimCMS1500Processor(cms15001, new EngineConfiguration(90));
                processor.Execute();
                //to do
                if (cms15001.ParserErrorCsv.Length > 2)
                {
                    isModelValid = false;
                    return OperationStatus.CreateFromException(cms15001.ParserErrorCsv, null);
                }
                // 01/01/2019 validation end 

                var editingField = DataContext.StagingClaimCms1500.Where(x => x.ClaimId == stagingClaimCms1500.ClaimId).FirstOrDefault();
                if (editingField != null)
                {
                    //DataContext.StagingClaimCms1500.Update(stagingClaimCms1500);
                    DataContext.Entry(editingField).State = EntityState.Detached;
                    foreach (var item in stagingClaimCms1500.StagingClaimCms1500Detail)
                    {
                        var previousChild = DataContext.StagingClaimCms1500Detail.Where(x => x.Id == item.Id).FirstOrDefault();
                        if (previousChild != null)
                        {
                            DataContext.Entry(previousChild).State = EntityState.Detached;
                        }
                        item.ModifiedDate = DateTime.Today;
                        DataContext.Entry(item).State = EntityState.Modified;
                    }
                    stagingClaimCms1500.ModifiedDate = DateTime.Now;
                    stagingClaimCms1500.ReviewStatus = ConstantStore.COMPLETED_STRING;
                    stagingClaimCms1500.ParserErrorCsv = cms15001.ParserErrorCsv;
                    DataContext.Entry(stagingClaimCms1500).State = EntityState.Modified;
                    await DataContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                return OperationStatus.CreateFromException("Error occured while update", e);
            }
            return new OperationStatus();
        }

        public async Task<OperationStatus> ValidatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500)
        {
            try
            {
                // 01/01/2019 validation start 
                var isModelValid = true;

                // Convert staging to dirty to enable processing
                Cms15001 cms15001 = Mapper.Map<Cms15001>(stagingClaimCms1500);
                cms15001.Cms15002 = new List<Cms15002>();
                foreach (var child in stagingClaimCms1500.StagingClaimCms1500Detail)
                {
                    var cmsChild = Mapper.Map<Cms15002>(child);
                    cms15001.Cms15002.Add(cmsChild);
                }
                IProcessor processor = new ClaimCMS1500Processor(cms15001, new EngineConfiguration(90));
                processor.Execute();
                //to do
                if (cms15001.ParserErrorCsv.Length > 2)
                {
                    isModelValid = false;
                    return OperationStatus.CreateFromException(cms15001.ParserErrorCsv, null);
                }
            }
            catch (Exception e)
            {
                return OperationStatus.CreateFromException("Error occured while validation", e);
            }
            return new OperationStatus();
        }



        public async Task<StagingClaimCms1500> GetStagingClaimAsync(string claimId)
        {
            if (String.IsNullOrEmpty(claimId)) return null;
            return await DataContext.StagingClaimCms1500

                .Include(claim => claim.StagingClaimCms1500Detail)
                //.Include(ba => ba.Positions)
                .SingleOrDefaultAsync(c => c.ClaimId.ToString() == claimId);
        }
        public async Task<Dashboard> GetDashboardAsync(string reviewerId)
        {

            var rdm = new Random((int)DateTime.Now.Ticks);
            var queryDate = DateTime.Now.Date;

            //DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            //var startOfWeekDate = DateTime.Now;

            //while (startOfWeekDate.DayOfWeek != weekStart)
            //    startOfWeekDate = startOfWeekDate.AddDays(-1);
            // >= startOfWeekDate && c.ModifiedDate <= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28))

            var CMS1500AssignedUnderVerificationRequired = await DataContext.StagingClaimCms1500
              // 2,3,4 verification required
              .Where(c => (c.ReviewerId == reviewerId) && (c.ParserStatus == 2
              || c.ParserStatus == 3 || c.ParserStatus == 4)
              && (c.CreatedDate.Value.Date == queryDate)
              )

            .GroupBy(c => new { c.ReviewerId }) //
            .Select(g => new
            {
                g.Key.ReviewerId,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var CMS1500AssignedUnderOptionalVerification = await DataContext.StagingClaimCms1500
              // 5- optional verification
              .Where(c => c.ReviewerId == reviewerId && c.ParserStatus == 5
                && c.CreatedDate.Value.Date == queryDate
              )

            .GroupBy(c => new { c.ParserStatus, c.ReviewerId }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ParserStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var CMS1500AssignedUnderRollback = await DataContext.StagingClaimCms1500

              .Where(c => c.ReviewerId == reviewerId && c.ParserStatus == 1
               && c.CreatedDate.Value.Date == queryDate
              )

            .GroupBy(c => new { c.ParserStatus, c.ReviewerId }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ParserStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var CMS1500ReviewedUnderVerificationRequired = await DataContext.StagingClaimCms1500
              // 2,3,4 verification required
              .Where(c => c.ReviewerId == reviewerId && (c.ParserStatus == 2
              || c.ParserStatus == 3 || c.ParserStatus == 4)
              && c.CreatedDate.Value.Date == queryDate && c.ReviewStatus == ConstantStore.COMPLETED_STRING
              )

            .GroupBy(c => new { c.ReviewStatus, c.ReviewerId }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var CMS1500ReviewedUnderOptionalVerification = await DataContext.StagingClaimCms1500
              // 5- optional verification
              .Where(c => c.ReviewerId == reviewerId && c.ParserStatus == 5
                && c.CreatedDate.Value.Date == queryDate && c.ReviewStatus == ConstantStore.COMPLETED_STRING
              )

            .GroupBy(c => new { c.ReviewStatus, c.ReviewerId }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var CMS1500ReviewedUnderRollback = await DataContext.StagingClaimCms1500

              .Where(c => c.ReviewerId == reviewerId && c.ParserStatus == 1
               && c.CreatedDate.Value.Date == queryDate && c.ReviewStatus == ConstantStore.COMPLETED_STRING
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();


            /*Key	Value 	Form Category
-1	Parser Error	 
1	Incomplete Form; Roll back required 	Roll back

2	Mandatory fields are filled; low confidence score; No business rule violation 	Verification required 
3	Mandatory fields are filled; high confidence score; business rule violation are present	Verification required 
4	Mandatory fields are filled; low confidence score; business rule violation are present  	Verification required 

5	Mandatory fields are filled; high confidence score; no business rule violation	Optional Verification
6	User validated the data 	 
             
             */
            Dashboard d = new Dashboard();
            if (CMS1500AssignedUnderVerificationRequired != null)
                d.ClaimsCMS100["VERIFICATIONREQUIRED_ASSIGNED"] = CMS1500AssignedUnderVerificationRequired.Claimcount;

            if (CMS1500AssignedUnderOptionalVerification != null)
                d.ClaimsCMS100["OPTIONALVERIFICATION_ASSIGNED"] = CMS1500AssignedUnderOptionalVerification.Claimcount;

            if (CMS1500AssignedUnderRollback != null)
                d.ClaimsCMS100["ROLLBACK_ASSIGNED"] = CMS1500AssignedUnderRollback.Claimcount;

            if (CMS1500ReviewedUnderVerificationRequired != null)
                d.ClaimsCMS100["VERIFICATIONREQUIRED_REVIEWED"] = CMS1500ReviewedUnderVerificationRequired.Claimcount;

            if (CMS1500ReviewedUnderOptionalVerification != null)
                d.ClaimsCMS100["OPTIONALVERIFICATION_REVIEWED"] = CMS1500ReviewedUnderOptionalVerification.Claimcount;

            if (CMS1500ReviewedUnderRollback != null)
                d.ClaimsCMS100["ROLLBACK_REVIEWED"] = CMS1500ReviewedUnderRollback.Claimcount;

            if (CMS1500AssignedUnderVerificationRequired != null)
            {
                if (CMS1500ReviewedUnderVerificationRequired != null)
                {
                    d.ClaimsCMS100["VERIFICATIONREQUIRED_PENDING"] = CMS1500AssignedUnderVerificationRequired.Claimcount - CMS1500ReviewedUnderVerificationRequired.Claimcount;
                }
                else
                {
                    d.ClaimsCMS100["VERIFICATIONREQUIRED_PENDING"] = CMS1500AssignedUnderVerificationRequired.Claimcount;
                }
            }

            if (CMS1500AssignedUnderOptionalVerification != null)
            {
                if (CMS1500ReviewedUnderOptionalVerification != null)
                {
                    d.ClaimsCMS100["OPTIONALVERIFICATION_PENDING"] = CMS1500AssignedUnderOptionalVerification.Claimcount - CMS1500ReviewedUnderOptionalVerification.Claimcount;
                }
                else
                {
                    d.ClaimsCMS100["OPTIONALVERIFICATION_PENDING"] = CMS1500AssignedUnderOptionalVerification.Claimcount;
                }
            }

            if (CMS1500AssignedUnderRollback != null)
            {
                if (CMS1500ReviewedUnderRollback != null)
                {
                    d.ClaimsCMS100["ROLLBACK_PENDING"] = CMS1500AssignedUnderRollback.Claimcount - CMS1500ReviewedUnderRollback.Claimcount;
                }
                else
                {
                    d.ClaimsCMS100["ROLLBACK_PENDING"] = CMS1500AssignedUnderRollback.Claimcount;
                }
            }
            // TODO: fill up other values once other claims types ready, Else carries 0!

            d.OverallProgress["VERIFICATIONREQUIRED_ASSIGNED"] = d.ClaimsCMS100["VERIFICATIONREQUIRED_ASSIGNED"]
                    + d.ClaimsPK83["VERIFICATIONREQUIRED_ASSIGNED"] + d.ClaimsUB04["VERIFICATIONREQUIRED_ASSIGNED"];

            d.OverallProgress["VERIFICATIONREQUIRED_REVIEWED"] = d.ClaimsCMS100["VERIFICATIONREQUIRED_REVIEWED"]
                    + d.ClaimsPK83["VERIFICATIONREQUIRED_REVIEWED"] + d.ClaimsUB04["VERIFICATIONREQUIRED_REVIEWED"];

            d.OverallProgress["OPTIONALVERIFICATION_ASSIGNED"] = d.ClaimsCMS100["OPTIONALVERIFICATION_ASSIGNED"]
                    + d.ClaimsPK83["OPTIONALVERIFICATION_ASSIGNED"] + d.ClaimsUB04["OPTIONALVERIFICATION_ASSIGNED"];

            d.OverallProgress["OPTIONALVERIFICATION_REVIEWED"] = d.ClaimsCMS100["OPTIONALVERIFICATION_REVIEWED"]
                    + d.ClaimsPK83["OPTIONALVERIFICATION_REVIEWED"] + d.ClaimsUB04["OPTIONALVERIFICATION_REVIEWED"];

            d.OverallProgress["ROLLBACK_ASSIGNED"] = d.ClaimsCMS100["ROLLBACK_ASSIGNED"]
                    + d.ClaimsPK83["ROLLBACK_ASSIGNED"] + d.ClaimsUB04["ROLLBACK_ASSIGNED"];

            d.OverallProgress["ROLLBACK_REVIEWED"] = d.ClaimsCMS100["ROLLBACK_REVIEWED"]
                    + d.ClaimsPK83["ROLLBACK_REVIEWED"] + d.ClaimsUB04["ROLLBACK_REVIEWED"];

            //d.TodoTotalCountByAllClaimTypes = d.ClaimsCMS100["TODO"]
            //      + d.ClaimsPK83["TODO"] + d.ClaimsUB04["TODO"];

            //d.RollbackTotalCountByAllClaimTypes = d.ClaimsCMS100["ROLLBACK"]
            //      + d.ClaimsPK83["ROLLBACK"] + d.ClaimsUB04["ROLLBACK"];

            //// Totals per Day
            //d.TotalClaimsCountByCMS1500PerDay = d.ClaimsCMS100["TODO"]
            //      + d.ClaimsCMS100["ROLLBACK"] + d.ClaimsCMS100["COMPLETED"];

            //d.TotalClaimsCountByUB04PerDay = d.ClaimsUB04["TODO"]
            //      + d.ClaimsUB04["ROLLBACK"] + d.ClaimsUB04["COMPLETED"];

            //d.TotalClaimsCountByPK83PerDay = d.ClaimsPK83["TODO"]
            //      + d.ClaimsPK83["ROLLBACK"] + d.ClaimsPK83["COMPLETED"];

            d.WeekData = await GetDashboardByWeekAsync("reviewerId1");
            return d;
        }


        public async Task<IDictionary<string, DayData>> GetDashboardByWeekAsync(string reviewerId)
        {
            DataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //DbInterception.Add(new TemporalTableCommandTreeInterceptor());
            //  DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            var startingDate = DateTime.Now;

            //while (startingDate.DayOfWeek != weekStart)
            //    startingDate = startingDate.AddDays(-1);

            // previous 7 days of the current date
            var previousWeekStart = startingDate.AddDays(-6);
            var previousWeekEnd = startingDate;
            var listOfDates = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                listOfDates.Add(previousWeekStart.AddDays(i));
            }

            var allocatedClaimsByReviewerWeek = await DataContext.StagingClaimCms1500

              .Where(c => c.ReviewerId == reviewerId
              && c.CreatedDate >= previousWeekStart && c.CreatedDate <= previousWeekEnd
              )

            .GroupBy(c => new { CreatedValue = c.CreatedDate.Value.ToShortDateString() }) //
            .Select(g => new
            {
                //g.Key.ReviewerId,
                g.Key.CreatedValue,
                Claimcount = g.Count()
            }).ToListAsync();

            var attendedClaimsByReviewerWeek = await DataContext.StagingClaimCms1500

              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == ConstantStore.COMPLETED_STRING
              && c.ModifiedDate >= previousWeekStart && c.ModifiedDate <= previousWeekEnd
              )

            .GroupBy(c => new { ModifiedValue = c.ModifiedDate.Value.ToShortDateString() }) //
            .Select(g => new
            {
                //g.Key.ReviewerId,
                g.Key.ModifiedValue,
                Claimcount = g.Count()
            }).ToListAsync();

            // Merge these two lists


            var tempList = allocatedClaimsByReviewerWeek.LeftJoin
                        (attendedClaimsByReviewerWeek, a => a.CreatedValue, b => b.ModifiedValue,
                    (a, b) =>
                    {
                        if (b == null)
                        {
                            return new { a.CreatedValue, allocated = a.Claimcount, attended = 0 };
                        }
                        else
                        {
                            return new { a.CreatedValue, allocated = a.Claimcount, attended = b.Claimcount };
                        }
                    }
                     ).ToList();

            //        var outerLeft =
            //listOfDates.SelectMany(l =>
            //   { return tempList.Where(r => r.ModifiedDate == l.Date)
            //          .DefaultIfEmpty(new { reviewDate = l.Date, Allocated = 0, Attended = 0 })
            //          .Select(r => new { reviewDate = l.Date, Allocated = r.Allocated, Attended = r.Attended }
            //          )
            //          });

            var outerLeft = listOfDates.LeftJoin(tempList, d => d.ToShortDateString(), t => t.CreatedValue,
                (d, t) =>
                {
                    if (t == null)
                    {
                        return new { reviewDate = d.ToShortDateString(), Allocated = 0, Attended = 0 };
                    }
                    else
                        return new { reviewDate = d.ToShortDateString(), Allocated = t.allocated, Attended = t.attended };
                }


                ).ToList();
            IDictionary<string, DayData> weekData = new Dictionary<string, DayData>();
            foreach (var item in outerLeft)
            {
                weekData.Add(item.reviewDate, new DayData { Allocated = item.Allocated, Attended = item.Attended });
            }


            return weekData;
        }

        public async Task<IList<StagingClaimCms1500>> GetStagingCMSClaimsByReviewerAsync(string reviewerId, int parserStatus, string reviewStatus)
        {
            if (String.IsNullOrEmpty(reviewerId)) return null;
            if (reviewStatus != ConstantStore.ALL_STRING)
            {
                if (parserStatus == 2 || parserStatus == 3 || parserStatus == 4)
                {
                    return await DataContext.StagingClaimCms1500
                        .Include(claim => claim.StagingClaimCms1500Detail)
                       .Where(c => c.ReviewerId == reviewerId && (c.ParserStatus == 2 || c.ParserStatus == 3 || c.ParserStatus == 4) && c.ReviewStatus == reviewStatus && c.CreatedDate.Value.Date == DateTime.Today.Date).ToListAsync<StagingClaimCms1500>();
                }
                else
                {
                    return await DataContext.StagingClaimCms1500
                        .Include(claim => claim.StagingClaimCms1500Detail)
                       .Where(c => c.ReviewerId == reviewerId && c.ParserStatus == parserStatus && c.ReviewStatus == reviewStatus && c.CreatedDate.Value.Date == DateTime.Today.Date).ToListAsync<StagingClaimCms1500>();
                }
            }
            else
            {
                if (parserStatus == 2 || parserStatus == 3 || parserStatus == 4)
                {
                    return await DataContext.StagingClaimCms1500
                        .Include(claim => claim.StagingClaimCms1500Detail)
                       .Where(c => c.ReviewerId == reviewerId && (c.ParserStatus == 2 || c.ParserStatus == 3 || c.ParserStatus == 4) && c.CreatedDate.Value.Date == DateTime.Today.Date).ToListAsync<StagingClaimCms1500>();
                }
                else
                {
                    return await DataContext.StagingClaimCms1500
                        .Include(claim => claim.StagingClaimCms1500Detail)
                       .Where(c => c.ReviewerId == reviewerId && c.ParserStatus == parserStatus && c.CreatedDate.Value.Date == DateTime.Today.Date).ToListAsync<StagingClaimCms1500>();
                }
            }
        }

        // TODO: for UB04 and PK83 claims
        //public Task<IList<StagingClaimCms1500>> GetStagingUB04ClaimsByReviewerAsync(string reviewerId, int reviewStatus)
        //{
        //    return null;
        //    //throw new NotImplementedException();
        //}

        //public Task<IList<StagingClaimCms1500>> GetStagingPK83ClaimsByReviewerAsync(string reviewerId, int reviewStatus)
        //{
        //    return null;
        //    //throw new NotImplementedException();
        //}

        //public async Task<StagingclaimCms1500> GetDashboardAsync(string reviewerId)
        //{
        //    throw NotImplementedException();
        //    ////if (String.IsNullOrEmpty(insuredId)) return null;
        //    //return await DataContext.StagingclaimCms1500
        //    //    //.Include(ba => ba.Orders)
        //    //    //.Include(ba => ba.Positions)
        //    //    .SingleOrDefaultAsync(c => c.ReviewerId == reviewerId);
        //}
        #region Seeding

        //public async Task<OperationStatus> CreateCustomerAsync()
        //{
        //    var opStatus = new OperationStatus { Status = true };
        //    try
        //    {
        //        await DataContext.DeleteStagingClaims();

        //        if (opStatus.Status)
        //        {
        //            var cust = new Customer
        //            {
        //                FirstName = "Marcus",
        //                LastName = "Hightower",
        //                Address = "1234 Anywhere St.",
        //                City = "Phoenix",
        //                State = "AZ",
        //                Zip = 85229,
        //                CustomerCode = "C15643"
        //            };
        //            DataContext.Customers.Add(cust);
        //            var stagingClaims = CreateStagingClaims(cust);
        //            foreach (var stagingClaim in stagingClaims)
        //            {
        //                cust.StagingClaims.Add(stagingClaim);
        //            }
        //            await DataContext.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        opStatus = OperationStatus.CreateFromException("Error updating security exchange: " + exp.Message, exp);
        //    }

        //    return opStatus;
        //}

        //private List<StagingclaimCms1500> CreateStagingClaims(Customer cust)
        //{
        //    List<StagingclaimCms1500> stagingClaims = new List<StagingclaimCms1500>();
        //    string[] stagingClaimTitles = { "IRA", "Joint Brokerage", "Brokerage StagingclaimCms1500" };
        //    for (int i = 0; i < stagingClaimTitles.Length; i++)
        //    {
        //        var stagingClaim = new StagingclaimCms1500
        //        {
        //            StagingClaimNumber = "Z48573988" + i.ToString(),
        //            StagingClaimTitle = stagingClaimTitles[i],
        //            IsRetirement = (i == 0) ? true : false,
        //            CashTotal = (i + 1) * 5000,
        //            CustomerId = cust.Id,
        //            Customer = cust
        //        };

        //        //FillStagingClaimSecurities(securities, stagingClaim, i);

        //        stagingClaim.PositionsTotal = stagingClaim.Positions.Sum(p => p.Total);
        //        stagingClaim.Total = stagingClaim.PositionsTotal + stagingClaim.CashTotal;
        //        stagingClaim.MarginBalance = (stagingClaim.IsRetirement) ? 0.00M : Math.Round(stagingClaim.Total / 3, 2);
        //        stagingClaims.Add(stagingClaim);
        //    }

        //    return stagingClaims;
        //}

        //Had to break this out into a separate DB call due to current state of EF7
        //public async Task<OperationStatus> CreateStagingClaimAsync()
        //{
        //    var opStatus = new OperationStatus { Status = true };
        //    //           try
        //    //           {



        //    //               for (int i = 0; i < 100; i++)
        //    //               {
        //    //                   var rdm = new Random((int)DateTime.Now.Ticks + i);

        //    //                   var detail1 = new StagingClaimCms1500Detail
        //    //                   {
        //    //                        _24aServiceStartMm = rdm.Next(1, 12),
        //    //                       _24aServiceStartDd = rdm.Next(1, 28), 
        //    //                       _24aServiceStartYyyy =  rdm.Next(1900, 2000),

        //    //                       _24aServiceEndMm = rdm.Next(1, 12),
        //    //                       _24aServiceEndDd = rdm.Next(1, 28),
        //    //                       _24aServiceEndYyyy = rdm.Next(1900, 2000),

        //    //                       _24bPlaceofService =  rdm.Next(10, 99),

        //    //                       _24cEmg = "Y" ,
        //    //                       _24dCpthcpcs = rdm.Next(1, 9),
        //    //                       _24dModifier = rdm.Next(1, 9),

        //    //                       _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
        //    //                       _24fChargesDollar =  rdm.Next(1900, 2000) ,
        //    //                       _24fChargesCents = rdm.Next(0, 99),
        //    //                       _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

        //    //                       _24hEpsdtcode = "AV",
        //    //                       _24hEpsdtyn = "Y",
        //    //                       _24iQual = "QQ",
        //    //                       _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
        //    //                       _24jRenderingProviderId = rdm.Next(1000, 2000),



        //    //                   };
        //    //                   var detail2 = new StagingClaimCms1500Detail
        //    //                   {
        //    //                       _24aServiceStartMm = rdm.Next(1, 12),
        //    //                       _24aServiceStartDd = rdm.Next(1, 28),
        //    //                       _24aServiceStartYyyy = rdm.Next(1900, 2000),

        //    //                       _24aServiceEndMm = rdm.Next(1, 12),
        //    //                       _24aServiceEndDd = rdm.Next(1, 28),
        //    //                       _24aServiceEndYyyy = rdm.Next(1900, 2000),

        //    //                       _24bPlaceofService = rdm.Next(10, 99),

        //    //                       _24cEmg = "Y",
        //    //                       _24dCpthcpcs = rdm.Next(1, 9),
        //    //                       _24dModifier = rdm.Next(1, 9),

        //    //                       _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
        //    //                       _24fChargesDollar = rdm.Next(1900, 2000),
        //    //                       _24fChargesCents = rdm.Next(0, 99),
        //    //                       _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

        //    //                       _24hEpsdtcode = "AV",
        //    //                       _24hEpsdtyn = "Y",
        //    //                       _24iQual = "" + rdm.Next(1, 20).ToString(),
        //    //                       _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
        //    //                       _24jRenderingProviderId = rdm.Next(1000, 2000),



        //    //                   };
        //    //                   var detail3 = new StagingClaimCms1500Detail
        //    //                   {
        //    //                       _24aServiceStartMm = rdm.Next(1, 12),
        //    //                       _24aServiceStartDd = rdm.Next(1, 28),
        //    //                       _24aServiceStartYyyy = rdm.Next(1900, 2000),

        //    //                       _24aServiceEndMm = rdm.Next(1, 12),
        //    //                       _24aServiceEndDd = rdm.Next(1, 28),
        //    //                       _24aServiceEndYyyy = rdm.Next(1900, 2000),

        //    //                       _24bPlaceofService = rdm.Next(10, 99),

        //    //                       _24cEmg = "Y",
        //    //                       _24dCpthcpcs = rdm.Next(1, 9),
        //    //                       _24dModifier = rdm.Next(1, 9),

        //    //                       _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
        //    //                       _24fChargesDollar = rdm.Next(1900, 2000),
        //    //                       _24fChargesCents = rdm.Next(0, 99),
        //    //                       _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

        //    //                       _24hEpsdtcode = "AV",
        //    //                       _24hEpsdtyn = "Y",
        //    //                       _24iQual = "" + rdm.Next(1, 20).ToString(),
        //    //                       _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
        //    //                       _24jRenderingProviderId = rdm.Next(1000, 2000),



        //    //                   };
        //    //                   var detail4 = new StagingClaimCms1500Detail
        //    //                   {
        //    //                       _24aServiceStartMm = rdm.Next(1, 12),
        //    //                       _24aServiceStartDd = rdm.Next(1, 28),
        //    //                       _24aServiceStartYyyy = rdm.Next(1900, 2000),

        //    //                       _24aServiceEndMm = rdm.Next(1, 12),
        //    //                       _24aServiceEndDd = rdm.Next(1, 28),
        //    //                       _24aServiceEndYyyy = rdm.Next(1900, 2000),

        //    //                       _24bPlaceofService = rdm.Next(10, 99),

        //    //                       _24cEmg = "Y",
        //    //                       _24dCpthcpcs = rdm.Next(1, 9),
        //    //                       _24dModifier = rdm.Next(1, 9),

        //    //                       _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
        //    //                       _24fChargesDollar = rdm.Next(1900, 2000),
        //    //                       _24fChargesCents = rdm.Next(0, 99),
        //    //                       _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

        //    //                       _24hEpsdtcode = "AV",
        //    //                       _24hEpsdtyn = "Y",
        //    //                       _24iQual = "" + rdm.Next(1, 20).ToString(),
        //    //                       _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
        //    //                       _24jRenderingProviderId = rdm.Next(1000, 2000),



        //    //                   };
        //    //                   var StagingclaimCms1500Item = new
        //    //                       StagingClaimCms1500
        //    //                   {

        //    //                       //alpha order
        //    //                       IaPayerName = "IaPayerName" + rdm.Next(99, 1000),
        //    //                       IbPayerAddress1 = "IbPayerAddress1" + rdm.Next(99, 1000),
        //    //                       IcPayerAddress2 = "IcPayerAddress2" + rdm.Next(99, 1000),
        //    //                       IdPayerCity = "NY",
        //    //                       IdPayerState = "NY",
        //    //                       IdPayerZipcode = "07304",

        //    //                       _1PayerType = "test" + rdm.Next(99, 1000),

        //    //                       _1aPatientInsuredId = " " + rdm.Next(99, 1000),

        //    //                       _2aPatientLastName = "_2PatientName" + rdm.Next(99, 1000),

        //    //                       _2bSuffix = "_2bSuffix" + rdm.Next(99, 1000),
        //    //                       _2dPatientMiddleName = "_2dPatientMiddleName" + rdm.Next(99, 1000),
        //    //                       _2cPatientFirstName = "_2PatientName" + rdm.Next(99, 1000),

        //    //                       _3PatientBirthMm = rdm.Next(1, 12),
        //    //                       _3PatientBirthDd = rdm.Next(1, 12),
        //    //                       _3PatientBirthYyyy = rdm.Next(1, 12),

        //    //                       _3PatientGender = "M",

        //    //                       _4InsuredFirstName = "_4InsuredFirstName" + rdm.Next(99, 1000),
        //    //                       _4InsuredMiddleName = "_4InsuredFirstName" + rdm.Next(99, 1000),
        //    //                       _4InsuredLastName = "_4InsuredFirstName" + rdm.Next(99, 1000),
        //    //                       _4InsuredSuffix = "MR",


        //    //                       _5PatientAddressStreet = "_5PatientAddr " + rdm.Next(99, 1000),
        //    //                       _5PatientAddressCity = "NYC" + rdm.Next(99, 1000),
        //    //                       _5PatientAddressState = "NY" ,
        //    //                       _5PatientAreaCode = rdm.Next(99, 1000).ToString(),
        //    //                       _5PatientTelePhone = rdm.Next(99, 1000).ToString(),
        //    //                       _5PatientZipCode = rdm.Next(99, 1000).ToString(),

        //    //                       _6PatientRelationToInsured = "rel " + rdm.Next(99, 1000),
        //    //                       _7InsuredAddressStreet = "_7InsuredAddressStreet" + rdm.Next(99, 1000),
        //    //                       _7InsuredAddressCity = "NYC" ,
        //    //                       _7InsuredAddressState = "NY" ,
        //    //                       _7InsuredAreaCode = rdm.Next(99, 1000).ToString(),
        //    //                       _7InsuredTelephone = rdm.Next(99, 1000).ToString(),
        //    //                       _7InsuredZipCode = rdm.Next(99, 1000).ToString(),


        //    //                       _8ReservedNucc = "_8ReservedNucc" + rdm.Next(99, 1000),



        //    //                       _9aOtherPolicyGroup = "_9 Name" + rdm.Next(99, 1000),
        //    //                       _9OtherInsuredFirstName = "_9OtherInsuredFirstName" + rdm.Next(99, 1000),
        //    //                       _9bOtherReservedNucc = "_9bOtherReservedNucc" + rdm.Next(99, 1000),
        //    //                       _9cOtherReservedNucc = "_9cOtherReservedNucc" + rdm.Next(99, 1000),
        //    //                       _9cOtherInsuranceName = "_9cOtherInsuranceName" + rdm.Next(99, 1000),
        //    //                       _9OtherInsuredLastName = "_9OtherInsuredFirstName" + rdm.Next(99, 1000),
        //    //                       _9OtherInsuredMiddleName = "_9OtherInsuredFirstName" + rdm.Next(99, 1000),
        //    //                       _9OtherInsuredSuffix = "Mrs",

        //    //                       //Y,                       N,                        NULL
        //    //                       _10aPatientConditionEmployment = "N",
        //    //                       _10bPatientConditionAuto = "Y",
        //    //                       _10bPatientConditionPlace = "NY",
        //    //                       _10cPatientConditionOther = "N",
        //    //                       _10dClaimCodes = "_10dClaimCodes" + rdm.Next(99, 1000),
        //    //                       //Y - NY,                    N,                        NULL



        //    //                       // --Y,                         N,                         NULL


        //    //                       _11InsuredPolicyGroup = rdm.Next(1111, 9999).ToString(),

        //    //                       _11aInsuredBirthMm = rdm.Next(1, 12),
        //    //                       _11aInsuredBirthDd = rdm.Next(1, 28),
        //    //                       _11aInsuredBirthYyyy = rdm.Next(1900, 2000),

        //    //                       _11aInsuredGender = "M",
        //    //                       _11bOtherClaimIdQual = "QA",
        //    //                       _11bOtherClaimId = "_11c" + rdm.Next(99, 1000),
        //    //                       _11cInsurancePlanName = "_11cOtherClaimIdNUCC" + rdm.Next(99, 1000),
        //    //                       _11dIsAnotherHealthPlan = "Y",

        //    //                       _12PatientAuthorizedSignatureImageUrl = "test" + rdm.Next(99, 1000),
        //    //                       _12PatientAuthorizedSignatureMm = rdm.Next(1, 12),
        //    //                       _12PatientAuthorizedSignatureDd = rdm.Next(1, 28),
        //    //                       _12PatientAuthorizedSignatureYyyy = rdm.Next(1900, 2000),

        //    //                       _13InsuredAuthorizedSignatureImageUrl = "test" + rdm.Next(99, 1000),



        //    //                       _14CurrentIllnessDd = rdm.Next(1, 28),
        //    //                       _14CurrentIllnessMm = rdm.Next(1, 12),
        //    //                       _14CurrentIllnessYyyy = rdm.Next(1900, 2000),

        //    //                       _14DateOfCurrentIllnessQual = "IND",

        //    //                       _15OtherDateMm = rdm.Next(1, 12),
        //    //                       _15OtherDateDd = rdm.Next(1, 28),
        //    //                       _15OtherDateYyyy = rdm.Next(1900, 2000),

        //    //                       _15OtherQual = "QP" ,


        //    //                       _16PatientUnableToWorkStartMm = rdm.Next(1, 12),
        //    //                       _16PatientUnableToWorkStartDd = rdm.Next(1, 28),
        //    //                       _16PatientUnableToWorkStartYyyy = rdm.Next(1900, 2000),

        //    //                       _16PatientUnableToWorkEndMm = rdm.Next(1, 12),
        //    //                       _16PatientUnableToWorkEndDd = rdm.Next(1, 28),
        //    //                       _16PatientUnableToWorkEndYyyy = rdm.Next(1900, 2000),

        //    //                       _17ReferringProviderName = "test" + rdm.Next(99, 1000),

        //    //                       _17aNonNpireferringProviderQual = "QA" ,
        //    //                       _17aNonNpireferringProvider = "NPI" + rdm.Next(99, 1000),
        //    //                       _17aNpireferringProvider = "PR" + rdm.Next(99, 1000),
        //    //                       _17aNpireferringProviderQual = "QA",
        //    //                       _17ReferringProviderQual = "QA",


        //    //                       _18HospitalizationStartMm = rdm.Next(1, 12),
        //    //                       _18HospitalizationStartDd = rdm.Next(1, 28),
        //    //                       _18HospitalizationStartYyyy = rdm.Next(1900, 2000),

        //    //                       _18HospitalizationEndMm = rdm.Next(1, 12),
        //    //                       _18HospitalizationEndDd = rdm.Next(1, 28),
        //    //                       _18HospitalizationEndYyyy = rdm.Next(1900, 2000),

        //    //                       _19AdditionalClaimInfo = "test" + rdm.Next(99, 1000),

        //    //                       _20OutsideLab = "Y",
        //    //                       _20ChargesCents = "00",
        //    //                       _20ChargesDollars = "130",



        //    //   _21NatureOfIllnessA= "NatureOfIllnessA" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessB= "NatureOfIllnessB" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessC= "NatureOfIllnessC" + rdm.Next(99, 1000),



        //    //   _21NatureOfIllnessD= "NatureOfIllnessD" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessE= "NatureOfIllnessE" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessF= "NatureOfIllnessF" + rdm.Next(99, 1000),


        //    //   _21NatureOfIllnessG= "NatureOfIllnessG" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessH= "_21NatureOfIllnessH" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessI= "_21NatureOfIllnessI" + rdm.Next(99, 1000),


        //    //   _21NatureOfIllnessJ= "_21NatureOfIllnessJ" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessK= "_21NatureOfIllnessK" + rdm.Next(99, 1000),

        //    //   _21NatureOfIllnessL= "_21NatureOfIllnessL" + rdm.Next(99, 1000),


        //    //   _21IcdindQual = "Q",
        //    //   _21IcdindValue = "ind" +rdm.Next(99, 1000),
        //    //   //--TODO: Deep / Adharsh

        //    //  _22ResubmissionCodeQual = "QA" ,
        //    //  _22OriginalRefNo= "test" + rdm.Next(99, 1000),
        //    //  _23PriorAuthorizationNumber = rdm.Next(99, 1000).ToString(),

        //    //                       // --24_ colums move to Child table


        //    //                       _25FederalTaxId = rdm.Next(99, 1000).ToString(),
        //    //                       _25FederalTaxType = "FA",


        //    //_26PatientAccountNumber=  rdm.Next(99, 1000) ,
        //    //_27AcceptAssignment ="N" ,
        //    //_28TotalCharges =  rdm.Next(99, 1000) ,
        //    //	_29AmountPaid =  rdm.Next(99, 1000) ,

        //    //		_30NuccuseCode = "AVC" ,
        //    //           _30NuccuseQualifier ="AB",
        //    //		_31PhysicianSignatureImageUrl = "_31 Signature ImageUrl" + rdm.Next(99, 1000) ,

        //    //                       _31PhysicianSignatureDd = rdm.Next(1, 28),
        //    //                       _31PhysicianSignatureMm = rdm.Next(1, 12),
        //    //                       _31PhysicianSignatureYyyy = rdm.Next(1900, 2000),


        //    //                       _32aServiceFacilityProviderId = "_32_" + rdm.Next(99, 1000) ,
        //    //		_32bServiceFacilityBillingProviderId = "_32a_" + rdm.Next(99, 1000) ,
        //    //		_32ServiceFacilityCityStateZipCode = rdm.Next(99, 1000).ToString() ,
        //    //                       _32ServiceFacilityProviderAddress = rdm.Next(99, 1000).ToString(),
        //    //                       _32ServiceFacilityProviderName = rdm.Next(99, 1000).ToString(),


        //    //                       _33aBillingProviderNpi = "_33 " + rdm.Next(99, 1000) ,
        //    //		_33bBillingProviderIdentifier = "MPI" + rdm.Next(99, 1000) ,
        //    //		_33BillingProviderAddress = "_33aBillingProviderInfo" + rdm.Next(99, 1000) ,
        //    //		_33BillingProviderAreaCode = "401" ,
        //    //           _33BillingProviderCityStateZipCode = "NY, 07304",
        //    //           _33BillingProviderName = "_33BillingProviderName" + rdm.Next(99, 1000),
        //    //           _33BillingProviderPhone = "1234567890",


        //    //                       ConfidenceLevel =  rdm.Next(50, 99),
        //    //                       ParserErrorCsv = "error list" + rdm.Next(99, 1000),
        //    //                       ReviewerId = "reviewerId" + rdm.Next(1, 2),
        //    //                       ReviewStatus = rdm.Next(0, 2),
        //    //                       SourceId = "sourceId" + rdm.Next(10, 100),

        //    //                       CreatedDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
        //    //                       ModifiedDate = DateTime.Now,

        //    //                   };

        //    //                   StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail1);
        //    //                   StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail2);
        //    //                   StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail3);
        //    //                   StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail4);

        //    //                   DataContext.StagingclaimCms1500.Add(StagingclaimCms1500Item);
        //    //               } 


        //    //               await DataContext.SaveChangesAsync();
        //    //           }
        //    //           catch (Exception exp)
        //    //           {
        //    //               opStatus = OperationStatus.CreateFromException("Error updating security exchange: " + exp.Message, exp);
        //    //           }
        //    //await DataContext.SaveChangesAsync();
        //    return opStatus;
        //}







        #endregion
    }

    public static class LinQExtensions
    {
        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.GroupJoin(
                inner,
                outerKeySelector,
                innerKeySelector,
                (outerElement, innerElements) => resultSelector(outerElement, innerElements.FirstOrDefault()));
        }
    }
}
