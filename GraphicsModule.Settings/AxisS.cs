using System.Drawing;

namespace GraphicsModule.Settings
{
    public class AxisS
    {
        public int Width { get; set; }
        public Color ColorX { get; set; }
        public Color ColorY { get; set; }
        public Color ColorZ { get; set; }
        public bool FlagDrawX { get; set; }
        public bool FlagDrawY { get; set; }
        public bool FlagDrawZ { get; set; }
        public bool IsDraw { get; set; }
        public AxisS()
        {
            Width = 1;
            ColorX = Color.Black;
            ColorY = Color.Black;
            ColorZ = Color.Black;
            FlagDrawX = true;
            FlagDrawY = true;
            FlagDrawZ = true;
            IsDraw = true;
        }
    }
}
