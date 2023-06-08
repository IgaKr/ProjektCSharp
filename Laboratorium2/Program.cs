using Laboratorium2.Enums;
using Laboratorium2.Interfejsy;
using Laboratorium2.Klasy;
using Laboratorium2.Klasy.Fabryki;
using Laboratorium2.Klasy.Formatery;
using Laboratorium2.Klasy.KlasyStatyczne;
using Laboratorium2.Klasy.Loggery;
using Laboratorium2.TypyGeneryczne;

internal class Program
{
    static void Main(string[] args)
    {
        PrzykladGeneryczneTypy();
    }

    private static void PrzykladGeneryczneTypy()
    {
        var kalkulator = new Kalkulator();

        //var wynik = kalkulator.Dodaj(1, 2);
        //var drugiWynik = kalkulator.Dodaj(2.0m, 2.4m);
        var test = kalkulator.Dodaj(kalkulator, kalkulator);
        //Console.WriteLine($"Wynik to: {wynik}");

        var wynikDecimal = kalkulator.Dodaj(2.0m, 3.0m);
        Console.WriteLine($"Wynik to: {wynikDecimal}");

    }

    private static void PrzykladInterfejsy()
    {
        var fabryka = new FabrykaLogow();
        IUserLogger userLogger = new FileLogger(fabryka);
        userLogger.Log("Testowa wartość1", RodzajLoga.Error);
        userLogger.Log("Testowa wartość1");
        userLogger.Log("Testowa wartość1");

        //userLogger.LogZStatycznaKlasa("Statyczna wartość", TypLogow.Warning);
        //userLogger.LogZStatycznaKlasa("Statyczna wartość", TypLogow.Error);
    }

    private static void PrzykladTemperatura()
    {
        Console.WriteLine("Podaj temperaturę");
        var temp = Console.ReadLine();
        
        KonwerterTemperatury konwerter = new CelsiuszNaKelwiny(int.Parse(temp!));

        konwerter.PrzeliczTemperature();

    }

    private static void PrzykladAuto()
    {
        var skoda = new Samochod("Skoda");
        skoda.IloscKol = 4;
        skoda.PrzekrecKluczyk();
        skoda.PrzekrecKluczyk();

        var wynik = KalkulatorIntow.DodajDwieLiczby(2, 5);
        Console.WriteLine(wynik);
        int test1 = 5;

        wynik = test1.DodajLiczbe(6);


        string losowaLiczba = "2.5";


        var decimalWynik = losowaLiczba.ParseDecimal();
        Console.WriteLine(decimalWynik);
        Console.ReadLine();
    }
}