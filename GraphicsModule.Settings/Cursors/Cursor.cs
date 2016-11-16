using System.Drawing;

namespace GraphicsModule.Settings.Cursors
{
    public abstract class Cursor
    {
        public Color CursorColor { get; set; }
        public abstract void Draw(int x, int y, Color color, Graphics picture);
    }
}
