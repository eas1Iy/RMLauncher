using MetroFramework;
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
        public string ip_namalsk = "185.189.255.184:27016"; // 1
        public string ip_epoch = "185.189.255.184:27024"; // 2
        public string ip_cherno = "185.189.255.184:27017"; // 3 (1pp)
        public string ip_cherno2 = "185.189.255.184:27023"; // 4 (3pp)

        IServerQuery serverQuery;

        string serverInfo;
        string serverOnline;
        int serverPing;

        public void GetServer(int serverID)
        {
            if (serverID != 0 && serverID < 5)
                GetInfromationAboutServer(serverID);
        }

        public string GetInfromationAboutServer(int serverID)
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

            return $"Онлайн: {serverInfo.Players}/{serverInfo.MaxPlayers}";
        }
    }
}
