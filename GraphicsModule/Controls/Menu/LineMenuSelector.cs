using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Rules.Objects;
using GraphicsModule.Rules.Objects.Lines;

namespace GraphicsModule.Controls.Menu
{
    public partial class LineMenuSelector : UserControl
    {
        private PictureBox _mainPictureBox;
        private ToolStripButton _mainStripButton;
        private StatusStrip _menuStrip;
        public LineMenuSelector(PictureBox mainPictureBox, ToolStripButton mainStripButton, StatusStrip menuStrip, LinesAccess linesAccess)
        {
            InitializeComponent();
            _mainPictureBox = mainPictureBox;
            _mainStripButton = mainStripButton;
            _menuStrip = menuStrip;
            buttonLine2D.Enabled = linesAccess.IsLine2DEnabled;
            buttonLine3D.Enabled = linesAccess.IsLine3DEnabled;
            buttonLineOfPlane1X0Y.Enabled = linesAccess.IsLineOfPlane1X0YEnabled;
            buttonLineOfPlane2X0Z.Enabled = linesAccess.IsLineOfPlane2X0ZEnabled;
            buttonLineOfPlane3Y0Z.Enabled = linesAccess.IsLineOfPlane3Y0ZEnabled;
            buttonGenerateLine3D.Enabled = linesAccess.IsGenerateLine3DEnabled;
        }
        public void SetAccess(LinesAccess linesAccess)
        {
            buttonLine2D.Enabled = linesAccess.IsLine2DEnabled;
            buttonLine3D.Enabled = linesAccess.IsLine3DEnabled;
            buttonLineOfPlane1X0Y.Enabled = linesAccess.IsLineOfPlane1X0YEnabled;
            buttonLineOfPlane2X0Z.Enabled = linesAccess.IsLineOfPlane2X0ZEnabled;
            buttonLineOfPlane3Y0Z.Enabled = linesAccess.IsLineOfPlane3Y0ZEnabled;
            buttonGenerateLine3D.Enabled = linesAccess.IsGenerateLine3DEnabled;
        }
        private void mainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Visible = false;
            GraphicsControl.Operations = null;
            _menuStrip.Visible = true;
            _menuStrip.Items[2].Visible = false;
        }
        private void buttonLine2D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateLine2D();
            _mainStripButton.Image = buttonLine2D.Image;
        }
        private void buttonLineOfPlane1X0Y_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateLineOfPlane1X0Y();
            _mainStripButton.Image = buttonLineOfPlane1X0Y.Image;
        }
        private void buttonLineOfPlane2X0Z_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateLineOfPlane2X0Z();
            _mainStripButton.Image = buttonLineOfPlane2X0Z.Image;
        }
        private void buttonLineOfPlane3Y0Z_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateLineOfPlane3Y0Z();
            _mainStripButton.Image = buttonLineOfPlane3Y0Z.Image;
        }
        private void buttonLine3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateLine3D();
            _mainStripButton.Image = buttonLine3D.Image;
        }
        private void buttonGenerateLine3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            GraphicsControl.SetObject = new GenerateLine3D();
            _mainStripButton.Image = buttonGenerateLine3D.Image;
        }
    }
}

