using Laboratorium3;
using Laboratorium3.Interfaces;
using Laboratorium5.Processor;
using Ninject.Modules;

namespace Laboratorium5.DependencyInjection;

public class CommonDependecies : NinjectModule
{
    public override void Load()
    {
        Bind<MainProcessor>().ToSelf().InSingletonScope();
        Bind<IGoldRateWebClient>().ToConstructor(_ => new NBPGoldRateWebClient("http://api.nbp.pl/api/"));
    }
}
