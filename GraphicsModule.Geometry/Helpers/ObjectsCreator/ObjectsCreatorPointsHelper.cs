using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Helpers.ObjectsCreator
{
    public class ObjectsCreatorPointsHelper
    {
        public Point3D Create(IList<IPointOfPlane> points, byte projectionsCount = 2)
        {
            if (projectionsCount < 2 && projectionsCount > 3) throw new ArgumentOutOfRangeException();
            if (points.Count != projectionsCount) throw new ArgumentOutOfRangeException();
            var pt1 = points.FirstOrDefault(x => x is PointOfPlane1X0Y) as PointOfPlane1X0Y;
            var pt2 = points.FirstOrDefault(x => x is PointOfPlane2X0Z) as PointOfPlane2X0Z;
            var pt3 = points.FirstOrDefault(x => x is PointOfPlane3Y0Z) as PointOfPlane3Y0Z;
            if (pt1 != null)
                return (pt2 != null)
                    ? IsCreatable(pt1, pt2) 
                        ? new Point3D(pt1, pt2) 
                        : null
                    : IsCreatable(pt1, pt3) 
                        ? new Point3D(pt1, pt3) 
                        : null;
            if (pt2 != null && pt3 != null)
                return IsCreatable(pt2, pt3) 
                    ? new Point3D(pt2, pt3) 
                    : null;
            return null;
        }

        public bool IsCreatable(PointOfPlane1X0Y pt1, PointOfPlane2X0Z pt2)
        {
            return Math.Abs(pt1.X - pt2.X) < Constants.Tolerance;
        }

        public bool IsCreatable(PointOfPlane1X0Y pt1, PointOfPlane3Y0Z pt3)
        {
            return Math.Abs(pt1.Y - pt3.Y) < Constants.Tolerance;
        }

        public bool IsCreatable(PointOfPlane2X0Z pt2, PointOfPlane3Y0Z pt3)
        {
            return Math.Abs(pt2.Z - pt3.Z) < Constants.Tolerance;
        }
    }
}
