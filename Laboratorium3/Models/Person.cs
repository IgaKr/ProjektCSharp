namespace Laboratorium3.Models
{
    internal class Person
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? City { get; set; } 
        public string Country { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsMen { get; set; }

       
    }
}
