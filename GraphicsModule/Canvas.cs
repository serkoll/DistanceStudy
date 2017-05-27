using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;

namespace GraphicsModule
{
    public class Canvas
    {
        private Bitmap _bitmap;

        public Canvas(Settings settings, PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            Settings = settings;
            this.CalculateBackground();
            _bitmap = new Bitmap(Background.Bitmap);
            _bitmap.MakeTransparent();
            Graphics = Graphics.FromImage(_bitmap);
            this.CalculatePlanes(Background.Axis.Center);
            this.Refresh();
        }

        public void CalculateBackground()
        {
            CenterSystemPoint = new Point(PictureBox.ClientSize.Width / 2, PictureBox.ClientSize.Height / 2);
            Background = new Background(CenterSystemPoint, Settings, PictureBox);
        }

        public void Refresh()
        {
            PictureBox.Image = (Image)_bitmap.Clone();
            PictureBox.Refresh();
        }

        public void Update(Storage strg)
        {
            _bitmap = new Bitmap(Background.Bitmap);
            _bitmap.MakeTransparent();
            Graphics = Graphics.FromImage(_bitmap);
            strg.DrawObjects(Settings, Background.Axis.Center, Graphics);
            this.CalculatePlanes(Background.Axis.Center);
            this.Refresh();
        }

        private void CalculatePlanes(Point centerPoint)
        {
            PlaneX0Y = new RectangleF(0, centerPoint.Y, centerPoint.X, centerPoint.Y);
            PlaneX0Z = new RectangleF(0, 0, centerPoint.X, centerPoint.Y);
            PlaneY0Z = new RectangleF(centerPoint.X, 0, centerPoint.X, centerPoint.Y);
        }

        public PictureBox PictureBox { get; set; }

        public Settings Settings { get; set; }

        public Background Background { get; set; }

        public Graphics Graphics { get; set; }

        public RectangleF PlaneX0Y { get; set; }

        public RectangleF PlaneX0Z { get; set; }

        public RectangleF PlaneY0Z { get; set; }

        public Point CenterSystemPoint { get; set; }
    }
}
