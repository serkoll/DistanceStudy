using System.Drawing;

namespace GraphicsModule.Configuration.Cursors
{
    public class Circle:Cursor
    {
        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            g.DrawEllipse(new Pen(color), 3*x/8,3*y/8,10,10);
        }
    }
}
