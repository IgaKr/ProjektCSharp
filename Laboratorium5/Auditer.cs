using Laboratorium3.Models;
using Laboratorium4.DataBaseRepository.Interfaces;

namespace Laboratorium5
{
    public class Auditer
    {
        private readonly IDataBaseRepository _dataBaseRepository = default!;

        public Auditer(IDataBaseRepository dataBaseRepository)
        {
                _dataBaseRepository = dataBaseRepository;
        }

        public void SaveGoldRate(GoldDTO goldDTO)
        {
            goldDTO.Price = 0.0m;
            _dataBaseRepository.SaveGoldRate(goldDTO);
        }
    }
}
