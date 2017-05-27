using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.CoordinateSystem;

namespace GraphicsModule
{
    public class Background
    {
        public Background(Point centerPoint, Settings settings, Control pictureBox)
        {
            Bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height, PixelFormat.Format24bppRgb);
            Bitmap.MakeTransparent();
            using (var graphics = Graphics.FromImage(Bitmap))
            {
                Axis = new Axis(centerPoint, graphics);
                Grid = new Grid(settings.GridSettings, centerPoint, graphics);
                this.Draw(settings, graphics);
            }
        }
        private void Draw(Settings settings, Graphics graphics)
        {
            Grid.DrawGrid(settings.GridSettings, graphics);
            Axis.DrawAxis(settings.AxisSettings, graphics);
        }

        public Bitmap Bitmap { get; private set; }

        public Axis Axis { get; private set; }

        public Grid Grid { get; private set; }
    }
}
