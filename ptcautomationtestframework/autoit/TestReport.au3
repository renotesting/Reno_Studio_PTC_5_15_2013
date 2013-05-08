;; This function can take unknown size of array as an argument  within function parameter
;; http://www.autoitscript.com/forum/topic/8956-array-as-function-parameter/

;~#include <TestStationInfo_Gathering.au3>

Func TestReport(ByRef $Msg)
Run("notepad.exe")
WinWaitActive("Untitled - Notepad")

ReDim $Msg[UBound($Msg)+1]
Local $j = 0

For $j = 0 To UBound($Msg)-1 Step 1
   Send($Msg[$j] & '{TAB 6}' & "VERIFYED & PASSED")
   Send('{ENTER}')
Next
WinClose("Untitled - Notepad")
WinWaitActive("Notepad", "Save")
Send("!s")
WinWaitActive("Save As")
Send("Test Report")
Send("!s")

EndFunc