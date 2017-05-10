using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry
{
    public static class Cnv
    {
        #region Points
        public static Point ToPoint(Point2D pt)
        {
            return new Point(Convert.ToInt32(pt.X), Convert.ToInt32(pt.Y));
        }
        public static Point ToPoint(PointOfPlane1X0Y pt)
        {
            return new Point(-Convert.ToInt32(pt.X), Convert.ToInt32(pt.Y));
        }
        public static Point ToPoint(PointOfPlane2X0Z pt)
        {
            return new Point(-Convert.ToInt32(pt.X), -Convert.ToInt32(pt.Z));
        }
        public static Point ToPoint(PointOfPlane3Y0Z pt)
        {
            return new Point(Convert.ToInt32(pt.Y), -Convert.ToInt32(pt.Z));
        }
        public static PointF ToPointF(Point2D pt)
        {
            return new PointF((float)pt.X, (float)pt.Y);
        }
        public static Point2D ToPoint2D(Point pt)
        {
            return new Point2D(pt.X, pt.Y);
        }
        public static Point2D ToPoint2D(PointF pt)
        {
            return new Point2D(pt.X, pt.Y);
        }
        public static Point2D ToPoint2D(PointOfPlane1X0Y pt)
        {
            return new Point2D(pt.X, pt.Y);
        }
        public static Point2D ToPoint2D(PointOfPlane2X0Z pt)
        {
            return new Point2D(pt.X, pt.Z);
        }
        public static Point2D ToPoint2D(PointOfPlane3Y0Z pt)
        {
            return new Point2D(pt.Y, pt.Z);
        }
        public static PointOfPlane1X0Y ToPointOfPlane1X0Y(Point pt)
        {
            return new PointOfPlane1X0Y(-pt.X, pt.Y);
        }
        public static PointOfPlane1X0Y ToPointOfPlane1X0Y(PointF pt)
        {
            return new PointOfPlane1X0Y(-pt.X, pt.Y);
        }
        public static PointOfPlane1X0Y ToPointOfPlane1X0Y(Point2D pt)
        {
            return new PointOfPlane1X0Y(-pt.X, pt.Y);
        }
        public static PointOfPlane2X0Z ToPointOfPlane2X0Z(Point pt)
        {
            return new PointOfPlane2X0Z(-pt.X, -pt.Y);
        }
        public static PointOfPlane2X0Z ToPointOfPlane2X0Z(PointF pt)
        {
            return new PointOfPlane2X0Z(-pt.X, -pt.Y);
        }
        public static PointOfPlane2X0Z ToPointOfPlane2X0Z(Point2D pt)
        {
            return new PointOfPlane2X0Z(-pt.X, -pt.Y);
        }
        public static PointOfPlane3Y0Z ToPointOfPlane3Y0Z(Point pt)
        {
            return new PointOfPlane3Y0Z(pt.X, -pt.Y);
        }
        public static PointOfPlane3Y0Z ToPointOfPlane3Y0Z(PointF pt)
        {
            return new PointOfPlane3Y0Z(pt.X, -pt.Y);
        }
        public static PointOfPlane3Y0Z ToPointOfPlane3Y0Z(Point2D pt)
        {
            return new PointOfPlane3Y0Z(pt.X, -pt.Y);
        }
        public static Point3D ToPoint3D(Point2D pt)
        {
            return new Point3D(pt, 0);
        }
        public static Point3D ToPoint3D(Point2D pt, double z)
        {
            return new Point3D(pt, z);
        }
        #endregion

        #region Lines
        public static Line2D ToLine2D(LineOfPlane1X0Y linePr)
        {
            return new Line2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }
        public static Line2D ToLine2D(LineOfPlane2X0Z linePr)
        {
            return new Line2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }
        public static Line2D ToLine2D(LineOfPlane3Y0Z linePr)
        {
            return new Line2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }
        public static LineOfPlane1X0Y ToLineOfPlane1X0Y(Line3D line)
        {
            return new LineOfPlane1X0Y(line);
        }
        public static LineOfPlane2X0Z ToLineOfPlane2X0Z(Line3D line)
        {
            return new LineOfPlane2X0Z(line);
        }
        public static LineOfPlane3Y0Z ToLineOfPlane3Y0Z(Line3D line)
        {
            return new LineOfPlane3Y0Z(line);
        }
        #endregion

        #region Segments
        public static Segment2D ToSegment2D(SegmentOfPlane1X0Y linePr)
        {
            return new Segment2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }
        public static Segment2D ToSegment2D(SegmentOfPlane2X0Z linePr)
        {
            return new Segment2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }
        public static Segment2D ToSegment2D(SegmentOfPlane3Y0Z linePr)
        {
            return new Segment2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }
        public static SegmentOfPlane1X0Y ToLineOfPlane1X0Y(Segment3D line)
        {
            return new SegmentOfPlane1X0Y(line);
        }
        public static SegmentOfPlane2X0Z ToLineOfPlane2X0Z(Segment3D line)
        {
            return new SegmentOfPlane2X0Z(line);
        }
        public static SegmentOfPlane3Y0Z ToLineOfPlane3Y0Z(Segment3D line)
        {
            return new SegmentOfPlane3Y0Z(line);
        }
        #endregion
    }
}
