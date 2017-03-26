using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;

namespace GraphicsModule
{
    public class Canvas
    {
        public PictureBox PicBox { get; set; }
        public Settings Settings { get; set; }
        public Bitmap Mainbmp { get; set; }
        public Background Background { get; set; }
        public Graphics Graphics { get; set; }
        public RectangleF PlaneX0Y { get; set; }
        public RectangleF PlaneX0Z { get; set; }
        public RectangleF PlaneY0Z { get; set; }
        public Point CenterSystemPoint { get; set; }
        public Canvas(Settings settings, PictureBox picBox)
        {
            PicBox = picBox;
            Settings = settings;
            CalculateBackground();
            Mainbmp = new Bitmap(Background.BackBitmap);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            CalculatePlanes(Background.Axis.Center);
            picBox.Image = (Image)Mainbmp.Clone();
            picBox.Refresh();
        }

        public void CalculateBackground()
        {
            CenterSystemPoint = new Point(PicBox.ClientSize.Width / 2, PicBox.ClientSize.Height / 2);
            Background = new Background(CenterSystemPoint, Settings, PicBox);
        }
        public void Refresh()
        {
            PicBox.Image = (Image)Mainbmp.Clone();
            PicBox.Refresh();
        }
        public void Update(Storage strg)
        {
            Mainbmp = new Bitmap(Background.BackBitmap);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            strg.DrawObjects(Settings, Background.Axis.Center, Graphics);
            CalculatePlanes(Background.Axis.Center);
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
