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

        //public async Task<OperationStatus> InsertStagingClaimAsync(StagingClaim stagingClaim)
        //{
        //    //simulate insert operation success
        //    return await Task.Run(() => new OperationStatus { Status = true });
        //}

        //public async Task<StagingClaim> GetStagingClaimAsync(string insureId)
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


        //public async Task<StagingClaim> GetDashboardAsync(string reviewerId)
        //{
        //    throw NotImplementedException();
        //    ////if (String.IsNullOrEmpty(insuredId)) return null;
        //    //return await DataContext.StagingClaim
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

        //private List<StagingClaim> CreateStagingClaims(Customer cust)
        //{
        //    List<StagingClaim> stagingClaims = new List<StagingClaim>();
        //    string[] stagingClaimTitles = { "IRA", "Joint Brokerage", "Brokerage StagingClaim" };
        //    for (int i = 0; i < stagingClaimTitles.Length; i++)
        //    {
        //        var stagingClaim = new StagingClaim
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
                         _24aServiceStartDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24aServiceEndDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                         _24bPlaceofService = "place of service" + rdm.Next(1900, 2000),

                        _24cEmg = "EMG" + rdm.Next(1, 9),
                        _24dCpthcpcs = "_24dCpthcpcs" + rdm.Next(1, 9),
                        _24dModifier = "_24dModifier" + rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fCharges = Convert.ToDecimal(rdm.Next(1900, 2000)),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdt = "" + rdm.Next(1, 20).ToString(),
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderId = rdm.Next(1000, 2000)
 
                    };
                    var detail2 = new StagingClaimCms1500Detail
                    {
                        _24aServiceStartDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24aServiceEndDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24bPlaceofService = "place of service" + rdm.Next(1900, 2000),

                        _24cEmg = "EMG" + rdm.Next(1, 9),
                        _24dCpthcpcs = "_24dCpthcpcs" + rdm.Next(1, 9),
                        _24dModifier = "_24dModifier" + rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fCharges = Convert.ToDecimal(rdm.Next(1900, 2000)),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdt = "" + rdm.Next(1, 20).ToString(),
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderId = rdm.Next(1000, 2000)

                    };
                    var detail3 = new StagingClaimCms1500Detail
                    {
                        _24aServiceStartDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24aServiceEndDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24bPlaceofService = "place of service" + rdm.Next(1900, 2000),

                        _24cEmg = "EMG" + rdm.Next(1, 9),
                        _24dCpthcpcs = "_24dCpthcpcs" + rdm.Next(1, 9),
                        _24dModifier = "_24dModifier" + rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fCharges = Convert.ToDecimal(rdm.Next(1900, 2000)),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdt = "" + rdm.Next(1, 20).ToString(),
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderId = rdm.Next(1000, 2000)

                    };
                    var detail4 = new StagingClaimCms1500Detail
                    {
                        _24aServiceStartDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24aServiceEndDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _24bPlaceofService = "place of service" + rdm.Next(1900, 2000),

                        _24cEmg = "EMG" + rdm.Next(1, 9),
                        _24dCpthcpcs = "_24dCpthcpcs" + rdm.Next(1, 9),
                        _24dModifier = "_24dModifier" + rdm.Next(1, 9),

                        _24eDiagnosisPointer = "DP " + rdm.Next(1, 9),
                        _24fCharges = Convert.ToDecimal(rdm.Next(1900, 2000)),
                        _24gDaysOrUnits = rdm.Next(1, 20).ToString(),

                        _24hEpsdt = "" + rdm.Next(1, 20).ToString(),
                        _24iQual = "" + rdm.Next(1, 20).ToString(),
                        _24jRenderingProviderId = rdm.Next(1000, 2000)

                    };

                    var StagingclaimCms1500Item = new
                        StagingClaimCms1500
                    {
                         
                        //alpha order
                         _1PayerType = "PayerType" + rdm.Next(99, 1000),
                        
                        _1aPatientInsuredId= " " + rdm.Next(99, 1000),

                        _2PatientName = "_2PatientName" + rdm.Next(99, 1000),
                        _3PatientBirthDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _3aPatientGender = "M",
                        _4InsuredName = "insured name" + rdm.Next(99, 1000),

                        _5PatientAddressStreet= "_5PatientAddr " + rdm.Next(99, 1000),
                        _5PatientAddressCity= "_5Patient City" + rdm.Next(99, 1000),
                        _5PatientAddressState= "_5Patient State" + rdm.Next(99, 1000),
                        _5PatientAddress= "_5PatientAddress" + rdm.Next(99, 1000),

                        _6PatientRelationToInsured = "rel " + rdm.Next(99, 1000),
                        _7InsuredAddressStreet= "_7InsuredAddressStreet" + rdm.Next(99, 1000),
                        _7InsuredAddressCity= "_7InsuredAddressCity" + rdm.Next(99, 1000),
                        _7InsuredAddressState= "_7InsuredAddressState" + rdm.Next(99, 1000),
                        _7InsuredAddressZip = "_7" + rdm.Next(99, 1000),
                        _7InsuredAddressTelephone= " " + rdm.Next(99, 1000),

                        _8ReservedNucc= "_8ReservedNucc" + rdm.Next(99, 1000),



                        _9OtherPayerInsuredName = "_9 Name" + rdm.Next(99, 1000),
                        _9aOtherPayerGroup = "_9aOtherPayerGroup" + rdm.Next(99, 1000),
                        _9bOtherReservedNucc = "_9bOtherReservedNucc" + rdm.Next(99, 1000),
                        _9cOtherReservedNucc = "_9cOtherReservedNucc" + rdm.Next(99, 1000),
                        _9cOtherInsuranceName = "_9cOtherInsuranceName" + rdm.Next(99, 1000),
                        //Y,                       N,                        NULL
  _10aPatientConditionEmployment = "N",
                        _10bPatientConditionAuto = "Y",
                        //Y - NY,                    N,                        NULL


   _10cPatientConditionOther = "N",
                       // --Y,                         N,                         NULL
  _10dClaimCodes = "_10dClaimCodes" + rdm.Next(99, 1000),

                        _11InsuredPolicyGroup = rdm.Next(1111, 9999),

                        _11aInsuredBirthDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _11aInsuredGender = "M",
                        _11bOtherClaimId = "_11bOtherClaimId" + rdm.Next(99, 1000),
                        _11cInsurancePlanName= "_11cInsurancePlanName" + rdm.Next(99, 1000),
                        _11cOtherClaimIdNucc= "_11cOtherClaimIdNUCC" + rdm.Next(99, 1000),
                        _11dIsAnotherHealthPlan = "Y",

                        _12PatientAuthorizedSignatureImageUrl= "PayerType" + rdm.Next(99, 1000),
                        _12PatientAuthorizedSignatureDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),

                        _13InsuredAuthorizedSignatureImageUrl= "PayerType" + rdm.Next(99, 1000),



                        _14DateOfCurrentIllness= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _14DateOfCurrentIllnessQual= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),

                        _15OtherDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _15OtherQual= "Q" + rdm.Next(99, 1000),


                        _16PatientUnableToWorkStartDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _16PatientUnableToWorkEndDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),

                        _17ReferringProvider= "PayerType" + rdm.Next(99, 1000),

                        _17aNonNpireferringProvider= "PayerType" + rdm.Next(99, 1000),

                        _18HospitalizationStartDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _18HospitalizationEndDate= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        _19AdditionalClaimInfo= "PayerType" + rdm.Next(99, 1000),

                        _20OutsideLab ="Y",
                        // --TODO: should it be bool or string


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


    _21Icdind= "_21Icdind" + rdm.Next(99, 1000),
    //--TODO: Deep / Adharsh



   _22ResubmissionCode= "PayerType" + rdm.Next(99, 1000),
   _22OriginalRefNo= "PayerType" + rdm.Next(99, 1000),
   _23PriorAuthorizationNumber = rdm.Next(99, 1000),

                        // --24_ colums move to Child table


                        _25FederalTaxId = rdm.Next(99, 1000),
                        _25IsSsnorEin = "Y" ,
	
	
	_26PatientAccountNumber= "_26PatientAccountNumber" + rdm.Next(99, 1000) ,
	_27AcceptAssignment ="N" ,
	_28TotalCharge = "PayerType" + rdm.Next(99, 1000) ,
		_29AmountPaid = "PayerType" + rdm.Next(99, 1000) ,
			_30Nuccuse = "PayerType" + rdm.Next(99, 1000) ,
			_31PhysicianSignatureImageUrl = "_31 Signature ImageUrl" + rdm.Next(99, 1000) ,
			_32ServiceFacilityLocationInfo = "_32ServiceFacilityLocationInfo" + rdm.Next(99, 1000) ,
			_32aServiceFacilityLocationInfo = "_32aServiceFacilityLocationInfo" + rdm.Next(99, 1000) ,
			_32bServiceFacilityLocationInfo = "_32bServiceFacilityLocationInfo" + rdm.Next(99, 1000) ,
			
			_33BillingProviderInfo = "_33BillingProviderInfo" + rdm.Next(99, 1000) ,
			_33BillingProviderInfoPhone = "_33BillingProviderInfoPhone" + rdm.Next(99, 1000) ,
			_33aBillingProviderInfo = "_33aBillingProviderInfo" + rdm.Next(99, 1000) ,
			_33bBillingProviderInfo = "PayerType" + rdm.Next(99, 1000) ,


                         ConfidenceLevel =  rdm.Next(50, 99),
                        ParserErrorCsv = "error list" + rdm.Next(99, 1000),
                        ReviewerId = "reviewerId" + rdm.Next(1, 2),
                        ReviewStatus = rdm.Next(0, 3),
                        SourceId = "sourceId" + rdm.Next(10, 100),

                        CreatedDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        ModifiedDate = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                       
                        //    stagingClaimCms1500Details = new StagingClaimCms1500Detail()
                        //    _27AcceptAssignment = ((rdm.Next(0, 1) == 0) ? "F" : "T"), // T, F
                        //    _19AdditionalClaimInfo = "_19Additional ClaimInfo " + rdm.Next(99, 1000),
                        //    //AnotherHealthBenefitPlan = bool.Parse((rdm.Next(0, 1) == 0) ? "False" : "True"),

                        //_33bBillingProviderInfo = "_33bBillingProviderInfo " + rdm.Next(99, 1000),
                        //    BirthDate = new= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),Time(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),
                        //   = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),OfIllness = new= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),Time(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),

                        //   = new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),OfService = rdm.Next(1, 100),
                        //    DaysOrUnits = rdm.Next(1, 100),
                        //    Emg = bool.Parse((rdm.Next(0, 1) == 0) ? "False" : "True"),

                        //    EpsdtfamilyPlan = "FamilyPlan",
                        //    FacilityNameAddress = "Facility, Name, Adress",
                        //    FederalTaxId = rdm.Next(99, 1000),

                        //    HospitalizationDates = rdm.Next(99, 1000),
                        //    //Id = -1,
                        //    InsurancePlan = "InsurancePlan" + rdm.Next(99, 1000),
                        //    InsurancePlanName = "InsurancePlanName" + rdm.Next(99, 1000),
                        //    InsuredAddress = "InsuredAddress" + rdm.Next(99, 1000),

                        //    InsuredAuthorizedSignature = "InsuredAuthorizedSignature" + rdm.Next(99, 1000),
                        //    InsuredDateOfBirth = (new= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),Time(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28))).ToShortDateString(),
                        //    InsuredId = rdm.Next(99, 1000).ToString(),

                        //    InsuredName = "InsuredName" + rdm.Next(99, 1000),
                        //    InsuredPolicyGroup = rdm.Next(99, 1000),
                        //    NatureOfIllness = "NatureOfIllness" + rdm.Next(99, 1000),

                        //    NoWorkDays = rdm.Next(1, 100),
                        //    OtherClaimId = "OtherClaimId" + rdm.Next(99, 1000),
                        //    OtherDate = new= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),Time(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),

                        //    OtherInsurance = "OtherInsurance" + rdm.Next(99, 1000),
                        //    OtherInsuranceNumber = "OtherInsuranceNumber" + rdm.Next(99, 1000),
                        //    OutsideLab = bool.Parse((rdm.Next(0, 1) == 0) ? "False" : "True"),

                        //    PatientAddress = "PatientAddress" + rdm.Next(99, 1000),
                        //    PatientAuthorizedSignature = "PatientAuthorizedSignature" + rdm.Next(99, 1000),
                        //    PatientCondition = bool.Parse((rdm.Next(0, 1) == 0) ? "False" : "True"),

                        //    PatientName = "PatientName" + rdm.Next(99, 1000),
                        //    PatientStagingClaimNumber = "PatientStagingClaimNumber" + rdm.Next(99, 1000),
                        //    PlaceOfService = "PlaceOfService" + rdm.Next(99, 1000),

                        //    PriorAuthorizationNumber = rdm.Next(99, 1000),
                        //    ProcedureCodes = rdm.Next(99, 1000),
                        //    ProviderBillingNumber = "ProviderBillingNumber" + rdm.Next(99, 1000),

                        //    ReferringProvider = "ReferringProvider" + rdm.Next(99, 1000),
                        //    RelationToInsured = "RelationToInsured" + rdm.Next(99, 1000),
                        //    RenderingProviderId = rdm.Next(99, 1000),

                        //    SecondaryRenderingProviderId = rdm.Next(99, 1000),
                        //    SignatureofProvider = "SignatureofProvider" + rdm.Next(99, 1000),
                        //    TotalCharge = Convert.ToDecimal(rdm.Next(99, 1000)),
                        //    TotalClaimAmount = Convert.ToDecimal(rdm.Next(99, 1000)),
                        //    PatientAccountNumber = "PatientAccountNumber" + rdm.Next(99, 1000),








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

            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            var startOfWeekDate = DateTime.Now;

            while (startOfWeekDate.DayOfWeek != weekStart)
                startOfWeekDate = startOfWeekDate.AddDays(-1);
            var claimsByReviewer0 = await DataContext.StagingClaim
              
              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 0
              && c.ModifiedDate >= startOfWeekDate && c.ModifiedDate <= new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28))
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var claimsByReviewer1 = await DataContext.StagingClaim

              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 1
              //TODO: remove this !&& c.ModifiedDate >= startOfWeek && c.ModifiedDate <== new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),Time.Now
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();

            var claimsByReviewer2 = await DataContext.StagingClaim

              .Where(c => c.ReviewerId == reviewerId && c.ReviewStatus == 2
              //TODO: remove this !&& c.ModifiedDate >= startOfWeek && c.ModifiedDate <== new DateTime(rdm.Next(1900, 2000), rdm.Next(1, 12), rdm.Next(1, 28)),Time.Now
              )

            .GroupBy(c => new { c.ReviewerId, c.ReviewStatus }) //
            .Select(g => new
            {
                g.Key.ReviewerId,
                g.Key.ReviewStatus,

                Claimcount = g.Count()
            }).FirstOrDefaultAsync();


            // "TODO", "ROLLBACK", "COMPLETED"
            Dashboard d = new Dashboard();
            d.ClaimsCMS100.Add("TODO", claimsByReviewer0.Claimcount);
            
            d.ClaimsCMS100.Add("ROLLBACK", claimsByReviewer1.Claimcount);
            d.ClaimsCMS100.Add("COMPLETED", claimsByReviewer2.Claimcount);

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



            var claimsByReviewerWeek = await DataContext.StagingClaim

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
