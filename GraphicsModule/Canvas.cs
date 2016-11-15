using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using GraphicsModule.Background;


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
            Grid = new Grid(st);
            Axis = new Axis(st);
            Grid.CreateGridToGraphics(Graphics);
            Axis.CalculateByGrid(Grid.Knots);
            if (st.AxisS.IsDraw)
            {
                Axis.AddAxisToGraphics(Grid.Center, Graphics);
            }
            PlaneX0Y = new RectangleF(0, Grid.Center.Y, Grid.Center.X, Grid.Center.Y);
            PlaneX0Z = new RectangleF(0, 0, Grid.Center.X, Grid.Center.Y);
            PlaneY0Z = new RectangleF(Grid.Center.X, 0, Grid.Center.X, Grid.Center.Y);
            picBox.Image = (Image)Mainbmp.Clone();
            picBox.Refresh();
        }
        
        public void Update()
        {
            PicBox.Image = (Image)Mainbmp.Clone();
            PicBox.Refresh();
        }
        public void Update(PictureBox pb)
        {
            pb.Image = (Image)Mainbmp.Clone();
            pb.Refresh();
        }
        public void ReDraw(Settings.Settings st, Storage strg, PictureBox pb)
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
            Mainbmp = new Bitmap(PicBox.ClientSize.Width, PicBox.ClientSize.Height, PixelFormat.Format24bppRgb);
            Mainbmp.MakeTransparent();
            Graphics = Graphics.FromImage(Mainbmp);
            Grid.CreateGridToGraphics(Graphics);
            Axis.CalculateByGrid(Grid.Knots);
            if (St.AxisS.IsDraw)
            {
                Axis.AddAxisToGraphics(Grid.Center, Graphics);
            }

            strg.DrawObjects(St, Grid.Center, Graphics);

            PicBox.Image = (Image)Mainbmp.Clone();
            PicBox.Refresh();
        }
    }
}
