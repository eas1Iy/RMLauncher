
namespace RMLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.StyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.StyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(0, 0);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.UseSelectable = true;
            // 
            // StyleExtender
            // 
            this.StyleExtender.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // StyleManager
            // 
            this.StyleManager.Owner = null;
            this.StyleManager.Style = MetroFramework.MetroColorStyle.Red;
            this.StyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 451);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "RMLauncher";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.StyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Components.MetroStyleExtender StyleExtender;
        private MetroFramework.Components.MetroStyleManager StyleManager;
    }
}

