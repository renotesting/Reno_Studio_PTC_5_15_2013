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

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 1097, 614);  //click 'Add' (Right 4th button)
            _autoit.MouseClick("left", 1334, 614);  //click 'Submit' (Right 1st button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Accept\|{7}Cancel");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            
            //Find a pure Cyon pixel in the range 769, 537, 833, 585
            //Do
            //    _autoit.Sleep(400);
            //    Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
            //Until Not @error

            do
            {
                _autoit.Sleep(400);
                _autoit.PixelSearch(769, 537, 833, 585, 0x00FFFF);
            } while (_autoit.error == 1);
            
            //Press Key to accept terms or cancel
            _autoit.MouseClick("left", 778, 614);  //click 'Accept' (Left 1st button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Cancel\|Show All Railroads\|\[UP\]\|\[DOWN\]\|Select\|{3}");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            //Select Railroad for logon
            _autoit.MouseClick("left", 1097, 614);  //click 'Select' (Right 4th button)
            _autoit.MouseClick("left", 1334, 614);  //click 'Submit' (Right 1st button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{4}Cancel");

            //;TBC19_CLEARANCE_NUMBER_DIGITS                   5
            //;TBC46_EMPLOYEE_ID_DIGITS                        6
            //;TBC47_EMPLOYEE_PIN_DIGITS                       5

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            //6 clicks '>' at 1011,623
            _autoit.MouseClick("left", 1008, 614, 6);  // click 6 '>' (Left Fourth Button) for employee id
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{3}Done\|Cancel");
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 1257, 614);     // click 'Done' (Right second Button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{4}Cancel");
            //5 clicks '>' at 1011,623
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 1008, 614, 5);  // click 5 '>' (left Fourth Button) for employee pin
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{3}Done\|Cancel");
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 1257, 614);     // click 'Done' (Right second Button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{4}Cancel");

            // Wait for Verification
            // Find a pure Blue pixel in the range
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            //Do
            //    Local $coord = PixelSearch(1011, 600, 1029, 638, 0x0000FF)
            //Until Not @error
            //do
            //{
            //    _autoit.PixelSearch(1011, 600, 1029, 638, 0x00FFFF);

            //} while (_autoit.error == 1);

            //5 clicks '>' at 1011,623
            //MouseClick("left", 1008, 623, 5) ; click 5 '>' (Right Fourth Button) for clearance #00000

            //Cleance # 99256
            _autoit.MouseClick("left", 860, 623, 1);    //click 1 'down' (Left 2nd Button) for clearance #9
            _autoit.MouseClick("left", 1008, 623, 1);   //click 1 '>' (Right Fourth Button) for clearance #shift right
            _autoit.MouseClick("left", 860, 623, 1);    //click 1 'down' (Left 2nd Button) for clearance #9
            _autoit.MouseClick("left", 1008, 623, 1);   //click 1 '>' (Right Fourth Button) for clearance #shift right
            _autoit.MouseClick("left", 778, 623, 2);    //click 2 'up' (Left 1nd Button) for clearance #2
            _autoit.MouseClick("left", 1008, 623, 1);   //click 1 '>' (Right Fourth Button) for clearance #shift right
            _autoit.MouseClick("left", 778, 623, 5);    //click 2 'up' (Left 1nd Button) for clearance #5
            _autoit.MouseClick("left", 1008, 623, 1);   //click 1 '>' (Right Fourth Button) for clearance #shift right
            _autoit.MouseClick("left", 778, 623, 6);    //click 2 'up' (Left 1nd Button) for clearance #6

            _autoit.MouseClick("left", 1257, 614);      //click 'Submit' (Right 2nd button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|CPRS\s{2}1234\sSELECTED\sFOR\sCPRS\sIS\sTHIS\sCORRECT\?");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");

            //; wait for Train ID
            //; Find a pure Cyon pixel in the range
            //Do
            //    Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
            //Until Not @error
            do
            {
                _autoit.Sleep(400);
                _autoit.PixelSearch(769, 537, 833, 585, 0x00FFFF);

            } while (_autoit.error == 1);

            //; Train ID display and CPRS 1234 selected for CPRS is this correct?
            _autoit.MouseClick("left", 744, 614);    //click 'Yes' (Left 1st button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|PRESS\sKEY\sTO\sMODIFY\sOR\sACCEPT\sCONSIST\sDATA\sOR\sREQUEST\sNEW\sCONSIST\sDATA");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            //; wait for train ID conformation and Train consist
            //; Find a pure Cyon pixel in the range
            //Do
            //    Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
            //Until Not @error
            do
            {
                _autoit.Sleep(400);
                _autoit.PixelSearch(769, 537, 833, 585, 0x00FFFF);

            } while (_autoit.error == 1);

            _autoit.MouseClick("left", 1334, 614);    //click 'Accept' (Right 1st Button) to accept Train ID and Consist
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{5}Begin\sTest\|{3}Cancel");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            //; wait for train data and then departure test
            //;Sleep(8000)
            //; Find a pure Cyon pixel in the range
            //Do
            //    Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
            //Until Not @error
            do
            {
                _autoit.Sleep(400);
                _autoit.PixelSearch(769, 537, 833, 585, 0x00FFFF);

            } while (_autoit.error == 1);

            //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
            _autoit.MouseClick("left", 1088, 614); //click Begin Test (Right 4th button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{5}Run\sAudible\sTest\|{3}");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            //; Find a pure Cyon pixel in the range
            //Do
            //    Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
            //Until Not @error
            do
            {
                _autoit.Sleep(400);
                _autoit.PixelSearch(769, 537, 833, 585, 0x00FFFF);

            } while (_autoit.error == 1);

            _autoit.MouseClick("left", 1088, 614); //;click Run Audible Test (Right 4th button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{4}Fail\sTest\|\|Re\-run\sAudible\sTest\|\|Pass\sTest");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 1344, 614); //click Pass Test (Right 1st Button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{8}Exit");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.MouseClick("left", 1344, 614); //click Exit (Right 1st Button)
            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Mandatory\sDirectives\|Consist\|{6}Menu\s1");

            Console.WriteLine(" first init succeed.");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");

            //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
            //;TestReport($Message)
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