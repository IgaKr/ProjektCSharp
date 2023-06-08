using Laboratorium2.Interfejsy;

namespace Laboratorium2.Klasy.Formatery
{
    public class FormaterInformacji : BazowyFormaterLogow, IFormaterLogow
    {
        public string FormatujLogi(string logi)
        {
            logi = $"#INFO# {logi}";
            return base.Formatuj(logi);
        }
    }
}
