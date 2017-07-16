using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class LineOfPlane1X0Y : ILineOfPlane
    {
        private Name _name;
        private LineDrawCalc _calc;
        //TODO: check
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
            //TODO: govnokod
            DrawPoints = _calc.CalculatePointsForDraw(this);
            Name = new Name();
        }

        public LineOfPlane1X0Y(Line3D line)
        {
            Point0 = new PointOfPlane1X0Y(line.Point0.X, line.Point0.Y);
            Point1 = new PointOfPlane1X0Y(line.Point1.X, line.Point1.Y);
        }

        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics g)
        {
            Point0.Draw(settings, coordinateSystemCenter, g);
            Point1.Draw(settings, coordinateSystemCenter, g);
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

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            var ln = this.ToGlobalCoordinatesLine2D(coordinateSystemCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane1X0Y Point0 { get; }

        public PointOfPlane1X0Y Point1 { get; }

        public double Kx { get; }

        public double Ky { get; }

        public Name Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Point0.Name = _name;
                Point1.Name = _name;          
            }
        }

    }
}