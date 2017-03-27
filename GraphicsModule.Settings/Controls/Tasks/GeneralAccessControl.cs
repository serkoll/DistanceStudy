using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class GeneralAccessControl : UserControl
    {
        public GeneralSettings GeneralSettings { get; set; }
        public GeneralAccessControl()
        {
            InitializeComponent();
            GeneralSettings = GraphicsControlSettingsForm.ValueS.PrimitivesAcces.General;
            AccessAxisXCheckBox.Checked = GeneralSettings.IsAxisOXEnabled;
            AccessAxisYCheckBox.Checked = GeneralSettings.IsAxisOYEnabled;
            AccessAxisZCheckBox.Checked = GeneralSettings.IsAxisOZEnabled;
            AccessGridCheckBox.Checked = GeneralSettings.IsGridEnabled;
            AccessLinkLinesCheckBox.Checked = GeneralSettings.IsLinkLinesEnabled;
            AccessBindToGridCheckBox.Checked = GeneralSettings.IsBindToGridEnabled;
        }

        private void AccessAxisXCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.IsAxisOXEnabled = AccessAxisXCheckBox.Checked;
        }

        private void AccessAxisYCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.IsAxisOYEnabled = AccessAxisYCheckBox.Checked;
        }

        private void AccessAxisZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.IsAxisOZEnabled = AccessAxisZCheckBox.Checked;
        }

        private void AccessLinkLineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.IsLinkLinesEnabled = AccessLinkLinesCheckBox.Checked;
        }

        private void AccessGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.IsGridEnabled = AccessGridCheckBox.Checked;
        }

        private void AccessBindToGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.IsBindToGridEnabled = AccessBindToGridCheckBox.Checked;
        }
    }
}
