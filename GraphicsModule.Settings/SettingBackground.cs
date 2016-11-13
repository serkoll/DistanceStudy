using System;
using System.Windows.Forms;

namespace GraphicsModule.Settings
{
    public partial class SettingBackground : UserControl
    {
        public SettingBackground()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }
    }
}
