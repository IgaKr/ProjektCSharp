using Laboratorium3.Interfaces;
using Laboratorium3.Models;
using Newtonsoft.Json;
using System.Net;

namespace Laboratorium3
{
    public class NBPCurrencyWebClient : NBPBaseWebClient ,ICurrencyWebClient
    {
        public NBPCurrencyWebClient(string address) : base(address)
        {
        }

        public List<string> GetAllCurrencies()
        {
            var result = new List<string>();
            var response = _webClient.DownloadString($"exchangerates/tables/a");

            var wynik = JsonConvert.DeserializeObject<CurrencyListDTO[]>(response)!.First();
            result = wynik.Rates.Select(_ => _.Code.ToUpper()).ToList();

            return result;
        }

        public CurrencyDTO GetCurrencyByCode(string code)
        {
            var wynik = new CurrencyDTO();

            var response = _webClient.DownloadString($"exchangerates/rates/a/{code}");
            wynik = JsonConvert.DeserializeObject<CurrencyDTO>(response)!;
            return wynik;
        }

        public CurrencyDTO GetLastCurrencyRates(string code, int count)
        {
            var result = new CurrencyDTO();

            var response = _webClient.DownloadString($"exchangerates/rates/a/{code}/last/{count}");
            result = JsonConvert.DeserializeObject<CurrencyDTO>(response)!;

            return result;
        }

        public CurrencyDTO? GetTodayCurrencyRate(string code)
        {
            var result = new CurrencyDTO();

            try
            {
                var response = _webClient.DownloadString($"exchangerates/rates/a/{code}/today");
                result = JsonConvert.DeserializeObject<CurrencyDTO>(response);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var exResponse = ex.Response as HttpWebResponse;
                    if (exResponse!.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                else
                    Console.WriteLine($"Nieznany błąd :{ex.Message}");
            }

            return result;
        }
    }
}
