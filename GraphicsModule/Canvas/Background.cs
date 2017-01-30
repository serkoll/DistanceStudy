using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using GraphicsModule.Geometry.CoordinateSystem;

namespace GraphicsModule.Canvas
{
    public class Background
    {
        public Bitmap BackBitmap { get; set; }
        public Axis Axis { get; set; }
        public Grid Grid { get; set; }
        public Background(Axis axis, Grid grid, Control pb)
        {
            Axis = axis;
            Grid = grid;
            BackBitmap = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height, PixelFormat.Format24bppRgb);
            BackBitmap.MakeTransparent();
        }
        public Background(Point centerPoint, Settings.Settings settings, Control pb)
        {
            BackBitmap = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height, PixelFormat.Format24bppRgb);
            BackBitmap.MakeTransparent();
            var graphics = Graphics.FromImage(BackBitmap);
            Axis = new Axis(centerPoint, graphics);
            Grid = new Grid(settings.GridS, centerPoint, graphics);
            DrawBackground(settings);
        }
        public void DrawBackground(Settings.Settings settings)
        {
            var graphics = Graphics.FromImage(BackBitmap);
            Grid.DrawGrid(settings.GridS, graphics);
            Axis.DrawAxis(settings.AxisS, graphics);
            graphics.Dispose();
        }
    }
}
