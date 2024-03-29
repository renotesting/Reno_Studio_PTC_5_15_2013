﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    public class TrackWarrent : Idispatch
    {
        public void issuance(bool direction)
        {
            Console.WriteLine(" TW line issuance succeeded.");
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
            Console.WriteLine(" IIS and BOS transmited message successfully.");
        }

        public void CheckingMiddleware()
        {
            checkIIS();
            checkBOS();
            testReportDispatch();
        }

    }
}
