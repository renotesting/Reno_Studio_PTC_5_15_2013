using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    public class trackWarrantLine2_4and11 : TrackWarrent
    {
        //line 2 with 11
        public void issuance(int line, float sMP, float eMP, float jsMP, float jeMP, bool direction)
        {
                Console.WriteLine(" TW line 2 with 11 issuance succeeded.");
        }

        //line 4 with 11
        public void issuance(int line, float sMP, float eMP, float jsMP, float jeMP)
        {
                Console.WriteLine(" TW line 4 with 11 issuance succeeded.");
        }

    }
}
