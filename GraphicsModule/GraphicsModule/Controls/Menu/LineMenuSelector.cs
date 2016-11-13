using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsModule.Controls.Menu
{
    public partial class LineMenuSelector : UserControl
    {
        private PictureBox pb;
        public LineMenuSelector(PictureBox pb)
        {
            InitializeComponent();
            this.pb = pb;
        }

        private void mainStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Visible = false;
            GraphicsControl.Operations = null;
        }

        private void buttonLine2D_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreateLine2D();
        }

        private void buttonLineOfPlane1X0Y_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreateLineOfPlane1X0Y();
        }

        private void buttonLineOfPlane2X0Z_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreateLineOfPlane2X0Z();
        }

        private void buttonLineOfPlane3Y0Z_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreateLineOfPlane3Y0Z();
        }

        private void buttonLine3D_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Cross;
            GraphicsControl.SetObject = new CreateLine3D();
        }

        private void buttonGenerateLine3D_Click(object sender, EventArgs e)
        {
            pb.Cursor = Cursors.Hand;
            GraphicsControl.SetObject = new GenerateLine3D();
        }
    }
}
