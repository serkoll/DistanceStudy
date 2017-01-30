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
            var centerPoint = new Point(picBox.ClientSize.Width / 2, picBox.ClientSize.Height / 2);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid = new Grid(St.GridS, centerPoint, Graphics);
            Axis = new Axis(centerPoint, Graphics);
            Grid.DrawGrid(st.GridS, Graphics);
            Axis.DrawAxis(st.AxisS, Graphics);
            CalculatePlanes(Axis.Center);
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
            Grid.CalculateKnotsPoints(Graphics);
            Grid.DrawGrid(St.GridS, Graphics);
            Axis.CalculateFinitePoints(Graphics);
            Axis.DrawAxis(St.AxisS, Graphics);
            strg.DrawObjects(St, Grid.CenterPoint, Graphics);
            CalculatePlanes(Axis.Center);
            PicBox.Image = (Image)Mainbmp.Clone();
            PicBox.Refresh();
        }
        private void CalculatePlanes(Point centerPoint)
        {
            PlaneX0Y = new RectangleF(0, centerPoint.Y, centerPoint.X, centerPoint.Y);
            PlaneX0Z = new RectangleF(0, 0, centerPoint.X, centerPoint.Y);
            PlaneY0Z = new RectangleF(centerPoint.X, 0, centerPoint.X, centerPoint.Y);
        }
    }
}
