using Newtonsoft.Json;

namespace Laboratorium3.Models
{
    public class RateDTO
    {
        [JsonProperty("no")]
        public string Number { get; set; } = string.Empty;
        [JsonProperty("effectiveDate")]
        public DateTime Date { get; set; }
        [JsonProperty("mid")]
        public decimal Price { get; set; }
    }
}
