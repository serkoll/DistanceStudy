using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class PointsAccess : UserControl
    {
        public AxisS AxisS { get; set; }
        public PointsAccess()
        {
            InitializeComponent();
            AxisS = GraphicsControlSettingsForm.ValueS.AxisS;
            CheckBoxFlagDrawAxisX.Checked = AxisS.FlagDrawX;
            CheckBoxFlagDrawAxisY.Checked = AxisS.FlagDrawY;
            CheckBoxFlagDrawAxisZ.Checked = AxisS.FlagDrawZ;
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
    }
}
