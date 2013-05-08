;Delete none related messages

Func DeleteDebugClientMessage()
   WinActivate("Debug Client [", "") ; Clean Up all hitory text in Debug Client window
   WinWait("Debug Client [")
   Send("{Alt}+L")
   Send("F")
   Send("N")
EndFunc