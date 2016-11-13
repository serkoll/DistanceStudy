using System;
using System.Windows.Forms;

namespace SettingsG
{
    public partial class SettingPoint : UserControl
    {
        public SettingPoint()
        {
            InitializeComponent();
        }

        private void pointColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pointColorBox.BackColor = colorDialog1.Color;
            }
        }
    }
}
