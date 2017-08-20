﻿using System;
using System.Drawing;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Objects.Planes
{
    public class PlaneOfPlane1X0Y: IPlaneOfPlane
    {
        public IObject[] Objects;

        private Name _name;
        public PlaneOfPlane1X0Y()
        {
            Objects = new IObject[3];
            _name = new Name();
        }
        public PlaneOfPlane1X0Y(Point2D[] pts)
        {
            Objects = new IObject[pts.Length];
            Array.Copy(pts, Objects, pts.Length);
            _name = new Name();
        }
        public PlaneOfPlane1X0Y(PointOfPlane1X0Y pt1, PointOfPlane1X0Y pt2, PointOfPlane1X0Y pt3)
        {
            Objects = new IObject[] { pt1, pt2, pt3 };
            _name = new Name();
        }
        public PlaneOfPlane1X0Y(LineOfPlane1X0Y ln1, PointOfPlane1X0Y pt1)
        {
            Objects = new IObject[] { ln1, pt1 };
            _name = new Name();
        }
        public PlaneOfPlane1X0Y(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            Objects = new IObject[] { ln1, ln2 };
            _name = new Name();
        }
        public PlaneOfPlane1X0Y(SegmentOfPlane1X0Y sg1, PointOfPlane1X0Y pt1)
        {
            Objects = new IObject[] { sg1, pt1 };
            _name = new Name();
        }
        public PlaneOfPlane1X0Y(SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2)
        {
            Objects = new IObject[] { sg1, sg2 };
            _name = new Name();
        }
        public void Draw(Blueprint blueprint)
        {
            foreach (var obj in Objects)
            {
                obj.Draw(blueprint);
            }
        }
        public bool IsSelected(Point mousecoords, Point coordinateSystemCenter, double distance)
        {
            return Objects.Any(obj => obj.IsSelected(mousecoords, coordinateSystemCenter, distance));
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
