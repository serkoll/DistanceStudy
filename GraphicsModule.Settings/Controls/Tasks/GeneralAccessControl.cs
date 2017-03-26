using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class GeneralAccessControl : UserControl
    {
        public AxisSettings AxisSettings { get; set; }
        public GeneralAccessControl()
        {
            InitializeComponent();
            AxisSettings = GraphicsControlSettingsForm.ValueS.AxisSettings;
            AccessAxisXCheckBox.Checked = AxisSettings.FlagDrawX;
            AccessAxisYCheckBox.Checked = AxisSettings.FlagDrawY;
            AccessAxisZCheckBox.Checked = AxisSettings.FlagDrawZ;
        }
        private void CheckBoxFlagDrawAxisX_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawX = AccessAxisXCheckBox.Checked;
        }

        private void CheckBoxFlagDrawAxisY_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawY = AccessAxisYCheckBox.Checked;
        }

        private void CheckBoxFlagDrawAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            AxisSettings.FlagDrawZ = AccessAxisZCheckBox.Checked;
        }
    }
}
