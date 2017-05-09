using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.CoordinateSystem;

namespace GraphicsModule
{
    //TODO: логика отрисовки
    public class Background
    {
        public Background(Point centerPoint, Settings settings, Control pb)
        {
            BackBitmap = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height, PixelFormat.Format24bppRgb);
            BackBitmap.MakeTransparent();
            var graphics = Graphics.FromImage(BackBitmap);
            Axis = new Axis(centerPoint, graphics);
            Grid = new Grid(settings.GridSettings, centerPoint, graphics);
            DrawBackground(settings);
        }
        public void DrawBackground(Settings settings)
        {
            var graphics = Graphics.FromImage(BackBitmap);
            Grid.DrawGrid(settings.GridSettings, graphics);
            Axis.DrawAxis(settings.AxisSettings, graphics);
            graphics.Dispose();
        }
        public Bitmap BackBitmap { get; set; }
        public Axis Axis { get; set; }
        public Grid Grid { get; set; }
    }
}
