using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailRoom.Model
{
    public partial class Cms15001
    {
        public Cms15001()
        {
            Cms15002 = new HashSet<Cms15002>();
        }

        public string ClaimId { get; set; }
        [Required]
        public string IaPayerName { get; set; }
        [Required]
        public string IbPayerAddress1 { get; set; }
        public string IcPayerAddress2 { get; set; }
        [Required]
        public string IdPayerCityStateZipcode { get; set; }

        [Required]
        public string _1PayerType { get; set; }
        [Required]
        public string _1aInsuredIdNumber { get; set; }
        public string _2aLastName { get; set; }
        public string _2bSuffix { get; set; }
        public string _2cFirstName { get; set; }
        public string _2dMiddleName { get; set; }
        [Required]
        public int? _3aMm { get; set; }
        [Required]
        public int? _3bDd { get; set; }
        [Required]
        public int? _3cYyyy { get; set; }

        public string _3dGender { get; set; }
        [Required]
        public string _4aLastName { get; set; }
        public string _4bSuffix { get; set; }
        [Required]
        public string _4cFirstName { get; set; }

        public string _4dMiddleName { get; set; }
        public string _5aStreetAddress { get; set; }
        public string _5bCity { get; set; }
        public string _5cState { get; set; }
        public string _5dZipcode { get; set; }
        public int? _5eTelephoneAreacode { get; set; }
        public int? _5fTelephonePhoneNumber { get; set; }

        [Required]
        public string _6PatientRelationshipToInsured { get; set; }
        [Required]
        public string _7aStreetAddress { get; set; }
        [Required]
        public string _7bCity { get; set; }
        [Required]
        public string _7cState { get; set; }
        [Required]
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
        [Required]
        public string _10aEmployment { get; set; }
        [Required]
        public string _10bAutoAccident { get; set; }

        public string _10bAAutoAccidentPlace { get; set; }
        [Required]
        public string _10cOtherAccident { get; set; }
        public string _10dClaimCodes { get; set; }
        public string _11InsuredsPolicyNumber { get; set; }
        public int? _11aAMm { get; set; }
        public int? _11aBDd { get; set; }

        public int? _11aCYyyy { get; set; }

        public string _11aDGender { get; set; }
        public string _11bAQualifier { get; set; }
        public string _11bBClaimId { get; set; }
        [Required]
        public string _11cInsurancePlanName { get; set; }
        [Required]
        public string _11dAnotherHealthBenefitPlan { get; set; }
        [Required]
        public string _12ASignatureUrl { get; set; }
        public int? _12BAMm { get; set; }
        public int? _12BBDd { get; set; }
        public int? _12BCYyyy { get; set; }
        [Required]
        public string _13InsuredsAuthorizedSignatureUrl { get; set; }
        [Required]
        public int? _14AMm { get; set; }
        [Required]
        public int? _14BDd { get; set; }
        [Required]
        public int? _14CYyyy { get; set; }
        [Required]
        public int? _14DQualifier { get; set; }

        [Required]
        public int? _15AMm { get; set; }
        [Required]
        public int? _15BDd { get; set; }
        [Required]
        public int? _15CYyyy { get; set; }
        [Required]
        public int? _15DQualifier { get; set; }
        public int? _16AMm { get; set; }
        public int? _16BDd { get; set; }
        public int? _16CYyyy { get; set; }
        public int? _16AAMm { get; set; }
        public int? _16ABDd { get; set; }
        public int? _16ACYyyy { get; set; }
        [Required]
        public string _17Qualifier { get; set; }
        [Required]
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
        [Required]
        public string _19AdditionalClaimInformation { get; set; }
        public string _20YesOrNo { get; set; }
        public int? _20AChargesDollars { get; set; }
        public int? _20BChargesCents { get; set; }

        [Required]
        public int? _21IcdIndicator { get; set; }
        [Display] // misusing for some other purpose...to validate A-L fields at a time
        public string _21aNatureOfIllnes { get; set; }
        [Display]
        public string _21bNatureOfIllnes { get; set; }
        [Display]
        public string _21cNatureOfIllnes { get; set; }
        [Display]
        public string _21dNatureOfIllnes { get; set; }
        [Display]
        public string _21eNatureOfIllnes { get; set; }
        [Display]
        public string _21fNatureOfIllnes { get; set; }
        [Display]
        public string _21gNatureOfIllnes { get; set; }
        [Display]
        public string _21hNatureOfIllnes { get; set; }
        [Display]
        public string _21iNatureOfIllnes { get; set; }
        [Display]
        public string _21jNatureOfIllnes { get; set; }
        [Display]
        public string _21kNatureOfIllnes { get; set; }
        [Display]
        public string _21lNatureOfIllnes { get; set; }

        public string _22AReSubmissionCodeQualifier { get; set; }
        public string _22BOriginalRefNo { get; set; }
        [Required]
        public string _23PriorAuthorizationNumber { get; set; }
        [Required]
        public string _25AType { get; set; }
        [Required]
        public string _25BIdNumber { get; set; }
        [Required]
        public int? _26PatientAccNumber { get; set; }
        [Required]
        public string _27AcceptAssignment { get; set; }
        [Required]
        public int? _28ADollars { get; set; }
        [Required]
        public int? _28BCents { get; set; }

        public int? _29ADollars { get; set; }
        public int? _29BCents { get; set; }
        public string _30ACode { get; set; }
        public string _30BQualifier { get; set; }

        [Required]
        public string _31ASignature { get; set; }
        public int? _31BAMm { get; set; }
        public int? _31BBDd { get; set; }
        public int? _31BCYyyy { get; set; }
        [Required]
        public string _32AProviderName { get; set; }
        [Required]
        public string _32BProviderAddress { get; set; }
        [Required]
        public string _32CCityStateZipcode { get; set; }
        [Required]
        public string _32aNationalProviderIdentifierNumber { get; set; }
        [Required]
        public string _32bPayerAssignedIdentifierOfBillingProvider { get; set; }

        public int? _33AAreaCode { get; set; }
        public int? _33BPhoneNumber { get; set; }
        [Required]
        public string _33CBillingProviderName { get; set; }
        [Required]
        public string _33DBillingProviderAddress { get; set; }
        [Required]
        public string _33EBillingproviderCityStateZipcode { get; set; }
        [Required]
        public string _33aNationalProviderIdentifierNumber { get; set; }
        [Required]
        public string _33bPayerAssignedIdentifierOfBillingProvider { get; set; }
        public int? Status { get; set; }
        public Cms15001Conf Cms15001Conf { get; set; }
        public ICollection<Cms15002> Cms15002 { get; set; }
    }
}
