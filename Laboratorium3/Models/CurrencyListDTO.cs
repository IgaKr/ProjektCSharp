namespace Laboratorium3.Models;

public class CurrencyListDTO
{
    public string Table { get; set; } = string.Empty;
    public string No { get; set; } = string.Empty;
    public DateTime EffectiveDate { get; set; }
    public List<ListRateDTO> Rates { get; set; } = new();
}
