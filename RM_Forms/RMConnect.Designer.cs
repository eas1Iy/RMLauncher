
namespace RMLauncher.RM_Forms
{
    partial class RMConnect
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
            this.StyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.StyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.Progress = new MetroFramework.Controls.MetroProgressBar();
            this.label_proc = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
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
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(-13, 108);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(648, 15);
            this.Progress.Style = MetroFramework.MetroColorStyle.Red;
            this.Progress.TabIndex = 0;
            this.Progress.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label_proc
            // 
            this.label_proc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_proc.Location = new System.Drawing.Point(541, 86);
            this.label_proc.Name = "label_proc";
            this.label_proc.Size = new System.Drawing.Size(81, 19);
            this.label_proc.Style = MetroFramework.MetroColorStyle.Red;
            this.label_proc.TabIndex = 1;
            this.label_proc.Text = "0%";
            this.label_proc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_proc.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.Location = new System.Drawing.Point(2, 86);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(533, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Please wait, DayZ is loading...";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RMConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 113);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.label_proc);
            this.Controls.Add(this.Progress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RMConnect";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "RMConnect";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.RMConnect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleExtender StyleExtender;
        private MetroFramework.Components.MetroStyleManager StyleManager;
        private MetroFramework.Controls.MetroProgressBar Progress;
        private MetroFramework.Controls.MetroLabel label_proc;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}