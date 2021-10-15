using MetroFramework;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher.RM_classes
{
    class DayZPath
    {
		public static string Locate()
		{
			string result;
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\bohemia interactive\\dayz");
				if (registryKey == null)
				{
					throw new ArgumentNullException("subKey");
				}
				result = registryKey.GetValue("MAIN").ToString();
			}
			catch 
			{
				return "Filed";
			}
			return result;
		}
	}
}
