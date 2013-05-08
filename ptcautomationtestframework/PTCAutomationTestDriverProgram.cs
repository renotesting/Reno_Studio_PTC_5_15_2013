using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using PTCAutomationTestFramework;

namespace PTCAutomationTestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoItX3Lib.AutoItX3 robot = new AutoItX3Lib.AutoItX3();

            testCase tc = new testCase();
            //line 2 increasing
            tc.runTestcase(2, 210, 220, true);
            robot.Sleep(1000);

            //line 2 decreasing
            tc.runTestcase(2, 220, 200, false);
            robot.Sleep(1000);

            //line 4 increasing
            tc.runTestcase(4, 200, 220, true);
            robot.Sleep(1000);

            //line 4 decreasing
            tc.runTestcase(4, 220, 200, false);
            robot.Sleep(1000);

            //line 2 and 7 increasing
            tc.runTestcase(2, 7, 200, 220, true);
            robot.Sleep(1000);
            
            //line 2 and 7 decreasing
            tc.runTestcase(2, 7, 200, 220, false);
            robot.Sleep(10000);
        }
    }
}
