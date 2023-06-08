using ProstyKalkulator;
using System.Globalization;

internal class Program
{
    static void Main(string[] args)
    {

        var test = new Test();
        if (args.Length == 0)
        {
            Console.WriteLine("Brak argumentu podaj 'P' lub 'Z'");
        }
        if (args[0] == "P")
            WykonajPodstawoweOperacje();
        else if (args[0] == "Z")
        {
            WykonajZaawansowaneOperacje();
        }
        else
        {
            Console.WriteLine("Błędny parametr");
        }


        Console.ReadLine();
    }

    static void WykonajZaawansowaneOperacje()
    {
        Console.WriteLine("Podaj pierwszą liczbę całkowitą");
        decimal pierwszaLiczba, drugaLiczba;
        pierwszaLiczba = PobierzLiczbeOdUzytkownika();

        Console.WriteLine("Podaj drugą liczbę całkowitą");
        drugaLiczba = PobierzLiczbeOdUzytkownika();

        Console.WriteLine("Podaj operację");
        var operacja = Console.ReadLine();
        if (SprawdzCzyZaawansowanaOperacjaJestPrawidlowa(operacja!))
        {
            Console.WriteLine("Wszystko jest ok");
            var wynik = ObliczZaawansowanyWynik(pierwszaLiczba, drugaLiczba, operacja!);
            Console.WriteLine($"Wynik operacji {pierwszaLiczba} {operacja} {drugaLiczba}: {wynik}");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Nieobsługiwana operacja");
        }
    }

    static void WykonajPodstawoweOperacje()
    {
        Console.WriteLine("Podaj pierwszą liczbę całkowitą");
        decimal pierwszaLiczba, drugaLiczba;
        pierwszaLiczba = PobierzLiczbeOdUzytkownika();

        Console.WriteLine("Podaj drugą liczbę całkowitą");
        drugaLiczba = PobierzLiczbeOdUzytkownika();

        Console.WriteLine("Podaj operację");
        var operacja = Console.ReadLine();
        if (SprawdzCzyOperacjaJestPrawidlowa(operacja!))
        {
            Console.WriteLine("Wszystko jest ok");
            var wynik = ObliczWynik(pierwszaLiczba, drugaLiczba, operacja!);
            Console.WriteLine($"Wynik operacji {pierwszaLiczba} {operacja} {drugaLiczba}: {wynik}");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Nieobsługiwana operacja");
        }
    }

    static decimal PobierzLiczbeOdUzytkownika()
    {
        decimal wynik = 0;
        var jakasLiczba = Console.ReadLine();
        while (!decimal.TryParse(jakasLiczba.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out wynik))
        {
            Console.WriteLine("Podałeś nieprawidłową liczbę, spróbuj ponownie");
            jakasLiczba = Console.ReadLine();
        }
        return wynik;
    }

    static bool SprawdzCzyOperacjaJestPrawidlowa(string operacja)
    {
        switch (operacja)
        {
            case "+":
            case "-":
            case "*":
            case "/":
            case "^":
                return true;
            default:
                return false;
        }
    }
    static bool SprawdzCzyZaawansowanaOperacjaJestPrawidlowa(string operacja)
    {
        switch (operacja)
        {
            case "^":
            case "sqrt":
                return true;
            default:
                return false;
        }
    }



    static decimal ObliczWynik(decimal x, decimal y, string operacja)
    {
        var wynik = operacja switch
        {
            "+" => x + y,
            "-" => x - y,
            "*" => x * y,
            _ => x / y
        };
        return wynik;
    }

    static double ObliczZaawansowanyWynik(decimal x, decimal y, string operacja)
    {
        var xJakoDouble = Convert.ToDouble(x);
        var yJakoDouble = Convert.ToDouble(y);
        var wynik = operacja switch
        {
            "^" => Math.Pow(xJakoDouble, yJakoDouble),
            "sqrt" => Math.Pow(xJakoDouble, (1 / yJakoDouble))
        } ;

        return wynik;
    }
}