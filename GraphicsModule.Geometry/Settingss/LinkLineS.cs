using System.Drawing;

namespace GraphicsModule.Geometry.Settings
{
    public class LinkLineS
    {
        public bool IsDraw { get; set; }
        public Pen LinkLineX0YToX { get; set; }
        public Pen LinkLineX0YToY { get; set; }
        public Pen LinkLineX0ZToX { get; set; }
        public Pen LinkLineX0ZToZ { get; set; }
        public Pen LinkLineY0ZToY { get; set; }
        public Pen LinkLineY0ZToZ { get; set; }
        public bool LinkPointToX { get; set; }
        public bool LinkPointToY { get; set; }
        public bool LinkPointToZ { get; set; }
        public bool LinkXToBorderPi1 { get; set; }
        public bool LinkYToBorderPi1 { get; set; }
        public bool LinkXToBorderPi2 { get; set; }
        public bool LinkZToBorderPi2 { get; set; }
        public bool LinkYToBorderPi3 { get; set; }
        public bool LinkZToBorderPi3 { get; set; }
        public bool LinkCurveY3ToY1 { get; set; }
        public bool LinkCurveY1ToY3 { get; set; }
        public LinkLineS()
        {
            IsDraw = true;
            LinkLineX0YToX = new Pen(Color.LightGreen, 0.3F);
            LinkLineX0YToY = new Pen(Color.Blue, 0.3F);
            LinkLineX0ZToX = new Pen(Color.LightGreen, 0.3F);
            LinkLineX0ZToZ = new Pen(Color.Red, 0.3F);
            LinkLineY0ZToY = new Pen(Color.Blue, 0.3F);
            LinkLineY0ZToZ = new Pen(Color.Red, 0.3F);
            LinkXToBorderPi1 = true;
            LinkYToBorderPi1 = true;
            LinkXToBorderPi2 = true;
            LinkZToBorderPi2 = true;
            LinkYToBorderPi3 = true;
            LinkZToBorderPi3 = true;
            LinkCurveY3ToY1 = true;
            LinkCurveY1ToY3 = true;
        }
        public LinkLineS(Pen selectedPen)
        {
            IsDraw = true;
            LinkLineX0YToX = selectedPen;
            LinkLineX0YToY = selectedPen;
            LinkLineX0ZToX = selectedPen;
            LinkLineX0ZToZ = selectedPen;
            LinkLineY0ZToY = selectedPen;
            LinkLineY0ZToZ = selectedPen;
            LinkXToBorderPi1 = true;
            LinkYToBorderPi1 = true;
            LinkXToBorderPi2 = true;
            LinkZToBorderPi2 = true;
            LinkYToBorderPi3 = true;
            LinkZToBorderPi3 = true;
            LinkCurveY3ToY1 = true;
            LinkCurveY1ToY3 = true;
        }
    }
}
