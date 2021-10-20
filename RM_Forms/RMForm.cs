using MetroFramework;
using RMLauncher.Properties;
using RMLauncher.RM_classes;
using RMLauncher.RM_classes.DayZ;
using RMLauncher.RM_classes.Discord;
using RMLauncher.RM_Forms;
using System;
using System.Diagnostics;
using System.Drawing;
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
        Discord Discord;
        //CheckOthersStats getStats;

        public bool ru;
        public RMForm()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            InitializeComponent();
            GetTheme();
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US") ru = false;
            else ru = true;
        }

        async void RMForm_Load(object sender, EventArgs e)
        {
            try
            {
                getInfo = new GetServersInformation();
                Discord = new Discord();

                await Task.Delay(200);
                Discord.Initialize("Main menu","Waiting...");
                LoadSettings();
                await Task.Delay(200);
                StatsChange();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void LoadSettings()
        {
            TextBox_username.Text = Settings.Default["username"].ToString();
            CheckBox_windowmode.Checked = Convert.ToBoolean(Settings.Default["window"]);
            CheckBox_priority.Checked = Convert.ToBoolean(Settings.Default["hight"]);
            CheckBox_updates.Checked = Convert.ToBoolean(Settings.Default["updates"]);
            CheckBox_shutdown.Checked = Convert.ToBoolean(Settings.Default["shutdown"]);
            CheckBox_stats.Checked = Convert.ToBoolean(Settings.Default["stats"]);
            AutoStats();
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
            label_cherno1_pp.Text = "1PP";
            label_cherno2_pp.Text = "3PP";
            //
            label_namalsk_map.Text = "namalsk";
            label_cherno1_map.Text = "chernarus";
            label_cherno2_map.Text = "chernarus";
            //
            Thread updateThread = new Thread(delegate ()
            {
                this.Invoke(new Action(() =>
                {
                    //UpdateStat();
                    //UpdateOnline();
                    //UpdatePing();
                }));
            });
            updateThread.Start();
        }
        #endregion

        #region Главная
        void button_connect_namalsk_Click(object sender, EventArgs e)
        {
            button_connect_namalsk.Enabled = false;
            GameStart(1);
            
            Discord.JoinServer("Russian Mafia ┃ Namalsk");

            button_connect_namalsk.Enabled = true;
        }

        void button_connect_livonia_Click(object sender, EventArgs e)
        {
            //button_connect_livonia.Enabled = false;
        }

        void button_connect_cherno1_Click(object sender, EventArgs e)
        {
            button_connect_cherno1.Enabled = false;

            GameStart(2);

            Discord.JoinServer("Russian Mafia ┃ Chernarussia 1PP");

            button_connect_cherno1.Enabled = true;
        }

        void button_connect_cherno2_Click(object sender, EventArgs e)
        {
            button_connect_cherno2.Enabled = false;

            GameStart(3);

            Discord.JoinServer("Russian Mafia ┃ Chernarussia 3PP");

            button_connect_cherno2.Enabled = true;
        }

        public bool GameStart(byte serverID)
        {
            SaveSettings();
            if (TextBox_username.Text.Length > 3 || TextBox_username.Text == "Survivor" || TextBox_username.Text == "Выживший")
            {
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
            else { MetroMessageBox.Show(this, "Please change your nickname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
        }

            #endregion

            #region Настройки
            void button_aboutRM_Click(object sender, EventArgs e)
        {
            button_aboutRM.Enabled = false;
            MetroMessageBox.Show(this, "This is launcher for project 'Russian Mafia'", "Information about project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button_aboutRM.Enabled = true;
        }

        void button_appRestart_Click(object sender, EventArgs e)
        {
            button_appRestart.Enabled = false;
            SaveSettings();
            Application.Restart();
        }
        void button_aboutDEV_Click(object sender, EventArgs e)
        {
            button_aboutDEV.Enabled = false;
            MetroMessageBox.Show(this, "developer - www.github.com/eas1Iy", "Contacts DEV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button_aboutDEV.Enabled = true;
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
                case 0: ComboBoxStyleChanger(0); break;
                case 1: ComboBoxStyleChanger(1); break;
                case 2: ComboBoxStyleChanger(2); break;
                default: break;
            }
        }

        void ComboBoxStyleChanger(int index)
        {
            switch (index)
            {
                case 0: Settings.Default["style"] = "Red"; ThemeChanger(MetroColorStyle.Red); break;
                case 1: Settings.Default["style"] = "Green"; ThemeChanger(MetroColorStyle.Green); break;
                case 2: Settings.Default["style"] = "Black"; ThemeChanger(MetroColorStyle.Black); break;
                default: break;
            }
            SaveSettings();
        }

        void GetTheme()
        {
            MetroColorStyle style = themeChanger.StyleChanger();
            ThemeChanger(style);
        }

        void ThemeChanger(MetroColorStyle metroColorStyle)
        {
            StyleManager.Update();

            changeImagesTheme(metroColorStyle);

            InterfaceSize.Style = metroColorStyle;

            ComboBox_Style.Style = metroColorStyle;
            StyleManager.Style = metroColorStyle;
            this.Style = metroColorStyle;

            tab.Style = metroColorStyle;
            Tile_servers.Style = metroColorStyle;
            Tile_stats.Style = metroColorStyle;
            Tile_server1.Style = metroColorStyle;
            //Tile_server2.Style = metroColorStyle;
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
        }

        void changeImagesTheme(MetroColorStyle metroColorStyle)
        {
            switch (metroColorStyle)
            {
                case MetroColorStyle.Black:
                    {
                        pictureBox_namalsk.Image = Resources.black_namalsk;
                        pictureBox_cherno1.Image = Resources.black_cherno;
                        pictureBox_cherno2.Image = Resources.black_cherno;
                    }
                    break;
                case MetroColorStyle.Green:
                    {
                        pictureBox_namalsk.Image = Resources.green_namalsk;
                        pictureBox_cherno1.Image = Resources.green_cherno;
                        pictureBox_cherno2.Image = Resources.green_cherno;
                    }
                    break;
                case MetroColorStyle.Red:
                    {
                        pictureBox_namalsk.Image = Resources.red_namalsk;
                        pictureBox_cherno1.Image = Resources.red_cherno;
                        pictureBox_cherno2.Image = Resources.red_cherno;
                    }
                    break;
                default:
                    pictureBox_namalsk.Image = Resources.red_namalsk;
                    pictureBox_cherno1.Image = Resources.red_cherno;
                    pictureBox_cherno2.Image = Resources.red_cherno;
                    break;
            }
        }

        void UpdateOnline()
        {
            getInfo.serversAllOnline = 0;

            label_namalsk_online.Text = getInfo.GetOnlineServer(1);
            label_cherno1_online.Text = getInfo.GetOnlineServer(2);
            label_cherno2_online.Text = getInfo.GetOnlineServer(3);

            label_statusOnline.Text = Convert.ToString(getInfo.OnlineAll(0));
        }

        void UpdatePing()
        {
            label_namalsk_ping.Text = Convert.ToString(getInfo.GetPingServer(1));
            label_cherno1_ping.Text = Convert.ToString(getInfo.GetPingServer(2));
            label_cherno2_ping.Text = Convert.ToString(getInfo.GetPingServer(3));
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
            button_updateStat.Enabled = false;
            try
            {
                UpdateStat();
                UpdateOnline();
                UpdatePing();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button_updateStat.Enabled = true;
        }
        void updateStats_Tick(object sender, EventArgs e)
        {
            UpdateStat();
            UpdateOnline();
        }

        void RMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Discord.Deinitialize();
            SaveSettings();
            Application.Exit();
        }

        void button_changeLanguage_Click(object sender, EventArgs e)
        {
            button_changeLanguage.Enabled = false;
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
            button_checkMods.Enabled = false;
            string result;


            if (ru)
            {
                result = "Проверка модификаций завершена!\n";

                if (DayZCheckMods.IsInstalledCheck(1))
                    result += "\nNamalsk - модификации успешно найдены.";
                else result += "\nNamalsk - модификации не найдены.";

                if (DayZCheckMods.IsInstalledCheck(2))
                    result += "\nChernarussia - модификации успешно найдены.";
                else result += "\nChernarussia - модификации не найдены.";
            }
            else
            {
                result = "Modification check completed!\n";

                if (DayZCheckMods.IsInstalledCheck(1))
                    result += "\nNamalsk - modifications found successfully.";
                else result += "\nNamalsk - no modifications found.";

                if (DayZCheckMods.IsInstalledCheck(2))
                    result += "\nChernarussia - modifications found successfully.";
                else result += "\nChernarussia - no modifications found.";
            }
            

            MetroMessageBox.Show(this,result, "Information about mods", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button_checkMods.Enabled = true;
        }

        void tile_beta_Click(object sender, EventArgs e)
        {
            Alert($"Application version: {ProductVersion}", RMNotification.enmType.Info);
        }

        void AutoStats()
        {
            if (CheckBox_stats.Checked == true)
            {
                update.Enabled = false;
            }
            else
            {
                update.Enabled = true;
            }
        }
        void CheckBox_stats_CheckedChanged(object sender, EventArgs e)
        {
            AutoStats();
        }
        #endregion

        void button_next_Click(object sender, EventArgs e)
        {
            button_next.Enabled = false;
            pb_help.Image = Resources.image_help2;
            button_back.Enabled = true;
        }

        void button_back_Click(object sender, EventArgs e)
        {
            button_back.Enabled = false;
            pb_help.Image = Resources.image_help1;
            button_next.Enabled = true;
        }

        void label_help_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/eas1Iy");
            Alert("Show developer page", RMNotification.enmType.Info);
        }

        void InterfaceSize_ValueChanged(object sender, EventArgs e)
        {
            lbl_procentSize.Text = InterfaceSize.Value+"%";

            if (this.WindowState == FormWindowState.Maximized)
                InferfaceSize(InterfaceSize.Value);
        }

        Rectangle screenSize = Screen.PrimaryScreen.Bounds;
        void InferfaceSize(int value)
        {
            if (screenSize.Height > 1920 && screenSize.Width > 1200)
            {

            }
            if (screenSize.Height >= 4096 && screenSize.Width >= 2160)
            {

            }
        }

        void RMForm_MaximumSizeChanged(object sender, EventArgs e)
        {

        }
    }
}
