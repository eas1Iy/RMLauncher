using MetroFramework;
using RMLauncher.Properties;
using RMLauncher.RM_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher
{
    public partial class RMForm : MetroFramework.Forms.MetroForm
    {
        #region Загрузка и переменные


        GetServersInformation getInfo;
        CheckOthersStats getStats;

        public bool ru;
        public RMForm()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            InitializeComponent();
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US") ru = false;
            else ru = true;
        }

        void RMForm_Load(object sender, EventArgs e)
        {
            getInfo = new GetServersInformation();
            StatsChange();
        }

        void StatsChange()
        {
            label_namalsk_pp.Text = "1PP";
            label_livonia_pp.Text = "3PP";
            label_cherno1_pp.Text = "1PP";
            label_cherno2_pp.Text = "3PP";
            //
            label_namalsk_map.Text = "namalsk";
            label_livonia_map.Text = "livonia";
            label_cherno1_map.Text = "chernorus";
            label_cherno2_map.Text = "chernorus";
            //
            updateStats_Tick(null, null);
            updateOnline_Tick(null, null);
            updatePing_Tick(null, null);
        }
        #endregion

        #region Главная
        void button_connect_namalsk_Click(object sender, EventArgs e)
        {

        }

        void button_connect_livonia_Click(object sender, EventArgs e)
        {

        }

        void button_connect_cherno1_Click(object sender, EventArgs e)
        {

        }

        void button_connect_cherno2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Настройки
        void button_aboutRM_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is launcher for project 'Russian Mafia'", "Information about project", MessageBoxButtons.OK);
        }

        void button_appRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        void button_aboutDEV_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "developer - www.github.com/eas1Iy", "Contacts DEV",MessageBoxButtons.OK);
        }

        #endregion

        #region Помощь

        #endregion

        #region Остальное
        void updateOnline_Tick(object sender, EventArgs e)
        {
            getInfo.serversAllOnline = 0;
            label_namalsk_online.Text = getInfo.GetOnlineServer(1);
            label_livonia_online.Text = getInfo.GetOnlineServer(2);
            label_cherno1_online.Text = getInfo.GetOnlineServer(3);
            label_cherno2_online.Text = getInfo.GetOnlineServer(4);
            //
            label_statusOnline.Text = Convert.ToString(getInfo.OnlineAll(0));
        }

        void updatePing_Tick(object sender, EventArgs e)
        {
            label_namalsk_ping.Text = Convert.ToString(getInfo.GetPingServer(1));
            label_livonia_ping.Text = Convert.ToString(getInfo.GetPingServer(2));
            label_cherno1_ping.Text = Convert.ToString(getInfo.GetPingServer(3));
            label_cherno2_ping.Text = Convert.ToString(getInfo.GetPingServer(4));
        }

        void button_updateStat_Click(object sender, EventArgs e)
        {
            updateOnline_Tick(sender, e);
            updatePing_Tick(sender, e);
        }
        void updateStats_Tick(object sender, EventArgs e)
        {
            if (CheckOthersStats.DayZ()) label_statusDayZ.Text = "Active"; else label_statusDayZ.Text = "Offline";
            if (CheckOthersStats.Steam()) label_statusSteam.Text = "Active"; else label_statusSteam.Text = "Offline";
        }
        #endregion

    }
}
