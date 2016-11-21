using System.Drawing;

namespace GraphicsModule.Settings
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

        public Settings(AxisS axisS, GridS gridS, DrawS drawS, DrawS selectedDrawS)
        {
            GridS = gridS;
            AxisS = axisS;
            DrawS = drawS;
            SelectedDrawS = SelectedDrawS;
        }
    }
}
