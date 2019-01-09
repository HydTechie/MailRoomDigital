using System;
using System.Collections.Generic;
using System.Text;

namespace MailRoom.Model
{

    public class Dashboard
    {
        // "TODO", "ROLLBACK", "COMPLETED"
        public IDictionary<string, int> ClaimsPK83;
        public IDictionary<string, int> ClaimsUB04;
        public IDictionary<string, int> ClaimsCMS100;
        public IDictionary<string, int> OverallProgress;

        public IDictionary<string, DayData> WeekData = new Dictionary<string, DayData>();

        //public int TodoTotalCountByAllClaimTypes { get; set; }
        //public int RollbackTotalCountByAllClaimTypes { get; set; }
        //public int CompletedTotalCountByAllClaimTypes { get; set; }

        //public int TotalClaimsCountByCMS1500PerDay { get; set; }
        //public int TotalClaimsCountByUB04PerDay { get; set; }
        //public int TotalClaimsCountByPK83PerDay { get; set; }

        public Dashboard()
        {
            OverallProgress = new Dictionary<string, int>();
            ClaimsPK83 = new Dictionary<string, int>();
            ClaimsUB04 = new Dictionary<string, int>();
            ClaimsCMS100 = new Dictionary<string, int>();

            OverallProgress.Add("VERIFICATIONREQUIRED_ASSIGNED", 0);
            OverallProgress.Add("ROLLBACK_ASSIGNED", 0);
            OverallProgress.Add("OPTIONALVERIFICATION_ASSIGNED", 0);
            OverallProgress.Add("VERIFICATIONREQUIRED_REVIEWED", 0);
            OverallProgress.Add("ROLLBACK_REVIEWED", 0);
            OverallProgress.Add("OPTIONALVERIFICATION_REVIEWED", 0);

            ClaimsUB04.Add("VERIFICATIONREQUIRED_ASSIGNED", 0);
            ClaimsUB04.Add("ROLLBACK_ASSIGNED", 0);
            ClaimsUB04.Add("OPTIONALVERIFICATION_ASSIGNED", 0);
            ClaimsUB04.Add("VERIFICATIONREQUIRED_REVIEWED", 0);
            ClaimsUB04.Add("ROLLBACK_REVIEWED", 0);
            ClaimsUB04.Add("OPTIONALVERIFICATION_REVIEWED", 0);
            ClaimsUB04.Add("VERIFICATIONREQUIRED_PENDING", 0);
            ClaimsUB04.Add("ROLLBACK_PENDING", 0);
            ClaimsUB04.Add("OPTIONALVERIFICATION_PENDING", 0);

            // Default keys are ready
            ClaimsCMS100.Add("VERIFICATIONREQUIRED_ASSIGNED", 0);
            ClaimsCMS100.Add("ROLLBACK_ASSIGNED", 0);
            ClaimsCMS100.Add("OPTIONALVERIFICATION_ASSIGNED", 0);
            ClaimsCMS100.Add("VERIFICATIONREQUIRED_REVIEWED", 0);
            ClaimsCMS100.Add("ROLLBACK_REVIEWED", 0);
            ClaimsCMS100.Add("OPTIONALVERIFICATION_REVIEWED", 0);
            ClaimsCMS100.Add("VERIFICATIONREQUIRED_PENDING", 0);
            ClaimsCMS100.Add("ROLLBACK_PENDING", 0);
            ClaimsCMS100.Add("OPTIONALVERIFICATION_PENDING", 0);

            ClaimsPK83.Add("VERIFICATIONREQUIRED_ASSIGNED", 0);
            ClaimsPK83.Add("ROLLBACK_ASSIGNED", 0);
            ClaimsPK83.Add("OPTIONALVERIFICATION_ASSIGNED", 0);
            ClaimsPK83.Add("VERIFICATIONREQUIRED_REVIEWED", 0);
            ClaimsPK83.Add("ROLLBACK_REVIEWED", 0);
            ClaimsPK83.Add("OPTIONALVERIFICATION_REVIEWED", 0);
            ClaimsPK83.Add("VERIFICATIONREQUIRED_PENDING", 0);
            ClaimsPK83.Add("ROLLBACK_PENDING", 0);
            ClaimsPK83.Add("OPTIONALVERIFICATION_PENDING", 0);
        }

    }

    //public class DashboardWeek
    //{
    //    /*
    //     { Date1: {Allocated:n1, attended:n2},

    //   Date2: {Allocated:n3, attended:n4},
    //     }
    //     */




    //}

    public class DayData
    {
        public int Allocated { get; set; }
        public int Attended { get; set; }
    }
}
