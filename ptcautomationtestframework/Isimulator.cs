using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    interface Isimulator
    {
        void setSimulator();
        void cleanDebugclientmessage();
        void deleteDebugClientmessage();
        void verifyDebugclientmessage();

        void verifyBrakingEnforcementStop();
        void verifyNewUpdatedAuthority();

        void clearCurrentGoverningSignal();
        void firstInit();
        void reInit();

        void LocoMotion(bool direction);
        void LocoMotion_SetSPD(float speed);

        void selectMaintrack();

        void changeSwitchposition(bool position);
        void changeFacingSignal(int SG);

        bool testAnalysis_Tracklmt(float expctedEndMP);
        bool testAnalysis_SPDtgt(float speed);
        void testReportTMC();

    }
}
