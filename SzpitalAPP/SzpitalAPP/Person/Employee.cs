
namespace SzpitalAPP.Person
{
    public class Employee : PersonBase
    {
        public override string ToString()=> $"Employee {Id},  {Pesel} , , {Name}, {SurName}";
        
    }
}
