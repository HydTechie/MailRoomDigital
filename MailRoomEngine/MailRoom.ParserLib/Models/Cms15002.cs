﻿using System;
using System.Collections.Generic;

namespace MailRoom.ParserLib
{
    public partial class Cms15002
    {
        public int Id { get; set; }
        public string _24XClaimId { get; set; }
        public int? _24aAMm { get; set; }
        public int? _24aBDd { get; set; }
        public int? _24aCYyyy { get; set; }
        public int? _24aDMm { get; set; }
        public int? _24aEDd { get; set; }
        public int? _24aFYyyy { get; set; }
        public int? _24bPlaceOfService { get; set; }
        public string _24cEmg { get; set; }
        public int? _24dACptHcpcs { get; set; }
        public int? _24dBModifier { get; set; }
        public string _24eDiagnosticPointer { get; set; }
        public int? _24fCharges { get; set; }
        public int? _24fFCharges { get; set; }
        public float? _24gDaysOrUnits { get; set; }
        public string _24hAEpsdtCode { get; set; }
        public string _24hBYesOrNo { get; set; }
        public string _24iQual { get; set; }
        public string _24jARenderingProviderId { get; set; }
        public string _24jBRenderingProviderId { get; set; }

        public Cms15001 _24XClaim { get; set; }
    }
}
