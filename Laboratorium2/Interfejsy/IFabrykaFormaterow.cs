using Laboratorium2.Enums;

namespace Laboratorium2.Interfejsy
{
    public interface IFabrykaFormaterow
    {
        IFormaterLogow Create(RodzajLoga typ);
        IFormaterLogow Create(string typ);
    }
}
