using Laboratorium2.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium2.Klasy.Formatery
{
    internal class FormaterBledow : BazowyFormaterLogow, IFormaterLogow
    {
        public string FormatujLogi(string logi)
        {
            logi = $"#BŁĄD# {logi}";
            return base.Formatuj(logi);
        }
    }
}
