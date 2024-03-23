
namespace SzpitalAPP.Person
{
    public class Patient : PersonBase
    {
        public override string ToString() => $"Patient {Id}, {Pesel}, {Name}, {SurName}";
    }
}
