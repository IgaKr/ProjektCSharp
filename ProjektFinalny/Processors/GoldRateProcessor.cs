using System.Globalization;
using Laboratorium2.Interfejsy;
using Laboratorium3.Interfaces;
using Laboratorium3.Models;
using ProjektFinalny.Constants;
using ProjektFinalny.Extensions;
using ProjektFinalny.Interfaces;

namespace ProjektFinalny.Processors;

internal class GoldRateProcessor : IGoldRateProcessor
{
    private readonly IUserInputHandler _userInputHandler = default!;
    private readonly IGoldRateWebClient _goldRateWebClient = default!;
    private readonly IUserLogger _userLogger = default!;

    public GoldRateProcessor(IUserInputHandler userInputHandler, IGoldRateWebClient goldRateWebClient,
        IUserLogger userLogger)
    {
        _userInputHandler = userInputHandler;
        _goldRateWebClient = goldRateWebClient;
        _userLogger = userLogger;
    }

    public void Process()
    {
        var input = _userInputHandler.GetUserInput(Messages.GoldOptions);
        switch (input)
        {
            case "1":
                ProcessLastGoldRate();
                break;
            case "2":
                ProcessLastGoldRates();
                break;
            case "3":
                GetTodayGoldRate();
                break;
            case "4":
                GetTopRateFromLast30Days();
                break;
            case "5":
                GetRateFromSpecificDate();
                break;
            case "6":
                GetAveragePrice();
                break;
            default:
                break;
        }
    }

    private void ProcessLastGoldRate()
    {
        var lastGoldRate = _goldRateWebClient.GetLastGoldRate();

        var formattedMessage = string.Format(Messages.LastGoldRateResult,
            lastGoldRate.Price, lastGoldRate.Date.ToString(ConstantValues.DateFormat));
        _userLogger.Log(formattedMessage);
    }

    private void ProcessLastGoldRates()
    {
        var count = _userInputHandler.GetUserInput(Messages.GoldRatesCount);

        var countInt = count.ToInt();
        var rates = _goldRateWebClient.GetLastGoldRates(countInt);
        PrintListDetails(rates);
    }

    private void GetTodayGoldRate()
    {
         var goldRate = _goldRateWebClient.GetTodayGoldRate();

        if (goldRate == null)
            _userLogger.Log(Messages.NoRatesToday);
        else
            _userLogger.Log(string.Format(Messages.TodayGoldRate, goldRate.Price));
    }

    private void GetTopRateFromLast30Days()
    {
        var rates = _goldRateWebClient.GetLastGoldRates(30);

        rates = rates.OrderByDescending(_ => _.Price).ToArray();
        var topRate = rates.First();

        var formattedMessage = string.Format(Messages.TopGoldRate, topRate.Price, topRate.Date);
        _userLogger.Log(formattedMessage);
    }

    private void GetRateFromSpecificDate()
    {
        var dateString = _userInputHandler.GetUserInput(Messages.SpecificDate);
        var date = DateTime.Parse(dateString);
        var rate = _goldRateWebClient.GetGoldRateInSpecificDate(date);
        var formattedMessage = string.Format("Cena złota w dniu {0} wynosiła {1}", rate.Date, rate.Price);
        _userLogger.Log(formattedMessage);
    }
    private void PrintListDetails(GoldDTO[] rates)
    {
        _userLogger.Log(Messages.LastGoldRates);
        foreach (GoldDTO rate in rates)
        {
            _userLogger.Log($"data: {rate.Date.ToString(ConstantValues.DateFormat)}" +
                $" cena: {rate.Price}");
        }
    }
    private void GetAveragePrice()
    {
        var countString = _userInputHandler.GetUserInput("Z ilu notowań obliczyć średnią cenę?");
        var count = int.Parse(countString);
        var goldRates = _goldRateWebClient.GetLastGoldRates(count);
        var averagePrice = goldRates.Average(_ => _.Price);
        _userLogger.Log($"Średnia cena z ostatnich {count} dni to {averagePrice}");
    }
}
