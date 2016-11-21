using System;
using System.Windows.Forms;

namespace GraphicsModule.Settings.Controls
{
    public partial class SettingsBackground : UserControl
    {
        public SettingsBackground()
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
