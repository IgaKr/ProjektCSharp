using Laboratorium2.Enums;
using Laboratorium2.Interfejsy;

namespace Laboratorium2.Klasy.Loggery
{
    internal class FileLogger : IUserLogger
    {
        private const string _nazwaPliku = "logi.txt";
        private readonly IFabrykaFormaterow _fabrykaFormaterow;

        public FileLogger(IFabrykaFormaterow fabrykaFormaterow)
        {
            _fabrykaFormaterow = fabrykaFormaterow;
        }

        public void Log(string message, RodzajLoga typLogow)
        {
            using (var writer = new StreamWriter(_nazwaPliku, true))
            {
                var formater = _fabrykaFormaterow.Create(typLogow);
                message = formater.FormatujLogi(message);
                writer.WriteLine(message);
            }
        }

        public void LogZStatycznaKlasa(string message, string typLoga)
        {
            using (var writer = new StreamWriter(_nazwaPliku, true))
            {
                var formater = _fabrykaFormaterow.Create(typLoga);
                message = formater.FormatujLogi(message);
                writer.WriteLine(message);
            }
        }
    }
}
