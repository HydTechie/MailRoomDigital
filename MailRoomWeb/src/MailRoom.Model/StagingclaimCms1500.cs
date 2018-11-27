using System;
using System.Collections.Generic;

namespace MailRoom.Model
{
    public partial class StagingClaimCms1500
    {
        public StagingClaimCms1500()
        {
            StagingclaimCms1500Detail = new HashSet<StagingClaimCms1500Detail>();
        }

        public int ClaimId { get; set; }
        public string IaPayerName { get; set; }
        public string IbPayerAddress1 { get; set; }
        public string IcPayerAddress2 { get; set; }
        public string IdPayerCity { get; set; }
        public string IdPayerState { get; set; }
        public string IdPayerZipcode { get; set; }
        public string _1PayerType { get; set; }
        public string _1aPatientInsuredId { get; set; }
        public string _2aPatientLastName { get; set; }
        public string _2bSuffix { get; set; }
        public string _2cPatientFirstName { get; set; }
        public string _2dPatientMiddleName { get; set; }
        public int? _3PatientBirthMm { get; set; }
        public int? _3PatientBirthDd { get; set; }
        public int? _3PatientBirthYyyy { get; set; }
        public string _3PatientGender { get; set; }
        public string _4InsuredLastName { get; set; }
        public string _4InsuredSuffix { get; set; }
        public string _4InsuredFirstName { get; set; }
        public string _4InsuredMiddleName { get; set; }
        public string _5PatientAddressStreet { get; set; }
        public string _5PatientAddressCity { get; set; }
        public string _5PatientAddressState { get; set; }
        public string _5PatientZipCode { get; set; }
        public string _5PatientAreaCode { get; set; }
        public string _5PatientTelePhone { get; set; }
        public string _6PatientRelationToInsured { get; set; }
        public string _7InsuredAddressStreet { get; set; }
        public string _7InsuredAddressCity { get; set; }
        public string _7InsuredAddressState { get; set; }
        public string _7InsuredZipCode { get; set; }
        public string _7InsuredAreaCode { get; set; }
        public string _7InsuredTelephone { get; set; }
        public string _8ReservedNucc { get; set; }
        public string _9OtherInsuredLastName { get; set; }
        public string _9OtherInsuredSuffix { get; set; }
        public string _9OtherInsuredFirstName { get; set; }
        public string _9OtherInsuredMiddleName { get; set; }
        public string _9aOtherPolicyGroup { get; set; }
        public string _9bOtherReservedNucc { get; set; }
        public string _9cOtherReservedNucc { get; set; }
        public string _9cOtherInsuranceName { get; set; }
        public string _10aPatientConditionEmployment { get; set; }
        public string _10bPatientConditionAuto { get; set; }
        public string _10bPatientConditionPlace { get; set; }
        public string _10cPatientConditionOther { get; set; }
        public string _10dClaimCodes { get; set; }
        public string _11InsuredPolicyGroup { get; set; }
        public int? _11aInsuredBirthMm { get; set; }
        public int? _11aInsuredBirthDd { get; set; }
        public int? _11aInsuredBirthYyyy { get; set; }
        public string _11aInsuredGender { get; set; }
        public string _11bOtherClaimIdQual { get; set; }
        public string _11bOtherClaimId { get; set; }
        public string _11cInsurancePlanName { get; set; }
        public string _11dIsAnotherHealthPlan { get; set; }
        public string _12PatientAuthorizedSignatureImageUrl { get; set; }
        public int? _12PatientAuthorizedSignatureMm { get; set; }
        public int? _12PatientAuthorizedSignatureDd { get; set; }
        public int? _12PatientAuthorizedSignatureYyyy { get; set; }
        public string _13InsuredAuthorizedSignatureImageUrl { get; set; }
        public int? _14CurrentIllnessMm { get; set; }
        public int? _14CurrentIllnessDd { get; set; }
        public int? _14CurrentIllnessYyyy { get; set; }
        public string _14DateOfCurrentIllnessQual { get; set; }
        public int? _15OtherDateMm { get; set; }
        public int? _15OtherDateDd { get; set; }
        public int? _15OtherDateYyyy { get; set; }
        public string _15OtherQual { get; set; }
        public int? _16PatientUnableToWorkStartMm { get; set; }
        public int? _16PatientUnableToWorkStartDd { get; set; }
        public int? _16PatientUnableToWorkStartYyyy { get; set; }
        public int? _16PatientUnableToWorkEndMm { get; set; }
        public int? _16PatientUnableToWorkEndDd { get; set; }
        public int? _16PatientUnableToWorkEndYyyy { get; set; }
        public string _17ReferringProviderQual { get; set; }
        public string _17ReferringProviderName { get; set; }
        public string _17aNonNpireferringProviderQual { get; set; }
        public string _17aNonNpireferringProvider { get; set; }
        public string _17aNpireferringProviderQual { get; set; }
        public string _17aNpireferringProvider { get; set; }
        public int? _18HospitalizationStartMm { get; set; }
        public int? _18HospitalizationStartDd { get; set; }
        public int? _18HospitalizationStartYyyy { get; set; }
        public int? _18HospitalizationEndMm { get; set; }
        public int? _18HospitalizationEndDd { get; set; }
        public int? _18HospitalizationEndYyyy { get; set; }
        public string _19AdditionalClaimInfo { get; set; }
        public string _20OutsideLab { get; set; }
        public string _20ChargesDollars { get; set; }
        public string _20ChargesCents { get; set; }
        public string _21NatureOfIllnessA { get; set; }
        public string _21NatureOfIllnessB { get; set; }
        public string _21NatureOfIllnessC { get; set; }
        public string _21NatureOfIllnessD { get; set; }
        public string _21NatureOfIllnessE { get; set; }
        public string _21NatureOfIllnessF { get; set; }
        public string _21NatureOfIllnessG { get; set; }
        public string _21NatureOfIllnessH { get; set; }
        public string _21NatureOfIllnessI { get; set; }
        public string _21NatureOfIllnessJ { get; set; }
        public string _21NatureOfIllnessK { get; set; }
        public string _21NatureOfIllnessL { get; set; }
        public string _21IcdindQual { get; set; }
        public string _21IcdindValue { get; set; }
        public string _22ResubmissionCodeQual { get; set; }
        public string _22OriginalRefNo { get; set; }
        public string _23PriorAuthorizationNumber { get; set; }
        public string _25FederalTaxId { get; set; }
        public string _25FederalTaxType { get; set; }
        public int? _26PatientAccountNumber { get; set; }
        public string _27AcceptAssignment { get; set; }
        public decimal? _28TotalCharges { get; set; }
        public decimal? _29AmountPaid { get; set; }
        public string _30NuccuseQualifier { get; set; }
        public string _30NuccuseCode { get; set; }
        public string _31PhysicianSignatureImageUrl { get; set; }
        public int? _31PhysicianSignatureMm { get; set; }
        public int? _31PhysicianSignatureDd { get; set; }
        public int? _31PhysicianSignatureYyyy { get; set; }
        public string _32ServiceFacilityProviderName { get; set; }
        public string _32ServiceFacilityProviderAddress { get; set; }
        public string _32ServiceFacilityCityStateZipCode { get; set; }
        public string _32aServiceFacilityProviderId { get; set; }
        public string _32bServiceFacilityBillingProviderId { get; set; }
        public string _33BillingProviderAreaCode { get; set; }
        public string _33BillingProviderPhone { get; set; }
        public string _33BillingProviderName { get; set; }
        public string _33BillingProviderAddress { get; set; }
        public string _33BillingProviderCityStateZipCode { get; set; }
        public string _33aBillingProviderNpi { get; set; }
        public string _33bBillingProviderIdentifier { get; set; }
        public string ReviewerId { get; set; }
        public int? ReviewStatus { get; set; }
        public int? ConfidenceLevel { get; set; }
        public string ParserErrorCsv { get; set; }
        public string SourceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<StagingClaimCms1500Detail> StagingclaimCms1500Detail { get; set; }
    }
}
