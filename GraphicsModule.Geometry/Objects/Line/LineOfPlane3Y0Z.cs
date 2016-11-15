using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Point;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Line
{
    /// <summary>Класс для расчета параметров проекции 3D линии на Y0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlane3Y0Z : IObject, ILineOfPlane
    {
        public PointOfPlane3Y0Z Point0 { get; set; }
        public PointOfPlane3Y0Z Point1 { get; set; }
        public List<PointF> pts { get; set; }
        private LineDrawCalc _calc;
        public double ky { get; set; }
        public double kz { get; set; }
        public LineOfPlane3Y0Z()
        {
            Point0 = new PointOfPlane3Y0Z();
            Point1 = new PointOfPlane3Y0Z();
        }
        public LineOfPlane3Y0Z(Point3D pt0, Point3D pt1)
        {
            Point0.Y = pt0.Y;
            Point0.Z = pt0.Z;
            Point1.Y = pt1.Y;
            Point1.Z = pt1.Z;
        }
        public LineOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            ky = pt1.Y - pt0.Y;
            kz = pt1.Z - pt0.Z;

        }
        public LineOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1, System.Drawing.Point frameCenter, RectangleF rc)
        {
            Point0 = pt0;
            Point1 = pt1;
            ky = pt1.Y - pt0.Y;
            kz = pt1.Z - pt0.Z;
            _calc = new LineDrawCalc(frameCenter, rc);
            pts = _calc.CalculatePointsForDraw(this);
        }
        
        public LineOfPlane3Y0Z(Line3D line)
        {
            Point0.Y = line.Point0.Y;
            Point0.Z = line.Point0.Z;
            Point1.Y = line.Point1.Y;
            Point1.Z = line.Point1.Z;
        }
        public void Draw(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane3Y0Z, pts[0], pts[1]);
        }
        public void DrawLineOnly(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane3Y0Z, pts[0], pts[1]);
        }
        public void CalculatePointsForDraw()
        {
            pts = _calc.CalculatePointsForDraw(this);
        }
        public void CalculatePointsForDraw(System.Drawing.Point frameCenter, RectangleF rc)
        {
            _calc = new LineDrawCalc(frameCenter, rc);
            pts = _calc.CalculatePointsForDraw(this);
        }
        public bool IsSelected(System.Drawing.Point mscoords, float ptR, System.Drawing.Point frameCenter, double distance)
        {
            var ln = DeterminePosition.ForLineProjection(this, frameCenter);
            return Analyze.Analyze.LinesPos.IncidenceOfPoint(mscoords, ln, 35 * distance);
        }
    }
}
