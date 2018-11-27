using System.Collections.Generic;
using MailRoom.Model;
using System.Threading.Tasks;

namespace MailRoom.Repository.Interfaces
{
    public interface IMarketsAndNewsRepository
    {
        Task<MarketQuotes> GetMarketsAsync();
        Task<List<TickerQuote>> GetMarketTickerQuotesAsync();
        Task<List<string>> GetMarketNewsAsync();
        Task<OperationStatus> InsertMarketDataAsync();
    }
}