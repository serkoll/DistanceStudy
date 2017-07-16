using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

//TODO: для некоторых методов конвертации сделать безопасную проверку. Дописать xml документацию. Покрыть тестами
namespace GraphicsModule.Geometry.Extensions
{
    /// <summary>
    /// Методы расширения для объектов. Выполняют конвертацию одного типа объекта в другой
    /// </summary>
    public static class ObjectsConvertExtensions
    {
        #region Points

        /// <summary>
        /// Конвертация 2D точки в System.Drawning.Point
        /// </summary>
        /// <param name="pt">2D точка</param>
        /// <returns></returns>
        public static Point ToPoint(this Point2D pt)
        {
            return new Point(Convert.ToInt32(pt.X), Convert.ToInt32(pt.Y));
        }

        /// <summary>
        /// Конвертация 
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point ToPoint(this PointOfPlane1X0Y pt)
        {
            return new Point(-Convert.ToInt32(pt.X), Convert.ToInt32(pt.Y));
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point ToPoint(this PointOfPlane2X0Z pt)
        {
            return new Point(-Convert.ToInt32(pt.X), -Convert.ToInt32(pt.Z));
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point ToPoint(this PointOfPlane3Y0Z pt)
        {
            return new Point(Convert.ToInt32(pt.Y), -Convert.ToInt32(pt.Z));
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointF ToPointF(this Point2D pt)
        {
            return new PointF((float)pt.X, (float)pt.Y);
        }

        public static Point2D ToPoint2D(this Point pt)
        {
            return new Point2D(pt.X, pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2D ToPoint2D(this PointF pt)
        {
            return new Point2D(pt.X, pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2D ToPoint2D(this PointOfPlane1X0Y pt)
        {
            return new Point2D(pt.X, pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2D ToPoint2D(this PointOfPlane2X0Z pt)
        {
            return new Point2D(pt.X, pt.Z);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2D ToPoint2D(this PointOfPlane3Y0Z pt)
        {
            return new Point2D(pt.Y, pt.Z);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane1X0Y ToPointOfPlane1X0Y(this Point pt)
        {
            return new PointOfPlane1X0Y(-pt.X, pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane1X0Y ToPointOfPlane1X0Y(this PointF pt)
        {
            return new PointOfPlane1X0Y(-pt.X, pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane1X0Y ToPointOfPlane1X0Y(this Point2D pt)
        {
            return new PointOfPlane1X0Y(-pt.X, pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane2X0Z ToPointOfPlane2X0Z(this Point pt)
        {
            return new PointOfPlane2X0Z(-pt.X, -pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane2X0Z ToPointOfPlane2X0Z(this PointF pt)
        {
            return new PointOfPlane2X0Z(-pt.X, -pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane2X0Z ToPointOfPlane2X0Z(this Point2D pt)
        {
            return new PointOfPlane2X0Z(-pt.X, -pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane3Y0Z ToPointOfPlane3Y0Z(this Point pt)
        {
            return new PointOfPlane3Y0Z(pt.X, -pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane3Y0Z ToPointOfPlane3Y0Z(this PointF pt)
        {
            return new PointOfPlane3Y0Z(pt.X, -pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static PointOfPlane3Y0Z ToPointOfPlane3Y0Z(this Point2D pt)
        {
            return new PointOfPlane3Y0Z(pt.X, -pt.Y);
        }

        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point3D ToPoint3D(this Point2D pt)
        {
            return new Point3D(pt, 0);
        }

        /// <summary>
        /// Конвертация 
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Point3D ToPoint3D(this Point2D pt, double z)
        {
            return new Point3D(pt, z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="frameCenter"></param>
        /// <returns></returns>
        public static IPointOfPlane ToPointOfPlane(this Point pt, Point frameCenter)
        {
            if (PointOfPlane1X0Y.IsCreatable(pt, frameCenter))
            {
                return new PointOfPlane1X0Y(pt, frameCenter);
            }
            if (PointOfPlane2X0Z.IsCreatable(pt, frameCenter))
            {
                return new PointOfPlane2X0Z(pt, frameCenter);
            }
            return PointOfPlane3Y0Z.IsCreatable(pt, frameCenter) ? new PointOfPlane3Y0Z(pt, frameCenter) : null;
        }
        #endregion

        #region Lines

        public static Line2D ToLine2D(this LineOfPlane1X0Y linePr)
        {
            return new Line2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }

        public static Line2D ToLine2D(this LineOfPlane2X0Z linePr)
        {
            return new Line2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }

        public static Line2D ToLine2D(this LineOfPlane3Y0Z linePr)
        {
            return new Line2D(ToPoint2D(linePr.Point0), ToPoint2D(linePr.Point1));
        }

        public static LineOfPlane1X0Y ToLineOfPlane1X0Y(this Line3D line)
        {
            return new LineOfPlane1X0Y(line);
        }

        public static LineOfPlane2X0Z ToLineOfPlane2X0Z(this Line3D line)
        {
            return new LineOfPlane2X0Z(line);
        }

        public static LineOfPlane3Y0Z ToLineOfPlane3Y0Z(this Line3D line)
        {
            return new LineOfPlane3Y0Z(line);
        }

        #endregion

        #region Segments

        public static Segment2D ToSegment2D(this SegmentOfPlane1X0Y sg)
        {
            return new Segment2D(ToPoint2D(sg.Point0), ToPoint2D(sg.Point1));
        }

        public static Segment2D ToSegment2D(this SegmentOfPlane2X0Z sg)
        {
            return new Segment2D(ToPoint2D(sg.Point0), ToPoint2D(sg.Point1));
        }

        public static Segment2D ToSegment2D(this SegmentOfPlane3Y0Z sg)
        {
            return new Segment2D(ToPoint2D(sg.Point0), ToPoint2D(sg.Point1));
        }

        public static SegmentOfPlane1X0Y ToLineOfPlane1X0Y(this Segment3D sg)
        {
            return new SegmentOfPlane1X0Y(sg);
        }

        public static SegmentOfPlane2X0Z ToLineOfPlane2X0Z(this Segment3D sg)
        {
            return new SegmentOfPlane2X0Z(sg);
        }

        public static SegmentOfPlane3Y0Z ToLineOfPlane3Y0Z(this Segment3D sg)
        {
            return new SegmentOfPlane3Y0Z(sg);
        }

        #endregion
    }
}
