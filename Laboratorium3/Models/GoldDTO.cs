using Newtonsoft.Json;

namespace Laboratorium3.Models
{
    public class GoldDTO
    {
        [JsonProperty("data")]
        public DateTime Date { get; set; }
        [JsonProperty("cena")]
        public decimal Price { get; set; }
    }
}
