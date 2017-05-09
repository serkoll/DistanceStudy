using System;
using System.Windows.Forms;

namespace GraphicsModule.Configuration.Controls
{
    public partial class PointsSettingsControl : UserControl
    {
        public PointsSettingsControl()
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
        private void name1stPlaneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (name1stPlaneBox.SelectedIndex == name1stPlaneBox.Items.IndexOf(name1stPlaneBox.SelectedItem))
            {
                name2ndPlaneBox.SelectedIndex = name1stPlaneBox.SelectedIndex;
                name3rdPlaneBox.SelectedIndex = name1stPlaneBox.SelectedIndex;
            }
        }
        private void name2ndPlaneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (name2ndPlaneBox.SelectedIndex == name2ndPlaneBox.Items.IndexOf(name2ndPlaneBox.SelectedItem))
            {
                name1stPlaneBox.SelectedIndex = name2ndPlaneBox.SelectedIndex;
                name3rdPlaneBox.SelectedIndex = name2ndPlaneBox.SelectedIndex;
            }
        }

        private void name3rdPlaneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (name3rdPlaneBox.SelectedIndex == name3rdPlaneBox.Items.IndexOf(name3rdPlaneBox.SelectedItem))
            {
                name1stPlaneBox.SelectedIndex = name3rdPlaneBox.SelectedIndex;
                name2ndPlaneBox.SelectedIndex = name3rdPlaneBox.SelectedIndex;
            }
        }
        private void color1stPlaneBox_Click(object sender, EventArgs e)
        {
            if (color1stPlaneDialog.ShowDialog() == DialogResult.OK)
                color1stPlaneBox.BackColor = color1stPlaneDialog.Color;
        }

        private void color2ndPlaneBox_Click(object sender, EventArgs e)
        {
            if (color2ndPlaneDialog.ShowDialog() == DialogResult.OK)
                color2ndPlaneBox.BackColor = color2ndPlaneDialog.Color;
        }

        private void color3rdPlaneBox_Click(object sender, EventArgs e)
        {

        }
    }
}
