using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.TaskAccess
{
    public partial class PlanesAccessControl : UserControl
    {
        public PlanesAccess PlanesAccess { get; set; }
        public PlanesAccessControl()
        {
            InitializeComponent();
            PlanesAccess = GraphicsControlSettingsForm.CurrentSettings.Access.Planes;
            accessPlanesCheckBox.Checked = PlanesAccess.IsPlanesEnabled;
            accessPlane2DCheckBox.Checked = PlanesAccess.IsPlane2DEnabled;
            accessPlane3DCheckBox.Checked = PlanesAccess.IsPlane3DEnabled;
            accessPlaneOfPlane1X0YCheckBox.Checked = PlanesAccess.IsPlaneOfPlane1X0YEnabled;
            accessPlaneOfPlane2X0ZCheckBox.Checked = PlanesAccess.IsPlaneOfPlane2X0ZEnabled;
            accessPlaneOfPlane3Y0ZCheckBox.Checked = PlanesAccess.IsPlaneOfPlane3Y0ZEnabled;
            accessGeneratePlane3DCheckBox.Checked = PlanesAccess.IsGeneratePlane3DEnabled;
        }

        private void accessPlanesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsPlanesEnabled = accessPlanesCheckBox.Checked;
        }

        private void accessPlane2DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsPlane2DEnabled = accessPlane2DCheckBox.Checked;
        }

        private void accessGeneratePlane3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsGeneratePlane3DEnabled = accessGeneratePlane3DCheckBox.Checked;
        }

        private void accessPlaneOfPlane2X0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsPlaneOfPlane2X0ZEnabled = accessPlaneOfPlane2X0ZCheckBox.Checked;
        }

        private void accessPlaneOfPlane3Y0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsPlaneOfPlane3Y0ZEnabled = accessPlaneOfPlane3Y0ZCheckBox.Checked;
        }

        private void accessPlaneOfPlane1X0YCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsPlaneOfPlane1X0YEnabled = accessPlaneOfPlane1X0YCheckBox.Checked;
        }

        private void accessPlane3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlanesAccess.IsGeneratePlane3DEnabled = accessGeneratePlane3DCheckBox.Checked;
        }
    }
}
