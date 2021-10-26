
namespace RMLauncher.RM_Forms
{
    partial class RMNotification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RMNotification));
            this.StyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.StyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.lbl_Message = new MetroFramework.Controls.MetroLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // StyleExtender
            // 
            this.StyleExtender.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // StyleManager
            // 
            this.StyleManager.Owner = this;
            this.StyleManager.Style = MetroFramework.MetroColorStyle.Red;
            this.StyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lbl_Message
            // 
            this.lbl_Message.Location = new System.Drawing.Point(23, 53);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(333, 52);
            this.lbl_Message.Style = MetroFramework.MetroColorStyle.Red;
            this.lbl_Message.TabIndex = 0;
            this.lbl_Message.Text = "metroLabel1";
            this.lbl_Message.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // RMNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 113);
            this.Controls.Add(this.lbl_Message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RMNotification";
            this.Opacity = 0.6D;
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Notification";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RMNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleExtender StyleExtender;
        private MetroFramework.Components.MetroStyleManager StyleManager;
        private MetroFramework.Controls.MetroLabel lbl_Message;
        private System.Windows.Forms.Timer timer;
    }
}