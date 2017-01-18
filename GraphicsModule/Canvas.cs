using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using GraphicsModule.Geometry.CoordinateSystem;

namespace GraphicsModule
{
    public class Canvas
    {
        public PictureBox PicBox { get; set; }
        public Settings.Settings St { get; set; }
        public Bitmap Mainbmp { get; set; }
        public Graphics Graphics { get; set; }
        public Grid Grid { get; set; }
        public Axis Axis { get; set; }
        public RectangleF PlaneX0Y { get; set; }
        public RectangleF PlaneX0Z { get; set; }
        public RectangleF PlaneY0Z { get; set; }
        public Canvas(Settings.Settings st, PictureBox picBox)
        {
            PicBox = picBox;
            St = st;
            Mainbmp = new Bitmap(picBox.ClientSize.Width, picBox.ClientSize.Height, PixelFormat.Format24bppRgb);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid = new Grid(St.GridS, Graphics);
            Axis = new Axis(Graphics);
            Grid.DrawGrid(st.GridS, Graphics);
            Axis.DrawAxis(st.AxisS, Graphics);
            PlaneX0Y = new RectangleF(0, Axis.Center.Y, Axis.Center.X, Axis.Center.Y);
            PlaneX0Z = new RectangleF(0, 0, Axis.Center.X, Axis.Center.Y);
            PlaneY0Z = new RectangleF(Axis.Center.X, 0, Axis.Center.X, Axis.Center.Y);
            picBox.Image = (Image)Mainbmp.Clone();
            picBox.Refresh();
        }  
        public void Refresh()
        {
            PicBox.Image = (Image)Mainbmp.Clone();
            PicBox.Refresh();
        }
        public void Update(Storage strg)
        {
            Mainbmp = new Bitmap(PicBox.ClientSize.Width, PicBox.ClientSize.Height, PixelFormat.Format24bppRgb);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid = new Grid(St.GridS, Graphics);
            Axis = new Axis(Graphics);
            Grid.DrawGrid(St.GridS, Graphics);
            Axis.DrawAxis(St.AxisS, Graphics);
            strg.DrawObjects(St, Grid.CenterPoint, Graphics);
            PicBox.Image = (Image)Mainbmp.Clone();
            PicBox.Refresh();
        }
    }
}
