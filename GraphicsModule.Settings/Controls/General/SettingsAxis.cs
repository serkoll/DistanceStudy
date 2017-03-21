using System;
using System.Globalization;
using System.Windows.Forms;
using GraphicsModule.Settings.Forms;

namespace GraphicsModule.Settings.Controls.General
{
    public partial class SettingsAxis : UserControl
    {
        public AxisS AxisS { get; set; }
        public SettingsAxis()
        {
            InitializeComponent();
            AxisS = GraphicsControlSettingsForm.ValueS.AxisS;
            CheckBoxFlagDrawAxisX.Checked = AxisS.FlagDrawX;
            CheckBoxFlagDrawAxisY.Checked = AxisS.FlagDrawY;
            CheckBoxFlagDrawAxisZ.Checked = AxisS.FlagDrawZ;
            NumericUpDownAxisWidth.Value = AxisS.Width;
            colorBoxX.BackColor = GraphicsControlSettingsForm.ValueS.AxisS.ColorX;
            colorBoxY.BackColor = GraphicsControlSettingsForm.ValueS.AxisS.ColorY;
            colorBoxZ.BackColor = GraphicsControlSettingsForm.ValueS.AxisS.ColorZ;
        }

        private void colorBoxX_Click(object sender, EventArgs e)
        {
            if (colorDialogX.ShowDialog() == DialogResult.OK)
            {
                colorBoxX.BackColor = colorDialogX.Color;
                AxisS.ColorX = colorDialogX.Color;
            }
        }

        private void colorBoxY_Click(object sender, EventArgs e)
        {
            if (colorDialogY.ShowDialog() == DialogResult.OK)
            {
                colorBoxY.BackColor = colorDialogY.Color;
                AxisS.ColorY = colorDialogY.Color;
            }
        }

        private void colorBoxZ_Click(object sender, EventArgs e)
        {
            if (colorDialogZ.ShowDialog() == DialogResult.OK)
            {
                colorBoxZ.BackColor = colorDialogZ.Color;
                AxisS.ColorZ = colorDialogZ.Color;
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
            AxisS.FlagDrawX = CheckBoxFlagDrawAxisX.Checked;
        }

        private void CheckBoxFlagDrawAxisY_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawY = CheckBoxFlagDrawAxisY.Checked;
        }

        private void CheckBoxFlagDrawAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawZ = CheckBoxFlagDrawAxisZ.Checked;
        }

        private void NumericUpDownAxisWidth_ValueChanged(object sender, EventArgs e)
        {
            AxisS.Width = Convert.ToInt32(NumericUpDownAxisWidth.Value.ToString(CultureInfo.InvariantCulture));
        }
    }
}
