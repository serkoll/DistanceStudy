using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class LinesAccessControl : UserControl
    {
        public AxisSettings AxisSettings { get; set; }
        public LinesAccessControl()
        {
            InitializeComponent();
            AxisSettings = GraphicsControlSettingsForm.ValueS.AxisSettings;
            AccessPoint2DCheckBox.Checked = AxisSettings.FlagDrawX;
            AccessPoint3DCheckBox.Checked = AxisSettings.FlagDrawY;
        }

        private void CheckBoxFlagDrawAxisX_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawX = AccessPoint2DCheckBox.Checked;
        }

        private void CheckBoxFlagDrawAxisY_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawY = AccessPoint3DCheckBox.Checked;
        }
    }
}
