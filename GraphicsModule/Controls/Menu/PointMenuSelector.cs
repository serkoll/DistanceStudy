using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Rules.Create.Points;
using GraphicsModule.Rules.Generate;

namespace GraphicsModule.Controls.Menu
{
    public partial class PointMenuSelector : UserControl
    {
        private PictureBox _mainPictureBox;
        private ToolStripButton _mainStripButton;
        private StatusStrip _menuStrip;
        public PointMenuSelector(PictureBox mainPictureBox, ToolStripButton mainButton, StatusStrip menuStrip, PointsAccess pointsAccess)
        {
            InitializeComponent();
            _mainStripButton = mainButton;
            _mainPictureBox = mainPictureBox;
            _menuStrip = menuStrip;
            buttonPoint2D.Enabled = pointsAccess.IsPoint2DEnabled;
            buttonPoint3D.Enabled = pointsAccess.IsPoint3DEnabled;
            buttonPointOfPlane1.Enabled = pointsAccess.IsPointOfPlane1X0YEnabled;
            buttonPointOfPlane2.Enabled = pointsAccess.IsPointOfPlane2X0ZEnabled;
            buttonPointOfPlane3.Enabled = pointsAccess.IsPointOfPlane3Y0ZEnabled;
            buttonPoint3DGenerate.Enabled = pointsAccess.IsGeneratePoint3DEnabled;
        }

        public void SetAccess(PointsAccess pointsAccess)
        {
            buttonPoint2D.Enabled = pointsAccess.IsPoint2DEnabled;
            buttonPoint3D.Enabled = pointsAccess.IsPoint3DEnabled;
            buttonPointOfPlane1.Enabled = pointsAccess.IsPointOfPlane1X0YEnabled;
            buttonPointOfPlane2.Enabled = pointsAccess.IsPointOfPlane2X0ZEnabled;
            buttonPointOfPlane3.Enabled = pointsAccess.IsPointOfPlane3Y0ZEnabled;
            buttonPoint3DGenerate.Enabled = pointsAccess.IsGeneratePoint3DEnabled;
        }
        private void buttonPoint2D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePoint2D();
            _mainStripButton.Image = buttonPoint2D.Image;
        }
        private void buttonPointOfPlane1_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePointOfPlane1X0Y();
            _mainStripButton.Image = buttonPointOfPlane1.Image;
        }
        private void buttonPointOfPlane2_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePointOfPlane2X0Z();
            _mainStripButton.Image = buttonPointOfPlane2.Image;
        }
        private void buttonPointOfPlane3_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePointOfPlane3Y0Z();
            _mainStripButton.Image = buttonPointOfPlane3.Image;
        }
        private void mainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Visible = false;
            GraphicsControl.Operations = null;
            _menuStrip.Visible = true;
            _menuStrip.Items[2].Visible = false;
        }
        private void buttonPoint3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreatePoint3D();
            _mainStripButton.Image = buttonPoint3D.Image;
            GraphicsControl.Operations = null;
        }
        private void buttonPoint3DGenerate_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            _mainStripButton.Image = buttonPoint3DGenerate.Image;
            GraphicsControl.SetObject = new GeneratePoint3D();
        }
    }
}
