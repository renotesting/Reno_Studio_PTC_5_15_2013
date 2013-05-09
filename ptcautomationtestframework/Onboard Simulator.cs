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

        public void deleteDebugClientmessage()
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

        public void clearCurrentGoverningSignal()
        {
            Console.WriteLine(" current governing signal cleared successfully.");
        }
        
        public void LocoMotion(bool direction)
        {
            Console.WriteLine(" Move loco succeed. Movement direction is " + direction.ToString());
        }

        public void LocoMotion_SetSPD(float speed)
        {
            Console.WriteLine(" Move loco succeed. Movement direction is " + speed.ToString());
        }

        public void changeSwitchposition(bool swPosition)
        {
                Console.WriteLine(" switch is in Normal position." + swPosition.ToString());
        }

        public void changeFacingSignal(int SG)
        {
                Console.WriteLine(" signal is SG2/3/4/5." + SG.ToString());
        }

        public void testReportTMC()
        {
            Console.WriteLine(" test report succeed.");
        }

        public void firstInit_run(bool direction)
        {
            setSimulator();
            firstInit();
            LocoMotion(direction);
            clearCurrentGoverningSignal();
            verifyDebugclientmessage();

        }

        public void reInit_run(bool direction)
        {
            setSimulator();
            reInit();
            LocoMotion(direction);
            verifyDebugclientmessage();
        }


        public void verifyBrakingEnforcementStop()
        {
                Console.WriteLine(" Train has braking enforcement and stops.");
        }

        public void verifyNewUpdatedAuthority()
        {
                Console.WriteLine(" Acknowledged authority.");
        }

        public void selectMaintrack()
        {
            Console.WriteLine(" Selected Main Track.");
        }


        public bool testAnalysis_Tracklmt(float expctedEndMP)
        {
            Console.WriteLine(" Test train stop before he end MP successfully .");
            return false;
        }

        public bool testAnalysis_SPDtgt(float expectedSPD)
        {
            Console.WriteLine(" Test train stop successfully when movement speed is enforced.");
            Console.WriteLine(expectedSPD);
            return true;
        }
        
    }
}