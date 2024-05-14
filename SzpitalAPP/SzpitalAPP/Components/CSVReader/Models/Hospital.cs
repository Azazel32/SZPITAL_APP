using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzpitalAPP.Components.CSVReader.Models
{
    public class Hospital
    {
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string Desc { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string Mark { get; set; }
        public string ExpiryDate { get; set; }
        public string AwardingDate { get; set; }
        public string UrlAddress { get; set; }

    }
}
