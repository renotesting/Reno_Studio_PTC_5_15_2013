#include <DebugClientMessage_Clean.au3>
#include <FirstInit.au3>
#include <LocoMotion.au3>
#include <LocoMotion_SetSPD.au3>
#include <ClearCurrentGoverningSignal.au3>
#include <VerifyBrakingEnforcementStop.au3>

DebugClientMessage_Clean()
FirstInit()
LocoMotion(230.8000, 5, 1) ; Argument list: MP, Speed, Direction
SelectMainTrack()
Sleep(5000)

;Case 1
;Speed RST SPD Reactive EnfoLFNrcement testing
LocoMotion_SetSPD(15, "Mocking")
Sleep(8000)
LocoMotion_SetSPD(17, "Mocking")
Sleep(8000)
LocoMotion_SetSPD(18, "Mocking") ;Warning Enforcement
Sleep(8000)
LocoMotion_SetSPD(20, "Mocking") ;Braking Enforcement
VerifyBrakingEnforcementStop()



