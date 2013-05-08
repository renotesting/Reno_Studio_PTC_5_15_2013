#include <DebugClientMessage_Clean.au3>
#include <FirstInit.au3>
#include <LocoMotion.au3>
#include <LocoMotion_SetSPD.au3>
#include <ClearCurrentGoverningSignal.au3>
#include <VerifyBrakingEnforcementStop.au3>

;Case 2
;Speed Track SPD Predictive Enforcement testing
ClearCurrentGoverningSignal()
Sleep(8000)
LocoMotion_SetSPD(40, "Mocking")
Sleep(8000)
LocoMotion_SetSPD(43, "Mocking") ;Warning Enforcement
Sleep(8000)
LocoMotion_SetSPD(45, "Mocking") ;Braking Enforcement
VerifyBrakingEnforcementStop()

;Case 3
;End of Authority Predictive Enforcement testing
ClearCurrentGoverningSignal()
LocoMotion(228.0000, 5, 1)
Sleep(8000)
LocoMotion_SetSPD(25, "Mocking")
VerifyBrakingEnforcementStop()
