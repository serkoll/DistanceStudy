using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.TaskAccess
{
    public partial class PointsAccessControl : UserControl
    {
        public PointsAccess PointsAccess { get; set; }
        public PointsAccessControl()
        {
            InitializeComponent();
            PointsAccess = GraphicsControlSettingsForm.CurrentSettings.Access.Points;
            accessPointsCheckBox.Checked = PointsAccess.IsPointsEnabled;
            accessPoint2DCheckBox.Checked = PointsAccess.IsPoint2DEnabled;
            accessPoint3DCheckBox.Checked = PointsAccess.IsPoint3DEnabled;
            accessPointOfPlane1X0YCheckBox.Checked = PointsAccess.IsPointOfPlane1X0YEnabled;
            accessPointOfPlane2X0ZCheckBox.Checked = PointsAccess.IsPointOfPlane2X0ZEnabled;
            accessPointOfPlane3Y0ZCheckBox.Checked = PointsAccess.IsPointOfPlane3Y0ZEnabled;
            accessGeneratePoint3DCheckBox.Checked = PointsAccess.IsGeneratePoint3DEnabled;
        }

        private void AccessPoint2DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsPoint2DEnabled = accessPoint2DCheckBox.Checked;
        }

        private void AccessPoint3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsPoint3DEnabled = accessPoint3DCheckBox.Checked;
        }

        private void AccessPointOfPlane1X0YCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsPointOfPlane1X0YEnabled = accessPointOfPlane1X0YCheckBox.Checked;
        }

        private void AccessPointOfPlane2X0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsPointOfPlane2X0ZEnabled = accessPointOfPlane2X0ZCheckBox.Checked;
        }

        private void AccessPointOfPlane3Y0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsPointOfPlane3Y0ZEnabled = accessPointOfPlane3Y0ZCheckBox.Checked;
        }
        private void AccessGeneratePoint3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsGeneratePoint3DEnabled = accessGeneratePoint3DCheckBox.Checked;
        }

        private void accessPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PointsAccess.IsPointsEnabled = accessPointsCheckBox.Checked;
        }
    }
}
