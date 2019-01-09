using MailRoom.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailRoom.Repository.Interfaces
{
    public interface IStagingClaimRepository
    {
        Task<StagingClaimCms1500> GetStagingClaimAsync(string claimId);

        Task<IList<StagingClaimCms1500>> GetStagingCMSClaimsByReviewerAsync(string reviewerId, int parserStatus, string reviewStatus);
        //Task<IList<StagingClaimCms1500>> GetStagingUB04ClaimsByReviewerAsync(string reviewerId, int reviewStatus);
        //Task<IList<StagingClaimCms1500>> GetStagingPK83ClaimsByReviewerAsync(string reviewerId, int reviewStatus);

        Task<Dashboard> GetDashboardAsync(string reviewerId);

        Task<IDictionary<string, DayData>> GetDashboardByWeekAsync(string reviewerId);

        //Task<OperationStatus> CreateStagingClaimAsync();

        Task<OperationStatus> UpdatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500);

        Task<OperationStatus> ValidatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500);
    }
}