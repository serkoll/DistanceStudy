using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.TaskAccess
{
    public partial class GeneralAccessControl : UserControl
    {
        public GeneralAccess GeneralAccess { get; set; }
        public GeneralAccessControl()
        {
            InitializeComponent();
            GeneralAccess = GraphicsControlSettingsForm.CurrentSettings.PrimitivesAcces.General;
            AccessAxisXCheckBox.Checked = GeneralAccess.IsAxisOXEnabled;
            AccessAxisYCheckBox.Checked = GeneralAccess.IsAxisOYEnabled;
            AccessAxisZCheckBox.Checked = GeneralAccess.IsAxisOZEnabled;
            AccessGridCheckBox.Checked = GeneralAccess.IsGridEnabled;
            AccessLinkLinesCheckBox.Checked = GeneralAccess.IsLinkLinesEnabled;
            AccessBindToGridCheckBox.Checked = GeneralAccess.IsBindToGridEnabled;
        }

        private void AccessAxisXCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralAccess.IsAxisOXEnabled = AccessAxisXCheckBox.Checked;
        }

        private void AccessAxisYCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralAccess.IsAxisOYEnabled = AccessAxisYCheckBox.Checked;
        }

        private void AccessAxisZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralAccess.IsAxisOZEnabled = AccessAxisZCheckBox.Checked;
        }

        private void AccessLinkLineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralAccess.IsLinkLinesEnabled = AccessLinkLinesCheckBox.Checked;
        }

        private void AccessGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralAccess.IsGridEnabled = AccessGridCheckBox.Checked;
        }

        private void AccessBindToGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralAccess.IsBindToGridEnabled = AccessBindToGridCheckBox.Checked;
        }
    }
}
