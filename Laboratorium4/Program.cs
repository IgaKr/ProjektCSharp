using Laboratorium4.DataBaseRepository;
using Laboratorium4.Models;

internal class Program
{
    static void Main(string[] args)
    {
        var repository = new SqlServerRepository();
        //repository.GetAllNames();
        //repository.GetNameId("Test'owe");
        //repository.GetNamesCount();
        //repository.InsertNewName("Janusz");

        //repository.InsertNewPerson(new Person
        //{
        //    Name = "NAME",
        //    LastName = "LASTNAME"
        //});

        //repository.GetAllSurnames();
    }
}