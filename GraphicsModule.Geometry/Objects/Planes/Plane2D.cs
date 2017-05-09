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
    public class Plane2D : IObject
    {
        //TODO: fix
        public IObject[] Objects;

        private Name _name;
        public Plane2D()
        {
            Objects = new IObject[3];
            _name = new Name();
        }
        public Plane2D(Point2D[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
            _name = new Name();
        }
        public Plane2D(Point2D pt1, Point2D pt2, Point2D pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
            _name = new Name();
        }
        public Plane2D(Line2D ln1, Point2D pt1)
        {
            Objects = new IObject[] {ln1, pt1};
            _name = new Name();
        }
        public Plane2D(Line2D ln1, Line2D ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
            _name = new Name();
        }
        public Plane2D(Segment2D sg1, Point2D pt1)
        {
            Objects = new IObject[] { sg1, pt1 };
            _name = new Name();
        }
        public Plane2D(Segment2D sg1, Segment2D sg2)
        {
            Objects = new IObject[] { sg1, sg2 };
            _name = new Name();
        }
        public void Draw(DrawSettings settings, Point frameCenter, Graphics graphics)
        {
            foreach (var obj in Objects)
            {
                obj.Draw(settings, frameCenter, graphics);
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
