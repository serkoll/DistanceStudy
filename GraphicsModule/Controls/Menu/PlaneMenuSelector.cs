﻿using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Rules.Create.Planes;
using GraphicsModule.Rules.Generate;

namespace GraphicsModule.Controls.Menu
{
    public partial class PlaneMenuSelector : UserControl
    {
        private PictureBox _mainPictureBox;
        private ToolStripButton _mainStripButton;
        private StatusStrip _menuStrip;
        public PlaneMenuSelector(PictureBox mainPictureBox, ToolStripButton mainStripButton, StatusStrip menuStrip, PlanesAccess planesAccess)
        {
            InitializeComponent();
            _mainPictureBox = mainPictureBox;
            _mainStripButton = mainStripButton;
            _menuStrip = menuStrip;
            buttonPlane2D.Enabled = planesAccess.IsPlane2DEnabled;
            buttonPlane3D.Enabled = planesAccess.IsPlane3DEnabled;
            buttonPlaneOfPlane1X0Y.Enabled = planesAccess.IsPlaneOfPlane1X0YEnabled;
            buttonPlaneOfPlane2X0Z.Enabled = planesAccess.IsPlaneOfPlane2X0ZEnabled;
            buttonPlaneOfPlane3Y0Z.Enabled = planesAccess.IsPlaneOfPlane3Y0ZEnabled;
        }

        public void SetAccess(PlanesAccess planesAccess)
        {
            buttonPlane2D.Enabled = planesAccess.IsPlane2DEnabled;
            buttonPlane3D.Enabled = planesAccess.IsPlane3DEnabled;
            buttonPlaneOfPlane1X0Y.Enabled = planesAccess.IsPlaneOfPlane1X0YEnabled;
            buttonPlaneOfPlane2X0Z.Enabled = planesAccess.IsPlaneOfPlane2X0ZEnabled;
            buttonPlaneOfPlane3Y0Z.Enabled = planesAccess.IsPlaneOfPlane3Y0ZEnabled;
            buttonGeneratePlane3D.Enabled = planesAccess.IsGeneratePlane3DEnabled;
        }
        private void mainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Visible = false;
            GraphicsControl.Operations = null;
            _menuStrip.Visible = true;
            _menuStrip.Items[2].Visible = true;
        }
        private void buttonPlane2D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePlane2D();
            _mainStripButton.Image = buttonPlane2D.Image;
        }
        private void buttonPlaneOfPlane1X0Y_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePlaneOfPlane1X0Y();
            _mainStripButton.Image = buttonPlaneOfPlane1X0Y.Image;
        }
        private void buttonPlaneOfPlane2X0Z_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePlaneOfPlane2X0Z();
            _mainStripButton.Image = buttonPlaneOfPlane2X0Z.Image;
        }
        private void buttonPlaneOfPlane3Y0Z_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePlaneOfPlane3Y0Z();
            _mainStripButton.Image = buttonPlaneOfPlane3Y0Z.Image;
        }
        private void buttonPlane3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePlane3D();
            _mainStripButton.Image = buttonPlane3D.Image;
        }
        private void buttonGeneratePlane3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            GraphicsControl.SetObject = new GenerateLine3D();
            _mainStripButton.Image = buttonGeneratePlane3D.Image;
        }
    }
}
