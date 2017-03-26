using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class PointsAccessControl : UserControl
    {
        public AxisSettings AxisSettings { get; set; }
        public PointsAccessControl()
        {
            InitializeComponent();
            AxisSettings = GraphicsControlSettingsForm.ValueS.AxisSettings;
            CheckBoxFlagDrawAxisX.Checked = AxisSettings.FlagDrawX;
            CheckBoxFlagDrawAxisY.Checked = AxisSettings.FlagDrawY;
            CheckBoxFlagDrawAxisZ.Checked = AxisSettings.FlagDrawZ;
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
    }
}
