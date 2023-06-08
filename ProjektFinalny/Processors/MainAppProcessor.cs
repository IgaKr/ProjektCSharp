using ProjektFinalny.Interfaces;

namespace ProjektFinalny.Processors;

public class MainAppProcessor
{
    private readonly IUserInputHandler _userInputHandler = default!;
    private readonly IGoldRateProcessor _goldRateProcessor = default!;
    private readonly ICurrencyProcessor _currencyProcessor = default!;

    public MainAppProcessor(IUserInputHandler userInputHandler, IGoldRateProcessor goldRateProcessor,
        ICurrencyProcessor currencyProcessor)
    {
        _userInputHandler = userInputHandler;
        _goldRateProcessor = goldRateProcessor;
        _currencyProcessor = currencyProcessor;
    }

    public void Process()
    {
        var userInput = _userInputHandler.GetUserInput(Messages.WhatToDo);
        switch (userInput)
        {
            case "1":
                _currencyProcessor.Process();
                break;
            case "2":
                _goldRateProcessor.Process();
                break;
            default:
                break;
        }

        Console.ReadLine();
    }

}
