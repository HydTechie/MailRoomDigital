using System;
using System.Collections.Generic;

namespace MailRoom.Model
{
    public partial class StagingClaimCms1500Detail
    {
        public int ClaimDetailId { get; set; }
        public int? ClaimId { get; set; }
        public int? _24aServiceStartMm { get; set; }
        public int? _24aServiceStartDd { get; set; }
        public int? _24aServiceStartYyyy { get; set; }
        public int? _24aServiceEndMm { get; set; }
        public int? _24aServiceEndDd { get; set; }
        public int? _24aServiceEndYyyy { get; set; }
        public int? _24bPlaceofService { get; set; }
        public string _24cEmg { get; set; }
        public int? _24dCpthcpcs { get; set; }
        public int? _24dModifier { get; set; }
        public string _24eDiagnosisPointer { get; set; }
        public int? _24fChargesDollar { get; set; }
        public int? _24fChargesCents { get; set; }
        public string _24gDaysOrUnits { get; set; }
        public string _24hEpsdtcode { get; set; }
        public string _24hEpsdtyn { get; set; }
        public string _24iQual { get; set; }
        public int? _24jRenderingProviderId { get; set; }
        public int? _24jRenderingProviderNpiid { get; set; }

        public StagingClaimCms1500 Claim { get; set; }
    }
}
