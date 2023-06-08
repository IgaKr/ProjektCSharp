using Laboratorium2.Interfejsy;
using Laboratorium2.Klasy.Formatery;
using Laboratorium2.Klasy.Loggery;
using Laboratorium3;
using Laboratorium3.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ProjektFinalny.Interfaces;
using ProjektFinalny.Processors;

namespace ProjektFinalny.Extensions;

public static class DependencyExtension
{
    public static void AddDependencies(this ServiceCollection collection)
    {
        collection.AddSingleton<MainAppProcessor>();
        collection.AddTransient<IUserInputHandler, UserInputHandler>();
        collection.AddTransient<IUserLogger, ConsoleLogger>();
        collection.AddTransient<IGoldRateProcessor, GoldRateProcessor>();
        collection.AddTransient<ICurrencyProcessor, CurrencyProcessor>();
        collection.AddSingleton<IFormaterLogow, FormaterInformacji>();
        collection.AddSingleton<IGoldRateWebClient, NBPGoldRateWebClient>(_ => new NBPGoldRateWebClient("http://api.nbp.pl/api/"));
        collection.AddSingleton<ICurrencyWebClient, NBPCurrencyWebClient>(_ => new NBPCurrencyWebClient("http://api.nbp.pl/api/"));
    }
}
