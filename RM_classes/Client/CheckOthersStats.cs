using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLauncher.RM_classes
{
    class CheckOthersStats
    {
        public static bool Steam()
        {
            if (ProcessExist("Steam"))
                return true;
            else return false;
        }

        public static bool DayZ()
        {
            if (ProcessExist("DayZ_x64.exe"))
                return true;
            else return false;
        }

        public static bool ProcessExist(string name)
        {
            Process[] processList = Process.GetProcessesByName(name);
            if (processList.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
