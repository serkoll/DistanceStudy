using System.Drawing;
using GraphicsModule.Geometry.Settingss;

namespace GraphicsModule.Setting
{
    public class Settings
    {
        public GridS GridS { get; set; }
        public AxisS AxisS { get; set; }
        public DrawS DrawS { get; set; }
        public DrawS SelectedDrawS { get; set; }
        public Settings()
        {
            GridS = new GridS();
            AxisS = new AxisS();
            DrawS = new DrawS();
            SelectedDrawS = new DrawS(new Pen(Brushes.Orange, 4), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), 2, 1);
        }
    }
}
