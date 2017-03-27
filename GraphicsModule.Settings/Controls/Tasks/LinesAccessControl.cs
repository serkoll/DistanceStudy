using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls.Tasks
{
    public partial class LinesAccessControl : UserControl
    {
        public LinesAccess LinesSettings { get; set; }
        public LinesAccessControl()
        {
            InitializeComponent();
            LinesSettings = GraphicsControlSettingsForm.ValueS.PrimitivesAcces.Lines;
            AccessLinesCheckBox.Checked = LinesSettings.IsLinesEnabled;
            AccessPoint2DCheckBox.Checked = LinesSettings.IsLine2DEnabled;
            AccessPoint3DCheckBox.Checked = LinesSettings.IsLine3DEnabled;
            AccessPointOfPlane1X0YCheckBox.Checked = LinesSettings.IsLineOfPlane1X0YEnabled;
            AccessPointOfPlane2X0ZCheckBox.Checked = LinesSettings.IsLineOfPlane2X0ZEnabled;
            AccessPointOfPlane3Y0ZCheckBox.Checked = LinesSettings.IsLineOfPlane3Y0ZEnabled;
            AccessGeneratePoint3DCheckBox.Checked = LinesSettings.IsGenerateLine3DEnabled;
        }
        private void AccessPoint2DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsLine2DEnabled = AccessPoint2DCheckBox.Checked;
        }

        private void AccessPoint3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsLine3DEnabled = AccessPoint3DCheckBox.Checked;
        }
        private void AccessPointOfPlane1X0YCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsLineOfPlane1X0YEnabled = AccessPointOfPlane1X0YCheckBox.Checked;
        }

        private void AccessPointOfPlane2X0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsLineOfPlane2X0ZEnabled = AccessPointOfPlane2X0ZCheckBox.Checked;
        }

        private void AccessPointOfPlane3Y0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsLineOfPlane3Y0ZEnabled = AccessPointOfPlane3Y0ZCheckBox.Checked;
        }

        private void AccessGeneratePoint3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsGenerateLine3DEnabled = AccessGeneratePoint3DCheckBox.Checked;
        }

        private void AccessLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesSettings.IsLinesEnabled = AccessLinesCheckBox.Checked;
        }
    }
}
