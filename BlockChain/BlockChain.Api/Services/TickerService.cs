using BlockChain.Api.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace BlockChain.Api.Services
{
    public class TickerService : ITickerService
    {
        public ILogger<TickerService> _logger;

        public TickerService(ILogger<TickerService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Dictionary<string, Currency> GetTickerData()
        {
            _logger.LogInformation("Get Data from BlockChain");
            using (var client = new HttpClient())
            {
                var url = new Uri("https://blockchain.info/ticker");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Dictionary<string, Currency>>(response).OrderBy(x => x.Value.The15M).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}
