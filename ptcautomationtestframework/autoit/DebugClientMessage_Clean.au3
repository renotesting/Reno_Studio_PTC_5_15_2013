;; This is compatible to IETMS6.3.8 Simulator

#include <GUIConstantsEx.au3>
#include <GuiListView.au3>

Func DebugClientMessage_Clean()

Local $hHandle, $iIndex

If WinExists("Log Manager") Then
    WinClose("Log Manager", "")
EndIf

WinActivate("Debug Client [", "")
WinWait("Debug Client [")
WinMove("Debug Client [","", 78, 224)
Send("{Alt}+L")
Send("View")
Send("Manager...")
Send("{ENTER}")

;Clear Comparator
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
send("{PGUP 10}")
$hHandle = ControlGetHandle("Log Manager", "", 1009)
$iIndex = _GUICtrlListView_FindText($hHandle, "COMPARATOR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2)

WinActivate("Log Severity - COMPARATOR","")
WinWait("Log Severity - COMPARATOR")
ControlClick ( "Log Severity - COMPARATOR", "Clear All", 1310)
ControlClick ( "Log Severity - COMPARATOR", "OK", 1)

;Clear TEST_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindText($hHandle, "TEST_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ;Double Click TEST_MGR

WinActivate("Log Severity - TEST_MGR","")
WinWait("Log Severity - TEST_MGR")
ControlClick ( "Log Severity - TEST_MGR", "Clear All", 1310)
ControlClick ( "Log Severity - TEST_MGR", "OK", 1)

;Clear SW_Update
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "SW_UPDATE")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ;Double Click SW_UPDATE item

WinActivate("Log Severity - SW_UPDATE","")
WinWait("Log Severity - SW_UPDATE")
ControlClick ( "Log Severity - SW_UPDATE", "Clear All", 1310)
ControlClick ( "Log Severity - SW_UPDATE", "OK", 1)

;Clear GPS
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "GPS")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click GPS item

WinActivate("Log Severity - GPS","")
WinWait("Log Severity - GPS")
ControlClick ( "Log Severity - GPS", "Clear All",1310)
ControlClick ( "Log Severity - GPS", "OK", 1)

;Clear Fault_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "FAULT_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click Fault_MGR item

WinActivate("Log Severity - FAULT_MGR","")
WinWait("Log Severity - FAULT_MGR")
ControlClick ( "Log Severity - FAULT_MGR", "Clear All", 1310)
ControlClick ( "Log Severity - FAULT_MGR", "OK", 1)

;Clear Train_Data_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "TRAIN_DATA_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click Train_Data_MGR item

WinActivate("Log Severity - TRAIN_DATA_MGR","")
WinWait("Log Severity - TRAIN_DATA_MGR")
ControlClick ( "Log Severity - TRAIN_DATA_MGR", "Clear All", 1310)
ControlClick ( "Log Severity - TRAIN_DATA_MGR", "OK", 1)

;Clear Wheel_calibration
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "WHEEL_CALIBRATION")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click Wheel_calibration item

WinActivate("Log Severity - WHEEL_CALIBRATION","")
WinWait("Log Severity - WHEEL_CALIBRATION")
ControlClick ("Log Severity - WHEEL_CALIBRATION", "Clear All", 1310)
ControlClick ("Log Severity - WHEEL_CALIBRATION", "OK", 1)

;Clear HOT_MONITOR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "HOT_MONITOR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click HOT_MONITOR item

WinActivate("Log Severity - HOT_MONITOR","")
WinWait("Log Severity - HOT_MONITOR")
ControlClick ("Log Severity - HOT_MONITOR", "Clear All", 1310)
ControlClick ("Log Severity - HOT_MONITOR", "OK", 1)

;Clear TMC_LRU_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "TMC_LRU_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click TMC_LRU_MGR item

WinActivate("Log Severity - TMC_LRU_MGR","")
WinWait("Log Severity - TMC_LRU_MGR")
ControlClick ("Log Severity - TMC_LRU_MGR", "Clear All", 1310)
ControlClick ("Log Severity - TMC_LRU_MGR", "OK", 1)

;Clear DIAG_SERVER
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "DIAG_SERVER")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click DIAG_SERVER item

WinActivate("Log Severity - DIAG_SERVER","")
WinWait("Log Severity - DIAG_SERVER")
ControlClick ("Log Severity - DIAG_SERVER", "Clear All", 1310)
ControlClick ("Log Severity - DIAG_SERVER", "OK", 1)

;Clear IOC_CAB_SIGNAL_MONITOR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "IOC_CAB_SIGNAL_MONITOR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click IOC_CAB_SIGNAL_MONITOR item

WinActivate("Log Severity - IOC_CAB_SIGNAL_MONITOR","")
WinWait("Log Severity - IOC_CAB_SIGNAL_MONITOR")
ControlClick ("Log Severity - IOC_CAB_SIGNAL_MONITOR", "Clear All", 1310)
ControlClick ("Log Severity - IOC_CAB_SIGNAL_MONITOR", "OK", 1)

;Clear SWITCH_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "SWITCH_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click SWITCH_MGR item

WinActivate("Log Severity - SWITCH_MGR","")
WinWait("Log Severity - SWITCH_MGR")
ControlClick ("Log Severity - SWITCH_MGR", "Clear All", 1310)
ControlClick ("Log Severity - SWITCH_MGR", "OK", 1)

;Clear HORN_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "HORN_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click HORN_MGR item

WinActivate("Log Severity - HORN_MGR","")
WinWait("Log Severity - HORN_MGR")
ControlClick ("Log Severity - HORN_MGR", "Clear All", 1310)
ControlClick ("Log Severity - HORN_MGR", "OK", 1)

;Clear WAYSIDE_MGR
WinActivate("Log Manager","")
WinWait("Log Manager")
WinMove("Log Manager", "", 74, 250)
$iIndex = _GUICtrlListView_FindInText($hHandle, "WAYSIDE_MGR")
_GUICtrlListView_ClickItem($hHandle, $iIndex, "left", False, 2) ; Double Click WAYSIDE_MGR item

WinActivate("Log Severity - WAYSIDE_MGR","")
WinWait("Log Severity - WAYSIDE_MGR")
ControlClick ("Log Severity - WAYSIDE_MGR", "Clear All", 1310)
ControlClick ("Log Severity - WAYSIDE_MGR", "OK", 1)

;
WinActivate("Log Manager")
WinClose("Log Manager") ; Close Log Manager

;Delete none related messages
WinActivate("Debug Client [", "") ; Clean Up all hitory text in Debug Client window
WinWait("Debug Client [")
WinMove("Debug Client [","", 78, 224)
Send("{Alt}+L")
Send("F")
Send("N")

EndFunc
