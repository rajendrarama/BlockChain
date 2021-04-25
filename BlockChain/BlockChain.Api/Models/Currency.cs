using Newtonsoft.Json;

namespace BlockChain.Api.Models
{
    public class Currency
    {
        [JsonProperty("15m")]
        public decimal The15M { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("buy")]
        public decimal Buy { get; set; }

        [JsonProperty("sell")]
        public decimal Sell { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
