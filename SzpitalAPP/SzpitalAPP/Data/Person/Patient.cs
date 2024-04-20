
using System.Text;
using SzpitalAPP.Data.Person;

namespace SzpitalAPP.Person
{
    public class Patient : PersonBase
    {
        public Branch Branch { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id} , PESEL: {Pesel}");
            sb.AppendLine($"Name: {Name} , SurName: {SurName}");
            sb.AppendLine($"Age: {Age}");
            sb.AppendLine($"Country: {Country} , City: {City}");
            sb.AppendLine($"Brnach: {Branch}");
            return sb.ToString();
        }
    }
}
