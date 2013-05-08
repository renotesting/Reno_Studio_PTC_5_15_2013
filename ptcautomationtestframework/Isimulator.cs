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
        void verifyDebugclientmessage();
        void firstInit();
        void reInit();
        void clearcurrentSignal();
        void readparams_comm_CPRS();
        void readparams_CPRS();

        void LocoMotion(bool direction);
        
        void changeSwitchposition();
        void changeSignalGoverning();
        
        void testReportTMC();

    }
}
