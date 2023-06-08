using Laboratorium2.Enums;
using Laboratorium2.Interfejsy;
using Laboratorium2.Klasy.Formatery;
using Laboratorium2.Klasy.KlasyStatyczne;

namespace Laboratorium2.Klasy.Fabryki
{
    internal class FabrykaLogow : IFabrykaFormaterow
    {
        public IFormaterLogow Create(RodzajLoga typ)
        {
            return typ switch
            {
                RodzajLoga.Error => new FormaterBledow(),
                RodzajLoga.Warning => new FormaterOstrzezen(),
                _ => new FormaterInformacji()
            };
        }

        public IFormaterLogow Create(string typ)
        {
            return typ switch
            {
                "error" => new FormaterBledow(),
                "warning" => new FormaterOstrzezen(),
                _ => new FormaterInformacji()
            };
        }
    }
}
