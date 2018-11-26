 
using MailRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailRoom.Repository.Helpers
{
    public interface IStagingEngine
    {
         Task<List<StagingClaim>> GetStaginClaimsAsync(params string[] stagingClaims);
         
    }
}
