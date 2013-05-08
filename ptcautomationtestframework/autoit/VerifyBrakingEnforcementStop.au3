<<<<<<< HEAD
;~ VerifyBrakingEnforcementStop
#include <GuiEdit.au3>

Func VerifyBrakingEnforcementStop()
Local $MP, $CurrentSpd
WinActivate("Motion Control - Heading", "")
WinWait("Motion Control - Heading")

Do
	$hHandle = ControlGetHandle("Motion Control - Heading", "", 1053)
	$MP = _GUICtrlEdit_GetText($hHandle)

	$hHandle = ControlGetHandle("Motion Control - Heading", "", 1032)
	$CurrentSpd = _GUICtrlEdit_GetText($hHandle)
Until $CurrentSpd = 0
EndFunc
=======
; VerifyBrakingEnforcementStop

Func VerifyBrakingEnforcementStop()
Local $Allmessage
WinActivate("Debug Client [", "")
WinWait("Debug Client [")
Do
	Sleep(3000)
	$Allmessage = WinGetText("Debug Client [")
	DeleteDebugClientMessage()
Until StringRegExp($Allmessage, '(\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d{2}\|BNR\|\d\|R\|BRAKING\sIN\sPROGRESS)', 0)
EndFunc


;~ Local $currentSPD, $promptRemoval, $pattern1, $pattern2
;~ $pattern1 = '(SYS\s\:\d{4}\/\d\d\/\d\d\s\d\d\:\d\d\:\d\d\.\d{3}\:ENFORCEMENT\:Enforcement\sdata\:\s{2}SPD\:[\d]\d\.\dmph.{366})'
;~ $pattern2 = '(\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d{2}\|BNR\|\d\|R\|BRAKING\sIN\sPROGRESS)'
;~ 	$currentSPD = StringRegExp($Allmessage, '(SYS\s\:\d{4}\/\d\d\/\d\d\s\d\d\:\d\d\:\d\d\.\d{3}\:ENFORCEMENT\:Enforcement\sdata\:\s{2}SPD\:[\d]\d\.\dmph.{366})', 1)
;~ 	$promptRemoval = StringRegExp($Allmessage, '(\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d{2}\|BNR\|\d\|R\|BRAKING\sIN\sPROGRESS)', 1)
	;Sleep(2000)
	;MsgBox(4096, "All Message", $Allmessage)
	;MsgBox(0, "test", $currentSPD[0])
	;MsgBox(0, "test", $promptRemoval[0])LFN
	;Sleep(5000)


;~ SYS :2013/04/04 14:30:39.360:ENFORCEMENT:Enforcement data:  SPND:5.5mph
;~ SYS :2013/04/04 15:30:01.121:ENFORCEMENT:Enforcement data:  SPD:20.7mph
;~ 04/05/2013|13:16:03.592|12|BNR|1|R|BRAKING IN PROGRESS
;~ 04/05/2013|13:16:04.871|14|KDP|2|Mandatory Directives|Consist||Switching Mode On||||Menu 1


;~ 04/04/2013|15:30:01.755|6|LOC|2|20.71|15|CPRS|153|MAIN|230.3612|14023|16981|CPRS|153|MAIN|230.7371|14023|18981|2|5
;~ 04/04/2013|16:02:59.582|6|LOC|2|20.71|15|CPRS|153|MAIN|230.3168|14023|16745|CPRS|153|MAIN|230.6927|14023|18745|2|5



;~ WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
;~ WinWait("CDU [D0403000][8 Hz] - {Active}")
;~ WinMove("CDU [D0403000][8 Hz] - {Active}", "", 713, 95)
;~ ; Find a pure Black pixel in the range at prompt position
;~ ; Braking Enforcement Propmt Color:  16711680 - FF0000   Red
;~ While Not @error
;~ 	Local $coord = PixelSearch(769, 537, 833, 585, 0xFF0000)
;~ Wend

;DeleteDebugClientMessage()

;~ VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d{2}\|BNR\|\d\|R\|BRAKING\sIN\sPROGRESS")
;~ DeleteDebugClientMessage()



>>>>>>> dev
