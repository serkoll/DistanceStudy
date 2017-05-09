using System;
using System.Globalization;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.SettingsForm
{
    public partial class AxisSettingsControl : UserControl
    {
        public AxisSettings AxisSettings { get; set; }
        public AxisSettingsControl()
        {
            InitializeComponent();
            AxisSettings = GraphicsControlSettingsForm.CurrentSettings.AxisSettings;
            CheckBoxFlagDrawAxisX.Checked = AxisSettings.FlagDrawX;
            CheckBoxFlagDrawAxisY.Checked = AxisSettings.FlagDrawY;
            CheckBoxFlagDrawAxisZ.Checked = AxisSettings.FlagDrawZ;
            NumericUpDownAxisWidth.Value = AxisSettings.Width;
            colorBoxX.BackColor = GraphicsControlSettingsForm.CurrentSettings.AxisSettings.ColorX;
            colorBoxY.BackColor = GraphicsControlSettingsForm.CurrentSettings.AxisSettings.ColorY;
            colorBoxZ.BackColor = GraphicsControlSettingsForm.CurrentSettings.AxisSettings.ColorZ;
        }

        private void colorBoxX_Click(object sender, EventArgs e)
        {
            if (colorDialogX.ShowDialog() == DialogResult.OK)
            {
                colorBoxX.BackColor = colorDialogX.Color;
                AxisSettings.ColorX = colorDialogX.Color;
            }
        }

        private void colorBoxY_Click(object sender, EventArgs e)
        {
            if (colorDialogY.ShowDialog() == DialogResult.OK)
            {
                colorBoxY.BackColor = colorDialogY.Color;
                AxisSettings.ColorY = colorDialogY.Color;
            }
        }

        private void colorBoxZ_Click(object sender, EventArgs e)
        {
            if (colorDialogZ.ShowDialog() == DialogResult.OK)
            {
                colorBoxZ.BackColor = colorDialogZ.Color;
                AxisSettings.ColorZ = colorDialogZ.Color;
            }
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

        private void CheckBoxFlagDrawAxisX_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawX = CheckBoxFlagDrawAxisX.Checked;
        }

        private void CheckBoxFlagDrawAxisY_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawY = CheckBoxFlagDrawAxisY.Checked;
        }

        private void CheckBoxFlagDrawAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawZ = CheckBoxFlagDrawAxisZ.Checked;
        }

        private void NumericUpDownAxisWidth_ValueChanged(object sender, EventArgs e)
        {
            AxisSettings.Width = Convert.ToInt32(NumericUpDownAxisWidth.Value.ToString(CultureInfo.InvariantCulture));
        }
    }
}
