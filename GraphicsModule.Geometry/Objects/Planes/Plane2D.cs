using System;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Planes
{
    public class Plane2D : IObject
    {
        public IObject[] Objects;
        private Name _name;
        public Plane2D()
        {
            Objects = new IObject[3];
        }

        public Plane2D(Point2D[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
        }

        public Plane2D(Point2D pt1, Point2D pt2, Point2D pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
        }
        public Plane2D(Line2D ln1, Point2D pt1)
        {
            Objects = new IObject[2];
            Objects[0] = ln1;
            Objects[1] = pt1;
        }
        public Plane2D(Line2D ln1, Line2D ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
        }
        public void Draw(DrawS st, Point frameCenter, Graphics graphics)
        {
            foreach (var obj in Objects)
            {
                obj.Draw(st, frameCenter, graphics);
            }
        }
        public bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance)
        {
            foreach (var obj in Objects)
            {
                if (obj.IsSelected(mousecoords, ptR, frameCenter, distance)) return true;
            }
            return false;
        }
        public Name GetName()
        {
            return _name;
        }
        public void SetName(Name name)
        {
            _name = new Name(_name);
        }
    }
}
