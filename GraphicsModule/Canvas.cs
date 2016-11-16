using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using GraphicsModule.Background;


namespace GraphicsModule
{
    public class Canvas
    {
        public PictureBox pb { get; set; }
        public Setting.Settings st { get; set; }
        public Bitmap Mainbmp { get; set; }
        public Graphics Graphics { get; set; }
        public Grid Grid { get; set; }
        public Axis Axis { get; set; }
        public RectangleF PlaneX0Y { get; set; }
        public RectangleF PlaneX0Z { get; set; }
        public RectangleF PlaneY0Z { get; set; }
        public Canvas(Setting.Settings st, PictureBox pb)
        {
            this.pb = pb;
            this.st = st;
            Mainbmp = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height, PixelFormat.Format24bppRgb);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid = new Grid(st);
            Axis = new Axis(st);
            Grid.CreateGridToGraphics(Graphics);
            Axis.CalculateByGrid(Grid.Knots);
            if (st.AxisS.IsDraw)
            {
                Axis.AddAxisToGraphics(Grid.Center, Graphics);
            }
            PlaneX0Y = new RectangleF(0, pb.Height / 2, pb.Width / 2, pb.Height / 2);
            PlaneX0Z = new RectangleF(0, 0, pb.Width / 2, pb.Height / 2);
            PlaneY0Z = new Rectangle(pb.Width / 2, 0, pb.Width / 2, pb.Height / 2);
            pb.Image = (Image)Mainbmp.Clone();
            pb.Refresh();
        }
        
        public void Update()
        {
            pb.Image = (Image)Mainbmp.Clone();
            pb.Refresh();
        }
        public void Update(PictureBox pb)
        {
            pb.Image = (Image)Mainbmp.Clone();
            pb.Refresh();
        }
        public void ReDraw(Setting.Settings st, Storage strg, PictureBox pb)
        {
            Mainbmp = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height, PixelFormat.Format24bppRgb);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid.CreateGridToGraphics(Graphics);
            Axis.CalculateByGrid(Grid.Knots);
            if (st.AxisS.IsDraw)
            {
                Axis.AddAxisToGraphics(Grid.Center, Graphics);
            }

            strg.DrawObjects(st, Grid.Center, Graphics);

            pb.Image = (Image)Mainbmp.Clone();
            pb.Refresh();
        }
        public void ReDraw(Storage strg)
        {
            Mainbmp = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height, PixelFormat.Format24bppRgb);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid.CreateGridToGraphics(Graphics);
            Axis.CalculateByGrid(Grid.Knots);
            if (st.AxisS.IsDraw)
            {
                Axis.AddAxisToGraphics(Grid.Center, Graphics);
            }

            strg.DrawObjects(st, Grid.Center, Graphics);

            pb.Image = (Image)Mainbmp.Clone();
            pb.Refresh();
        }
    }
}
