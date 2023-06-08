using Laboratorium3.Models;
using Laboratorium4.Models;

namespace Laboratorium4.DataBaseRepository.Interfaces
{
    public interface IDataBaseRepository
    {
        List<string> GetAllNames();
        int GetNameId(string name);
        int GetNamesCount();
        void InsertNewName(string name);
        void InsertNewPerson(Person person);
        List<string> GetAllSurnames();
        void SaveGoldRate(GoldDTO goldRate);
    }
}
