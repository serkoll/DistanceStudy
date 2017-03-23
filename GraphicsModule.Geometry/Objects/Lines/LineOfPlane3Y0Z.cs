using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    /// <summary>Класс для расчета параметров проекции 3D линии на Y0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlane3Y0Z : ILineOfPlane
    {
        public PointOfPlane3Y0Z Point0 { get; set; }
        public PointOfPlane3Y0Z Point1 { get; set; }
        public Name Name { get; set; }
        public List<PointF> DrawPoints { get; set; }
        private LineDrawCalc _calc;
        public double Ky { get; set; }
        public double Kz { get; set; }
        public LineOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;

        }
        public LineOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1, Point frameCenter, RectangleF rc)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;
            _calc = new LineDrawCalc(frameCenter, rc);
            DrawPoints = _calc.CalculatePointsForDraw(this);
            Name = new Name();
        }
        
        public LineOfPlane3Y0Z(Line3D line)
        {
            Point0.Y = line.Point0.Y;
            Point0.Z = line.Point0.Z;
            Point1.Y = line.Point1.Y;
            Point1.Z = line.Point1.Z;
        }
        public void Draw(DrawS st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane3Y0Z, DrawPoints[0], DrawPoints[1]);
        }
        public void DrawLineOnly(DrawS st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane3Y0Z, DrawPoints[0], DrawPoints[1]);
        }
        public void CalculatePointsForDraw(Point frameCenter, RectangleF rc)
        {
            _calc = new LineDrawCalc(frameCenter, rc);
            DrawPoints = _calc.CalculatePointsForDraw(this);
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var ln = DeterminePosition.ForLineProjection(this, frameCenter);
            return Analyze.Analyze.LinesPos.IncidenceOfPoint(mscoords, ln, 35 * distance);
        }
        public Name GetName()
        {
            var name = new Name(Name.Value.Remove(Name.Value.IndexOf("'", StringComparison.Ordinal)), Name.Dx, Name.Dy);
            return name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Name.Value += "'''";
            Point0.Name = Name;
            Point1.Name = Name;
        }
    }
}
