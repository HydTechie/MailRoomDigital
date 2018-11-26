using System.Collections.Generic;
using MailRoom.Model;
using System.Threading.Tasks;

namespace MailRoom.Repository.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> GetSecurityAsync(string symbol);
        Task<List<TickerQuote>> GetSecurityTickerQuotesAsync();
        Task<OperationStatus> UpdateSecuritiesAsync();
        Task<OperationStatus> InsertSecurityDataAsync();
    }
}