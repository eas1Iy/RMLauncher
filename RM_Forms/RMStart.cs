﻿using MetroFramework;
using RMLauncher.RM_classes;
using SteamQueryNet;
using SteamQueryNet.Interfaces;
using SteamQueryNet.Models;
using Steamworks;
using Steamworks.Data;
using Steamworks.ServerList;
using Steamworks.Ugc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher.RM_Forms
{
    public partial class RMStart : MetroFramework.Forms.MetroForm
    {
        public RMStart()
        {
            InitializeComponent();
        }

        async void RMStart_Load(object sender, EventArgs e)
        {
            //int error = 0;
            //int errorMax = 3;
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
                //if (error >= errorMax)
                //{
                //    if (MetroMessageBox.Show(this, "Stop DayZ and start Steam?", "RMLoader", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        ProcessCustom.Kill("DayZ_x64.exe");
                //        Process.Start("Steam.exe");
                //    }
                //    else Application.Exit();
                //}
                //else
                //{
                    MetroMessageBox.Show(this, "Please start and auth Steam", "Error startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //error += 1;
                    await Task.Delay(1500);
                    goto back;
                //}
            }
        }

        bool LauncherNeedCheck()
        {
            if (CheckOthersStats.Steam() && !CheckOthersStats.DayZ()) // CheckAvailable.CheckConnectionAvailable()
                return true;
            else return false;
        }
    }
}
