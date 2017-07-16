using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Objects.Planes
{
    public class Plane3D : IPlaneOfPlane
    {
        public IObject[] Objects;

        private Name _name;

        public Plane3D()
        {
            Objects = new IObject[3];
            _name = new Name();
        }
        public Plane3D(Point3D[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
            _name = new Name();
        }
        public Plane3D(Point3D pt1, Point3D pt2, Point3D pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
            _name = new Name();
        }
        public Plane3D(Line3D ln1, Point3D pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
            _name = new Name();
        }
        public Plane3D(Line3D ln1, Line3D ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
            _name = new Name();
        }
        public Plane3D(Segment3D sg1, Point3D pt1)
        {
            Objects = new IObject[] { sg1, pt1 };
            _name = new Name();
        }
        public Plane3D(Segment3D sg1, Segment3D sg2)
        {
            Objects = new IObject[] { sg1, sg2 };
            _name = new Name();
        }
        public void Draw(DrawSettings settings, Point coordinateSystemCenter, Graphics graphics)
        {
            foreach (var obj in Objects)
            {
                obj.Draw(settings, coordinateSystemCenter, graphics);
            }
        }
        public bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance)
        {
            return Objects.Any(obj => obj.IsSelected(mousecoords, ptR, frameCenter, distance));
        }
        public Name Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                foreach (var t in Objects)
                {
                    t.Name = _name;
                }
            }
        }
    }
}
