using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    public class Onboard_Simulator : Isimulator
    {
        private AutoItX3Lib.AutoItX3 _autoit = new AutoItX3Lib.AutoItX3();

        public void setSimulator()
        {
            Console.WriteLine(" set simulator succeed.");
        }

        public void cleanDebugclientmessage()
        {
            Console.WriteLine(" clean debug client succeed.");
        }

        public void verifyDebugclientmessage()
        {
                Console.WriteLine(" Warning/braking enforcement succeeded.");
        }
        public void firstInit()
        {
            Console.WriteLine(" first init succeed.");
        }

        public void reInit()
        {
            Console.WriteLine(" reinit succeed.");
        }

        public void clearcurrentSignal()
        {
            Console.WriteLine(" current governing signal cleared successfully.");
        }
        public void readparams_comm_CPRS()
        {
            Console.WriteLine(" read params comm CPRS succeed.");
        }
        public void readparams_CPRS()
        {
            Console.WriteLine(" read params CPRS succeed.");
        }

        public void LocoMotion(bool direction)
        {
            Console.WriteLine(" Move loco succeed. Movement direction is " + direction.ToString());
        }

        public void changeSwitchposition()
        {
                Console.WriteLine(" switch is in Normal position.");
        }

        public void changeSignalGoverning()
        {
                Console.WriteLine(" signal is SG2/3/4/5.");
                Console.WriteLine(" signal is SG1.");
        }

        public void testReportTMC()
        {
            Console.WriteLine(" test report succeed.");
        }

        public void firstInit_run(bool direction)
        {
            readparams_comm_CPRS();
            readparams_CPRS();
            setSimulator();
            firstInit();
            LocoMotion(direction);
            clearcurrentSignal();
            verifyDebugclientmessage();

        }

        public void reInit_run(bool direction)
        {
            readparams_comm_CPRS();
            readparams_CPRS();
            setSimulator();
            reInit();
            LocoMotion(direction);
            clearcurrentSignal();
            verifyDebugclientmessage();
        }

        
    }
}
