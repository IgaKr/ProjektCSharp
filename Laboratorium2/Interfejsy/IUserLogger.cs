using Laboratorium2.Enums;

namespace Laboratorium2.Interfejsy
{
    public interface IUserLogger
    {
        void Log(string message, RodzajLoga typLogow = RodzajLoga.Info);
        //void LogZStatycznaKlasa(string message, string typLoga);
    }
}
