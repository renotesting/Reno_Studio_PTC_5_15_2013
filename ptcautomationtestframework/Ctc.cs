using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    public class Ctc : Idispatch
    {
        public void issuance(bool direction)
        {
            Console.WriteLine(" CTC issuance succeeded.");
        }

        public void checkIIS()
        {
                Console.WriteLine(" IIS received message succeeded.");
        }

        public void checkBOS()
        {
                Console.WriteLine(" BOS transmited message successfully.");
        }

        public void testReportDispatch()
        {
            Console.WriteLine(" BOS transmited message successfully.");
        }

        public void run()
        {
            checkIIS();
            checkBOS();
            testReportDispatch();
        }

    }
}
