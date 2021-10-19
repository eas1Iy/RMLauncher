using RMLauncher.Properties;
using RMLauncher.RM_classes.DayZ;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RMLauncher.RM_classes
{
    class DayZLaunch
    {
        public static string _pathExe = DayZPath.Locate() + "\\DayZ_BE.exe";

        public static string _pathMods = DayZPath.Locate() + "\\!Workshop\\";

        public static string _pathModsDZSA = DayZPath.Locate() + "\\!dzsal\\";

        public static string _username = Settings.Default["username"].ToString();

        public static string RM_namalsk = $@"""-mod={_pathMods + "@CF"};{_pathMods + "@Russian Mafia"};{_pathMods + "@BuildAnywhere_v3"};{_pathMods + "@VPPAdminTools"};{_pathMods + "@Advanced Weapon Scopes"};{_pathMods + "@Namalsk Island"};{_pathMods + "@Namalsk Survival"};{_pathMods + "@Ear-Plugs"};{_pathMods + "@Code Lock"};""";

        public static string RM_cherno = $@"""-mod={_pathMods + "@CF"};{_pathMods + "@Russian Mafia"};{_pathMods + "@BuildAnywhere_v3"};{_pathMods + "@VPPAdminTools"};{_pathMods + "@Advanced Weapon Scopes"};{_pathMods + "@Ear-Plugs"};{_pathMods + "@Code Lock"};""";

        public static string RM_namalskDZSA = $@"""-mod={_pathModsDZSA + "@CF"};{_pathModsDZSA + "@Russian Mafia"};{_pathModsDZSA + "@BuildAnywhere_v3"};{_pathModsDZSA + "@VPPAdminTools"};{_pathModsDZSA + "@Advanced Weapon Scopes"};{_pathModsDZSA + "@Namalsk Island"};{_pathModsDZSA + "@Namalsk Survival"};{_pathModsDZSA + "@Ear-Plugs"};{_pathModsDZSA + "@Code Lock"};""";

        public static string RM_chernoDZSA = $@"""-mod={_pathModsDZSA + "@CF"};{_pathModsDZSA + "@Russian Mafia"};{_pathModsDZSA + "@BuildAnywhere_v3"};{_pathModsDZSA + "@VPPAdminTools"};{_pathModsDZSA + "@Advanced Weapon Scopes"};{_pathModsDZSA + "@Ear-Plugs"};{_pathModsDZSA + "@Code Lock"};""";

        public static string ip = "185.189.255.184";
        public static string port_namalsk = "2402";
        public static string port_cherno = "2302";

        public static string _gameArgument;

        public static Process GameProcess;

        public static bool IsWindow = Convert.ToBoolean(Settings.Default["window"]); // -window
        public static bool IsHight = Convert.ToBoolean(Settings.Default["hight"]); // GameProcess.PriorityClass = ProcessPriorityClass.High;

        public static bool GameStart(byte ID)
        {
            if (DayZCheckMods.IsInstalledCheck(ID) == true)
            {
                if (!CheckOthersStats.DayZ() && CheckOthersStats.Steam())
                {
                    switch (ID)
                    {
                        case 1: // namalsk
                            {
                                if(DayZCheckMods.IsDZSAModsCheck(1) == false)
                                {
                                    if (IsWindow)
                                        _gameArgument = $@"{RM_namalsk} -window -skipIntro -noPause -connect={ip} -port={port_namalsk} -name={_username}";
                                    else _gameArgument = $@"{RM_namalsk} -skipIntro -noPause -connect={ip} -port={port_namalsk} -name={_username}";
                                } 
                                else
                                {
                                    if (IsWindow)
                                        _gameArgument = $@"{RM_namalskDZSA} -window -skipIntro -noPause -connect={ip} -port={port_namalsk} -name={_username}";
                                    else _gameArgument = $@"{RM_namalskDZSA} -skipIntro -noPause -connect={ip} -port={port_namalsk} -name={_username}";
                                }

                                if (GameLaunch() == true) { return true; } else return false;
                            }
                        case 2: // cherno 1pp
                            {
                                if (DayZCheckMods.IsDZSAModsCheck(2) == false)
                                {
                                    if (IsWindow)
                                        _gameArgument = $@"{RM_cherno} -window -skipIntro -noPause -connect={ip} -port={port_cherno} -name={_username}";
                                    else _gameArgument = $@"{RM_cherno} -skipIntro -noPause -connect={ip} -port={port_cherno} -name={_username}";
                                }
                                else
                                {
                                    if (IsWindow)
                                        _gameArgument = $@"{RM_chernoDZSA} -window -skipIntro -noPause -connect={ip} -port={port_cherno} -name={_username}";
                                    else _gameArgument = $@"{RM_chernoDZSA} -skipIntro -noPause -connect={ip} -port={port_cherno} -name={_username}";
                                }
                                    
                                if (GameLaunch() == true) { return true; } else return false;
                            }
                        default: return false;
                    }
                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }

        public static bool GameLaunch()
        {
            gameCheck:
            if (!CheckOthersStats.DayZ())
            {
                GameProcess = new Process();
                GameProcess.StartInfo.FileName = _pathExe;
                GameProcess.StartInfo.Arguments = _gameArgument;

               // if (IsHight) GameProcess.PriorityClass = ProcessPriorityClass.High;

                GameProcess.StartInfo.Verb = "runas";
                GameProcess.Start();
                return true;
            }
            else
            {
                if (CheckOthersStats.ProcessExist("DayZ_BE.exe"))
                ProcessCustom.Kill("DayZ_BE.exe");
                else if (CheckOthersStats.ProcessExist("DayZ_x64.exe"))
                    ProcessCustom.Kill("DayZ_x64.exe");

                goto gameCheck;
            }
        }
    }
}
