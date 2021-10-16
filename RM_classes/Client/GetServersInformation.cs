﻿using MetroFramework;
using RMLauncher.RM_Forms;
using SteamQueryNet;
using SteamQueryNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLauncher.RM_classes
{
    class GetServersInformation
    {
        public static string ip_namalsk = "185.189.255.184:27016"; // 1
        public static string ip_epoch = "185.189.255.184:27024"; // 2
        public static string ip_cherno = "185.189.255.184:27017"; // 3 (1pp)
        public static string ip_cherno2 = "185.189.255.184:27023"; // 4 (3pp)

        IServerQuery serverQuery;

        public int serversAllOnline = 0;

        public string GetOnlineServer(int serverID)
        {
            

            switch (serverID)
            {
                case 1: 
                    serverQuery = new ServerQuery(ip_namalsk); 
                    break;
                case 2: 
                    serverQuery = new ServerQuery(ip_epoch);  
                    break;
                case 3: 
                    serverQuery = new ServerQuery(ip_cherno); 
                    break;
                case 4: 
                    serverQuery = new ServerQuery(ip_cherno2); 
                    break;
                default: break;
            }

            SteamQueryNet.Models.ServerInfo serverInfo = serverQuery.GetServerInfo();
            OnlineAll(serverInfo.Players);
            return $"{serverInfo.Players}/{serverInfo.MaxPlayers}";
        }

        public int GetPingServer(int serverID)
        {
            switch (serverID)
            {
                case 1: serverQuery = new ServerQuery(ip_namalsk); break;
                case 2: serverQuery = new ServerQuery(ip_epoch); break;
                case 3: serverQuery = new ServerQuery(ip_cherno); break;
                case 4: serverQuery = new ServerQuery(ip_cherno2); break;
                default: break;
            }

            SteamQueryNet.Models.ServerInfo serverInfo = serverQuery.GetServerInfo();

            return Convert.ToInt32(serverInfo.Ping);
        }

        public int OnlineAll(int tempOnline)
        {
            return serversAllOnline += tempOnline;
        }
    }
}