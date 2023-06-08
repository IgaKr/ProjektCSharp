using Laboratorium3.Models;
using Newtonsoft.Json;
using System.Net;

namespace Laboratorium3
{
    public abstract class NBPBaseWebClient
    {
        protected WebClient _webClient;
        protected const string _dateFormat = "yyyy-MM-dd";

        public NBPBaseWebClient(string address)
        {
            _webClient = new WebClient();
            _webClient.BaseAddress = address;
        }

        protected T Get<T>(string url) 
        {
            var response = _webClient.DownloadString(url);
            var result = JsonConvert.DeserializeObject<T>(response);
            return result!;
        }
    }
}
