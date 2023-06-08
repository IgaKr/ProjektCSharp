namespace Laboratorium3.Models
{
    public class CurrencyDTO
    {
        public string Table { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;    
        public List<RateDTO> Rates { get; set; } = new List<RateDTO>();
    }
}
