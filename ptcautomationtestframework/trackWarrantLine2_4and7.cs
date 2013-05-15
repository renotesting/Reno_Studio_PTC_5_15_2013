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
        public bool issuance(string line, double sMP, double eMP, double meetAtMP, bool direction)
        {
            if (true)
            {
                Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " meet at " + meetAtMP.ToString() + " " + direction.ToString() + " issuance succeeded.");
                return true;
            }
            else
            {
                Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " meet at " + meetAtMP.ToString() + " " + direction.ToString() + " issuance failed.");
                return false;
            }
        }

        //line 4 with 7
        public bool issuance(string line, double sMP, double eMP, double meetAtMP)
        {
            if (true)
            {
                Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " meet at " + meetAtMP.ToString() + " " + " issuance succeeded.");
                return true;
            }
            else
            {
                Console.WriteLine(" TW line " + line + " from " + sMP.ToString() + " to " + eMP.ToString() + " meet at " + meetAtMP.ToString() + " " + " issuance succeeded.");
                return false;
            }
        }

    }
}
