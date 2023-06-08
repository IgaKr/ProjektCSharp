using Laboratorium3.Models;

namespace Laboratorium3.Interfaces
{
    public interface ICurrencyWebClient
    {
        CurrencyDTO GetCurrencyByCode(string code);
        CurrencyDTO GetLastCurrencyRates(string code, int count);
        List<string> GetAllCurrencies();
        CurrencyDTO? GetTodayCurrencyRate(string code);
    }
}
