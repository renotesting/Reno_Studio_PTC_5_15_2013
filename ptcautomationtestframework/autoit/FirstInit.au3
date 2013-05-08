;~ This is compatible to IETMS6.3.8 Simulator
;~ #include <DebugClientMessage_Verify.au3>
;~ DebugClientMessage_Delete.au3 has been included within DebugClientMessage_Verify.au3
#include <SelectMainTrack.au3>
#include <TestReport.au3>

Func FirstInit()
;Right 1st: 1334, 614
;Right 2nd: 1257, 614
;Right 3rd: 1174, 614
;Right 4th: 1097, 614
;Left 4th: 1008, 614
;Left 3rd: 927, 614
;Left 2nd: 860, 614
;Left 1th: 778, 614
;Window Position: 713, 95
;Window Size: 660, 573

;Precondition:
;First time init ever,
;only Menu1 button at right 1st and Consist button at left 2nd

DeleteDebugClientMessage()


;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Activate and Focus on the CDU window
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
WinMove("CDU [D0403000][8 Hz] - {Active}", "", 713, 95)

Local $size = WinGetPos("CDU [D0403000][8 Hz] - {Active}")
Dim $Result[1]
Dim $Message[15]
Local $i = 0


MouseClick("left", 1334, 614) ; click 'Menu1' (Right 1st button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Init\|Depart\sTest\|{5}[\|Crew\sLogoff]Main")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 788, 614) ; click 'Init' (Left 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|THIS WILL ERASE EXISTING TRAIN DATA. DO YOU WANT TO CONTINUE\?")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 788, 614) ; click 'Yes' (Left 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|SELECT RAILROADS FOR INITIALIZATION")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
;select Railroad for init
MouseClick("left", 1097, 614) ;click 'Add' (right 4th button)
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1334, 614) ; click 'Submit' (Right 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Accept\|{7}Cancel")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
;Sleep(8000); wait for system Configuration
;Find a pure Cyon pixel in the range 769, 537, 833, 585
Do
	Sleep(400)
	Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
Until Not @error

;Press Key to accept terms or cancel
MouseClick("left", 788, 614) ; click 'Accept' (Left 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Cancel\|Show All Railroads\|\[UP\]\|\[DOWN\]\|Select\|{3}")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
;Select Railroad for logon
MouseClick("left", 1097, 614) ;click 'Select' (right 4th button)
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1334, 614) ;click 'Submit' (right 1st button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{4}Cancel")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")

;TBC19_CLEARANCE_NUMBER_DIGITS                   5
;TBC46_EMPLOYEE_ID_DIGITS                        6
;TBC47_EMPLOYEE_PIN_DIGITS                       5

;6 clicks '>' at 1011,623
MouseClick("left", 1008, 614, 6) ; click 6 '>' (Left Fourth Button) for employee id
;$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{3}Done\|Cancel")
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1257, 614) ; click 'Done' (Right Second Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{4}Cancel")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")

; 5 clicks '>' at 1011,623
MouseClick("left", 1008, 614, 5) ; click 5 '>' (left Fourth Button) for employee pin
;$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{3}Done\|Cancel")
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1257, 614) ;click 'Done' (Right second Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|\[UP\]\|\[DOWN\]\|\[LEFT\]\|\[RIGHT\]\|{4}Cancel")
$Message[$i] = $Result[0]
$i = $i+1
; Wait for Verification
; Find a pure Blue pixel in the range
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
Do
	Local $coord = PixelSearch(1011, 600, 1029, 638, 0x0000FF)
Until Not @error

;5 clicks '>' at 1011,623
;MouseClick("left", 1008, 623, 5) ; click 5 '>' (Right Fourth Button) for clearance #00000
;Cleance # 99256
MouseClick("left", 860, 623, 1) ; click 1 'down' (Left 2nd Button) for clearance #9
MouseClick("left", 1008, 623, 1) ; click 1 '>' (Right Fourth Button) for clearance #shift right
MouseClick("left", 860, 623, 1) ; click 1 'down' (Left 2nd Button) for clearance #9
MouseClick("left", 1008, 623, 1) ; click 1 '>' (Right Fourth Button) for clearance #shift right
MouseClick("left", 778, 623, 2) ; click 2 'up' (Left 1nd Button) for clearance #2
MouseClick("left", 1008, 623, 1) ; click 1 '>' (Right Fourth Button) for clearance #shift right
MouseClick("left", 778, 623, 5) ; click 2 'up' (Left 1nd Button) for clearance #5
MouseClick("left", 1008, 623, 1) ; click 1 '>' (Right Fourth Button) for clearance #shift right
MouseClick("left", 778, 623, 6) ; click 2 'up' (Left 1nd Button) for clearance #6

MouseClick("left", 1257, 614) ;click 'Submit' (Right 2nd button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|CPRS\s{2}1234\sSELECTED\sFOR\sCPRS\sIS\sTHIS\sCORRECT\?")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
; wait for Train ID
;Sleep(8000)
; Find a pure Cyon pixel in the range
Do
	Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
Until Not @error

; Train ID display and CPRS 1234 selected for CPRS is this correct?
MouseClick("left", 744, 614) ; click 'Yes' (Left 1st button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|PRESS\sKEY\sTO\sMODIFY\sOR\sACCEPT\sCONSIST\sDATA\sOR\sREQUEST\sNEW\sCONSIST\sDATA")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
; wait for train ID conformation and Train consist
;Sleep(8000)
; Find a pure Cyon pixel in the range
Do
	Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
Until Not @error

MouseClick("left", 1334, 614) ;click 'Accept' (Right 1st Button) to accept Train ID and Consist
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{5}Begin\sTest\|{3}Cancel")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
; wait for train data and then departure test
;Sleep(8000)
; Find a pure Cyon pixel in the range
Do
	Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
Until Not @error
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

MouseClick("left", 1088, 622) ;click Begin Test (Right 4th button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{5}Run\sAudible\sTest\|{3}")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
;Sleep(25000)
; Find a pure Cyon pixel in the range
Do
	Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
Until Not @error

MouseClick("left", 1088, 622) ;click Run Audible Test (Right 4th button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{4}Fail\sTest\|\|Re\-run\sAudible\sTest\|\|Pass\sTest")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1344, 614) ;click Pass Test (Right 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{8}Exit")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1344, 614) ;click Exit (Right 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Mandatory\sDirectives\|Consist\|{6}Menu\s1")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;TestReport($Message)

EndFunc

