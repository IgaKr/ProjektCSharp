using Laboratorium3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium5
{
    internal class LINQ
    {
        public void ShowLinq()
        {
            List<string> imiona = new List<string>
            {
                "ALA",
                "KASIA",
                "OLA",
                "MAŁGOSIA"
            };

            var przefiltrowaneImiona = imiona.Where(imie => imie.Contains("L"));

            int[] oceny = new int[] { 2, 4, 3, 6 };

            oceny = oceny.OrderByDescending(x => x).ToArray();

            int suma = 0;

            foreach (var ocena in oceny)
            {
                suma += ocena;
            }
            suma = 0;
            suma = oceny.Sum();

            var client = new NBPGoldRateWebClient("");
            var kursy = client.GetLastGoldRates(10);
            kursy = kursy.OrderByDescending(kurs => kurs.Price).ToArray();

            var sredniKurs = kursy.Average(kurs => kurs.Price);

            var rates = kursy
                .Where(kurs => kurs.Price > 265.0m);

            if (rates.Any(price => price.Price > 280.0m))
            {
                Console.WriteLine("Kolekcja nie jest pusta");
            }
        }
    }
}
