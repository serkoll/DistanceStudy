using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.TaskAccess
{
    public partial class LinesAccessControl : UserControl
    {
        public LinesAccess LinesAccess { get; set; }
        public LinesAccessControl()
        {
            InitializeComponent();
            LinesAccess = GraphicsControlSettingsForm.CurrentSettings.PrimitivesAcces.Lines;
            AccessLinesCheckBox.Checked = LinesAccess.IsLinesEnabled;
            AccessPoint2DCheckBox.Checked = LinesAccess.IsLine2DEnabled;
            AccessPoint3DCheckBox.Checked = LinesAccess.IsLine3DEnabled;
            AccessPointOfPlane1X0YCheckBox.Checked = LinesAccess.IsLineOfPlane1X0YEnabled;
            AccessPointOfPlane2X0ZCheckBox.Checked = LinesAccess.IsLineOfPlane2X0ZEnabled;
            AccessPointOfPlane3Y0ZCheckBox.Checked = LinesAccess.IsLineOfPlane3Y0ZEnabled;
            AccessGeneratePoint3DCheckBox.Checked = LinesAccess.IsGenerateLine3DEnabled;
        }
        private void AccessPoint2DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsLine2DEnabled = AccessPoint2DCheckBox.Checked;
        }

        private void AccessPoint3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsLine3DEnabled = AccessPoint3DCheckBox.Checked;
        }
        private void AccessPointOfPlane1X0YCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsLineOfPlane1X0YEnabled = AccessPointOfPlane1X0YCheckBox.Checked;
        }

        private void AccessPointOfPlane2X0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsLineOfPlane2X0ZEnabled = AccessPointOfPlane2X0ZCheckBox.Checked;
        }

        private void AccessPointOfPlane3Y0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsLineOfPlane3Y0ZEnabled = AccessPointOfPlane3Y0ZCheckBox.Checked;
        }

        private void AccessGeneratePoint3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsGenerateLine3DEnabled = AccessGeneratePoint3DCheckBox.Checked;
        }

        private void AccessLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LinesAccess.IsLinesEnabled = AccessLinesCheckBox.Checked;
        }
    }
}
