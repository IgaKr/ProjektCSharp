using Laboratorium3.Interfaces;
using Laboratorium3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium3
{
    internal class NBPCommonWebClient 
    {
        private readonly ICurrencyWebClient _currencyWebClient;
        private readonly IGoldRateWebClient _goldRateWebClient;

        public NBPCommonWebClient(ICurrencyWebClient currencyWebClient, IGoldRateWebClient goldRateWebClient)
        {
            _currencyWebClient = currencyWebClient;
            _goldRateWebClient = goldRateWebClient;
        }

        public CurrencyDTO GetCurrencyByCode(string code)
        {
            return _currencyWebClient.GetCurrencyByCode(code);
        }

        public GoldDTO GetGoldRateInSpecificDate(DateTime date)
        {
            return _goldRateWebClient.GetGoldRateInSpecificDate(date);
        }

        public IList<GoldDTO> GetGoldRatesInSpecificPeriod(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public GoldDTO GetLastGoldRate()
        {
            throw new NotImplementedException();
        }

        public GoldDTO[] GetLastGoldRates(int count)
        {
            throw new NotImplementedException();
        }

        public GoldDTO GetTodayGoldRate()
        {
            throw new NotImplementedException();
        }

        public bool IsGoldRatePublishedToday()
        {
            throw new NotImplementedException();
        }
    }
}
