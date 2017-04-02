using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    /// <summary>Класс для расчета параметров проекции 3D линии на X0Y плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlane1X0Y : ILineOfPlane
    {
        //TODO: логику имен, рефакторинг
        public PointOfPlane1X0Y Point0 { get; set; }
        public PointOfPlane1X0Y Point1 { get; set; }
        public Name Name { get; set; }
        public double Kx { get; set; }
        public double Ky { get; set; }
        private LineDrawCalc _calc;
        public List<PointF> DrawPoints { get; set; }
        public LineOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
        }
        public LineOfPlane1X0Y(PointOfPlane1X0Y pt0, PointOfPlane1X0Y pt1, Point frameCenter, RectangleF rc)
        {
            Point0 = pt0;
            Point1 = pt1;
            Kx = pt1.X - pt0.X;
            Ky = pt1.Y - pt0.Y;
            _calc = new LineDrawCalc(frameCenter, rc);
            DrawPoints = _calc.CalculatePointsForDraw(this);
            Name = new Name();
        }
        public LineOfPlane1X0Y(Line3D line)
        {
            Point0.X = line.Point0.X;
            Point0.Y = line.Point0.Y;
            Point1.X = line.Point1.X;
            Point1.Y = line.Point1.Y;
        }
        public void Draw(DrawSettings settings, Point framecenter, Graphics g)
        {
            Point0.Draw(settings, framecenter, g);
            Point1.Draw(settings, framecenter, g);
            g.DrawLine(settings.PenLineOfPlane1X0Y, DrawPoints[0], DrawPoints[1]);
        }
        public void DrawLineOnly(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane1X0Y, DrawPoints[0], DrawPoints[1]);
        }
        public void CalculatePointsForDraw(Point frameCenter, RectangleF rc)
        {
            _calc = new LineDrawCalc(frameCenter, rc);
            DrawPoints = _calc.CalculatePointsForDraw(this);
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var ln = DeterminePosition.ForLineProjection(this, frameCenter);
            return Analyze.Analyze.LinesPosition.IncidenceOfPoint(mscoords, ln, 35 * distance);
        }
        public Name GetName()
        {
            var name = new Name(Name.Value.Remove(Name.Value.IndexOf("'", StringComparison.Ordinal)), Name.Dx, Name.Dy);
            return name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Name.Value += "'";
            Point0.Name = Name;
            Point1.Name = Name;
        }
    }
}