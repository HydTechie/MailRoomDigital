using System;
using System.Collections.Generic;

namespace MailRoom.Model
{
    public partial class StagingClaimCms1500Detail
    {
        public int ClaimDetailId { get; set; }
        public int? ClaimId { get; set; }
        public DateTime? _24aServiceStartDate { get; set; }
        public DateTime? _24aServiceEndDate { get; set; }
        public string _24bPlaceofService { get; set; }
        public string _24cEmg { get; set; }
        public string _24dCpthcpcs { get; set; }
        public string _24dModifier { get; set; }
        public string _24eDiagnosisPointer { get; set; }
        public decimal? _24fCharges { get; set; }
        public string _24gDaysOrUnits { get; set; }
        public string _24hEpsdt { get; set; }
        public string _24iQual { get; set; }
        public int? _24jRenderingProviderId { get; set; }

        public StagingClaimCms1500 Claim { get; set; }
    }
}
