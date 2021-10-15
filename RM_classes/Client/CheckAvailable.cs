using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLauncher.RM_classes
{
    class CheckAvailable
    {
        public static bool CheckStartAvailable()
        {
            return true;
        }

        public static bool CheckConnectionAvailable()
        {
            if (GetInternetConnection.CheckConnection())
                return true;
            else return false;
        }
    }
}
