using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class LineOfPlane2X0Z : ILineOfPlane
    {
        private Name _name;
        //TODO: GOVNO SMENIT
        private LineDrawCalc _calc;
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
            Point0 = new PointOfPlane2X0Z(line.Point0.X, line.Point0.Z);
            Point1 = new PointOfPlane2X0Z(line.Point1.X, line.Point1.Z);
        }
        public void Draw(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane2X0Z, DrawPoints[0], DrawPoints[1]);
        }
        public void DrawLineOnly(DrawSettings st, Point framecenter, Graphics g)
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
            var ln = this.ToGlobalCoordinatesLine2D(frameCenter);
            return ln.IsIncidentalToPoint(mscoords, 35 * distance);
        }

        public PointOfPlane2X0Z Point0 { get; }

        public PointOfPlane2X0Z Point1 { get; }

        public List<PointF> DrawPoints { get; set; }

        public double Kx { get; }

        public double Kz { get; }

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