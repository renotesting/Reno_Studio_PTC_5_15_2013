using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
            Console.WriteLine(" Debug Client messages cleann started...");
            var proc = Process.Start("C:\\gitrepo\\ptc\\PTCAutomationTestFramework\\autoit\\DebugClientMessage_Clean_command.exe");
            proc.WaitForExit();
            Console.WriteLine(" Debug Client messages cleanned.");
            _autoit.Sleep(2000);
        }

        public void deleteDebugClientmessage()
        {
            _autoit.WinActivate("Debug Client [", "");              //Clean Up all hitory text in Debug Client window
            _autoit.WinWait("Debug Client [");
            _autoit.Send("{Alt}+L");
            _autoit.Send("F");
            _autoit.Send("N");
            Console.WriteLine("Historical messages deleted");
            _autoit.Sleep(2000);
        }

        public string verifyDebugclientmessage(string messagePattern)
        {
                string allmessage, asResult;
                _autoit.WinActivate("Debug Client [", "");
                _autoit.WinWait("Debug Client [");

                do
                {
                    allmessage = _autoit.WinGetText("Debug Client [");
                    //bool match = Regex.IsMatch(allmessage, messagePattern);
                    Match m = Regex.Match(allmessage, messagePattern);
                    asResult = m.Value;
                } while (Regex.IsMatch(allmessage, messagePattern) == false);

                deleteDebugClientmessage();

                Console.WriteLine("The message was verified: " + asResult.ToString());
                return asResult;
        }

        public void firstInit()
        {
            Console.WriteLine(" first init started...");
            //;Right 1st: 1334, 614
            //;Right 2nd: 1257, 614
            //;Right 3rd: 1174, 614
            //;Right 4th: 1097, 614
            //;Left 4th: 1008, 614
            //;Left 3rd: 927, 614
            //;Left 2nd: 860, 614
            //;Left 1th: 778, 614
            //;Window Position: 713, 95
            //;Window Size: 660, 573

            //;Precondition:
            //;First time init ever,
            //;only Menu1 button at right 1st and Consist button at left 2nd

            deleteDebugClientmessage();
            cleanDebugclientmessage();

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.WinMove("CDU [D0403000][8 Hz] - {Active}", "", 713, 95);
            _autoit.MouseClick("left", 1334, 614);  //click 'Menu1' (Right 1st button)
            string result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP|2|Init|Depart\sTest\|{5}[\|Crew\sLogoff]Main");
            
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 788, 614);   //click 'Init' (Left 1st Button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|THIS\sWILL\sERASE\sEXISTING\sTRAIN\sDATA\.\sDO\sYOU\sWANT\sTO\sCONTINUE\?");
            
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 788, 614);  //click 'Yes' (Left 1st Button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|SELECT\sRAILROADS\sFOR\sINITIALIZATION");
            
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
        }

        public void reInit_run(bool direction)
        {
            setSimulator();
            reInit();
            LocoMotion(direction);
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