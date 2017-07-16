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
    public class PlaneOfPlane2X0Z : IPlaneOfPlane
    {
        public IObject[] Objects;

        private Name _name;

        public PlaneOfPlane2X0Z()
        {
            Objects = new IObject[3];
            _name = new Name();
        }
        public PlaneOfPlane2X0Z(PointOfPlane2X0Z[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
            _name = new Name();
        }
        public PlaneOfPlane2X0Z(PointOfPlane2X0Z pt1, PointOfPlane2X0Z pt2, PointOfPlane2X0Z pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
            _name = new Name();
        }
        public PlaneOfPlane2X0Z(LineOfPlane2X0Z ln1, PointOfPlane2X0Z pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
            _name = new Name();
        }
        public PlaneOfPlane2X0Z(LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
            _name = new Name();
        }
        public PlaneOfPlane2X0Z(SegmentOfPlane2X0Z sg1, PointOfPlane2X0Z pt1)
        {
            Objects = new IObject[] { sg1, pt1 };
            _name = new Name();
        }
        public PlaneOfPlane2X0Z(SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2)
        {
            Objects = new IObject[] { sg1, sg2 };
            _name = new Name();
        }
        public void Draw(DrawSettings st, Point coordinateSystemCenter, Graphics graphics)
        {
            foreach (var obj in Objects)
            {
                obj.Draw(st, coordinateSystemCenter, graphics);
            }
        }
        public bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance)
        {
            return Objects.Any(obj => obj.IsSelected(mousecoords, ptR, frameCenter, distance));
        }

        public Name Name
        {
            get { return _name; }
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
