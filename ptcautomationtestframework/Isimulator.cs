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
        string verifyDebugclientmessage(string message);

        void verifyBrakingEnforcementStop();
        void verifyNewUpdatedAuthority();

        void clearCurrentGoverningSignal();
        void firstInit();
        void reInit();

        void LocoMotion(double StartMP, double SetSPD, bool SetDirection);
        void LocoMotion_SetSPD(double speed);

        void selectMaintrack();

        void changeSwitchposition(bool position);
        void changeFacingSignal(string SG);

        bool testAnalysis_Tracklmt(double expctedEndMP);
        bool testAnalysis_SPDtgt(double speed);
        void testReportTMC();

    }
}
