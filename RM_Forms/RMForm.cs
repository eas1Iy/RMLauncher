using MetroFramework;
using RMLauncher.Properties;
using RMLauncher.RM_classes;
using RMLauncher.RM_classes.DayZ;
using RMLauncher.RM_Forms;
using System;
using System.Globalization;
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
            Themes();
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US") ru = false;
            else ru = true;
        }

        async void RMForm_Load(object sender, EventArgs e)
        {
            getInfo = new GetServersInformation();
            await Task.Delay(200);
            LoadSettings();
            StatsChange();
        }

        void LoadSettings()
        {
            TextBox_username.Text = Settings.Default["username"].ToString();
            CheckBox_windowmode.Checked = Convert.ToBoolean(Settings.Default["window"]);
            CheckBox_priority.Checked = Convert.ToBoolean(Settings.Default["hight"]);
            CheckBox_updates.Checked = Convert.ToBoolean(Settings.Default["updates"]);
            CheckBox_shutdown.Checked = Convert.ToBoolean(Settings.Default["shutdown"]);
            //CheckBox_stats.Checked = Convert.ToBoolean(Settings.Default["stats"]);
            //AutoStats();
        }

        void SaveSettings()
        {
            Settings.Default["window"] = CheckBox_windowmode.Checked;
            Settings.Default["hight"] = CheckBox_priority.Checked;
            Settings.Default["updates"] = CheckBox_updates.Checked;
            Settings.Default["shutdown"] = CheckBox_shutdown.Checked;
            Settings.Default["stats"] = CheckBox_stats.Checked;
            Settings.Default["username"] = TextBox_username.Text;
            Settings.Default.Save();
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
            label_cherno1_map.Text = "chernarus";
            label_cherno2_map.Text = "chernarus";
            //
            try
            {
               // UpdateStat();
                //UpdateOnline();
                //UpdatePing();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Главная
        void button_connect_namalsk_Click(object sender, EventArgs e)
        {
            GameStart(1);
        }

        void button_connect_livonia_Click(object sender, EventArgs e)
        {

        }

        void button_connect_cherno1_Click(object sender, EventArgs e)
        {
            GameStart(2);
        }

        void button_connect_cherno2_Click(object sender, EventArgs e)
        {

        }

        public bool GameStart(byte serverID)
        {
            SaveSettings();
            if (DayZLaunch.GameStart(serverID) == true)
            {
                this.WindowState = FormWindowState.Minimized;
                Alert("Success game start", RMNotification.enmType.Success);

                if (CheckBox_shutdown.Checked == true)
                    Application.Exit();

                return true;
            }
            else { MetroMessageBox.Show(this, "Game start error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }

        }
        #endregion

        #region Настройки
        void button_aboutRM_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "This is launcher for project 'Russian Mafia'", "Information about project", MessageBoxButtons.OK);
        }

        void button_appRestart_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Application.Restart();
        }
        void button_aboutDEV_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "developer - www.github.com/eas1Iy", "Contacts DEV", MessageBoxButtons.OK);
        }

        #endregion

        #region Помощь

        #endregion

        #region Остальное
        public void Alert(string msg, RMNotification.enmType type)
        {
            RMNotification frm = new RMNotification();
            frm.showAlert(msg, type);
        }

        void ComboBox_Style_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox_Style.SelectedIndex)
            {
                case 0: Settings.Default["style"] = "Red"; break;
                case 1: Settings.Default["style"] = "Green"; break;
                case 2: Settings.Default["style"] = "Black"; break;
                default: break;
            }
            SaveSettings();
        }

        void Themes()
        {
            MetroColorStyle metroColorStyle = themeChanger.StyleChanger();

            changeImagesTheme(metroColorStyle);

            tab.Style = metroColorStyle;
            Tile_servers.Style = metroColorStyle;
            Tile_stats.Style = metroColorStyle;
            Tile_server1.Style = metroColorStyle;
            Tile_server2.Style = metroColorStyle;
            Tile_server3.Style = metroColorStyle;
            Tile_server4.Style = metroColorStyle;

            CheckBox_windowmode.Style = metroColorStyle;
            CheckBox_priority.Style = metroColorStyle;
            CheckBox_batteye.Style = metroColorStyle;
            CheckBox_updates.Style = metroColorStyle;
            CheckBox_shutdown.Style = metroColorStyle;
            CheckBox_stats.Style = metroColorStyle;

            tile_beta.Style = metroColorStyle;
            TextBox_username.Style = metroColorStyle;

            ComboBox_Style.Style = metroColorStyle;
            StyleManager.Style = metroColorStyle;
            this.Style = metroColorStyle;
        }

        void changeImagesTheme(MetroColorStyle metroColorStyle)
        {
            if (metroColorStyle == MetroColorStyle.Green)
            {
                pictureBox_namalsk.Image = Resources.green_namalsk;
                pictureBox_cherno1.Image = Resources.green_cherno;
                pictureBox_cherno2.Image = Resources.green_cherno;
            }
            else if (metroColorStyle == MetroColorStyle.Black)
            {
                ;
                pictureBox_namalsk.Image = Resources.black_namalsk;
                pictureBox_cherno1.Image = Resources.black_cherno;
                pictureBox_cherno2.Image = Resources.black_cherno;
            }
            else
            {
                pictureBox_namalsk.Image = Resources.red_namalsk;
                pictureBox_cherno1.Image = Resources.red_cherno;
                pictureBox_cherno2.Image = Resources.red_cherno;
            }
        }
        void updateOnline_Tick(object sender, EventArgs e)
        {
            UpdateOnline();
        }

        void updatePing_Tick(object sender, EventArgs e)
        {
            UpdatePing();
        }

        void UpdateOnline()
        {
            getInfo.serversAllOnline = 0;

            label_namalsk_online.Text = getInfo.GetOnlineServer(1);
            label_cherno1_online.Text = getInfo.GetOnlineServer(2);

            label_statusOnline.Text = Convert.ToString(getInfo.OnlineAll(0));
        }

        void UpdatePing()
        {
            label_namalsk_ping.Text = Convert.ToString(getInfo.GetPingServer(1));
            label_cherno1_ping.Text = Convert.ToString(getInfo.GetPingServer(2));
        }

        async void UpdateStat()
        {
            if (CheckOthersStats.DayZ()) label_statusDayZ.Text = "Active"; else label_statusDayZ.Text = "Offline";
            if (CheckOthersStats.Steam()) label_statusSteam.Text = "Active";
            else
            {
                label_statusSteam.Text = "Offline";
            steamOff:
                if (CheckOthersStats.Steam()) { }
                else
                {
                    if (MetroMessageBox.Show(this, "Please start STEAM!", "Steam error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) Application.Exit();
                    else
                    {
                        await Task.Delay(1000);
                        goto steamOff;
                    }
                }
            }
        }

        void button_updateStat_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStat();
                //UpdateOnline();
                UpdatePing();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void updateStats_Tick(object sender, EventArgs e)
        {
            UpdateStat();
        }

        void RMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            Application.Exit();
        }

        void button_changeLanguage_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
                Properties.Settings.Default.Language = "ru-RU";
                Properties.Settings.Default.Save();
                Application.Restart();
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                Properties.Settings.Default.Language = "en-US";
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
        void button_checkMods_Click(object sender, EventArgs e)
        {
            if (DayZCheckMods.IsInstalledCheck(1))
                MetroMessageBox.Show(this, "Модификации сервера: Namalsk\nУспешно проверены.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MetroMessageBox.Show(this, "Модификации сервера: Namalsk\nНе найдены, подпишитесь на наши модификации.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (DayZCheckMods.IsInstalledCheck(2))
                MetroMessageBox.Show(this, "Модификации серверов: Chernarus\nУспешно проверены.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MetroMessageBox.Show(this, "Модификации сервера: Chernarus\nНе найдены, подпишитесь на наши модификации.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void tile_beta_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, $"Application version: {ProductVersion}");
        }

        void AutoStats()
        {
            //if (CheckBox_stats.Checked == true)
            //{
            //    updateStats.Enabled = false;
            //    updateOnline.Enabled = false;
            //    updatePing.Enabled = false;
            //}
            //else
            //{
            //    updateStats.Enabled = true;
            //    updateOnline.Enabled = true;
            //    updatePing.Enabled = true;
            //}
        }
        void CheckBox_stats_CheckedChanged(object sender, EventArgs e)
        {
            AutoStats();
        }
        #endregion
    }
}
