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

namespace RMLauncher.RM_Forms
{
    public partial class RMConnect : MetroFramework.Forms.MetroForm
    {
        public bool ru;
        public RMConnect()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            InitializeComponent();
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US") ru = false;
            else ru = true;
            Themes();
        }

        void RMConnect_Load(object sender, EventArgs e)
        {

        }

        void Themes()
        {
            MetroColorStyle metroColorStyle = themeChanger.StyleChanger();

            Progress.Style = metroColorStyle;
            StyleManager.Style = metroColorStyle;
            this.Style = metroColorStyle;
        }
    }
}
