using Laboratorium3.Interfaces;
using Laboratorium3;
using Laboratorium5.Processor;
using Microsoft.Extensions.DependencyInjection;

namespace Laboratorium5.Extensions;

public static class DependencyInjectionExtensions
{
    public static void AddDependencies(this ServiceCollection services)
    {
        services.AddSingleton<MainProcessor>();
        services.AddTransient<IGoldRateWebClient, NBPGoldRateWebClient>
            (_ => new NBPGoldRateWebClient("http://api.nbp.pl/api/"));
    }
}
