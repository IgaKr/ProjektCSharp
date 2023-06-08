using Laboratorium2.Interfejsy;

namespace Laboratorium2.Klasy.Formatery
{
    public abstract class BazowyFormaterLogow 
    {
        public string Formatuj(string logi)
        {
            return $"{DateTime.Now.ToString("HH-mm.ss")} {logi}";
        }
    }
}
