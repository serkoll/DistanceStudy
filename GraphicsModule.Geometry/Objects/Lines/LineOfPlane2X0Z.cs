using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Lines
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlane2X0Z : ILineOfPlane
    { 
        public PointOfPlane2X0Z Point0 { get; set; }
        public PointOfPlane2X0Z Point1 { get; set; }
        public Name Name { get; set; }
        public List<PointF> DrawPoints { get; set; }
        private LineDrawCalc _calc;
        public double Kx { get; set; }
        public double Kz { get; set; }
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
        }
        public LineOfPlane2X0Z(PointOfPlane2X0Z pt0, PointOfPlane2X0Z pt1, Point frameCenter, RectangleF rc)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Kz = pt1.Z - pt0.Z;
            _calc = new LineDrawCalc(frameCenter, rc);
            DrawPoints = _calc.CalculatePointsForDraw(this);
            Name = new Name();
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
            g.DrawLine(st.PenLineOfPlane2X0Z, DrawPoints[0], DrawPoints[1]);
        }
        public void DrawLineOnly(DrawS st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane2X0Z, DrawPoints[0], DrawPoints[1]);
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
            Name.Value += "''";
            Point0.Name = Name;
            Point1.Name = Name;
        }
    }
}