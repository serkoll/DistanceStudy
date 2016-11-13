using System;
using System.Windows.Forms;

namespace SettingsG
{
    public partial class SettingSegment : UserControl
    {
        public SettingSegment()
        {
            InitializeComponent();
        }

        private void colorSegment1stPlaneBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorSegment1stPlaneBox.BackColor = colorDialog1.Color;
            }
        }

        private void colorSegment2ndPlaneBox_Click(object sender, EventArgs e)
        {
            colorSegment2ndPlaneBox.BackColor = colorDialog2.Color;
        }

        private void colorSegment3rdPlaneBox_Click(object sender, EventArgs e)
        {
            colorSegment3rdPlaneBox.BackColor = colorDialog3.Color;
        }
    }
}
