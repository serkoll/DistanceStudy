using System;
using System.Windows.Forms;
using GraphicsModule.CreateObjects;

namespace GraphicsModule.Controls.Menu
{
    public partial class SegmentMenuSelector : UserControl
    {
        private PictureBox _mainPictureBox;
        private ToolStripButton _mainStripButton;
        private StatusStrip _menuStrip;
        public SegmentMenuSelector(PictureBox mainPictureBox, ToolStripButton mainStripButton, StatusStrip mainStrip)
        {
            InitializeComponent();
            _mainPictureBox = mainPictureBox;
            _mainStripButton = mainStripButton;
            _menuStrip = mainStrip;
        }
        private void mainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Visible = false;
            GraphicsControl.Operations = null;
            _menuStrip.Visible = true;
            _menuStrip.Items[2].Visible = false;
        }
        private void buttonSegment2D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateSegment2D();
            _mainStripButton.Image = buttonSegment2D.Image;
        }
        private void buttonSegmentOfPlane1X0Y_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateSegmentOfPlane1X0Y();
            _mainStripButton.Image = buttonSegmentOfPlane1X0Y.Image;
        }
        private void buttonSegmentOfPlane2X0Z_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateSegmentOfPlane2X0Z();
            _mainStripButton.Image = buttonSegmentOfPlane2X0Z.Image;
        }
        private void buttonSegmentOfPlane3Y0Z_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateSegmentOfPlane3Y0Z();
            _mainStripButton.Image = buttonSegmentOfPlane3Y0Z.Image;
        }
        private void buttonSegment3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            GraphicsControl.SetObject = new CreateSegment3D();
            _mainStripButton.Image = buttonSegment3D.Image;
        }

        private void GenerateSegment3D_Click(object sender, EventArgs e)
        {
            _mainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            GraphicsControl.SetObject = new GenerateSegment3D();
            _mainStripButton.Image = buttonGenerateSegment3D.Image;
        }
    }
}
