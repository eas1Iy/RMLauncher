using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher.RM_Forms
{
    public partial class RM_TestForm : MetroFramework.Forms.MetroForm
    {
        public RM_TestForm()
        {
            InitializeComponent();
        }

        void InterfaceSize_ValueChanged(object sender, EventArgs e)
        {
            lbl_procentSize.Text = InterfaceSize.Value + "%";

            if (InterfaceSize.Value >= 0)
                SizeChanger(0);
            else if (InterfaceSize.Value >= 20)
                SizeChanger(1);
            else if (InterfaceSize.Value >= 50)
                SizeChanger(2);
            else if (InterfaceSize.Value >= 80)
                SizeChanger(3);
        }

        void SizeChanger(byte count)
        {
            switch (count)
            {
                case 0: { break; }
                case 1: { break; }
                case 2: { break; }
                case 3: { break; }
                default: { break; }
            }
        }
    }
}
