

using SzpitalAPP.Components.CSVReader.Models;

namespace SzpitalAPP.Components.CSVReader
{
    public interface ICsvReader
    {
        List<Hospital> ProcessedHospitals(string filePath);
        List<Localization> ProcesedLocal(string filePath);
    }
}
