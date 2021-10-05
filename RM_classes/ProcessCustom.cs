using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLauncher.RM_classes
{
    class ProcessCustom
    {
        public static bool Kill(string name)
        {
            foreach (Process pc in Process.GetProcessesByName(name))
            {
                pc.Kill();
            }
            if (CheckOthersStats.ProcessExist(name) == true)
                return false;
            else return true;
        }
    }
}
