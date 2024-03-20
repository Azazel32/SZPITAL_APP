
namespace SzpitalAPP.Person
{
    public class Patient : PersonBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public override string ToString() => $"Patient {Id}, {Name}, {SurName}";
    }
}
