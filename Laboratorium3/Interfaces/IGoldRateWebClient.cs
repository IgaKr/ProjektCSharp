using Laboratorium3.Models;

namespace Laboratorium3.Interfaces
{
    public interface IGoldRateWebClient
    {
        GoldDTO GetLastGoldRate();
        GoldDTO[] GetLastGoldRates(int count);
        GoldDTO GetGoldRateInSpecificDate(DateTime date);
        bool IsGoldRatePublishedToday();
        IList<GoldDTO> GetGoldRatesInSpecificPeriod(DateTime startDate, DateTime endDate);
        GoldDTO? GetTodayGoldRate();
    }
}
