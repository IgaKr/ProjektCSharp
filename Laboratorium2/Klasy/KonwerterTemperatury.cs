namespace Laboratorium2.Klasy
{
    internal abstract class KonwerterTemperatury
    {
        protected int Temperatura;

        public KonwerterTemperatury(int temperatura)
        {
            Temperatura = temperatura;
        }

        public abstract void PrzeliczTemperature();
    }
}
