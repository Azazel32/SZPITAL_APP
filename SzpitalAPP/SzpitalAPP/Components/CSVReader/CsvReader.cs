using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Components.CSVReader.Extesions;
using SzpitalAPP.Components.CSVReader.Models;

namespace SzpitalAPP.Components.CSVReader
{
    public class CsvReader : ICsvReader
    {
        public List<Localization> ProcesedLocal(string filePath)
        {
            if (!File.Exists(filePath)) 
            {
                return new List<Localization>();
            }
            var local= File.ReadAllLines(filePath).Skip(1)
                .Where(x=>x.Length>1)
                .Select(x=>
                {
                    var column = x.Split(";");
                    return new Localization()
                    {
                        City = column[0],
                        State = column[1]
                    };
                });
            return local.ToList();
        }

        public List<Hospital> ProcessedHospitals(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Hospital>();
            }
            var hospital = File.ReadAllLines(filePath).Skip(1)
                .Where(x=>x.Length >0).ToDrug();
            return hospital.ToList();
        }       
    }
}
