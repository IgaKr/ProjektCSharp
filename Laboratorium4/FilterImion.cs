using Laboratorium4.DataBaseRepository.Interfaces;
using System.Buffers;

namespace Laboratorium4
{
    public class FilterImion
    {
        private readonly IDataBaseRepository _dataBaseRepository = default!;

        public FilterImion(IDataBaseRepository dataBaseRepository)
        {
            _dataBaseRepository = dataBaseRepository;
        }

        public List<string> ZwrocImionaZaczynajaceSieNaPodanaLitere(string litera)
        {
            var imiona = _dataBaseRepository.GetAllNames();

            imiona = imiona.Where(_ => _.StartsWith(litera)).ToList();
            return imiona;
        }
    }
}
