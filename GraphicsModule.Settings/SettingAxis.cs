using System;
using System.Windows.Forms;

namespace GraphicsModule.Settings
{
    public partial class SettingAxis : UserControl
    {
        public SettingAxis()
        {
            InitializeComponent();
        }

        private void colorBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                colorBox1.BackColor = colorDialog1.Color;
        }

        private void colorBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                colorBox2.BackColor = colorDialog2.Color;
        }

        private void colorBox3_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
                colorBox3.BackColor = colorDialog3.Color;
        }

        private void axis1NameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (axis1NameBox.SelectedIndex == axis1NameBox.Items.IndexOf(axis1NameBox.SelectedItem))
            {
                axis2NameBox.SelectedIndex = axis1NameBox.SelectedIndex;
                axis3NameBox.SelectedIndex = axis1NameBox.SelectedIndex;
            }
        }

        private void axis2NameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (axis2NameBox.SelectedIndex == axis2NameBox.Items.IndexOf(axis2NameBox.SelectedItem))
            {
                axis1NameBox.SelectedIndex = axis2NameBox.SelectedIndex;
                axis3NameBox.SelectedIndex = axis2NameBox.SelectedIndex;
            }
        }

        private void axis3NameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (axis3NameBox.SelectedIndex == axis3NameBox.Items.IndexOf(axis3NameBox.SelectedItem))
            {
                axis1NameBox.SelectedIndex = axis3NameBox.SelectedIndex;
                axis2NameBox.SelectedIndex = axis3NameBox.SelectedIndex;
            }
        }
    }
}
