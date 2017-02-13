using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Settings.Forms;

namespace GraphicsModule.Settings.Controls
{
    public partial class SettingsBackground : UserControl
    {
        public Color BackgroundColor { get; set; }
        public SettingsBackground()
        {

            InitializeComponent();
            BackgroundColor = FormSettings.ValueS.BackgroundColor;
            pictureBox1.BackColor = BackgroundColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                BackgroundColor = colorDialog1.Color;
            }
        }
    }
}
