
using System.Diagnostics.SymbolStore;
using System.Text;

namespace SzpitalAPP.Person
{
    public class Doctor : PersonBase
    {
        public string? Job { get; set; }
        public decimal? Salary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id} , PESEL: {Pesel}");
            sb.AppendLine($"Name: {Name} , SurName: {SurName}");
            sb.AppendLine($"Age: {DateTime.Now.Year - Birthday.Year} , BirthDay: {Birthday.ToShortDateString()}");
            sb.AppendLine($"Country: {Country} , City: {City}");
            sb.AppendLine($"Job {Job} , Salary: {Salary}");
            return sb.ToString();
        }              
    }
}
