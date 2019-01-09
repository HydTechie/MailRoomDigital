using System;
using System.Collections.Generic;

namespace MailRoom.Model
{
    public partial class Cms15002Conf
    {
        public int Id { get; set; }
        public string ClaimId { get; set; }
        public float? _24aAMm { get; set; }
        public float? _24aBDd { get; set; }
        public float? _24aCYyyy { get; set; }
        public float? _24aDMm { get; set; }
        public float? _24aEDd { get; set; }
        public float? _24aFYyyy { get; set; }
        public float? _24bPlaceOfService { get; set; }
        public float? _24cEmg { get; set; }
        public float? _24dACptHcpcs { get; set; }
        public float? _24dBModifier { get; set; }
        public float? _24eDiagnosticPointer { get; set; }
        public float? _24fCharges { get; set; }
        public float? _24fFCharges { get; set; }
        public float? _24gDaysOrUnits { get; set; }
        public float? _24hAEpsdtCode { get; set; }
        public float? _24hBYesOrNo { get; set; }
        public float? _24iQual { get; set; }
        public float? _24jARenderingProviderId { get; set; }
        public float? _24jBRenderingProviderId { get; set; }
        public float? TotalConfidence { get; set; }

        public Cms15002 IdNavigation { get; set; }
    }
}
