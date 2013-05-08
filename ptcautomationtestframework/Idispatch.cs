using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    interface Idispatch
    {
        void issuance(bool direction);
        void checkIIS();
        void checkBOS();

        void testReportDispatch();
    }
}
