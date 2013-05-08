#include <CompInfo.au3>
#include <GUIConstantsEx.au3>
#include <GuiListView.au3>

Func GatherTestStationInfo()
;GET Test Workstation
Dim $System

_ComputerGetSystem($System)
If @error Then
	$error = @error
	$extended = @extended
	Switch $extended
		Case 1
			_ErrorMsg("Array contains no information.")
		Case 2
			_ErrorMsg("$colItems isnt an object.")
	EndSwitch
 EndIf

For $i = 1 To $System[0][0] Step 1
	Send("Test _ComputerGetSystem: " & $System[$i][0] & @CRLF & _
											"Current Time Zone: " & $System[$i][11] & @CRLF & _
											"Domain: " & $System[$i][13] & @CRLF & _
											"Manufacturer: " & $System[$i][21] & @CRLF & _
											"Model: " & $System[$i][22] & @CRLF & _
											"Number Of Processors: " & $System[$i][25] & @CRLF & _
											"System Type: " & $System[$i][46] & @CRLF & _
											"Total Physical Memory: " & $System[$i][48] & @CRLF & _
											"User Name: " & $System[$i][49] & @CRLF)
Next

;GET TMDS VERSION
Local $TMDStitle = WinGetTitle("Train Management and Dispatch System (TMDS)", "")
Send("Current TMDS version is: " & $TMDStitle )
Send('{ENTER 2}')
;GET BOS VERSION
Local $BOStitle = WinGetTitle("POSITIVE TRAIN CONTROL - BACK OFFICE SERVER", "")
Send("Current BOS version is: " & $BOStitle)
Send('{ENTER 2}')

EndFunc
