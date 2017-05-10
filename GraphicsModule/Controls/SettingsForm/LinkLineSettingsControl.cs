using System;
using System.Windows.Forms;

namespace GraphicsModule.Controls.SettingsForm
{
    public partial class LinkLineSettingsControl : UserControl
    {
        public LinkLineSettingsControl()
        {
            InitializeComponent();
        }
        private void link1ColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                link1ColorBox.BackColor = colorDialog1.Color;
            }
        }

        private void link2ColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                link2ColorBox.BackColor = colorDialog2.Color;
            }
        }

        private void link3ColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                link3ColorBox.BackColor = colorDialog3.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
            }
            else
            {
            }
        }
    }
}
