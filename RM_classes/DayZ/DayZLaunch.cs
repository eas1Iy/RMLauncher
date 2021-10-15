using RMLauncher.RM_classes.DayZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLauncher.RM_classes
{
    class DayZLaunch
    {
        public bool GameStart(byte ID)
        {
            if (DayZCheckMods.IsInstalledCheck(ID) == true)
            {
                //
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
