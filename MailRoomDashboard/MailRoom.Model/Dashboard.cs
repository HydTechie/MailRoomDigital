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

        public int TodoTotalCount { get; set; }
        public int RollbackTotalCount { get; set; }
        public int CompletedTotalCount { get; set; }
        public Dashboard()
        {
            ClaimsPK83 = new Dictionary<string, int>();
            ClaimsUB04 = new Dictionary<string, int>();
            ClaimsCMS100 = new Dictionary<string, int>();

            ClaimsCMS100.Add("TODO", 0);
            ClaimsCMS100.Add("COMPLETED", 0);
            ClaimsCMS100.Add("ROLLBACK", 0);

            // Default keys are ready
            ClaimsPK83.Add("TODO", 0);
             ClaimsPK83.Add("COMPLETED", 0);
             ClaimsPK83.Add("ROLLBACK", 0);

             ClaimsUB04.Add("TODO", 0);
             ClaimsUB04.Add("COMPLETED", 0);
             ClaimsUB04.Add("ROLLBACK", 0);
        }

    }

    public class DashboardWeek
    {
        // x -axis contains dates of wek 
        //List<string>() { "Red", "Green", "Yellow", "Grey", "Blue" };
        public List<string> DateOnXaxis = new List<string>();
        // y-axis contains number of claims...
        public List<double> ClaimCountOnYaxis = new List<double>();

    }
}
