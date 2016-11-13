using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GeometryObjects
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlane2X0Z : IObject, ILineOfPlane
    { 
        public PointOfPlane2X0Z Point0 { get; set; }
        public PointOfPlane2X0Z Point1 { get; set; }
        public List<PointF> pts { get; set; }
        private LineDrawCalc calc;
        public double kx { get; set; }
        public double kz { get; set; }
        public LineOfPlane2X0Z()
        {
            Point0 = new PointOfPlane2X0Z();
            Point1 = new PointOfPlane2X0Z();
        }
        public LineOfPlane2X0Z(Point3D pt0, Point3D pt1)
        {
            Point0.X = pt0.X;
            Point0.Z = pt0.Z;
            Point1.X = pt1.X;
            Point1.Z = pt1.Z;
        }
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            kx = pt1.X - pt0.X;
            kz = pt1.Z - pt0.Z;
        }
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1, Point frameCenter, RectangleF rc)
        {
            Point0 = pt0;
            Point1 = pt1;
            kx = pt1.X - pt0.X;
            kz = pt1.Z - pt0.Z;
            calc = new LineDrawCalc(frameCenter, rc);
            pts = calc.CalculatePointsForDraw(this);
        }
        public LineOfPlane2X0Z(Line3D line)
        {
            Point0.X = line.Point0.X;
            Point0.Z = line.Point0.Z;
            Point1.X = line.Point1.X;
            Point1.Z = line.Point1.Z;
        }
        public void Draw(DrawS st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane2X0Z, pts[0], pts[1]);
        }
        public void DrawLineOnly(DrawS st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane2X0Z, pts[0], pts[1]);
        }
        public void CalculatePointsForDraw()
        {
            pts = calc.CalculatePointsForDraw(this);
        }
        public void CalculatePointsForDraw(Point frameCenter, RectangleF rc)
        {
            calc = new LineDrawCalc(frameCenter, rc);
            pts = calc.CalculatePointsForDraw(this);
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var ln = DeterminePosition.ForLineProjection(this, frameCenter);
            if (Analyze.LinesPos.IncidenceOfPoint(mscoords, ln, 35 * distance))
                return true;
            else
                return false;
        }
    }
}