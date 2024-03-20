
namespace SzpitalAPP.Person
{
    public class Employee : PersonBase
    {
        public int Id {get;set;}
        public string Name { get;set;}
        public string SurName { get;set;}
        public override string ToString()=> $"Employee {Id}, {Name}, {SurName}";
        
    }
}
