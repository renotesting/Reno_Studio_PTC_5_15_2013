#include <GUIConstantsEx.au3>
#include <GuiRichEdit.au3>
#include <GuiEdit.au3>
#include <DebugClientMessage_Delete.au3>


Func VerifyDebugClientMessage(Const $Message)

Local $Allmessage, $asResult
WinActivate("Debug Client [", "")
WinWait("Debug Client [")

Do
   $Allmessage = WinGetText("Debug Client [")
   $asResult = StringRegExp($Allmessage, $Message, 1)
Until StringRegExp($Allmessage, $Message)

DeleteDebugClientMessage()

Return $asResult

EndFunc

