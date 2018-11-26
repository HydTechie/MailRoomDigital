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

        public Dashboard()
        {
            ClaimsPK83 = new Dictionary<string, int>();
            ClaimsUB04 = new Dictionary<string, int>();
            ClaimsCMS100 = new Dictionary<string, int>();
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
