using MetroFramework;
using RMLauncher.Properties;
using RMLauncher.RM_classes;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher.RM_Forms
{
    public partial class RMStart : MetroFramework.Forms.MetroForm
    {
        public static string my_version = Application.ProductVersion;

        public static string temp_version;

        private string url_version = "http://f0538041.xsph.ru/RM/version.txt";

        public bool ru;
        public RMStart()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            InitializeComponent();
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US") ru = false;
            else ru = true;
            Themes();
        }

        bool CheckVersion()
        {
            if (GetInternetConnection.CheckConnection())
            {
                var client = new WebClient();
                var stream = client.OpenRead(url_version);
                client.DownloadFile(url_version, @"temp_version.ini");

                var reader = new StreamReader(stream);

                var content = reader.ReadToEnd();

                string temp_version = content;

                if (File.Exists(@"temp_version.ini"))
                {
                    Thread.Sleep(500);

                    if (my_version == temp_version)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else
                {
                    MetroMessageBox.Show(this, "Application update check error.\n\nError: Temp version file bad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return false;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Application update check error.\n\nError: Internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        async void RMStart_Load(object sender, EventArgs e)
        {
            try
            {
                if (CheckVersion() == true)
                {
                back:
                    if (LauncherNeedCheck() == true)
                    {
                        await Task.Delay(1000);
                        RMForm Form = new RMForm();
                        this.Hide();
                        Form.Show();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Please start and auth Steam", "Error startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await Task.Delay(1500);
                        goto back;
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "New version found, press 'OK' to start update.", "UPDATE LAUNCHER",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Process.Start("RMUpdater.exe");
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Application update check error.\n\nError: Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        bool LauncherNeedCheck()
        {
            if (CheckOthersStats.Steam()) // CheckAvailable.CheckConnectionAvailable()
                return true;
            else return false;
        }

        void Themes()
        {
            MetroColorStyle metroColorStyle = themeChanger.StyleChanger();

            StyleManager.Style = metroColorStyle;
            Progress.Style = metroColorStyle;
            this.Style = metroColorStyle;
        }
    }
}
