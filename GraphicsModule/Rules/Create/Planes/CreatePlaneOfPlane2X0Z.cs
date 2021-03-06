﻿using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Enums;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Planes;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;
using GraphicsModule.Rules.Create.Lines;
using GraphicsModule.Rules.Create.Points;
using GraphicsModule.Rules.Create.Segments;

namespace GraphicsModule.Rules.Create.Planes
{
    public class CreatePlaneOfPlane2X0Z : ICreate, ICreatePlanes
    {
        private PlaneCreateType _creationType;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            switch (_creationType)
            {
                case PlaneCreateType.ThreePoints:
                    {
                        CreateByThreePoints(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
                case PlaneCreateType.LineAndPoint:
                    {
                        CreateByLineAndPoint(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
                case PlaneCreateType.ParallelLines:
                    {
                        CreateByParallelLines(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
                case PlaneCreateType.CrossedLines:
                    {
                        CreateByCrossedLines(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
                case PlaneCreateType.SegmentAndPoint:
                    {
                        CreateBySegmentAndPoint(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
                case PlaneCreateType.ParallelSegments:
                    {
                        CreateByParallelSegments(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
                case PlaneCreateType.CrossedSegments:
                    {
                        CreateByCrossedSegments(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
                        break;
                    }
            }
        }
        private void CreateByThreePoints(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            var tmpobj = new CreatePointOfPlane2X0Z().Create(pt, blueprint);
            tmpobj.Draw(blueprint);
            _planeObjects.Add(tmpobj);
            if (_planeObjects.Count != 3) return;
            var source = CreateByThreePoints(_planeObjects);
            var nameparams = _planeObjects[0].Name;
            source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
            _planeObjects.Clear();
            strg.AddToCollection(source);
            blueprint.Update();
        }
        private void CreateByLineAndPoint(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateLineOfPlane2X0Z().Create(pt, blueprint);
                if (tmpobj == null) return;
                tmpobj.Draw(blueprint);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePointOfPlane2X0Z().Create(pt, blueprint);
                var source = CreateByLineAndPoint((LineOfPlane2X0Z)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                blueprint.Update();
            }
        }
        private void CreateByParallelLines(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLineOfPlane2X0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelLines((LineOfPlane2X0Z)_planeObjects[0], (LineOfPlane2X0Z)_planeObjects[1]);
            if (source != null)
            {
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                blueprint.Update();
            }
            else
            {
                _planeObjects.RemoveAt(1);
                blueprint.Update();
                foreach (var o in _planeObjects)
                {
                    var ln = (LineOfPlane2X0Z) o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByCrossedLines(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLineOfPlane2X0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedLines((LineOfPlane2X0Z)_planeObjects[0], (LineOfPlane2X0Z)_planeObjects[1], frameCenter);
            if (source != null)
            {
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                blueprint.Update();
            }
            else
            {
                _planeObjects.RemoveAt(1);
                blueprint.Update();
                foreach (var o in _planeObjects)
                {
                    var ln = (LineOfPlane2X0Z) o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateBySegmentAndPoint(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateSegmentOfPlane2X0Z().Create(pt, blueprint);
                if (tmpobj == null) return;
                tmpobj.Draw(blueprint);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePointOfPlane2X0Z().Create(pt, blueprint);
                var source = CreateBySegmentAndPoint((SegmentOfPlane2X0Z)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                blueprint.Update();
            }
        }
        private void CreateByParallelSegments(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateSegmentOfPlane2X0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelSegments((SegmentOfPlane2X0Z)_planeObjects[0], (SegmentOfPlane2X0Z)_planeObjects[1]);
            if (source != null)
            {
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                blueprint.Update();
            }
            else
            {
                _planeObjects.RemoveAt(1);
                blueprint.Update();
                foreach (var o in _planeObjects)
                {
                    var ln = (SegmentOfPlane2X0Z)o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByCrossedSegments(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateSegmentOfPlane2X0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedSegments((SegmentOfPlane2X0Z)_planeObjects[0], (SegmentOfPlane2X0Z)_planeObjects[1], frameCenter);
            if (source != null)
            {
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                blueprint.Update();
            }
            else
            {
                _planeObjects.RemoveAt(1);
                blueprint.Update();
                foreach (var o in _planeObjects)
                {
                    var ln = (SegmentOfPlane2X0Z)o;
                    ln.Draw(blueprint);
                }
            }
        }
        public PlaneOfPlane2X0Z CreateByThreePoints(Collection<IObject> obj)
        {
            return obj.Count != 3 ? null : new PlaneOfPlane2X0Z((PointOfPlane2X0Z)obj[0], (PointOfPlane2X0Z)obj[1], (PointOfPlane2X0Z)obj[2]);
        }
        public PlaneOfPlane2X0Z CreateByLineAndPoint(LineOfPlane2X0Z ln, PointOfPlane2X0Z pt)
        {
            return new PlaneOfPlane2X0Z(ln, pt);
        }
        public PlaneOfPlane2X0Z CreateByParallelLines(LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2)
        {
            return ln1.IsParallel(ln2) ? new PlaneOfPlane2X0Z(ln1, ln2) : null;
        }
        public PlaneOfPlane2X0Z CreateByCrossedLines(LineOfPlane2X0Z ln1, LineOfPlane2X0Z ln2, Point frameCenter)
        {
            return ln1.IsIntersect(ln2, frameCenter) ? new PlaneOfPlane2X0Z(ln1, ln2) : null;
        }
        public PlaneOfPlane2X0Z CreateBySegmentAndPoint(SegmentOfPlane2X0Z sg, PointOfPlane2X0Z pt)
        {
            return new PlaneOfPlane2X0Z(sg, pt);
        }
        public PlaneOfPlane2X0Z CreateByParallelSegments(SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2)
        {
            return sg1.IsParallel(sg2) ? new PlaneOfPlane2X0Z(sg1, sg2) : null;
        }
        public PlaneOfPlane2X0Z CreateByCrossedSegments(SegmentOfPlane2X0Z sg1, SegmentOfPlane2X0Z sg2, Point frameCenter)
        {
            return sg1.IsIntersect(sg2, frameCenter) ? new PlaneOfPlane2X0Z(sg1, sg2) : null;
        }
        public void SetBuildType(PlaneCreateType type)
        {
            _creationType = type;
        }
    }
}
