using System;
using System.Collections.Generic;

namespace MailRoom.ParserLib
{
    public partial class Aspnetuserclaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public Aspnetusers User { get; set; }
    }
}
