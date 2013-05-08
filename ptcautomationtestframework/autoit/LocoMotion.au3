; #include <SelectMainTrack.au3>

Func LocoMotion($StartMP, $SetSPD, $SetDirection)
;Close LocoSimulator if exist
If WinExists("Motion Control - ", "") Then
  WinClose("Motion Control - ", "")
  Sleep(1000)
  RunWait("C:\Ubuntu\Simulators\Vital-LocoSimulator.exe")
EndIf

;Activate and Focus on the CDU window
WinActivate("Loco[CPRS  1234]", "")
WinMove("Loco[CPRS  1234]", "", 810, 39)

Send("{Alt}+F")
Send("T")
Send("L")
Send("S")
;Send("CPRS.00153.66.opk")

WinActivate("Open", "")
ControlSetText("Open", "", "[CLASS:Edit; ID:1148]", "CPRS.00153.70.opk")
Send("{TAB 2}")
Send("{ENTER}")
;Sleep(5000)
;ControlClick("Open", "", "[CLASS:Button; ID: 1; INSTANCE:2]")

WinActivate("Loco[CPRS  1234]", "")
Send("{Alt}+M")
Send("Controls...")

WinActivate("Motion Control - Heading","")
WinMove("Motion Control - Heading", "", 810, 192)
;MouseClick("left", 932, 245) ;click 'Sub' dropdown
Send("{DOWN}")
;MouseClick("left", 929, 261) ;click dropdown "153 [CPRS]"
Send("{TAB 2}")
;MouseClick("left", 1101, 246) ;click dropdown "Offset" and "MP"
;MouseClick("left", 1101, 278) ;click dropdown "MP"
Send("{DOWN}")

;MouseClick("left", 1165, 245) ;click MP input
Send("{TAB}")
;~ Send(230.8000)
; Input head end starting MP for locomotive
send($StartMP)

; Move to Direction option check box
Send("{TAB 1}")
Local $checkButtonstatus = ControlCommand("Motion Control - Heading", "DEC", "[CLASS:Button; ID:1043]", "IsChecked", "")
if $SetDirection = 1 AND $checkButtonstatus = 0 Then ;Decreasing and never checked
	Send("{SPACE}")
	Send("{TAB 1}")
ElseIf $SetDirection = 1 AND $checkButtonstatus = 1 Then ;Decreasing but checked
	Send("{TAB 1}")
ElseIf $SetDirection = 0 AND $checkButtonstatus = 0 Then ; Increasing and never checked
	Send("{TAB 1}")
ElseIf $SetDirection = 0 AND $checkButtonstatus = 1 Then  ; Increasing but checked
	Send("{SPACE}")   ; unCheck it
	Send("{TAB 1}")
EndIf

; Hit Set button
Send("{SPACE}")
;Select Main or Siding on pop up "Select Milepost Dialog"
WinActivate("Select Milepost", "")
Send("{SPACE}")


;MouseClick("left", 1169, 465) ;click Speed Control
Send("{TAB 4}")
;Send("{END}")
;Send("{LSHIFT}+{HOME}")
;Send("{DEL 7}")
Sleep(2000)
;~ Send(5.00)
Send($SetSPD)
;MouseClick("left", 1127, 464)
Send("+{TAB 1}")
Send("{SPACE}")
Sleep(1000)


EndFunc