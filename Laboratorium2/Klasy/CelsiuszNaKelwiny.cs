using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium2.Klasy
{
    internal class CelsiuszNaKelwiny : KonwerterTemperatury
    {
        public CelsiuszNaKelwiny(int temperatura) : base(temperatura)
        {
        }

        public override void PrzeliczTemperature()
        {
            Temperatura = Temperatura + 273;
            Console.WriteLine($"Temperatura w Kelwinach to {Temperatura}");
        }

        public void PowiedzJakaJestTemperatura()
        {
            Console.WriteLine($"Temperatura to: {Temperatura}");
        }

    }
}
