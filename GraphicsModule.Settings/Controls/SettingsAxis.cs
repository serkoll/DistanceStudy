using System;
using System.Windows.Forms;

namespace GraphicsModule.Settings.Controls
{
    public partial class SettingsAxis : UserControl
    {
        public SettingsAxis()
        {
            InitializeComponent();
        }

        private void colorBoxX_Click(object sender, EventArgs e)
        {
            if (colorDialogX.ShowDialog() == DialogResult.OK)
                colorBoxX.BackColor = colorDialogX.Color;
        }

        private void colorBoxY_Click(object sender, EventArgs e)
        {
            if (colorDialogY.ShowDialog() == DialogResult.OK)
                colorBoxY.BackColor = colorDialogY.Color;
        }

        private void colorBoxZ_Click(object sender, EventArgs e)
        {
            if (colorDialogZ.ShowDialog() == DialogResult.OK)
                colorBoxZ.BackColor = colorDialogZ.Color;
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
