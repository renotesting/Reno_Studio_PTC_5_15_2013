; #include <SelectMainTrack.au3>
; #include <DebugClientMessage_Verify.au3>
; #include <TestReport.au3>

Func LocoMotion_SetSPD($SetSPD, $TargetTxt)

Dim $Result[1]
Dim $Message[1]
Local $i = 0

;~ Close Motion Control - Headding window if exist
If WinExists("Motion Control - Heading", "") Then
  WinClose("Motion Control - Heading", "")
EndIf

;Activate and Focus on the Loco window
WinActivate("Loco[CPRS  1234]", "")
WinMove("Loco[CPRS  1234]", "", 810, 39)

WinActivate("Loco[CPRS  1234]", "")
Send("{Alt}+M")
Send("Controls...")

WinActivate("Motion Control - Heading","")
WinMove("Motion Control - Heading", "", 810, 192)
; Set Block dropdown MP"
Send("{TAB 2}")
Send("{DOWN}")

; Set Current Speed
Send("{TAB 7}")
; Send(15) ;debug purpose
Send($SetSPD)
; Hit the Set button to change the speed
Send("+{TAB 1}")
Send("{SPACE}")

;Sleep(5000)

;~ $Result = VerifyDebugClientMessage($TargetTxt)
;~ $Message[$i] = $Result[0]
;~ $i = $i+1

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;TestReport($Message)

EndFunc