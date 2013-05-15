using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    public class trackWarrantLine2and12 : TrackWarrent
    {
        //line 2 with 12
        public void issuance(string line, double sMP, double eMP, double jsMP, double jeMP, bool direction)
        {
            Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " joint with Foreman from " + jsMP.ToString() + " to " + jeMP.ToString() + " " + direction.ToString() + " issuance succeeded.");
        }

        //line 4 with 12
        public void issuance(string line, double sMP, double eMP, double jsMP, double jeMP)
        {
            Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " joint with Foreman from " + jsMP.ToString() + " to " + jeMP.ToString() + " " + " issuance succeeded.");
        }

    }
}
