using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Lines
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlane2X0Z : IObject, ILineOfPlane
    { 
        public PointOfPlane2X0Z Point0 { get; set; }
        public PointOfPlane2X0Z Point1 { get; set; }
        public List<PointF> pts { get; set; }
        private LineDrawCalc _calc;
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
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1, System.Drawing.Point frameCenter, RectangleF rc)
        {
            Point0 = pt0;
            Point1 = pt1;
            kx = pt1.X - pt0.X;
            kz = pt1.Z - pt0.Z;
            _calc = new LineDrawCalc(frameCenter, rc);
            pts = _calc.CalculatePointsForDraw(this);
        }
        public LineOfPlane2X0Z(Line3D line)
        {
            Point0.X = line.Point0.X;
            Point0.Z = line.Point0.Z;
            Point1.X = line.Point1.X;
            Point1.Z = line.Point1.Z;
        }
        public void Draw(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane2X0Z, pts[0], pts[1]);
        }
        public void DrawLineOnly(DrawS st, System.Drawing.Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane2X0Z, pts[0], pts[1]);
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