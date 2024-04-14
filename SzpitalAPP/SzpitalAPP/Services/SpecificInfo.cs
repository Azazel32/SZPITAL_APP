using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzpitalAPP.Data;

namespace SzpitalAPP.Services
{
    public class SpecificInfo : UserCommunicationBase, ISepecificinfo
    {
        private readonly IPersonProvider _personProvider;
        public SpecificInfo(IPersonProvider personProvider)
        {
            _personProvider = personProvider;
        }

        public void GetspecyficInfo()
        {
            bool closeLoop=false;
            while(closeLoop) 
            {
                WritelineColor("----Specific Info----\n+" +
                    "1. Get unique National\n"+
                    "2. Get unique City\n"+
                    "3. Get max docktor's Salary\n"+
                    "4. Order doctors by age\n"+
                    "5. Order doctors by salary\n" +
                    "6. Order doctors by country\n" +
                    "7. Order doctors by \n" +
                    "4. Order doctors by age\n" +
                    "4. Order doctors by age\n" +
                    "4. Order doctors by age\n" +









                    , ConsoleColor.Cyan);
            }
        }

        public override void Task()
        {
            throw new NotImplementedException();
        }
    }

}
