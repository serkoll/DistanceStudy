using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    public class Line3D : IObject
    {
        public static Line3D Create(IList<IObject> lst)
        {
            if (lst[0].GetType() == typeof(LineOfPlane1X0Y))
            {
                return lst[1].GetType() == typeof(LineOfPlane2X0Z) 
                    ? new Line3D((LineOfPlane1X0Y)lst[0], (LineOfPlane2X0Z)lst[1]) 
                    : new Line3D((LineOfPlane1X0Y)lst[0], (LineOfPlane3Y0Z)lst[1]);
            }
            if (lst[0].GetType() == typeof(LineOfPlane2X0Z))
            {
                return lst[1].GetType() == typeof(LineOfPlane1X0Y) 
                    ? new Line3D((LineOfPlane1X0Y)lst[1], (LineOfPlane2X0Z)lst[0]) 
                    : new Line3D((LineOfPlane2X0Z)lst[0], (LineOfPlane3Y0Z)lst[1]);
            }
            return lst[1].GetType() == typeof(LineOfPlane1X0Y) 
                ? new Line3D((LineOfPlane1X0Y)lst[1], (LineOfPlane3Y0Z)lst[0]) 
                : new Line3D((LineOfPlane2X0Z)lst[1], (LineOfPlane3Y0Z)lst[0]);
        }

        public Line3D(LineOfPlane1X0Y linePi1, LineOfPlane2X0Z linePi2)
        {
            if (Math.Abs(linePi1.Point0.X - linePi2.Point0.X) < Constants.Tolerance && Math.Abs(linePi1.Point1.X - linePi2.Point1.X) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi1.Point0, linePi2.Point0);
                Point1 = new Point3D(linePi1.Point1, linePi2.Point1);
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = new LineOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point1.Z));
            }
            else 
            {
                Point0 = new Point3D(linePi1.Point1.ToPoint2D(), linePi2.Point0.Z);
                Point1 = new Point3D(linePi1.Point1.ToPoint2D(), linePi2.Point1.Z);
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = new LineOfPlane3Y0Z(new PointOfPlane3Y0Z(linePi1.Point1.Y, linePi2.Point0.Z), new PointOfPlane3Y0Z(linePi1.Point0.Y, linePi2.Point1.Z));
            }
        }
        public Line3D(LineOfPlane1X0Y linePi1, LineOfPlane3Y0Z linePi3)
        {
            if (Math.Abs(linePi1.Point0.Y - linePi3.Point0.Y) < Constants.Tolerance && Math.Abs(linePi1.Point1.Y - linePi3.Point1.Y) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi1.Point0, linePi3.Point0);
                Point1 = new Point3D(linePi1.Point1, linePi3.Point1);
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = new LineOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point0.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point1.Z));
                LineOfPlane3Y0Z = linePi3;
            }
            else 
            {
                Point0 = new Point3D(linePi1.Point0.ToPoint2D(), linePi3.Point1.Z);
                Point1 = new Point3D(linePi1.Point1.ToPoint2D(), linePi3.Point0.Z);
                LineOfPlane1X0Y = linePi1;
                LineOfPlane2X0Z = new LineOfPlane2X0Z(new PointOfPlane2X0Z(linePi1.Point0.X, linePi3.Point1.Z), new PointOfPlane2X0Z(linePi1.Point1.X, linePi3.Point0.Z));
                LineOfPlane3Y0Z = linePi3;
            }
        }
        public Line3D(LineOfPlane2X0Z linePi2, LineOfPlane3Y0Z linePi3)
        {
            if (Math.Abs(linePi2.Point0.Z - linePi3.Point0.Z) < Constants.Tolerance && Math.Abs(linePi2.Point1.Z - linePi3.Point1.Z) < Constants.Tolerance)
            {
                Point0 = new Point3D(linePi2.Point0, linePi3.Point0);
                Point1 = new Point3D(linePi2.Point1, linePi3.Point1);
                LineOfPlane1X0Y = new LineOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point0.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point1.Y));
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = linePi3;
            }
            else 
            {
                Point0 = new Point3D(linePi2.Point0.X, linePi3.Point1.Y, linePi2.Point0.Z);
                Point1 = new Point3D(linePi2.Point1.X, linePi3.Point0.Y, linePi2.Point1.Z);
                LineOfPlane1X0Y = new LineOfPlane1X0Y(new PointOfPlane1X0Y(linePi2.Point0.X, linePi3.Point1.Y), new PointOfPlane1X0Y(linePi2.Point1.X, linePi3.Point0.Y));
                LineOfPlane2X0Z = linePi2;
                LineOfPlane3Y0Z = linePi3;
            }
        }
        public void Draw(Blueprint blueprint)
        {
            var settings = blueprint.Settings.Drawing.LinkLinesSettings;
            if (settings.Enabled)
            {
                Point0.DrawLinkLine(settings, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
                Point1.DrawLinkLine(settings, blueprint.CoordinateSystemCenterPoint, blueprint.Graphics);
            }

            LineOfPlane1X0Y.DrawLineOnly(blueprint);
            LineOfPlane2X0Z.DrawLineOnly(blueprint);
            LineOfPlane3Y0Z.DrawLineOnly(blueprint);

        }

        public bool IsSelected(Point mscoords, float ptR, Point coordinateSystemCenter, double distance)
        {
            return LineOfPlane1X0Y.IsSelected(mscoords, ptR, coordinateSystemCenter, distance) ||
                   LineOfPlane2X0Z.IsSelected(mscoords, ptR, coordinateSystemCenter, distance) ||
                   LineOfPlane3Y0Z.IsSelected(mscoords, ptR, coordinateSystemCenter, distance);
        }

        public void SpecifyBoundaryPoints(Point frameCenter, Rectangle rc1, Rectangle rc2, Rectangle rc3)
        {
            //LineOfPlane1X0Y.EndingPoints = LineOfPlane1X0Y.CalculateEndingPointsOnFrame(frameCenter);
            //LineOfPlane2X0Z.EndingPoints = LineOfPlane2X0Z.CalculateEndingPointsOnFrame(frameCenter);
            //LineOfPlane3Y0Z.EndingPoints = LineOfPlane3Y0Z.CalculateEndingPointsOnFrame(frameCenter);
            CutLineX0YtoX0Z(frameCenter, rc1);
            CutLineX0ZtoX0Y(frameCenter, rc1);
            CutLineX0ZtoY0Z(frameCenter, rc1);
            CutLineY0ZtoX0Z(frameCenter, rc1);
        }
        private void CutLineX0YtoX0Z(Point frameCenter, Rectangle rc)
        {
            //if ((LineOfPlane1X0Y.EndingPoints.Point0.X > LineOfPlane2X0Z.EndingPoints.Point0.X) && (LineOfPlane1X0Y.EndingPoints.Point0.Y == rc.Top))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane1X0Y.EndingPoints.Point0.X, LineOfPlane1X0Y.EndingPoints.Point0.Y),
            //                        new Point2D(LineOfPlane1X0Y.EndingPoints.Point0.X, LineOfPlane1X0Y.EndingPoints.Point0.Y - 10));
            //    LineOfPlane2X0Z.EndingPoints.Point0 = LineOfPlane2X0Z.GetCrossingPoint(ln, frameCenter);
            //}
            //if (LineOfPlane1X0Y.EndingPoints.Point1.X < LineOfPlane2X0Z.EndingPoints.Point1.X && (LineOfPlane1X0Y.EndingPoints.Point1.Y == rc.Top))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane1X0Y.EndingPoints.Point1.X, LineOfPlane1X0Y.EndingPoints.Point1.Y),
            //                        new Point2D(LineOfPlane1X0Y.EndingPoints.Point1.X, LineOfPlane1X0Y.EndingPoints.Point1.Y - 10));
            //    LineOfPlane2X0Z.EndingPoints.Point1 = (PointF)LineOfPlane2X0Z.GetCrossingPoint(ln, frameCenter);
            //}
        }
        private void CutLineX0ZtoX0Y(Point frameCenter, RectangleF rc)
        {
            //if ((LineOfPlane2X0Z.EndingPoints[0].X > LineOfPlane1X0Y.EndingPoints[0].X) && (LineOfPlane2X0Z.EndingPoints[0].Y == rc.Top))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane2X0Z.EndingPoints[0].X, LineOfPlane2X0Z.EndingPoints[0].Y),
            //                        new Point2D(LineOfPlane2X0Z.EndingPoints[0].X, LineOfPlane2X0Z.EndingPoints[0].Y - 10));
            //    LineOfPlane1X0Y.EndingPoints[0] = (PointF)LineOfPlane1X0Y.GetCrossingPoint(ln, frameCenter);
            //}
            //if ((LineOfPlane2X0Z.EndingPoints[1].X < LineOfPlane1X0Y.EndingPoints[1].X) && (LineOfPlane2X0Z.EndingPoints[1].Y == rc.Top))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane2X0Z.EndingPoints[1].X, LineOfPlane2X0Z.EndingPoints[1].Y),
            //                        new Point2D(LineOfPlane2X0Z.EndingPoints[1].X, LineOfPlane2X0Z.EndingPoints[1].Y - 10));
            //    LineOfPlane1X0Y.EndingPoints[1] = (PointF)LineOfPlane1X0Y.GetCrossingPoint(ln, frameCenter);
            //}
        }
        private void CutLineX0ZtoY0Z(Point frameCenter, RectangleF rc)
        {
            //if ((LineOfPlane2X0Z.EndingPoints[0].Y < LineOfPlane3Y0Z.EndingPoints[0].Y) && (LineOfPlane2X0Z.EndingPoints[0].X == rc.Right))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane2X0Z.EndingPoints[0].X, LineOfPlane2X0Z.EndingPoints[0].Y),
            //                        new Point2D(LineOfPlane2X0Z.EndingPoints[0].X - 10, LineOfPlane2X0Z.EndingPoints[0].Y));
            //    LineOfPlane3Y0Z.EndingPoints[0] = (PointF)LineOfPlane3Y0Z.GetCrossingPoint(ln, frameCenter);
            //}
            //if((LineOfPlane2X0Z.EndingPoints[1].Y > LineOfPlane3Y0Z.EndingPoints[1].Y) && (LineOfPlane2X0Z.EndingPoints[1].X == rc.Right))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane2X0Z.EndingPoints[1].X, LineOfPlane2X0Z.EndingPoints[1].Y),
            //                        new Point2D(LineOfPlane2X0Z.EndingPoints[1].X - 10, LineOfPlane2X0Z.EndingPoints[1].Y));
            //    LineOfPlane3Y0Z.EndingPoints[1] = (PointF)LineOfPlane3Y0Z.GetCrossingPoint(ln, frameCenter);
            //}
        }
        private void CutLineY0ZtoX0Z(Point frameCenter, RectangleF rc)
        {
            //if ((LineOfPlane3Y0Z.EndingPoints[0].Y > LineOfPlane2X0Z.EndingPoints[0].Y) && (LineOfPlane3Y0Z.EndingPoints[0].X == rc.Right))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane3Y0Z.EndingPoints[0].X, LineOfPlane3Y0Z.EndingPoints[0].Y),
            //                        new Point2D(LineOfPlane3Y0Z.EndingPoints[0].X - 10, LineOfPlane3Y0Z.EndingPoints[0].Y));
            //    LineOfPlane2X0Z.EndingPoints[0] = (PointF)LineOfPlane2X0Z.GetCrossingPoint(ln, frameCenter);
            //}
            //if ((LineOfPlane3Y0Z.EndingPoints[1].Y > LineOfPlane2X0Z.EndingPoints[1].Y) && (LineOfPlane3Y0Z.EndingPoints[1].X == rc.Right))
            //{
            //    var ln = new Line2D(new Point2D(LineOfPlane3Y0Z.EndingPoints[1].X, LineOfPlane3Y0Z.EndingPoints[1].Y),
            //                        new Point2D(LineOfPlane3Y0Z.EndingPoints[1].X - 10, LineOfPlane3Y0Z.EndingPoints[1].Y));
            //    LineOfPlane2X0Z.EndingPoints[1] = (PointF)LineOfPlane2X0Z.GetCrossingPoint(ln, frameCenter);
            //}
        }

        public Point3D Point0 { get; }

        public Point3D Point1 { get; }

        public LineOfPlane1X0Y LineOfPlane1X0Y { get; }

        public LineOfPlane2X0Z LineOfPlane2X0Z { get; }

        public LineOfPlane3Y0Z LineOfPlane3Y0Z { get; }

        public double Kx { get; private set; }

        public double Ky { get; private set; }

        public double Kz { get; private set; }

        public Name Name { get; set; }
    }
}
