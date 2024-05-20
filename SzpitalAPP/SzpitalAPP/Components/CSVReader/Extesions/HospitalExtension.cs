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
                    Mark = column[4],
                    ExpiryDate = column[5],
                    AwardingDate = column[6],
                    UrlAddress = column[7]
                };
            }
        }
    }
}
