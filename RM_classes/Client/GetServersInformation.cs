using MetroFramework;
using RMLauncher.RM_Forms;
using SteamQueryNet;
using SteamQueryNet.Interfaces;
using SteamQueryNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher.RM_classes
{
    class GetServersInformation
    {
        public string ip_namalsk = "185.189.255.184:27017"; // 2402 или 27017
        public string ip_cherno = "185.189.255.184:27016"; // 2302 или 27016
        public string ip_cherno3 = "185.189.255.184:27023"; // 2602 или 27023

        IServerQuery serverQuery;
        SteamQueryNet.Models.ServerInfo serverInfo;

        public int serversAllOnline = 0;

        public string GetOnlineServer(int serverID)
        {
            try
            {
                switch (serverID)
                {
                    case 1:
                        {
                            serverQuery = new ServerQuery(ip_namalsk);
                            break;
                        }
                    case 2:
                        {
                            serverQuery = new ServerQuery(ip_cherno);
                            break;
                        }
                    case 3:
                        {
                            serverQuery = new ServerQuery(ip_cherno3);
                            break;
                        }
                }

                serverInfo = serverQuery.GetServerInfo();

                OnlineAll(serverInfo.Players);

                return $"{serverInfo.Players}/{serverInfo.MaxPlayers}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetPingServer(int serverID)
        {
            try
            {
                switch (serverID)
                {
                    case 1:
                        {
                            serverQuery = new ServerQuery(ip_namalsk);
                            break;
                        }
                    case 2:
                        {
                            serverQuery = new ServerQuery(ip_cherno);
                            break;
                        }
                    case 3:
                        {
                            serverQuery = new ServerQuery(ip_cherno3);
                            break;
                        }
                }

                serverInfo = serverQuery.GetServerInfo();

                return Convert.ToInt32(serverInfo.Ping);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int OnlineAll(int tempOnline)
        {
            try
            {
                return serversAllOnline += tempOnline;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
