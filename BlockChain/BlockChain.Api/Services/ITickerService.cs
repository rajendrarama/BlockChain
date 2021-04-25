using BlockChain.Api.Models;
using System.Collections.Generic;

namespace BlockChain.Api.Services
{
    public interface ITickerService
    {
        Dictionary<string, Currency> GetTickerData();
    }
}
