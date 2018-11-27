using MailRoom.Model;
using System.Threading.Tasks;

namespace MailRoom.Repository.Interfaces
{
    public interface IStagingClaimRepository
    {
        Task<StagingClaimCms1500> GetStagingClaimAsync(string insureId);

        Task<Dashboard> GetDashboardAsync(string reviewerId);

        Task<DashboardWeek> GetDashboardByWeekAsync(string reviewerId);
        ////StagingclaimCms1500 GetStagingClaim(int id);
        //Task<Customer> GetCustomerAsync(string custId);
        //Task<OperationStatus> CreateCustomerAsync();

        Task<OperationStatus> CreateStagingClaimAsync();
    
        Task<OperationStatus> UpdatestagingClaimCms1500Async(StagingClaimCms1500 stagingClaimCms1500);
    }
}