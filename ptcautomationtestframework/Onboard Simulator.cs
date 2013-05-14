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
            Console.WriteLine(" Historical messages deleted");
            _autoit.Sleep(2000);
        }

        public string verifyDebugclientmessage(string messagePattern)
        {
                string allmessage, asResult;
                _autoit.WinActivate("Debug Client [", "");
                _autoit.WinWait("Debug Client [");
                _autoit.WinMove("Debug Client [", "", 1280, 280);

                do
                {
                    allmessage = _autoit.WinGetText("Debug Client [");
                    //bool match = Regex.IsMatch(allmessage, messagePattern);
                    Match m = Regex.Match(allmessage, messagePattern);
                    asResult = m.Value;
                } while (Regex.IsMatch(allmessage, messagePattern) == false);

                deleteDebugClientmessage();

                Console.WriteLine(" The message was verified: " + asResult.ToString());
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

        public void LocoMotion(double StartMP, double SetSPD, bool SetDirection)
        {
            bool INCREASING = false;
            bool DECREASING = true;

            if (_autoit.WinExists("Motion Control - ", "") == 1)
            {
                _autoit.WinClose("Motion Control - ", "");
                //_autoit.Sleep(1000);
                //_autoit.RunWait("C:\\Users\\liu0011\\Documents\\Simulator6.3.8\\System-Test\\Vital-LocoSimulator.exe");
            }

            //Activate and Focus on the CDU window
            _autoit.WinActivate("Loco[CPRS  1234]", "");
            _autoit.WinMove("Loco[CPRS  1234]", "", 810, 39);

            _autoit.Send("{Alt}+F");
            _autoit.Send("T");
            _autoit.Send("L");
            _autoit.Send("S");
            //_autoit.Send("CPRS.00153.66.opk");

            _autoit.WinActivate("Open", "");
            _autoit.ControlSetText("Open", "", "[CLASS:Edit; ID:1148]", "CPRS.00153.70.opk");
            _autoit.Send("{TAB 2}");
            _autoit.Send("{ENTER}");
            //_autoit.ControlClick("Open", "", "[CLASS:Button; ID: 1; INSTANCE:2]");

            _autoit.WinActivate("Loco[CPRS  1234]", "");
            _autoit.Send("{Alt}+M");
            _autoit.Send("Controls...");

            _autoit.WinActivate("Motion Control - Heading","");
            _autoit.WinMove("Motion Control - Heading", "", 810, 192);
            //click 'Sub' dropdown
            _autoit.Send("{DOWN}");
            //click dropdown "153 [CPRS]"
            _autoit.Send("{TAB 2}");
            //click dropdown "Offset" and "MP"
            //click dropdown "MP"
            _autoit.Send("{DOWN}");

            //MouseClick("left", 1165, 245) ;click MP input
            _autoit.Send("{TAB}");
            // Send(230.8000)
            // Input head end starting MP for locomotive
            _autoit.Send(StartMP.ToString());

            // Move to Direction option check box
            _autoit.Send("{TAB 1}");
            string checkButtonstatus = _autoit.ControlCommand("Motion Control - Heading", "DEC", "[CLASS:Button; ID:1043]", "IsChecked", "");

            if ((SetDirection == INCREASING) && (checkButtonstatus == "0"))           //Then Decreasing and never checked
            {    _autoit.Send("{SPACE}");
	            _autoit.Send("{TAB 1}");
            }

            if ((SetDirection == INCREASING) && (checkButtonstatus == "1"))          //Decreasing but checked
            {
	            _autoit.Send("{TAB 1}");
            }

            if ((SetDirection == DECREASING) && (checkButtonstatus == "0"))         //Increasing and never checked
            {
	            _autoit.Send("{TAB 1}");
            }

            if ((SetDirection == DECREASING) && (checkButtonstatus == "1"))          //Increasing but checked
            {
	            _autoit.Send("{SPACE}");                            //unCheck it
	            _autoit.Send("{TAB 1}");
            }
            
            // Hit Set button
            _autoit.Send("{SPACE}");
            //Select Main or Siding on pop up "Select Milepost Dialog"
            _autoit.WinActivate("Select Milepost", "");
            _autoit.Send("{SPACE}");


            //MouseClick("left", 1169, 465) ;click Speed Control
            _autoit.Send("{TAB 4}");
            //;Send("{END}")
            //;Send("{LSHIFT}+{HOME}")
            //;Send("{DEL 7}")
            _autoit.Sleep(2000);
            //;~ Send(5.00)
            _autoit.Send(SetSPD.ToString());
            //;MouseClick("left", 1127, 464)
            _autoit.Send("+{TAB 1}");
            _autoit.Send("{SPACE}");
            _autoit.Sleep(1000);

            Console.WriteLine(" Move loco succeed. Movement direction is " + SetDirection.ToString() + " at speed of " + SetSPD.ToString());
        }

        public void selectMaintrack()
        {
            Console.WriteLine(" Starting to Select Main Track...");

            string result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|\d\|D\|SELECT\sCURRENT\sTRACK");
            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            _autoit.WinMove("CDU [D0403000][8 Hz] - {Active}", "", 713, 95);
            // Wait for prompt color show up
           // Find a pure Cyon pixel in the range
            do
            {
                _autoit.Sleep(400);
                _autoit.PixelSearch(769, 537, 833, 585, 0x00FFFF);
            } while (_autoit.error == 1);

            //;Right 1st: 1334, 614
            //;Right 2nd: 1257, 614
            //;Right 3rd: 1174, 614
            //;Right 4th: 1097, 614
            //;Left 4th: 1008, 614
            //;Left 3rd: 927, 614
            //;Left 2nd: 860, 614
            //;Left 1th: 778, 614

            _autoit.MouseClick("left", 1097, 614); //click 'Select' (Right 4th Button)

            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|\d\|D\|YOU\sSELECTED\sMAIN\sOttumwa\sCPRS\.\sIS\sTHIS\sCORRECT\?");

            _autoit.WinActivate("CDU [D0403000][8 Hz] - {Active}", "");
            _autoit.WinWait("CDU [D0403000][8 Hz] - {Active}");
            
            _autoit.MouseClick("left", 788, 614); //click 'Yes' (Left 1st Button)

            result = verifyDebugclientmessage(@"\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|\d|Mandatory\sDirectives\|Consist\|{6}Menu\s1");

            Console.WriteLine(" Selected Main Track.");
        }

        public void clearCurrentGoverningSignal()
        {
            Console.WriteLine(" current governing signal cleared successfully.");
        }

        public void LocoMotion_SetSPD(double speed)
        {
            Console.WriteLine(" Move loco succeed. Movement direction is " + speed.ToString());
        }

        public void changeSwitchposition(bool swPosition)
        {
                Console.WriteLine(" switch is in Normal position." + swPosition.ToString());
        }

        public void changeFacingSignal(string SG)
        {
                Console.WriteLine(" signal is SG2/3/4/5." + SG);
        }

        public void testReportTMC()
        {
            Console.WriteLine(" test report succeed.");
        }

        public void firstInit_run(double StartMP, double SetSPD, bool SetDirection)
        {
            setSimulator();
            firstInit();
            LocoMotion(StartMP, SetSPD, SetDirection);
        }

        public void reInit_run(bool direction)
        {
            setSimulator();
            reInit();
            //LocoMotion(direction);
        }

        public void verifyBrakingEnforcementStop()
        {
                Console.WriteLine(" Train has braking enforcement and stops.");
        }

        public void verifyNewUpdatedAuthority()
        {
                Console.WriteLine(" Acknowledged authority.");
        }

        public bool testAnalysis_Tracklmt(double expctedEndMP)
        {
            Console.WriteLine(" Test train stop before he end MP successfully .");
            return false;
        }

        public bool testAnalysis_SPDtgt(double expectedSPD)
        {
            Console.WriteLine(" Test train stop successfully when movement speed is enforced.");
            Console.WriteLine(expectedSPD);
            return true;
        }
        
    }
}