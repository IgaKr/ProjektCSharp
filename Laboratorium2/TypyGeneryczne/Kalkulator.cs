namespace Laboratorium2.TypyGeneryczne
{
    internal class Kalkulator
    {
        public T Dodaj<T>(T x, T y)
        {


            dynamic x1 = x;
            dynamic y1 = y;
            
            return x1 + y1;
        }

        public T Odejmij<T>(int x, int y)
        {
            dynamic x1 = x;
            dynamic y1 = y;

            return x1 - y1;
        }
    }
}
