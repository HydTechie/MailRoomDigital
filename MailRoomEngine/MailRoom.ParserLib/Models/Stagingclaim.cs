using System;
using System.Collections.Generic;

namespace MailRoom.ParserLib
{
    public partial class Stagingclaim //: Row
    {
         
      
        public int ClaimId { get; set; }
        public string InsuredId { get; set; }
        public string PatientName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string InsuredName { get; set; }
        public string PatientAddress { get; set; }
        public string RelationToInsured { get; set; }
        public string InsuredAddress { get; set; }
        public string OtherInsurance { get; set; }
        public string OtherInsuranceNumber { get; set; }
        public string InsurancePlan { get; set; }
        public bool? PatientCondition { get; set; }
        public int? InsuredPolicyGroup { get; set; }
        public string InsuredDateOfBirth { get; set; }
        public string PatientStagingClaimNumber { get; set; }
        public string OtherClaimId { get; set; }
        public string InsurancePlanName { get; set; }
        public bool? AnotherHealthBenefitPlan { get; set; }
        public string PatientAuthorizedSignature { get; set; }
        public string InsuredAuthorizedSignature { get; set; }
        public DateTime? DateOfIllness { get; set; }
        public DateTime? OtherDate { get; set; }
        public int? NoWorkDays { get; set; }
        public string ReferringProvider { get; set; }
        public int? RenderingProviderId { get; set; }
        public int? SecondaryRenderingProviderId { get; set; }
        public int? HospitalizationDates { get; set; }
        public bool? AdditionalClaimInfo { get; set; }
        public bool? OutsideLab { get; set; }
        public string NatureOfIllness { get; set; }
        public int? PriorAuthorizationNumber { get; set; }
        public int? DateOfService { get; set; }
        public string PlaceOfService { get; set; }
        public bool? Emg { get; set; }
        public int? ProcedureCodes { get; set; }
        public decimal? TotalCharge { get; set; }
        public decimal? TotalClaimAmount { get; set; }
        public int? DaysOrUnits { get; set; }
        public string EpsdtfamilyPlan { get; set; }
        public int? FederalTaxId { get; set; }
        public string PatientAccountNumber { get; set; }
        public bool? AcceptAssignment { get; set; }
        public string SignatureofProvider { get; set; }
        public string FacilityNameAddress { get; set; }
        public string ProviderBillingNumber { get; set; }
        public int? BillingProviderNpi { get; set; }
        public string ReviewerId { get; set; }
        public int? ReviewStatus { get; set; }
        public string ParserErrorCsv { get; set; }
        public string SourceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
