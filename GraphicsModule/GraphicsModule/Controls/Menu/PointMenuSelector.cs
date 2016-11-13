using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometryObjects;

namespace GraphicsModule.Controls.Menu
{
    public partial class PointMenuSelector : UserControl
    {
        private PictureBox pb;
        public PointMenuSelector(PictureBox pb)
        {
            InitializeComponent();
            this.pb = pb;
        }

        private void buttonPoint2D_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreatePoint2D();
        }

        private void buttonPointOfPlane1_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreatePointOfPlane1X0Y();
        }

        private void buttonPointOfPlane2_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreatePointOfPlane2X0Z();
        }

        private void buttonPointOfPlane3_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreatePointOfPlane3Y0Z();
        }

        private void mainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Visible = false;
            GraphicsControl.Operations = null;
        }

        private void buttonPoint3D_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreatePoint3D();
            GraphicsControl.Operations = null;
        }

        private void buttonPoint3DGenerate_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Hand;
            GraphicsControl.SetObject = new GeneratePoint3D();
        }
    }
}
