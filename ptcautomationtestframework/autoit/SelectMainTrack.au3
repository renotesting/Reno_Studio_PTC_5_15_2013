#include <DebugClientMessage_Verify.au3>

Func SelectMainTrack ()
Dim $Result[1]
Dim $Message[15]
Local $i = 0

$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|\d\|D\|SELECT\sCURRENT\sTRACK")
$Message[$i] = $Result[0]
$i = $i+1
WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")
WinMove("CDU [D0403000][8 Hz] - {Active}", "", 713, 95)
; wait for prompt color show up
; Find a pure Cyon pixel in the range
Do
	Local $coord = PixelSearch(769, 537, 833, 585, 0x00FFFF)
Until Not @error
;Right 1st: 1334, 614
;Right 2nd: 1257, 614
;Right 3rd: 1174, 614
;Right 4th: 1097, 614
;Left 4th: 1008, 614
;Left 3rd: 927, 614
;Left 2nd: 860, 614
;Left 1th: 778, 614

MouseClick("left", 1097, 614) ; click 'Select' (Right 4th Button)

$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|PRM\|\d\|D\|YOU\sSELECTED\sMAIN\sOttumwa\sCPRS\.\sIS\sTHIS\sCORRECT\?")
$Message[$i] = $Result[0]
$i = $i+1


WinActivate("CDU [D0403000][8 Hz] - {Active}", "")
WinWait("CDU [D0403000][8 Hz] - {Active}")

MouseClick("left", 788, 614) ; click 'Yes' (Left 1st Button)

$Result = VerifyDebugClientMessage("\d\d\/\d\d\/\d{4}\|\d\d\:\d\d\:\d\d\.\d{3}\|\d\d\|KDP\|\d|Mandatory\sDirectives\|Consist\|{6}Menu\s1")
$Message[$i] = $Result[0]
$i = $i+1

EndFunc