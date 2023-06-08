using Laboratorium3;
using Laboratorium3.Interfaces;
using Laboratorium3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

internal class Program
{
    static void Main(string[] args)
    {

        IGoldRateWebClient goldRateWebClient = new NBPGoldRateWebClient("");

        try
        {
            var rates = goldRateWebClient.GetLastGoldRates(5);

        }
        catch (Exception ex)
        {

        }
        //for (int i = 0; i > -20; i--)
        //{
        //    client.GetGoldRateInSpecificDate(DateTime.Now.AddDays(i));
        //}

        //var result = client.GetGoldRatesInSpecificPeriod(DateTime.Now.AddDays(-3), DateTime.Now);


        //var person = new Person
        //{
        //    Name = "Wojciech",
        //    LastName = "Nowak",
        //    Country = "Poland",
        //    Age = 26,
        //    IsMen = true
        //};

        //var settings = new JsonSerializerSettings
        //{
        //    Formatting = Formatting.Indented,
        //    NullValueHandling = NullValueHandling.Ignore,
        //   ContractResolver = new DefaultContractResolver
        //   {
        //       NamingStrategy = new CamelCaseNamingStrategy()
        //   }
        //};


        //using (var writer = new StreamWriter($"C:\\Users\\Wojtek\\Desktop\\KartotekiOsobowe\\" +
        //    $"{person.Name}.txt"))
        //{
        //    var personAsJson = JsonConvert.SerializeObject(person, settings);
        //    writer.WriteLine(personAsJson);
        //}



    }
}
