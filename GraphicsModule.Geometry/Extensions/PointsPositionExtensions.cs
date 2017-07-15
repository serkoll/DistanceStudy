using System;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Extensions
{

    public static class PointsPositionExtensions
    {
        #region X,Y,Z IsCoincides

        public static bool IsCoincidesOnX(this Point2D pt1, Point2D pt2)
        {
            return Math.Abs(pt2.X - pt1.X) < 0.0001;
        }

        public static bool IsCoincidesOnX(this Point2D pt1, Point2D pt2, double solveerror)
        {
            return pt2.X - pt1.X < solveerror;
        }

        public static bool IsCoincidesOnY(this Point2D pt1, Point2D pt2)
        {
            return Math.Abs(pt2.Y - pt1.Y) < 0.0001;
        }

        public static bool IsCoincidesOnY(this Point2D pt1, Point2D pt2, double solveerror)
        {
            return pt2.Y - pt1.Y < solveerror;
        }

        public static bool IsCoincidesOnX(this Point3D pt1, Point3D pt2)
        {
            return Math.Abs(pt2.X - pt1.X) < 0.0001;
        }
        public static bool IsCoincidesOnX(this Point3D pt1, Point3D pt2, double solveerror)
        {
            return pt2.X - pt1.X < solveerror;
        }

        public static bool IsCoincidesOnY(this Point3D pt1, Point3D pt2)
        {
            return Math.Abs(pt2.Y - pt1.Y) < 0.0001;
        }

        public static bool IsCoincidesOnY(this Point3D pt1, Point3D pt2, double solveerror)
        {
            return pt2.Y - pt1.Y <= solveerror;
        }

        public static bool IsCoincidesOnZ(this Point3D pt1, Point3D pt2)
        {
            return Math.Abs(pt2.Z - pt1.Z) < 0.0001;
        }

        public static bool IsCoincidesOnZ(this Point3D pt1, Point3D pt2, double solveerror)
        {
            return pt2.Z - pt1.Z <= solveerror;
        }

        #endregion

        #region Full IsCoincides

        public static bool IsCoincides(this Point2D pt1, Point2D pt2)
        {
            return Math.Abs(Math.Abs(pt1.X - pt2.X)) < 0.0001 && Math.Abs(Math.Abs(pt1.Y - pt2.Y)) < 0.0001;
        }

        public static bool IsCoincides(this Point2D pt1, Point2D pt2, double solveerror)
        {
            return Math.Abs(pt1.X - pt2.X) <= solveerror & Math.Abs(pt1.Y - pt2.Y) <= solveerror;
        }

        public static bool IsCoincides(this Point2D[] points)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!IsCoincides(points[i], points[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsCoincides(this Point2D[] points, double solveerror)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!IsCoincides(points[i], points[i + 1], solveerror))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsCoincides(this Point3D pt1, Point3D pt2)
        {
            return Math.Abs(Math.Abs(pt1.X - pt2.X)) < 0.0001 & Math.Abs(Math.Abs(pt1.Y - pt2.Y)) < 0.0001 & Math.Abs(Math.Abs(pt1.Z - pt2.Z)) < 0.0001;
        }

        public static bool IsCoincides(this Point3D pt1, Point3D pt2, double solveerror)
        {
            return Math.Abs(pt1.X - pt2.X) <= solveerror & Math.Abs(pt1.Y - pt2.Y) <= solveerror & Math.Abs(pt1.Z - pt2.Z) <= solveerror;
        }

        public static bool IsCoincides(this Point3D[] points)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!IsCoincides(points[i], points[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsCoincides(this Point3D[] points, double solveerror)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!IsCoincides(points[i], points[i + 1], solveerror))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsCoincides(this PointOfPlane1X0Y pt1, PointOfPlane1X0Y pt2)
        {
            return IsCoincides(pt1.ToPoint2D(), pt2.ToPoint2D());
        }

        public static bool IsCoincides(this PointOfPlane1X0Y pt1, PointOfPlane1X0Y pt2, double solveerror)
        {
            return IsCoincides(pt1.ToPoint2D(), pt2.ToPoint2D(), solveerror);
        }

        public static bool IsCoincides(this PointOfPlane2X0Z pt1, PointOfPlane2X0Z pt2)
        {
            return IsCoincides(pt1.ToPoint2D(), pt2.ToPoint2D());
        }

        public static bool IsCoincides(this PointOfPlane2X0Z pt1, PointOfPlane2X0Z pt2, double solveerror)
        {
            return IsCoincides(pt1.ToPoint2D(), pt2.ToPoint2D(), solveerror);
        }

        public static bool IsCoincides(this PointOfPlane3Y0Z pt1, PointOfPlane3Y0Z pt2)
        {
            return IsCoincides(pt1.ToPoint2D(), pt2.ToPoint2D());
        }

        public static bool IsCoincides(this PointOfPlane3Y0Z pt1, PointOfPlane3Y0Z pt2, double solveerror)
        {
            return IsCoincides(pt1.ToPoint2D(), pt2.ToPoint2D(), solveerror);
        }
        #endregion

        #region Relative Positioning
        
        public static bool IsLeftOfPoint(this Point2D pt, Point2D pt2)
        {
            return pt2.X - pt.X < 0;
        }

        public static bool IsLeftOfPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return pt2.X - pt.X < solveerror;
        }

        public static bool IsLeftOfPoint(this Point3D pt, Point3D pt2)
        {
            return pt2.X - pt.X < 0;
        }

        public static bool IsLeftOfPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return pt2.X - pt.X < solveerror;
        }

        public static bool IsRightOfPoint(this Point2D pt, Point2D pt2)
        {
            return pt2.X - pt.X > 0;
        }

        public static bool IsRightOfPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return pt2.X - pt.X > solveerror;
        }

        public static bool IsRightOfPoint(this Point3D pt, Point3D pt2)
        {
            return pt2.X - pt.X > 0;
        }

        public static bool IsRightOfPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return pt2.X - pt.X > solveerror;
        }

        public static bool IsOverAPoint(this Point2D pt, Point2D pt2)
        {
            return pt2.Y - pt.Y > 0;
        }

        public static bool IsOverAPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return pt2.Y - pt.Y > solveerror;
        }

        public static bool IsOverAPoint(this Point3D pt, Point3D pt2)
        {
            return pt2.Z - pt.Z > 0;
        }

        public static bool IsOverAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return pt2.Z - pt.Z > solveerror;
        }

        public static bool IsUnderAPoint(this Point2D pt, Point2D pt2)
        {
            return pt2.Y - pt.Y < 0;
        }

        public static bool IsUnderAPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return pt2.Y - pt.Y < solveerror;
        }

        public static bool IsUnderAPoint(this Point3D pt, Point3D pt2)
        {
            return pt2.Z - pt.Z < 0;
        }

        public static bool IsUnderAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return pt2.Z - pt.Z < solveerror;
        }

        public static bool IsBeforeAPoint(this Point3D pt, Point3D pt2)
        {
            return pt2.Y - pt.Y > 0;
        }

        public static bool IsBeforeAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return pt2.Y - pt.Y > solveerror;
        }

        public static bool IsAfterAPoint(this Point3D pt, Point3D pt2)
        {
            return pt2.Y - pt.Y < 0;
        }

        public static bool IsAfterAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return pt2.Y - pt.Y < solveerror;
        }
        #endregion

        #region Strictly Relative Positioning

        public static bool IsStrictlyLeftOfPoint(this Point2D pt, Point2D pt2)
        {
            return (Math.Abs(pt2.Y - pt.Y) < 0.0001) && (pt2.X - pt.X < 0);
        }

        public static bool IsStrictlyLeftOfPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - pt.Y) <= solveerror) && (pt2.X - pt.X < solveerror);
        }

        public static bool IsStrictlyLeftOfPoint(this Point3D pt, Point3D pt2)
        {
            return (Math.Abs(pt2.Y - pt.Y) < 0.0001) && (Math.Abs(pt2.Z - pt.Z) < 0.0001) && (pt2.X - pt.X < 0);
        }

        public static bool IsStrictlyLeftOfPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - pt.Y) <= solveerror) && (Math.Abs(pt2.Z - pt.Z) <= solveerror) && (pt2.X - pt.X < solveerror);
        }

        public static bool IsStrictlyRightOfPoint(this Point2D pt, Point2D pt2)
        {
            return (Math.Abs(pt2.Y - pt.Y) < 0.0001) && (pt2.X - pt.X > 0);
        }

        public static bool IsStrictlyRightOfPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - pt.Y) <= solveerror) && (pt2.X - pt.X < solveerror);
        }

        public static bool IsStrictlyRightOfPoint(this Point3D pt, Point3D pt2)
        {
            return (Math.Abs(pt2.Y - pt.Y) < 0.0001) && (Math.Abs(pt2.Z - pt.Z) < 0.0001) && (pt2.X - pt.X > 0);
        }

        public static bool IsStrictlyRightOfPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - pt.Y) <= solveerror) && (Math.Abs(pt2.Z - pt.Z) <= solveerror) && (pt2.X - pt.X > solveerror);
        }

        public static bool IsStrictlyOverAPoint(this Point2D pt, Point2D pt2)
        {
            return (Math.Abs(pt2.X - pt.X) < 0.0001) && (pt2.Y - pt.Y > 0);
        }

        public static bool IsStrictlyOverAPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - pt.X) <= solveerror) && (pt2.Y - pt.Y > solveerror);
        }

        public static bool IsStrictlyOverAPoint(this Point3D pt, Point3D pt2)
        {
            return (Math.Abs(pt2.X - pt.X) < 0.0001) && (Math.Abs(pt2.Y - pt.Y) < 0.0001) && (pt2.Z - pt.Z > 0);
        }

        public static bool IsStrictlyOverAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - pt.X) <= solveerror) && (Math.Abs(pt2.Y - pt.Y) <= solveerror) && (pt2.Z - pt.Z > solveerror);
        }

        public static bool IsStrictlyUnderAPoint(this Point2D pt, Point2D pt2)
        {
            return (Math.Abs(pt2.X - pt.X) < 0.0001) && (pt2.Y - pt.Y < 0);
        }

        public static bool IsStrictlyUnderAPoint(this Point2D pt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - pt.X) <= solveerror) && (pt2.Y - pt.Y < solveerror);
        }

        public static bool IsStrictlyUnderAPoint(this Point3D pt, Point3D pt2)
        {
            return (Math.Abs(pt2.X - pt.X) < 0.0001) && (Math.Abs(pt2.Y - pt.Y) < 0.0001) && (pt2.Z - pt.Z < 0);
        }

        public static bool IsStrictlyUnderAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - pt.X) <= solveerror) && (Math.Abs(pt2.Y - pt.Y) <= solveerror) && (pt2.Z - pt.Z < solveerror);
        }

        public static bool IsStrictlyBeforeAPoint(this Point3D pt, Point3D pt2)
        {
            return (Math.Abs(pt2.X - pt.X) < 0.0001) && (Math.Abs(pt2.Z - pt.Z) < 0.0001) && (pt2.Y - pt.Y > 0);
        }

        public static bool IsStrictlyBeforeAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - pt.X) <= solveerror) && (Math.Abs(pt2.Z - pt.Z) <= solveerror) && (pt2.Y - pt.Y > solveerror);
        }

        public static bool IsStrictlyAfterAPoint(this Point3D pt, Point3D pt2)
        {
            return (Math.Abs(pt2.X - pt.X) < 0.0001) && (Math.Abs(pt2.Z - pt.Z) < 0.0001) && (pt2.Y - pt.Y < 0);
        }

        public static bool IsStrictlyAfterAPoint(this Point3D pt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - pt.X) <= solveerror) && (Math.Abs(pt2.Z - pt.Z) <= solveerror) && (pt2.Y - pt.Y < solveerror);
        }
        #endregion
    }
}
