using MetroFramework;
using RMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLauncher.RM_classes
{
    class themeChanger
    {
        public static MetroColorStyle StyleChanger()
        {
            MetroColorStyle result;

            string tempColor = Settings.Default["style"].ToString();

            if (tempColor == "Red") result = MetroColorStyle.Red;
            else if (tempColor == "Green") result = MetroColorStyle.Green;
            else if (tempColor == "Black") result = MetroColorStyle.Black;
            else result = MetroColorStyle.Red;

            return result;
        }
    }
}
