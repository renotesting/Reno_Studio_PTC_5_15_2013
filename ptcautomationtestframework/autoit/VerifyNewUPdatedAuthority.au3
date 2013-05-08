#include <DebugClientMessage_Verify.au3>


Func VerifyNewUpdateAuthority()

WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
WinMove("CDU [D0403000][8 Hz] - {Active}", "", 713, 95)

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

Dim $Result[1]
Dim $Message[15]
Local $i = 0

$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|AUTHORITY\sCHANGE\sRECEIVED\sPRESS\sKEY\sTO\sREVIEW")
$Message[$i] = $Result[0]
$i = $i+1
;~ $Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|{5}Review\|{3}")
;~ $Message[$i] = $Result[0]
;~ $i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1097, 614) ; click 'Review' (Right 4th Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|1\|D\|PRESS\sKEY\sTO\sACKNOWLEDGE\sTHIS\sAUTHORITY")
$Message[$i] = $Result[0]
$i = $i+1
;~ $Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\{2}\[UP\]\|\[DOWN\]\|\|Acknow\sledge\|{3}")
;~ $Message[$i] = $Result[0]
;~ $i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 1097, 614) ; click 'Acknowledge' (Right 4th Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Return\|{6}")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
MouseClick("left", 778, 614) ; click 'Return' (Left 1st Button)
$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|2\|Mandatory\sDirectives\|Consist\|\|Switching\sMode\sOn\|{4}Menu\s1")
$Message[$i] = $Result[0]
$i = $i+1

EndFunc