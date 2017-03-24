using System.Drawing;

namespace GraphicsModule.Configuration.Cursors
{
    class Square:Cursor
    {
        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            g.DrawRectangle(new Pen(color), 3*x/8,3*y/8,10,10);
        }
    }
}
