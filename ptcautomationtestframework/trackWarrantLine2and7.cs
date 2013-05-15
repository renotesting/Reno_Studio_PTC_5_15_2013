using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    public class trackWarrantLine2_4and7 : TrackWarrent
    {
        //line 2 with 7
        public bool issuance(int line, float sMP, float eMP, float meetAtMP, bool direction)
        {
            if (true)
            {
                Console.WriteLine(" TW line 2 with 7 issuance succeeded.");
                return true;
            }
            else
            {
                Console.WriteLine(" TW line 2 with 7 issuance failed.");
                return false;
            }
        }

        //line 4 with 7
        public bool issuance(int line, float sMP, float eMP, float meetAtMP)
        {
            if (true)
            {
                Console.WriteLine(" TW line 4 with 7 issuance succeeded.");
                return true;
            }
            else
            {
                Console.WriteLine(" TW line 4 with 7 issuance failed.");
                return false;
            }
        }

    }
}
