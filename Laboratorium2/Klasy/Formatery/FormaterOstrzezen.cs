using Laboratorium2.Interfejsy;

namespace Laboratorium2.Klasy.Formatery
{
    internal class FormaterOstrzezen : BazowyFormaterLogow, IFormaterLogow
    {
        public string FormatujLogi(string logi)
        {
            logi = $"#WARNING# {logi}";
            return base.Formatuj(logi);
        }
    }
}
