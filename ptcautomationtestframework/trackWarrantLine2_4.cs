using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTCAutomationTestFramework;

namespace PTCAutomationTestFramework
{
    public class trackWarrantLine2_4 : TrackWarrent
    {
        //line 2
        public void issuance(string line, double sMP, double eMP, bool direction)
        {
            Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + "  " + direction.ToString() + " issuance succeeded.");
        }
        //line 4
        public void issuance(string line, double sMP, double eMP)
        {
            Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " issuance succeeded.");
        }

    }
}
