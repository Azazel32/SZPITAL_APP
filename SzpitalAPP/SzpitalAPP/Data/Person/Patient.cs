
using System.Text;
using SzpitalAPP.Data.Person;

namespace SzpitalAPP.Person
{
    public class Patient : PersonBase
    {
        public int CardNumber { get; set; }
        public Branch Branch { get; set; }
        public Doctor Doctor { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id} , PESEL: {Pesel}");
            sb.AppendLine($"Name: {Name} , SurName: {SurName}");
            sb.AppendLine($"Age: {DateTime.Now.Year - Birthday.Year} , BirthDay: {Birthday.ToShortDateString()}");
            sb.AppendLine($"Country: {Country} , City: {City}");
            sb.AppendLine($"CardNumber {CardNumber} , Brnach: {Branch}");
            sb.AppendLine($"Doctor: {Doctor.Name} {Doctor.SurName}");
            return sb.ToString();
        }
    }
}
