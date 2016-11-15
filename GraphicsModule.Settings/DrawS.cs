using System.Drawing;

namespace GraphicsModule.Settings
{
    public class DrawS
    {
        public Pen PenPoints { get; set; }
        public Pen PenLine2D { get; set; }
        public Pen PenLineOfPlane1X0Y { get; set; }
        public Pen PenLineOfPlane2X0Z { get; set; }
        public Pen PenLineOfPlane3Y0Z { get; set; }
        public int RadiusPoints { get; set; }  
        public int RadiusLines { get; set; }
        public LinkLineS LinkLineSettings { get; set; }
        public DrawS()
        {
            RadiusPoints = 2;
            RadiusLines = 1;
            PenPoints = new Pen(Brushes.Black, RadiusPoints * 2);
            PenLine2D = new Pen(Brushes.Black, RadiusLines);
            PenLineOfPlane1X0Y = new Pen(Brushes.LightGreen, RadiusLines);
            PenLineOfPlane2X0Z = new Pen(Brushes.Red, RadiusLines);
            PenLineOfPlane3Y0Z = new Pen(Brushes.Blue, RadiusLines);
            LinkLineSettings = new LinkLineS();
        }
        public DrawS(Pen pnPoints, Pen pnLine2D, Pen pnLn1, Pen pnLn2, Pen pnLn3, int rPoints, int rLines)
        {
            RadiusPoints = rPoints;
            RadiusLines = rLines;
            PenPoints = pnPoints;
            PenLine2D = pnLine2D;
            PenLineOfPlane1X0Y = pnLn1;
            PenLineOfPlane2X0Z = pnLn2;
            PenLineOfPlane3Y0Z = pnLn3;
            LinkLineSettings = new LinkLineS(pnLine2D);
        }
    }
}
