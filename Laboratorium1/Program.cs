using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Laboratorium1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Jak masz na imię i nazwisko?");
            //var dane = Console.ReadLine();
            //var tablicaDanych = dane.Split(' ');


            //var osoba = new Osoba
            //{
            //    Imie = tablicaDanych[0],
            //    Nazwisko = tablicaDanych[1]
            //};
            //switch (osoba.Nazwisko)
            //{
            //    case "Kowalski":
            //        Console.WriteLine("Witaj szefie");
            //        break;
            //    default:
            //        Console.WriteLine( "Witamy w pracy");
            //        break;
            //}

            //switch (osoba)
            //{
            //    case Osoba o when o.Imie == "Jan" && o.Nazwisko != "Kowalski":
            //        Console.WriteLine("Cześć Janek");
            //        break;
            //    case Osoba o when o.Nazwisko == "Kowalski":
            //        Console.WriteLine( "Witaj szfie");
            //        break;
            //    default:
            //        Console.WriteLine("Nie znam cię");
            //        break;
            //}

            //var pozycja = osoba switch
            //{
            //    Osoba o when o.Imie.ToLower() == "jan" && o.Nazwisko.ToLower() == "kowalski" => "Szef",
            //    _ => "Nie pracujesz tutaj"
            //};


            //var osoba = new Osoba
            //{
            //    Imie = "Jan",
            //    Nazwisko = "kowalski"
            //};


            //Console.WriteLine("Masz na imię "+ osoba.Imie + " a na nazwisko " + osoba.Nazwisko);
            //Console.WriteLine($"Masz na imię {osoba.Imie} a na nazwisko {osoba.Nazwisko}");
            //Console.WriteLine("Masz na imię {0} a na nazwisko {1}", osoba.Imie, osoba.Nazwisko);

            ObliczMiejsceZerowe(3, 4, 1);
            Console.ReadLine();
        }

        static void SetValueToFive(ref int value)
        {
            value = 5;
        }

        static void SetValueToSix(out int value)
        {
            value = 0;
        }

        static int GetSix(params string[] x)
        {
            return 6;
        }

        static int PomnozLiczbeXPrzezLiczbeY(int x, int y)
        {
            var wynik = 0;

            for (int i = 0; i < y; i++)
            {
                wynik += x;
            }

            return wynik;
        }

        static int PotegujLiczbe(int podstawa, int wykladnik)
        {
            var wynik = 1;

            for (int i = 0; i < wykladnik; i++)
            {
                wynik = wynik * podstawa;
            }

            return wynik;
        }

        static void ObliczMiejsceZerowe(int a, int b, int c)
        {
            var wynik = 0.0M;

            // ax^2+bx+c
            // Delta = b^2 -4ac
            var bKwadrat = PotegujLiczbe(b, 2);
            var delta = bKwadrat - (4 * a * c);

            if(delta < 0)
            {
                Console.WriteLine("Brak miejsca zerowego w przestrzeni liczb rzeczywistych");
            }else if(delta == 0)
            {
                // x1 = x2 = -b/2a
                var x1x2 = ((-1) * b) / (2 * a);
                Console.WriteLine($"Jedno miejsce zerowe {x1x2}");
            }
            else
            {
                // x1 = -b - d^1/2 /2a x2 = -b + d^1/2 /2a
                var pierwiastekZDelty = Math.Sqrt(delta);
                var x1 = (((-1)* b) - pierwiastekZDelty)/ (2 * a);  
                var x2 = (((-1)* b) + pierwiastekZDelty)/ (2 * a);

                Console.WriteLine($"Dwa miejsca zerowe: {x1} oraz {x2}");
            }

        }

        private class Osoba
        {
            public string Imie { get; set; } = string.Empty;
            public string Nazwisko { get; set; } = string.Empty;
        }
    }
}