using System;
using System.Collections.Generic;
using System.Text;

namespace MailRoom.ParserLib
{
    //public partial class StagingClaimCms1500 : Row
    //{
        

        

    //    public int ClaimId { get; set; }
    //    public string _1PayerType { get; set; }
    //    public string _1aPatientInsuredId { get; set; }
    //    public string _2PatientName { get; set; }
    //    public DateTime? _3PatientBirthDate { get; set; }
    //    public string _3aPatientGender { get; set; }
    //    public string _4InsuredName { get; set; }
    //    public string _5PatientAddressStreet { get; set; }
    //    public string _5PatientAddressCity { get; set; }
    //    public string _5PatientAddressState { get; set; }
    //    public string _5PatientAddress { get; set; }
    //    public string _6PatientRelationToInsured { get; set; }
    //    public string _7InsuredAddressStreet { get; set; }
    //    public string _7InsuredAddressCity { get; set; }
    //    public string _7InsuredAddressState { get; set; }
    //    public string _7InsuredAddressZip { get; set; }
    //    public string _7InsuredAddressTelephone { get; set; }
    //    public string _8ReservedNucc { get; set; }
    //    public string _9OtherPayerInsuredName { get; set; }
    //    public string _9aOtherPayerGroup { get; set; }
    //    public string _9bOtherReservedNucc { get; set; }
    //    public string _9cOtherReservedNucc { get; set; }
    //    public string _9cOtherInsuranceName { get; set; }
    //    public string _10aPatientConditionEmployment { get; set; }
    //    public string _10bPatientConditionAuto { get; set; }
    //    public string _10cPatientConditionOther { get; set; }
    //    public string _10dClaimCodes { get; set; }
    //    public int? _11InsuredPolicyGroup { get; set; }
    //    public DateTime? _11aInsuredBirthDate { get; set; }
    //    public string _11aInsuredGender { get; set; }
    //    public string _11bOtherClaimId { get; set; }
    //    public string _11cInsurancePlanName { get; set; }
    //    public string _11cOtherClaimIdNucc { get; set; }
    //    public string _11dIsAnotherHealthPlan { get; set; }
    //    public string _12PatientAuthorizedSignatureImageUrl { get; set; }
    //    public DateTime? _12PatientAuthorizedSignatureDate { get; set; }
    //    public string _13InsuredAuthorizedSignatureImageUrl { get; set; }
    //    public DateTime? _14DateOfCurrentIllness { get; set; }
    //    public DateTime? _14DateOfCurrentIllnessQual { get; set; }
    //    public DateTime? _15OtherDate { get; set; }
    //    public string _15OtherQual { get; set; }
    //    public DateTime? _16PatientUnableToWorkStartDate { get; set; }
    //    public DateTime? _16PatientUnableToWorkEndDate { get; set; }
    //    public string _17ReferringProvider { get; set; }
    //    public string _17aNonNpireferringProvider { get; set; }
    //    public DateTime? _18HospitalizationStartDate { get; set; }
    //    public DateTime? _18HospitalizationEndDate { get; set; }
    //    public string _19AdditionalClaimInfo { get; set; }
    //    public string _20OutsideLab { get; set; }
    //    public string _21NatureOfIllnessA { get; set; }
    //    public string _21NatureOfIllnessB { get; set; }
    //    public string _21NatureOfIllnessC { get; set; }
    //    public string _21NatureOfIllnessD { get; set; }
    //    public string _21NatureOfIllnessE { get; set; }
    //    public string _21NatureOfIllnessF { get; set; }
    //    public string _21NatureOfIllnessG { get; set; }
    //    public string _21NatureOfIllnessH { get; set; }
    //    public string _21NatureOfIllnessI { get; set; }
    //    public string _21NatureOfIllnessJ { get; set; }
    //    public string _21NatureOfIllnessK { get; set; }
    //    public string _21NatureOfIllnessL { get; set; }
    //    public string _21Icdind { get; set; }
    //    public string _22ResubmissionCode { get; set; }
    //    public string _22OriginalRefNo { get; set; }
    //    public int? _23PriorAuthorizationNumber { get; set; }
    //    public int? _25FederalTaxId { get; set; }
    //    public string _25IsSsnorEin { get; set; }
    //    public string _26PatientAccountNumber { get; set; }
    //    public string _27AcceptAssignment { get; set; }
    //    public string _28TotalCharge { get; set; }
    //    public string _29AmountPaid { get; set; }
    //    public string _30Nuccuse { get; set; }
    //    public string _31PhysicianSignatureImageUrl { get; set; }
    //    public string _32ServiceFacilityLocationInfo { get; set; }
    //    public string _32aServiceFacilityLocationInfo { get; set; }
    //    public string _32bServiceFacilityLocationInfo { get; set; }
    //    public string _33BillingProviderInfo { get; set; }
    //    public string _33BillingProviderInfoPhone { get; set; }
    //    public string _33aBillingProviderInfo { get; set; }
    //    public string _33bBillingProviderInfo { get; set; }
    //    public string ReviewerId { get; set; }
    //    public int? ReviewStatus { get; set; }
    //    public int? ConfidenceLevel { get; set; }
    //    public string ParserErrorCsv { get; set; }
    //    public string SourceId { get; set; }
    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public ICollection<StagingClaimCms1500Detail> StagingclaimCms1500Detail { get; set; }
    //}

    //public partial class StagingClaimCms1500Detail
    //{
    //    public int ClaimDetailId { get; set; }
    //    public int? ClaimId { get; set; }
    //    public DateTime? _24aServiceStartDate { get; set; }
    //    public DateTime? _24aServiceEndDate { get; set; }
    //    public string _24bPlaceofService { get; set; }
    //    public string _24cEmg { get; set; }
    //    public string _24dCpthcpcs { get; set; }
    //    public string _24dModifier { get; set; }
    //    public string _24eDiagnosisPointer { get; set; }
    //    public decimal? _24fCharges { get; set; }
    //    public string _24gDaysOrUnits { get; set; }
    //    public string _24hEpsdt { get; set; }
    //    public string _24iQual { get; set; }
    //    public int? _24jRenderingProviderId { get; set; }

    //    public StagingClaimCms1500 Claim { get; set; }
    //}
     
    
}
