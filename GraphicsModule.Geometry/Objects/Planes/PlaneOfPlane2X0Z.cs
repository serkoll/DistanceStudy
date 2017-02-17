using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Planes
{
    public class PlaneOfPlane2X0Z : IObject
    {
        public IObject[] Objects;
        private Name _name;
        public PlaneOfPlane2X0Z()
        {
            Objects = new IObject[3];
        }
        public PlaneOfPlane2X0Z(PointOfPlane2X0Z[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
        }
        public PlaneOfPlane2X0Z(PointOfPlane2X0Z pt1, PointOfPlane2X0Z pt2, PointOfPlane2X0Z pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
        }
        public PlaneOfPlane2X0Z(LineOfPlane2X0Z ln1, PointOfPlane2X0Z pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
        }
        public PlaneOfPlane2X0Z(LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
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
