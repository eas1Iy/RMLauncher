using System.IO;

namespace RMLauncher.RM_classes.DayZ
{
    class DayZCheckMods
    {
        public static string _pathMods = DayZPath.Locate() + "\\!Workshop\\";

        public static string[] RM_namalsk = {
                                    "@Russian Mafia",
                                    "@CF",
                                    "@BuildAnywhere_v3",
                                    "@VPPAdminTools",
                                    "@Advanced Weapon Scopes",
                                    "@Ear-Plugs",
                                    "@Namalsk Island",
                                    "@Namalsk Survival",
                                    "@Code Lock" };
        public static string[] RM_livoniaANDcherno = {
                                    "@Russian Mafia",
                                    "@CF",
                                    "@BuildAnywhere_v3",
                                    "@VPPAdminTools",
                                    "@Advanced Weapon Scopes",
                                    "@Ear-Plugs",
                                    "@Code Lock" };

        public static bool IsInstalledCheck(byte ID)
        {
            switch (ID)
            {
                case 1:
                    {
                        for (int i = 0; i < RM_namalsk.Length; i++)
                        {
                            if (Directory.Exists(_pathMods + RM_namalsk[i]))
                                return true;
                            else return false;
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < RM_livoniaANDcherno.Length; i++)
                        {
                            if (Directory.Exists(_pathMods + RM_livoniaANDcherno[i]))
                                return true;
                            else return false;
                        }
                        break;
                    }
            }
            return false;
        }
    }
}
