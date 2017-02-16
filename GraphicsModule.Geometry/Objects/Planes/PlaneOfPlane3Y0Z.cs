using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Objects.Planes
{
    public class PlaneOfPlane3Y0Z : IObject
    {
        public IObject[] Objects;
        private Name _name;
        public PlaneOfPlane3Y0Z()
        {
            Objects = new IObject[3];
        }
        public PlaneOfPlane3Y0Z(PointOfPlane3Y0Z[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
        }
        public PlaneOfPlane3Y0Z(PointOfPlane3Y0Z pt1, PointOfPlane3Y0Z pt2, PointOfPlane3Y0Z pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
        }
        public PlaneOfPlane3Y0Z(LineOfPlane3Y0Z ln1, PointOfPlane3Y0Z pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
        }
        public PlaneOfPlane3Y0Z(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
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
            _name = new Name(_name);
        }
    }
}
