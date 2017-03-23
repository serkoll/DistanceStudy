using System;
using System.Windows.Forms;
using GraphicsModule.Settings.Forms;

namespace GraphicsModule.Settings.Controls.Tasks
{
    public partial class GeneralAccess : UserControl
    {
        public AxisS AxisS { get; set; }
        public GeneralAccess()
        {
            InitializeComponent();
            AxisS = GraphicsControlSettingsForm.ValueS.AxisS;
            AccessAxisXCheckBox.Checked = AxisS.FlagDrawX;
            AccessAxisYCheckBox.Checked = AxisS.FlagDrawY;
            AccessAxisZCheckBox.Checked = AxisS.FlagDrawZ;
        }
        private void CheckBoxFlagDrawAxisX_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawX = AccessAxisXCheckBox.Checked;
        }

        private void CheckBoxFlagDrawAxisY_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawY = AccessAxisYCheckBox.Checked;
        }

        private void CheckBoxFlagDrawAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawZ = AccessAxisZCheckBox.Checked;
        }
    }
}
