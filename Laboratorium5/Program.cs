using Laboratorium3;
using Laboratorium3.Interfaces;
using Laboratorium5.DependencyInjection;
using Laboratorium5.Extensions;
using Laboratorium5.Processor;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDependencies();
        
        var provider = serviceCollection.BuildServiceProvider();

        var processor = provider.GetService<MainProcessor>();
        processor.Process();

        //using (var kernel = new StandardKernel(new CommonDependecies()))
        //{
        //    var processor = kernel.Get<MainProcessor>();
        //    processor.Process();
        //}
    }
}