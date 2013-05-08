#include <GUIConstantsEx.au3>
#include <GuiListView.au3>

Func ClearCurrentGoverningSignal()
Local $hHandle, $iIndex

If WinExists("Debug Client Session") Then
    WinClose("Debug Client Session", "")
EndIf

If WinExists("Signal Authority Pages") Then
    WinClose("Signal Authority Pages", "")
EndIf

If WinExists("Current Governing Signal") Then
    WinClose("Current Governing Signal", "")
EndIf

$hHandle = WinActivate("Debug Client [", "")
WinWait("Debug Client [")
Send("{ALT}+B")
Send("{ENTER}")

WinActivate("Debug Client Session","")
WinWait("Debug Client Session")
send("{PGUP 10}")
$hHandle = ControlGetHandle("Debug Client Session", "", 1010)
$iIndex = _GUICtrlListView_FindText($hHandle, "Signal Authority Pages...")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2)

WinActivate("Signal Authority Pages","")
WinWait("Signal Authority Pages")
$hHandle = ControlGetHandle("Signal Authority Pages", "", 1010)
$iIndex = _GUICtrlListView_FindText($hHandle, "Current Governing Signal")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2)

WinActivate("Current Governing Signal","")
WinWait("Current Governing Signal")
ControlClick ( "Current Governing Signal", "Override", 1015)

WinClose("Current Governing Signal","")
WinClose("Signal Authority Pages","")
WinClose("Debug Client Session","")

EndFunc
