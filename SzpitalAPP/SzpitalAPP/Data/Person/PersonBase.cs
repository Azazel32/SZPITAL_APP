
namespace SzpitalAPP.Person
{
    public class PersonBase : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Pesel { get; set; }
        public DateTime Birthday { get; set ; }
        public string City { get; set; }
        public string Country { get ; set ; }
        
    }
}
