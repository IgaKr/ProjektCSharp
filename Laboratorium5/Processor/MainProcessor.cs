using Laboratorium3;
using Laboratorium3.Interfaces;

namespace Laboratorium5.Processor;

public class MainProcessor
{
    private readonly IGoldRateWebClient _goldRateClient = default!;

    public MainProcessor(IGoldRateWebClient goldRateClient)
    {
        _goldRateClient = goldRateClient;
    }
    public void Process()
    {
        var kurs = _goldRateClient.GetLastGoldRate();
    }
}
