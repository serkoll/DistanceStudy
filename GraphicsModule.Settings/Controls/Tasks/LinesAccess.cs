using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class LinesAccess : UserControl
    {
        public AxisS AxisS { get; set; }
        public LinesAccess()
        {
            InitializeComponent();
            AxisS = GraphicsControlSettingsForm.ValueS.AxisS;
            AccessPoint2DCheckBox.Checked = AxisS.FlagDrawX;
            AccessPoint3DCheckBox.Checked = AxisS.FlagDrawY;
        }

        private void CheckBoxFlagDrawAxisX_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawX = AccessPoint2DCheckBox.Checked;
        }

        private void CheckBoxFlagDrawAxisY_CheckedChanged(object sender, EventArgs e)
        {
            AxisS.FlagDrawY = AccessPoint3DCheckBox.Checked;
        }
    }
}
