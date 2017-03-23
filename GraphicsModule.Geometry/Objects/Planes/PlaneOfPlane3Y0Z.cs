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
    public class PlaneOfPlane3Y0Z : IObject
    {
        public IObject[] Objects;
        private Name _name;
        public PlaneOfPlane3Y0Z()
        {
            Objects = new IObject[3];
            _name = new Name();
        }
        public PlaneOfPlane3Y0Z(PointOfPlane3Y0Z[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
            _name = new Name();
        }
        public PlaneOfPlane3Y0Z(PointOfPlane3Y0Z pt1, PointOfPlane3Y0Z pt2, PointOfPlane3Y0Z pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
            _name = new Name();
        }
        public PlaneOfPlane3Y0Z(LineOfPlane3Y0Z ln1, PointOfPlane3Y0Z pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
            _name = new Name();
        }
        public PlaneOfPlane3Y0Z(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
            _name = new Name();
        }
        public PlaneOfPlane3Y0Z(SegmentOfPlane3Y0Z ln1, PointOfPlane3Y0Z pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
            _name = new Name();
        }
        public PlaneOfPlane3Y0Z(SegmentOfPlane3Y0Z ln1, SegmentOfPlane3Y0Z ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
            _name = new Name();
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
            return Objects.Any(obj => obj.IsSelected(mousecoords, ptR, frameCenter, distance));
        }
        public Name GetName()
        {
            return _name;
        }
        public void SetName(Name name)
        {
            _name = new Name(name);
            foreach (var t in Objects)
            {
                var n = t.GetName();
                n.Value.Remove(n.Value.Length - 1);
                n.Value += _name.Value;
                t.SetName(n);
            }
        }
    }
}
