﻿using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Planes;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;
using GraphicsModule.Geometry.Analyze;

namespace GraphicsModule.Rules.Objects.Planes
{
    public class CreatePlaneOfPlane1X0Y : ICreate, ICreatePlanes
    {
        private byte _creationType = 0;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            switch (_creationType)
            {
                case 0:
                    {
                        CreateBy3Point(pt, frameCenter, can, setting, strg);
                        break;
                    }
                case 1:
                    {
                        CreateByLinePoint(pt, frameCenter, can, setting, strg);
                        break;
                    }
                case 2:
                    {
                        CreateByParallelLines(pt, frameCenter, can, setting, strg);
                        break;
                    }
                case 3:
                    {
                        CreateByIntersectedLines(pt, frameCenter, can, setting, strg);
                        break;
                    }
            }
        }
        private void CreateBy3Point(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var tmpobj = new CreatePointOfPlane1X0Y().Create(pt, frameCenter, can, setting, strg);
            tmpobj.Draw(setting, frameCenter, can.Graphics);
            _planeObjects.Add(tmpobj);
            if (_planeObjects.Count == 3)
            {
                var source = CreateBy3Point(_planeObjects);
                source.SetName(new Name(@"p", 0, 0));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
            }
        }
        private void CreateByLinePoint(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateLine2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            else
            {
                var tmpobj = new CreatePoint2D().Create(pt, frameCenter, can, setting, strg);
                var source = CreateByLinePoint((Line2D)_planeObjects[0], tmpobj);
                source.SetName(new Name(@"p", 0, 0));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
            }
        }
        private void CreateByParallelLines(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLine2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count == 2)
            {
                var source = CreateByParallelLines((Line2D)_planeObjects[0], (Line2D)_planeObjects[1]);
                if (source != null)
                {
                    source.SetName(new Name(@"p", 0, 0));
                    _planeObjects.Clear();
                    strg.AddToCollection(source);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    _planeObjects.RemoveAt(1);
                    can.Update(strg);
                    foreach (Line2D ln in _planeObjects)
                        ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
        }
        private void CreateByIntersectedLines(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLine2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count == 2)
            {
                var source = CreateByIntersectedLines((Line2D)_planeObjects[0], (Line2D)_planeObjects[1]);
                if (source != null)
                {
                    source.SetName(new Name(@"p", 0, 0));
                    _planeObjects.Clear();
                    strg.AddToCollection(source);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    _planeObjects.RemoveAt(1);
                    can.Update(strg);
                    foreach (Line2D ln in _planeObjects)
                        ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
        }
        public PlaneOfPlane1X0Y CreateBy3Point(Collection<IObject> obj)
        {
            if (obj.Count != 3) return null;
            return new PlaneOfPlane1X0Y((PointOfPlane1X0Y)obj[0], (PointOfPlane1X0Y)obj[1], (PointOfPlane1X0Y)obj[2]);
        }
        public PlaneOfPlane1X0Y CreateByLinePoint(LineOfPlane1X0Y ln, PointOfPlane1X0Y pt)
        {
            return new PlaneOfPlane1X0Y(ln, pt);
        }
        public PlaneOfPlane1X0Y CreateByParallelLines(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            if (Analyze.LinesPos.Parallelism(ln1, ln2))
                return new PlaneOfPlane1X0Y(ln1, ln2);
            else
                return null;
        }
        public PlaneOfPlane1X0Y CreateByIntersectedLines(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            if (Analyze.LinesPos.Intersection(ln1, ln2))
                return new PlaneOfPlane1X0Y(ln1, ln2);
            else
                return null;
        }
        public void SetBuildType(byte type)
        {
            if (type < 5)
                _creationType = type;
            else
                _creationType = 0;
        }
    }
