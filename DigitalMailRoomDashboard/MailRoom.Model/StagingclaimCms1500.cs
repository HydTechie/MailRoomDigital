using System;
using System.Collections.Generic;

namespace MailRoom.Model
{
    public partial class StagingClaimCms1500
    {
        //public StagingClaimCms1500()
        //{
        //    StagingClaimCms1500Detail = new List<StagingClaimCms1500Detail>();
        //}

        public string ClaimId { get; set; }
        public string IaPayerName { get; set; }
        public string IbPayerAddress1 { get; set; }
        public string IcPayerAddress2 { get; set; }
        public string IdPayerCityStateZipcode { get; set; }
        public string _1PayerType { get; set; }
        public string _1aInsuredIdNumber { get; set; }
        public string _2aLastName { get; set; }
        public string _2bSuffix { get; set; }
        public string _2cFirstName { get; set; }
        public string _2dMiddleName { get; set; }
        public int? _3aMm { get; set; }
        public int? _3bDd { get; set; }
        public int? _3cYyyy { get; set; }
        public string _3dGender { get; set; }
        public string _4aLastName { get; set; }
        public string _4bSuffix { get; set; }
        public string _4cFirstName { get; set; }
        public string _4dMiddleName { get; set; }
        public string _5aStreetAddress { get; set; }
        public string _5bCity { get; set; }
        public string _5cState { get; set; }
        public string _5dZipcode { get; set; }
        public int? _5eTelephoneAreacode { get; set; }
        public int? _5fTelephonePhoneNumber { get; set; }
        public string _6PatientRelationshipToInsured { get; set; }
        public string _7aStreetAddress { get; set; }
        public string _7bCity { get; set; }
        public string _7cState { get; set; }
        public string _7dZipCode { get; set; }
        public int? _7eTelephoneAreacode { get; set; }
        public int? _7fTelephonePhonenumber { get; set; }
        public string _8ReservedForNuccUse { get; set; }
        public string _9ALastName { get; set; }
        public string _9BSuffix { get; set; }
        public string _9CFirstName { get; set; }
        public string _9DMiddleName { get; set; }
        public string _9aOtherPoliciesNumber { get; set; }
        public string _9bReservedForNuccUse { get; set; }
        public string _9cReservedForNuccUse { get; set; }
        public string _9dInsuranceplanName { get; set; }
        public string _10aEmployment { get; set; }
        public string _10bAutoAccident { get; set; }
        public string _10bAAutoAccidentPlace { get; set; }
        public string _10cOtherAccident { get; set; }
        public string _10dClaimCodes { get; set; }
        public string _11InsuredsPolicyNumber { get; set; }
        public int? _11aAMm { get; set; }
        public int? _11aBDd { get; set; }
        public int? _11aCYyyy { get; set; }
        public string _11aDGender { get; set; }
        public string _11bAQualifier { get; set; }
        public string _11bBClaimId { get; set; }
        public string _11cInsurancePlanName { get; set; }
        public string _11dAnotherHealthBenefitPlan { get; set; }
        public string _12ASignatureUrl { get; set; }
        public int? _12BAMm { get; set; }
        public int? _12BBDd { get; set; }
        public int? _12BCYyyy { get; set; }
        public string _13InsuredsAuthorizedSignatureUrl { get; set; }
        public int? _14AMm { get; set; }
        public int? _14BDd { get; set; }
        public int? _14CYyyy { get; set; }
        public int? _14DQualifier { get; set; }
        public int? _15AMm { get; set; }
        public int? _15BDd { get; set; }
        public int? _15CYyyy { get; set; }
        public int? _15DQualifier { get; set; }
        public int? _16AMm { get; set; }
        public int? _16BDd { get; set; }
        public int? _16CYyyy { get; set; }
        public int? _16AAMm { get; set; }
        public int? _16ABDd { get; set; }
        public int? _16ACYyyy { get; set; }
        public string _17Qualifier { get; set; }
        public string _17AName { get; set; }
        public string _17aAQualifier { get; set; }
        public string _17aBIdNumber { get; set; }
        public string _17bIdNumber { get; set; }
        public int? _18AMm { get; set; }
        public int? _18BDd { get; set; }
        public int? _18CYyyy { get; set; }
        public int? _18AAMm { get; set; }
        public int? _18ABDd { get; set; }
        public int? _18ACYyyy { get; set; }
        public string _19AdditionalClaimInformation { get; set; }
        public string _20YesOrNo { get; set; }
        public int? _20AChargesDollars { get; set; }
        public int? _20BChargesCents { get; set; }
        public int? _21IcdIndicator { get; set; }
        public string _21aNatureOfIllnes { get; set; }
        public string _21bNatureOfIllnes { get; set; }
        public string _21cNatureOfIllnes { get; set; }
        public string _21dNatureOfIllnes { get; set; }
        public string _21eNatureOfIllnes { get; set; }
        public string _21fNatureOfIllnes { get; set; }
        public string _21gNatureOfIllnes { get; set; }
        public string _21hNatureOfIllnes { get; set; }
        public string _21iNatureOfIllnes { get; set; }
        public string _21jNatureOfIllnes { get; set; }
        public string _21kNatureOfIllnes { get; set; }
        public string _21lNatureOfIllnes { get; set; }
        public string _22AReSubmissionCodeQualifier { get; set; }
        public string _22BOriginalRefNo { get; set; }
        public string _23PriorAuthorizationNumber { get; set; }
        public string _25AType { get; set; }
        public string _25BIdNumber { get; set; }
        public int? _26PatientAccNumber { get; set; }
        public string _27AcceptAssignment { get; set; }
        public int? _28ADollars { get; set; }
        public int? _28BCents { get; set; }
        public int? _29ADollars { get; set; }
        public int? _29BCents { get; set; }
        public string _30ACode { get; set; }
        public string _30BQualifier { get; set; }
        public string _31ASignature { get; set; }
        public int? _31BAMm { get; set; }
        public int? _31BBDd { get; set; }
        public int? _31BCYyyy { get; set; }
        public string _32AProviderName { get; set; }
        public string _32BProviderAddress { get; set; }
        public string _32CCityStateZipcode { get; set; }
        public string _32aNationalProviderIdentifierNumber { get; set; }
        public string _32bPayerAssignedIdentifierOfBillingProvider { get; set; }
        public int? _33AAreaCode { get; set; }
        public int? _33BPhoneNumber { get; set; }
        public string _33CBillingProviderName { get; set; }
        public string _33DBillingProviderAddress { get; set; }
        public string _33EBillingproviderCityStateZipcode { get; set; }
        public string _33aNationalProviderIdentifierNumber { get; set; }
        public string _33bPayerAssignedIdentifierOfBillingProvider { get; set; }
        public string ReviewerId { get; set; }
        public int? ParserStatus { get; set; }
        public string ReviewStatus { get; set; }
        public int? ConfidenceLevel { get; set; }
        public string ParserErrorCsv { get; set; }
        public string SourceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public List<StagingClaimCms1500Detail> StagingClaimCms1500Detail { get; set; }
    }
}
