using Microsoft.Extensions.DependencyInjection;
using ProjektFinalny.Extensions;
using ProjektFinalny.Processors;

internal class Program
{
    static void Main(string[] args)
    { 
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependencies();
        var processor = serviceCollection
            .BuildServiceProvider()
            .GetService<MainAppProcessor>();

        processor.Process();
    }
}