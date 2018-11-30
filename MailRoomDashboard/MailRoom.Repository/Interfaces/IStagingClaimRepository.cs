using MailRoom.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailRoom.Repository.Interfaces
{
    public interface IStagingClaimRepository
    {
        Task<StagingClaimCms1500> GetStagingClaimAsync(string claimId);

        Task<IList<StagingClaimCms1500>> GetStagingCMSClaimsByReviewerAsync(string reviewerId, int reviewStatus);
        //Task<IList<StagingClaimCms1500>> GetStagingUB04ClaimsByReviewerAsync(string reviewerId, int reviewStatus);
        //Task<IList<StagingClaimCms1500>> GetStagingPK83ClaimsByReviewerAsync(string reviewerId, int reviewStatus);

        Task<Dashboard> GetDashboardAsync(string reviewerId);

        Task<DashboardWeek> GetDashboardByWeekAsync(string reviewerId);
   
        //Task<OperationStatus> CreateStagingClaimAsync();
    
        Task<OperationStatus> UpdatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500);
    }
}