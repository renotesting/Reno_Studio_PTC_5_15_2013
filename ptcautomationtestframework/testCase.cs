using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCAutomationTestFramework
{
    class testCase
    {
        trackWarrantLine2_4 tw_Line2 = new trackWarrantLine2_4();
        trackWarrantLine2_4 tw_Line4 = new trackWarrantLine2_4();
        trackWarrantLine2_4and7 tw_Line2_7 = new trackWarrantLine2_4and7();
        trackWarrantLine2_4and7 tw_Line4_7 = new trackWarrantLine2_4and7();
        trackWarrantLine2_4and11 tw_Line2_11 = new trackWarrantLine2_4and11();
        trackWarrantLine2_4and11 tw_Line4_11 = new trackWarrantLine2_4and11();
        
        Onboard_Simulator tmc = new Onboard_Simulator();

        //line 2 overload
        public void runTestcase(int line, float sMP, float eMP, bool direction)
        {
            tw_Line2.issuance(line, sMP, eMP, direction);
            tw_Line2.run();
            tmc.firstInit_run(direction);
        }
        //line 4 overload
        public void runTestcase_Line4(int line, float sMP, float eMP, bool direction)
        {
            tw_Line4.issuance(line, sMP, eMP);
            tw_Line4.run();
            tmc.firstInit_run(direction);
        }

        //line 2 with 7 overload
        public void runTestcase(int line, float sMP, float eMP, float meetAtMP, Boolean direction)
        {
            tw_Line2_7.issuance(line, sMP, eMP, meetAtMP, direction);
            tw_Line2_7.run();
            tmc.firstInit_run(direction);
        }

        //line 4 with 7 overload
        public void runTestcase_Line4_7(int line, float sMP, float eMP, float meetAtMP, Boolean direction)
        {
            tw_Line4_7.issuance(line, sMP, eMP, meetAtMP);
            tw_Line4_7.run();
            tmc.firstInit_run(direction);
        }

        //line 2 with 11 overload
        public void runTestcase(int line, float sMP, float eMP, float jsMP, float jeMP, Boolean direction)
        {
            tw_Line2_11.issuance(line, sMP, eMP, jsMP, jeMP, direction);
            tw_Line2_11.run();
            tmc.firstInit_run(direction);
        }

        //line 4 with 11 overload
        public void runTestcase_Line4_7(int line, float sMP, float eMP, float jsMP, float jeMP, Boolean direction)
        {
            tw_Line4_11.issuance(line, sMP, eMP, jsMP, jeMP);
            tw_Line4_11.run();
            tmc.firstInit_run(direction);
        }

    }
}
