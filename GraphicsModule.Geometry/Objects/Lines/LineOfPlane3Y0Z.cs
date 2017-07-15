using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class LineOfPlane3Y0Z : ILineOfPlane
    {
        private Name _name;
        private LineDrawCalc _calc;

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
            Point0 = new PointOfPlane3Y0Z(line.Point0.Y, line.Point0.Z);
            Point1 = new PointOfPlane3Y0Z(line.Point1.Y, line.Point1.Z);
        }

        public void Draw(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLineOfPlane3Y0Z, DrawPoints[0], DrawPoints[1]);
        }

        public void DrawLineOnly(DrawSettings st, Point framecenter, Graphics g)
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
            return Analyze.Analyze.LinesPositionExtensions.IsIncidentalToPoint(mscoords, ln, 35 * distance);
        }

        public PointOfPlane3Y0Z Point0 { get; }

        public PointOfPlane3Y0Z Point1 { get; }
        //TODO: check
        public List<PointF> DrawPoints { get; set; }

        public double Ky { get; }

        public double Kz { get; }

        public Name Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Point0.Name = _name;
                Point1.Name = _name;
            }
        }

    }
}
