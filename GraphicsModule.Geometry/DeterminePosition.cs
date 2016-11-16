using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry
{
    public static class DeterminePosition
    {
        public static Point ForPointProjection(PointOfPlane1X0Y pt, float ptR, Point frameCenter)
        {
            var cnvPt = Cnv.ToPoint(pt);
            return new Point(cnvPt.X + frameCenter.X - Convert.ToInt32(ptR),
                             cnvPt.Y + frameCenter.Y - Convert.ToInt32(ptR));
        }
        public static Point ForPointProjection(PointOfPlane2X0Z pt, float ptR, Point frameCenter)
        {
            var cnvPt = Cnv.ToPoint(pt);
            return new Point(cnvPt.X + frameCenter.X - Convert.ToInt32(ptR),
                             cnvPt.Y + frameCenter.Y - Convert.ToInt32(ptR));
        }
        public static Point ForPointProjection(PointOfPlane3Y0Z pt, float ptR, Point frameCenter)
        {
            var cnvPt = Cnv.ToPoint(pt);
            return new Point(cnvPt.X + frameCenter.X - Convert.ToInt32(ptR),
                             cnvPt.Y + frameCenter.Y - Convert.ToInt32(ptR));
        }
        public static Line2D ForLineProjection(LineOfPlane1X0Y ln, float ptR, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        public static Line2D ForLineProjection(LineOfPlane1X0Y ln, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
        public static Line2D ForLineProjection(LineOfPlane2X0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        public static Line2D ForLineProjection(LineOfPlane2X0Z ln, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
        public static Line2D ForLineProjection(LineOfPlane3Y0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        public static Line2D ForLineProjection(LineOfPlane3Y0Z ln, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
        public static Segment2D ForSegmentProjection(SegmentOfPlane1X0Y ln, float ptR, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        public static Segment2D ForSegmentProjection(SegmentOfPlane1X0Y ln, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
        public static Segment2D ForSegmentProjection(SegmentOfPlane2X0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        public static Segment2D ForSegmentProjection(SegmentOfPlane2X0Z ln, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
        public static Segment2D ForSegmentProjection(SegmentOfPlane3Y0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        public static Segment2D ForSegmentProjection(SegmentOfPlane3Y0Z ln, Point framecenter)
        {
            var cnvPt0 = Cnv.ToPoint(ln.Point0);
            var cnvPt1 = Cnv.ToPoint(ln.Point1);
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
    }
}
