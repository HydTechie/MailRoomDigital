using MailRoom.Model;
using MailRoom.Repository.Helpers;
using MailRoom.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace MailRoom.Repository
{

    public class StagingClaimRepository : RepositoryBase<MailRoomContext>, IStagingClaimRepository
    {
        IStagingEngine _StagingEngine;
        //ISecurityRepository _SecurityRepository;

        public StagingClaimRepository(IStagingEngine StagingEngine,
            //ISecurityRepository securityRepository,
            MailRoomContext context) : base(context)
        {
            _StagingEngine = StagingEngine;
           // _SecurityRepository = securityRepository;
        }

        //public async Task<Customer> GetCustomerAsync(string custId)
        //{
        //    return await DataContext.StagingClaims
        //        .Include(c => c.StagingClaims)
        //        .SingleOrDefaultAsync(c => c.CustomerCode == custId);
        //}

        //public async Task<OperationStatus> InsertStagingClaimAsync(StagingclaimCms1500 stagingClaim)
        //{
        //    //simulate insert operation success
        //    return await Task.Run(() => new OperationStatus { Status = true });
        //}

        //public async Task<StagingclaimCms1500> GetStagingClaimAsync(string insureId)
        //{
        //    if (String.IsNullOrEmpty(insureId)) return null;
        //    return await UpdateStagingClaimAsync(insureId);
        //}

        public async Task<OperationStatus> UpdatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500)
        {
            try
            {

                DataContext.Entry(stagingClaimCms1500).State = EntityState.Modified;
                // DataContext.Entry<StagingClaimCms1500Detail>().State = EntityState.Modified;
                foreach ( var item in stagingClaimCms1500.StagingclaimCms1500Detail)
                {
                    if (item.ClaimDetailId == 0)
                    {
                       DataContext.Entry(item).State = EntityState.Added;
                    }
                    else
                        DataContext.Entry(item).State = EntityState.Modified;
                }

                await DataContext.SaveChangesAsync();


                
            }
            catch(Exception e)
            {
                return OperationStatus.CreateFromException("Error occured while update", e);
            }
            return new OperationStatus();
        }
    
        public async Task<StagingClaimCms1500> GetStagingClaimAsync(string insuredId)
        {
            if (String.IsNullOrEmpty(insuredId)) return null;
            return await DataContext.StagingclaimCms1500
                
                .Include(claim => claim.StagingclaimCms1500Detail)
                //.Include(ba => ba.Positions)
                .SingleOrDefaultAsync(c => c._1aPatientInsuredId.Trim() == insuredId.Trim());
        }


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
        public async Task<OperationStatus> CreateStagingClaimAsync()
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {



                for (int i = 0; i < 100; i++)
                {
                    var rdm = new Random((int)DateTime.Now.Ticks + i);

                    var detail1 = new StagingClaimCms1500Detail
                    {
                         _24aServiceStartMm = rdm.Next(1, 12),
                        _24aServiceStartDd = rdm.Next(1, 28), 
                        _24aServiceStartYyyy =  rdm.Next(1900, 2000),

                        _24aServiceEndMm = rdm.Next(1, 12),
                        _24aServiceEndDd = rdm.Next(1, 28),
                        _24aServiceEndYyyy = rdm.Next(1900, 2000),

                        _24bPlaceofService =  rdm.Next(10, 99),
                      
                        _24cEmg = "Y" ,
                        _24dCpthcpcs = rdm.Next(1, 9),
                        _24dModifier = rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fChargesDollar =  rdm.Next(1900, 2000) ,
                        _24fChargesCents = rdm.Next(0, 99),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdtcode = "AV",
                        _24hEpsdtyn = "Y",
                        _24iQual = "QQ",
                        _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
                        _24jRenderingProviderId = rdm.Next(1000, 2000),

                        

                    };
                    var detail2 = new StagingClaimCms1500Detail
                    {
                        _24aServiceStartMm = rdm.Next(1, 12),
                        _24aServiceStartDd = rdm.Next(1, 28),
                        _24aServiceStartYyyy = rdm.Next(1900, 2000),

                        _24aServiceEndMm = rdm.Next(1, 12),
                        _24aServiceEndDd = rdm.Next(1, 28),
                        _24aServiceEndYyyy = rdm.Next(1900, 2000),

                        _24bPlaceofService = rdm.Next(10, 99),

                        _24cEmg = "Y",
                        _24dCpthcpcs = rdm.Next(1, 9),
                        _24dModifier = rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fChargesDollar = rdm.Next(1900, 2000),
                        _24fChargesCents = rdm.Next(0, 99),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdtcode = "AV",
                        _24hEpsdtyn = "Y",
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
                        _24jRenderingProviderId = rdm.Next(1000, 2000),



                    };
                    var detail3 = new StagingClaimCms1500Detail
                    {
                        _24aServiceStartMm = rdm.Next(1, 12),
                        _24aServiceStartDd = rdm.Next(1, 28),
                        _24aServiceStartYyyy = rdm.Next(1900, 2000),

                        _24aServiceEndMm = rdm.Next(1, 12),
                        _24aServiceEndDd = rdm.Next(1, 28),
                        _24aServiceEndYyyy = rdm.Next(1900, 2000),

                        _24bPlaceofService = rdm.Next(10, 99),

                        _24cEmg = "Y",
                        _24dCpthcpcs = rdm.Next(1, 9),
                        _24dModifier = rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fChargesDollar = rdm.Next(1900, 2000),
                        _24fChargesCents = rdm.Next(0, 99),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdtcode = "AV",
                        _24hEpsdtyn = "Y",
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
                        _24jRenderingProviderId = rdm.Next(1000, 2000),



                    };
                    var detail4 = new StagingClaimCms1500Detail
                    {
                        _24aServiceStartMm = rdm.Next(1, 12),
                        _24aServiceStartDd = rdm.Next(1, 28),
                        _24aServiceStartYyyy = rdm.Next(1900, 2000),

                        _24aServiceEndMm = rdm.Next(1, 12),
                        _24aServiceEndDd = rdm.Next(1, 28),
                        _24aServiceEndYyyy = rdm.Next(1900, 2000),

                        _24bPlaceofService = rdm.Next(10, 99),

                        _24cEmg = "Y",
                        _24dCpthcpcs = rdm.Next(1, 9),
                        _24dModifier = rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fChargesDollar = rdm.Next(1900, 2000),
                        _24fChargesCents = rdm.Next(0, 99),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdtcode = "AV",
                        _24hEpsdtyn = "Y",
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderNpiid = rdm.Next(1000, 2000),
                        _24jRenderingProviderId = rdm.Next(1000, 2000),



                    };
                    var StagingclaimCms1500Item = new
                        StagingClaimCms1500
                    {

                        //alpha order
                        IaPayerName = "IaPayerName" + rdm.Next(99, 1000),
                        IbPayerAddress1 = "IbPayerAddress1" + rdm.Next(99, 1000),
                        IcPayerAddress2 = "IcPayerAddress2" + rdm.Next(99, 1000),
                        IdPayerCity = "NY",
                        IdPayerState = "NY",
                        IdPayerZipcode = "07304",

                        _1PayerType = "test" + rdm.Next(99, 1000),

                        _1aPatientInsuredId = " " + rdm.Next(99, 1000),

                        _2aPatientLastName = "_2PatientName" + rdm.Next(99, 1000),

                        _2bSuffix = "_2bSuffix" + rdm.Next(99, 1000),
                        _2dPatientMiddleName = "_2dPatientMiddleName" + rdm.Next(99, 1000),
                        _2cPatientFirstName = "_2PatientName" + rdm.Next(99, 1000),

                        _3PatientBirthMm = rdm.Next(1, 12),
                        _3PatientBirthDd = rdm.Next(1, 12),
                        _3PatientBirthYyyy = rdm.Next(1, 12),

                        _3PatientGender = "M",

                        _4InsuredFirstName = "_4InsuredFirstName" + rdm.Next(99, 1000),
                        _4InsuredMiddleName = "_4InsuredFirstName" + rdm.Next(99, 1000),
                        _4InsuredLastName = "_4InsuredFirstName" + rdm.Next(99, 1000),
                        _4InsuredSuffix = "MR",


                        _5PatientAddressStreet = "_5PatientAddr " + rdm.Next(99, 1000),
                        _5PatientAddressCity = "NYC" + rdm.Next(99, 1000),
                        _5PatientAddressState = "NY" ,
                        _5PatientAreaCode = rdm.Next(99, 1000).ToString(),
                        _5PatientTelePhone = rdm.Next(99, 1000).ToString(),
                        _5PatientZipCode = rdm.Next(99, 1000).ToString(),

                        _6PatientRelationToInsured = "rel " + rdm.Next(99, 1000),
                        _7InsuredAddressStreet = "_7InsuredAddressStreet" + rdm.Next(99, 1000),
                        _7InsuredAddressCity = "NYC" ,
                        _7InsuredAddressState = "NY" ,
                        _7InsuredAreaCode = rdm.Next(99, 1000).ToString(),
                        _7InsuredTelephone = rdm.Next(99, 1000).ToString(),
                        _7InsuredZipCode = rdm.Next(99, 1000).ToString(),


                        _8ReservedNucc = "_8ReservedNucc" + rdm.Next(99, 1000),



                        _9aOtherPolicyGroup = "_9 Name" + rdm.Next(99, 1000),
                        _9OtherInsuredFirstName = "_9OtherInsuredFirstName" + rdm.Next(99, 1000),
                        _9bOtherReservedNucc = "_9bOtherReservedNucc" + rdm.Next(99, 1000),
                        _9cOtherReservedNucc = "_9cOtherReservedNucc" + rdm.Next(99, 1000),
                        _9cOtherInsuranceName = "_9cOtherInsuranceName" + rdm.Next(99, 1000),
                        _9OtherInsuredLastName = "_9OtherInsuredFirstName" + rdm.Next(99, 1000),
                        _9OtherInsuredMiddleName = "_9OtherInsuredFirstName" + rdm.Next(99, 1000),
                        _9OtherInsuredSuffix = "Mrs",

                        //Y,                       N,                        NULL
                        _10aPatientConditionEmployment = "N",
                        _10bPatientConditionAuto = "Y",
                        _10bPatientConditionPlace = "NY",
                        _10cPatientConditionOther = "N",
                        _10dClaimCodes = "_10dClaimCodes" + rdm.Next(99, 1000),
                        //Y - NY,                    N,                        NULL



                        // --Y,                         N,                         NULL


                        _11InsuredPolicyGroup = rdm.Next(1111, 9999).ToString(),

                        _11aInsuredBirthMm = rdm.Next(1, 12),
                        _11aInsuredBirthDd = rdm.Next(1, 28),
                        _11aInsuredBirthYyyy = rdm.Next(1900, 2000),

                        _11aInsuredGender = "M",
                        _11bOtherClaimIdQual = "QA",
                        _11bOtherClaimId = "_11c" + rdm.Next(99, 1000),
                        _11cInsurancePlanName = "_11cOtherClaimIdNUCC" + rdm.Next(99, 1000),
                        _11dIsAnotherHealthPlan = "Y",

                        _12PatientAuthorizedSignatureImageUrl = "test" + rdm.Next(99, 1000),
                        _12PatientAuthorizedSignatureMm = rdm.Next(1, 12),
                        _12PatientAuthorizedSignatureDd = rdm.Next(1, 28),
                        _12PatientAuthorizedSignatureYyyy = rdm.Next(1900, 2000),

                        _13InsuredAuthorizedSignatureImageUrl = "test" + rdm.Next(99, 1000),



                        _14CurrentIllnessDd = rdm.Next(1, 28),
                        _14CurrentIllnessMm = rdm.Next(1, 12),
                        _14CurrentIllnessYyyy = rdm.Next(1900, 2000),

                        _14DateOfCurrentIllnessQual = "IND",

                        _15OtherDateMm = rdm.Next(1, 12),
                        _15OtherDateDd = rdm.Next(1, 28),
                        _15OtherDateYyyy = rdm.Next(1900, 2000),

                        _15OtherQual = "QP" ,


                        _16PatientUnableToWorkStartMm = rdm.Next(1, 12),
                        _16PatientUnableToWorkStartDd = rdm.Next(1, 28),
                        _16PatientUnableToWorkStartYyyy = rdm.Next(1900, 2000),

                        _16PatientUnableToWorkEndMm = rdm.Next(1, 12),
                        _16PatientUnableToWorkEndDd = rdm.Next(1, 28),
                        _16PatientUnableToWorkEndYyyy = rdm.Next(1900, 2000),

                        _17ReferringProviderName = "test" + rdm.Next(99, 1000),

                        _17aNonNpireferringProviderQual = "QA" ,
                        _17aNonNpireferringProvider = "NPI" + rdm.Next(99, 1000),
                        _17aNpireferringProvider = "PR" + rdm.Next(99, 1000),
                        _17aNpireferringProviderQual = "QA",
                        _17ReferringProviderQual = "QA",


                        _18HospitalizationStartMm = rdm.Next(1, 12),
                        _18HospitalizationStartDd = rdm.Next(1, 28),
                        _18HospitalizationStartYyyy = rdm.Next(1900, 2000),

                        _18HospitalizationEndMm = rdm.Next(1, 12),
                        _18HospitalizationEndDd = rdm.Next(1, 28),
                        _18HospitalizationEndYyyy = rdm.Next(1900, 2000),

                        _19AdditionalClaimInfo = "test" + rdm.Next(99, 1000),

                        _20OutsideLab = "Y",
                        _20ChargesCents = "00",
                        _20ChargesDollars = "130",
                      


    _21NatureOfIllnessA= "NatureOfIllnessA" + rdm.Next(99, 1000),

    _21NatureOfIllnessB= "NatureOfIllnessB" + rdm.Next(99, 1000),

    _21NatureOfIllnessC= "NatureOfIllnessC" + rdm.Next(99, 1000),



    _21NatureOfIllnessD= "NatureOfIllnessD" + rdm.Next(99, 1000),

    _21NatureOfIllnessE= "NatureOfIllnessE" + rdm.Next(99, 1000),

    _21NatureOfIllnessF= "NatureOfIllnessF" + rdm.Next(99, 1000),


    _21NatureOfIllnessG= "NatureOfIllnessG" + rdm.Next(99, 1000),

    _21NatureOfIllnessH= "_21NatureOfIllnessH" + rdm.Next(99, 1000),

    _21NatureOfIllnessI= "_21NatureOfIllnessI" + rdm.Next(99, 1000),


    _21NatureOfIllnessJ= "_21NatureOfIllnessJ" + rdm.Next(99, 1000),

    _21NatureOfIllnessK= "_21NatureOfIllnessK" + rdm.Next(99, 1000),

    _21NatureOfIllnessL= "_21NatureOfIllnessL" + rdm.Next(99, 1000),


    _21IcdindQual = "Q",
    _21IcdindValue = "ind" +rdm.Next(99, 1000),
    //--TODO: Deep / Adharsh

   _22ResubmissionCodeQual = "QA" ,
   _22OriginalRefNo= "test" + rdm.Next(99, 1000),
   _23PriorAuthorizationNumber = rdm.Next(99, 1000).ToString(),

                        // --24_ colums move to Child table


                        _25FederalTaxId = rdm.Next(99, 1000).ToString(),
                        _25FederalTaxType = "FA",
	                  
	
	_26PatientAccountNumber=  rdm.Next(99, 1000) ,
	_27AcceptAssignment ="N" ,
	_28TotalCharges =  rdm.Next(99, 1000) ,
		_29AmountPaid =  rdm.Next(99, 1000) ,
        
			_30NuccuseCode = "AVC" ,
            _30NuccuseQualifier ="AB",
			_31PhysicianSignatureImageUrl = "_31 Signature ImageUrl" + rdm.Next(99, 1000) ,

                        _31PhysicianSignatureDd = rdm.Next(1, 28),
                        _31PhysicianSignatureMm = rdm.Next(1, 12),
                        _31PhysicianSignatureYyyy = rdm.Next(1900, 2000),
                        

                        _32aServiceFacilityProviderId = "_32_" + rdm.Next(99, 1000) ,
			_32bServiceFacilityBillingProviderId = "_32a_" + rdm.Next(99, 1000) ,
			_32ServiceFacilityCityStateZipCode = rdm.Next(99, 1000).ToString() ,
                        _32ServiceFacilityProviderAddress = rdm.Next(99, 1000).ToString(),
                        _32ServiceFacilityProviderName = rdm.Next(99, 1000).ToString(),
                        

                        _33aBillingProviderNpi = "_33 " + rdm.Next(99, 1000) ,
			_33bBillingProviderIdentifier = "MPI" + rdm.Next(99, 1000) ,
			_33BillingProviderAddress = "_33aBillingProviderInfo" + rdm.Next(99, 1000) ,
			_33BillingProviderAreaCode = "401" ,
            _33BillingProviderCityStateZipCode = "NY, 07304",
            _33BillingProviderName = "_33BillingProviderName" + rdm.Next(99, 1000),
            _33BillingProviderPhone = "1234567890",
           

                        ConfidenceLevel =  rdm.Next(50, 99),
                        ParserErrorCsv = "error list" + rdm.Next(99, 1000),
                        ReviewerId = "reviewerId" + rdm.Next(1, 2),
                        ReviewStatus = rdm.Next(0, 2),
                        SourceId = "sourceId" + rdm.Next(10, 100),

                        CreatedDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        ModifiedDate = DateTime.Now,
           
                    };

                    StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail1);
                    StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail2);
                    StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail3);
                    StagingclaimCms1500Item.StagingclaimCms1500Detail.Add(detail4);

                    DataContext.StagingclaimCms1500.Add(StagingclaimCms1500Item);
                } 
                     

                await DataContext.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                opStatus = OperationStatus.CreateFromException("Error updating security exchange: " + exp.Message, exp);
            }
            return opStatus;
        }

 

        public async Task<Dashboard>  GetDashboardAsync(string reviewerId)
        {
            
            var rdm = new Random((int)DateTime.Now.Ticks);

            //DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            //var startOfWeekDate = DateTime.Now;

            //while (startOfWeekDate.DayOfWeek != weekStart)
            //    startOfWeekDate = startOfWeekDate.AddDays(-1);
            // >= startOfWeekDate && c.ModifiedDate <= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28))

            var claimsByReviewer0 = await DataContext.StagingclaimCms1500
              
              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 0
              && c.ModifiedDate.Value.Date == DateTime.Now.Date
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var claimsByReviewer1 = await DataContext.StagingclaimCms1500

              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 1
                && c.ModifiedDate.Value.Date == DateTime.Now.Date
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var claimsByReviewer2 = await DataContext.StagingclaimCms1500

              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 2
               && c.ModifiedDate.Value.Date == DateTime.Now.Date
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();


            // "TODO"-0, "ROLLBACK"-2, "COMPLETED"-1
            Dashboard d = new Dashboard();
            d.ClaimsCMS100["TODO"] = claimsByReviewer0.Claimcount;
            d.ClaimsCMS100["COMPLETED"] = claimsByReviewer1.Claimcount;
            d.ClaimsCMS100["ROLLBACK"] = claimsByReviewer2.Claimcount;
            

          
            // TODO: fill up other values once other claims types ready, Else carries 0!

            d.CompletedTotalCount = d.ClaimsCMS100["COMPLETED"]
                    + d.ClaimsPK83["COMPLETED"] + d.ClaimsUB04["COMPLETED"];

            d.TodoTotalCount = d.ClaimsCMS100["TODO"]
                  + d.ClaimsPK83["TODO"] + d.ClaimsUB04["TODO"];

            d.RollbackTotalCount = d.ClaimsCMS100["ROLLBACK"]
                  + d.ClaimsPK83["ROLLBACK"] + d.ClaimsUB04["ROLLBACK"];
            return d;
        }


        public async Task<DashboardWeek> GetDashboardByWeekAsync(string reviewerId)
        {
            DataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //DbInterception.Add(new TemporalTableCommandTreeInterceptor());
            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            var startingDate = DateTime.Now;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            // TODO: verify the values... 
            var previousWeekStart = startingDate.AddDays(-7);
            var previousWeekEnd = previousWeekStart.AddDays(7);



            var claimsByReviewerWeek = await DataContext.StagingclaimCms1500

              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 0
              && c.ModifiedDate >= previousWeekStart && c.ModifiedDate <= previousWeekEnd
              )

            .GroupBy(c => new { c.ReviewerId, c.ModifiedDate }) //
            .Select(g => new 
            {
                //g.Key.ReviewerId,
                g.Key.ModifiedDate,

                Claimcount = g.Count()
            }).ToListAsync();
            //("SELECT ModifiedDate WorkDate, COUNT(ClaimID) FROM stagingclaim a WHERE ReviewerId = {0} and ModifiedDate >= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),_SUB(DATE(NOW()), INTERVAL 1 WEEK)  GROUP BY WorkDate order by workdate asc", reviewerId)
            // .AsNoTracking()



            //// "TODO", "ROLLBACK", "COMPLETED"
            DashboardWeek d = new DashboardWeek();
            //d.ClaimsCMS100.Add("TODO", claimsByReviewer0.Claimcount);
             foreach(var item in claimsByReviewerWeek)
            {
                d.DateOnXaxis.Add(item.ModifiedDate.Value.ToShortDateString());
                d.ClaimCountOnYaxis.Add(item.Claimcount);
            }
            //d.ClaimsCMS100.Add("ROLLBACK", claimsByReviewer1.Claimcount);
            //d.ClaimsCMS100.Add("COMPLETED", claimsByReviewer2.Claimcount);

            return d;
        }



        #endregion
    }
}
