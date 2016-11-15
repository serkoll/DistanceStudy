using System;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Analyze
{

    public class PointsPosition
    {
        #region X,Y,Z Coincidence
        public bool CoincidenceOnX(Point2D pt1, Point2D pt2)
        {
            return pt2.X - pt1.X == 0;
        }
        public bool CoincidenceOnX(Point2D pt1, Point2D pt2, double solveerror)
        {
            return pt2.X - pt1.X < solveerror;
        }
        public bool CoincidenceOnY(Point2D pt1, Point2D pt2)
        {
            return pt2.Y - pt1.Y == 0;
        }
        public bool CoincidenceOnY(Point2D pt1, Point2D pt2, double solveerror)
        {
            return pt2.Y - pt1.Y < solveerror;
        }
        public bool CoincidenceOnX(Point3D pt1, Point3D pt2)
        {
            return pt2.X - pt1.X == 0;
        }
        public bool CoincidenceOnX(Point3D pt1, Point3D pt2, double solveerror)
        {
            return pt2.X - pt1.X < solveerror;
        }
        public bool CoincidenceOnY(Point3D pt1, Point3D pt2)
        {
            if (pt2.Y - pt1.Y == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CoincidenceOnY(Point3D pt1, Point3D pt2, double solveerror)
        {
            return pt2.Y - pt1.Y <= solveerror;
        }
        public bool CoincidenceOnZ(Point3D pt1, Point3D pt2)
        {
            return pt2.Z - pt1.Z == 0;
        }
        public bool CoincidenceOnZ(Point3D pt1, Point3D pt2, double solveerror)
        {
            return pt2.Z - pt1.Z <= solveerror;
        }
        #endregion

        #region Full Coincidence
        public bool Coincidence(Point2D pt1, Point2D pt2)
        {
            return Math.Abs(pt1.X - pt2.X) == 0 & Math.Abs(pt1.Y - pt2.Y) == 0;
        }
        public bool Coincidence(Point2D pt1, Point2D pt2, double solveerror)
        {
            return Math.Abs(pt1.X - pt2.X) <= solveerror & Math.Abs(pt1.Y - pt2.Y) <= solveerror;
        }
        public bool Coincidence(Point2D[] points)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!Coincidence(points[i], points[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Coincidence(Point2D[] points, double solveerror)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!Coincidence(points[i], points[i + 1], solveerror))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Coincidence(Point3D pt1, Point3D pt2)
        {
            return Math.Abs(pt1.X - pt2.X) == 0 & Math.Abs(pt1.Y - pt2.Y) == 0 & Math.Abs(pt1.Z - pt2.Z) == 0;
        }
        public bool Coincidence(Point3D pt1, Point3D pt2, double solveerror)
        {
            return Math.Abs(pt1.X - pt2.X) <= solveerror & Math.Abs(pt1.Y - pt2.Y) <= solveerror & Math.Abs(pt1.Z - pt2.Z) <= solveerror;
        }
        public bool Coincidence(Point3D[] points)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!Coincidence(points[i], points[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Coincidence(Point3D[] points, double solveerror)
        {
            for (int i = 0; i < points.GetUpperBound(0) - 1; i++)
            {
                if (!Coincidence(points[i], points[i + 1], solveerror))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Coincidence(PointOfPlane1X0Y pt1, PointOfPlane1X0Y pt2)
        {
            return Coincidence(Cnv.ToPoint2D(pt1), Cnv.ToPoint2D(pt2));
        }
        public bool Coincidence(PointOfPlane1X0Y pt1, PointOfPlane1X0Y pt2, double solveerror)
        {
            return Coincidence(Cnv.ToPoint2D(pt1), Cnv.ToPoint2D(pt2), solveerror);
        }
        public bool Coincidence(PointOfPlane2X0Z pt1, PointOfPlane2X0Z pt2)
        {
            return Coincidence(Cnv.ToPoint2D(pt1), Cnv.ToPoint2D(pt2));
        }
        public bool Coincidence(PointOfPlane2X0Z pt1, PointOfPlane2X0Z pt2, double solveerror)
        {
            return Coincidence(Cnv.ToPoint2D(pt1), Cnv.ToPoint2D(pt2), solveerror);
        }
        public bool Coincidence(PointOfPlane3Y0Z pt1, PointOfPlane3Y0Z pt2)
        {
            return Coincidence(Cnv.ToPoint2D(pt1), Cnv.ToPoint2D(pt2));
        }
        public bool Coincidence(PointOfPlane3Y0Z pt1, PointOfPlane3Y0Z pt2, double solveerror)
        {
            return Coincidence(Cnv.ToPoint2D(pt1), Cnv.ToPoint2D(pt2), solveerror);
        }
        #endregion

        #region Relative Positioning
        public bool LeftOfPoint(Point2D spt, Point2D pt2)
        {
            return pt2.X - spt.X < 0;
        }
        public bool LeftOfPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return pt2.X - spt.X < solveerror;
        }
        public bool LeftOfPoint(Point3D spt, Point3D pt2)
        {
            return pt2.X - spt.X < 0;
        }
        public bool LeftOfPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return pt2.X - spt.X < solveerror;
        }
        public bool RightOfPoint(Point2D spt, Point2D pt2)
        {
            return pt2.X - spt.X > 0;
        }
        public bool RightOfPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return pt2.X - spt.X > solveerror;
        }
        public bool RightOfPoint(Point3D spt, Point3D pt2)
        {
            return pt2.X - spt.X > 0;
        }
        public bool RightOfPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return pt2.X - spt.X > solveerror;
        }
        public bool OverAPoint(Point2D spt, Point2D pt2)
        {
            return pt2.Y - spt.Y > 0;
        }
        public bool OverAPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return pt2.Y - spt.Y > solveerror;
        }
        public bool OverAPoint(Point3D spt, Point3D pt2)
        {
            return pt2.Z - spt.Z > 0;
        }
        public bool OverAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return pt2.Z - spt.Z > solveerror;
        }
        public bool UnderAPoint(Point2D spt, Point2D pt2)
        {
            return pt2.Y - spt.Y < 0;
        }
        public bool UnderAPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return pt2.Y - spt.Y < solveerror;
        }
        public bool UnderAPoint(Point3D spt, Point3D pt2)
        {
            return pt2.Z - spt.Z < 0;
        }
        public bool UnderAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return pt2.Z - spt.Z < solveerror;
        }
        public bool BeforeAPoint(Point3D spt, Point3D pt2)
        {
            return pt2.Y - spt.Y > 0;
        }
        public bool BeforeAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return pt2.Y - spt.Y > solveerror;
        }
        public bool AfterAPoint(Point3D spt, Point3D pt2)
        {
            return pt2.Y - spt.Y < 0;
        }
        public bool AfterAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return pt2.Y - spt.Y < solveerror;
        }
        #endregion

        #region Strictly Relative Positioning
        public bool StrictlyLeftOfPoint(Point2D spt, Point2D pt2)
        {
            return (pt2.Y - spt.Y == 0) && (pt2.X - spt.X < 0);
        }
        public bool StrictlyLeftOfPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - spt.Y) <= solveerror) && (pt2.X - spt.X < solveerror);
        }
        public bool StrictlyLeftOfPoint(Point3D spt, Point3D pt2)
        {
            return (pt2.Y - spt.Y == 0) && (pt2.Z - spt.Z == 0) && (pt2.X - spt.X < 0);
        }
        public bool StrictlyLeftOfPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - spt.Y) <= solveerror) && (Math.Abs(pt2.Z - spt.Z) <= solveerror) && (pt2.X - spt.X < solveerror);
        }
        public bool StrictlyRightOfPoint(Point2D spt, Point2D pt2)
        {
            return (pt2.Y - spt.Y == 0) && (pt2.X - spt.X > 0);
        }
        public bool StrictlyRightOfPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - spt.Y) <= solveerror) && (pt2.X - spt.X < solveerror);
        }
        public bool StrictlyRightOfPoint(Point3D spt, Point3D pt2)
        {
            return (pt2.Y - spt.Y == 0) && (pt2.Z - spt.Z == 0) && (pt2.X - spt.X > 0);
        }
        public bool StrictlyRightOfPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.Y - spt.Y) <= solveerror) && (Math.Abs(pt2.Z - spt.Z) <= solveerror) && (pt2.X - spt.X > solveerror);
        }
        public bool StrictlyOverAPoint(Point2D spt, Point2D pt2)
        {
            return (pt2.X - spt.X == 0) && (pt2.Y - spt.Y > 0);
        }
        public bool StrictlyOverAPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - spt.X) <= solveerror) && (pt2.Y - spt.Y > solveerror);
        }
        public bool StrictlyOverAPoint(Point3D spt, Point3D pt2)
        {
            return (pt2.X - spt.X == 0) && (pt2.Y - spt.Y == 0) && (pt2.Z - spt.Z > 0);
        }
        public bool StrictlyOverAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - spt.X) <= solveerror) && (Math.Abs(pt2.Y - spt.Y) <= solveerror) && (pt2.Z - spt.Z > solveerror);
        }
        public bool StrictlyUnderAPoint(Point2D spt, Point2D pt2)
        {
            return (pt2.X - spt.X == 0) && (pt2.Y - spt.Y < 0);
        }
        public bool StrictlyUnderAPoint(Point2D spt, Point2D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - spt.X) <= solveerror) && (pt2.Y - spt.Y < solveerror);
        }
        public bool StrictlyUnderAPoint(Point3D spt, Point3D pt2)
        {
            return (pt2.X - spt.X == 0) && (pt2.Y - spt.Y == 0) && (pt2.Z - spt.Z < 0);
        }
        public bool StrictlyUnderAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - spt.X) <= solveerror) && (Math.Abs(pt2.Y - spt.Y) <= solveerror) && (pt2.Z - spt.Z < solveerror);
        }
        public bool StrictlyBeforeAPoint(Point3D spt, Point3D pt2)
        {
            return (pt2.X - spt.X == 0) && (pt2.Z - spt.Z == 0) && (pt2.Y - spt.Y > 0);
        }
        public bool StrictlyBeforeAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - spt.X) <= solveerror) && (Math.Abs(pt2.Z - spt.Z) <= solveerror) && (pt2.Y - spt.Y > solveerror);
        }
        public bool StrictlyAfterAPoint(Point3D spt, Point3D pt2)
        {
            return (pt2.X - spt.X == 0) && (pt2.Z - spt.Z == 0) && (pt2.Y - spt.Y < 0);
        }
        public bool StrictlyAfterAPoint(Point3D spt, Point3D pt2, double solveerror)
        {
            return (Math.Abs(pt2.X - spt.X) <= solveerror) && (Math.Abs(pt2.Z - spt.Z) <= solveerror) && (pt2.Y - spt.Y < solveerror);
        }
        #endregion
    }
}
