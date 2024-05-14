using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Components.CSVReader.Models;

namespace SzpitalAPP.Components.CSVReader.Extesions
{
    public static class HospitalExtension
    {
        public static IEnumerable<Hospital> ToDrug(this IEnumerable<string> source)
        {
            foreach (var line in source) 
            {
                var column = line.Split(';');
                yield return new Hospital
                {
                    Nip = column[0],
                    Regon = column[1],
                    Desc = column[2],
                    City = column[3],
                    State = column[4],
                    Mark = column[5],
                    ExpiryDate = column[6],
                    AwardingDate = column[7],
                    UrlAddress = column[8]
                };
            }
        }
    }
}
