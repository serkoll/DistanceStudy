using System;
using System.Drawing;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Extensions
{
    /// <summary>
    /// Методы расширения, позволяющие конвертировать проекцию с локальными координатами в 2D аналог с глобальными координатами
    /// </summary>
    public static class ObjectsDeterminePositionExtensions
    {
        #region Points

        /// <summary>
        /// Конвертирует горизонтальную проекцию точки в точку с глобальными координатами
        /// </summary>
        /// <param name="pt">Горизонтальная проекция точки</param>
        /// <param name="coordinateSystemCenter">Центр системы координат</param>
        /// <returns>Точка, соответствующая проекции, с глобальными координатами</returns>
        public static Point ToGlobalCoordinates(this PointOfPlane1X0Y pt, Point coordinateSystemCenter)
        {
            var cnvPt = pt.ToPoint();
            return new Point(cnvPt.X + coordinateSystemCenter.X, cnvPt.Y + coordinateSystemCenter.Y);
        }

        /// <summary>
        /// Конвертирует фронтальную проекцию точки в точку с глобальными координатами
        /// </summary>
        /// <param name="pt">Фротнальная проекция точки</param>
        /// <param name="coordinateSystemCenter">Центр системы координат</param>
        /// <returns>Точка, соответствующая проекции, с глобальными координатами</returns>
        public static Point ToGlobalCoordinates(this PointOfPlane2X0Z pt, Point coordinateSystemCenter)
        {
            var cnvPt = pt.ToPoint();
            return new Point(cnvPt.X + coordinateSystemCenter.X, cnvPt.Y + coordinateSystemCenter.Y);
        }

        /// <summary>
        /// Конвертирует профильную проекцию точки в точку с глобальными координатами
        /// </summary>
        /// <param name="pt">Фронтальная проекция точки</param>
        /// <param name="ptR">Радиус точки</param>
        /// <param name="coordinateSystemCenter">Центр системы координат</param>
        /// <returns>Точка, соответствующая проекции, с глобальными координатами</returns>
        public static Point ToGlobalCoordinates(this PointOfPlane3Y0Z pt, Point coordinateSystemCenter)
        {
            var cnvPt = pt.ToPoint();
            return new Point(cnvPt.X + coordinateSystemCenter.X, cnvPt.Y + coordinateSystemCenter.Y);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="ptR"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Line2D ToGlobalCoordinates(this LineOfPlane1X0Y ln, float ptR, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Line2D ToGlobalCoordinates(this LineOfPlane1X0Y ln, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="ptR"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Line2D ToGlobalCoordinates(this LineOfPlane2X0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Line2D ToGlobalCoordinates(this LineOfPlane2X0Z ln, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="ptR"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Line2D ToGlobalCoordinates(this LineOfPlane3Y0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Line2D ToGlobalCoordinates(this LineOfPlane3Y0Z ln, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Line2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="ptR"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Segment2D ToGlobalCoordinates(this SegmentOfPlane1X0Y ln, float ptR, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Segment2D ToGlobalCoordinates(this SegmentOfPlane1X0Y ln, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="ptR"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Segment2D ToGlobalCoordinates(this SegmentOfPlane2X0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Segment2D ToGlobalCoordinates(this SegmentOfPlane2X0Z ln, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="ptR"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Segment2D ToGlobalCoordinates(this SegmentOfPlane3Y0Z ln, float ptR, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt0.Y + framecenter.Y - Convert.ToInt32(ptR)),
                              new Point2D(cnvPt1.X + framecenter.X - Convert.ToInt32(ptR),
                                          cnvPt1.Y + framecenter.Y - Convert.ToInt32(ptR)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ln"></param>
        /// <param name="framecenter"></param>
        /// <returns></returns>
        public static Segment2D ToGlobalCoordinates(this SegmentOfPlane3Y0Z ln, Point framecenter)
        {
            var cnvPt0 = ln.Point0.ToPoint();
            var cnvPt1 = ln.Point1.ToPoint();
            return new Segment2D(new Point2D(cnvPt0.X + framecenter.X,
                                          cnvPt0.Y + framecenter.Y),
                              new Point2D(cnvPt1.X + framecenter.X,
                                          cnvPt1.Y + framecenter.Y));
        }
    }
}
