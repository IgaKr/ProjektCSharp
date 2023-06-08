namespace Laboratorium2.Klasy
{
    internal class Samochod : Pojazd
    {
        public string Marka {get; set;}
        private bool _czySilnikJestOdpalony;


        public Samochod(string marka)
        {
            Marka = marka;
        }

        public void PrzekrecKluczyk()
        {
            if (SprawdzCzySilnikJestOdpalony())
            {
                ZgasSilnik();
            }
            else
            {
                OdpalSilnik();
            }
        }

        private void OdpalSilnik()
        {
            Console.WriteLine("Odpalam silnik");
            PompujPaliwo();
            _czySilnikJestOdpalony = true;
        }

        private void ZgasSilnik()
        {
            Console.WriteLine("Gaszę silnik");
            _czySilnikJestOdpalony = false;
        }

        private void PompujPaliwo()
        {
            Console.WriteLine("Zaczęto pompować palilwo");
        }

        private bool SprawdzCzySilnikJestOdpalony()
        {
            return _czySilnikJestOdpalony;
        }
    }
}
