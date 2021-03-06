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
    public class CreatePlaneOfPlane3Y0Z : ICreate, ICreatePlanes
    {
        private PlaneCreateType _creationType;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            switch (_creationType)
            {
                case PlaneCreateType.ThreePoints:
                    {
                        CreateByThreePoint(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
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
        private void CreateByThreePoint(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            var tmpobj = new CreatePointOfPlane3Y0Z().Create(pt, blueprint);
            tmpobj.Draw(blueprint);
            _planeObjects.Add(tmpobj);
            if (_planeObjects.Count != 3) return;
            var source = CreateByThreePoint(_planeObjects);
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
                var tmpobj = new CreateLineOfPlane3Y0Z().Create(pt, blueprint);
                if (tmpobj == null) return;
                tmpobj.Draw(blueprint);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePointOfPlane3Y0Z().Create(pt, blueprint);
                var source = CreateByLineAndPoint((LineOfPlane3Y0Z)_planeObjects[0], tmpobj);
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
                var tmpobj = new CreateLineOfPlane3Y0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelLines((LineOfPlane3Y0Z)_planeObjects[0], (LineOfPlane3Y0Z)_planeObjects[1]);
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
                    var ln = (LineOfPlane3Y0Z) o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByCrossedLines(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLineOfPlane3Y0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedLines((LineOfPlane3Y0Z)_planeObjects[0], (LineOfPlane3Y0Z)_planeObjects[1], frameCenter);
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
                    var ln = (LineOfPlane3Y0Z) o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateBySegmentAndPoint(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateSegmentOfPlane3Y0Z().Create(pt, blueprint);
                if (tmpobj == null) return;
                tmpobj.Draw(blueprint);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePointOfPlane3Y0Z().Create(pt, blueprint);
                var source = CreateBySegmentAndPoint((SegmentOfPlane3Y0Z)_planeObjects[0], tmpobj);
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
                var tmpobj = new CreateSegmentOfPlane3Y0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelSegments((SegmentOfPlane3Y0Z)_planeObjects[0], (SegmentOfPlane3Y0Z)_planeObjects[1]);
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
                    var ln = (SegmentOfPlane3Y0Z)o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByCrossedSegments(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateSegmentOfPlane3Y0Z().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedSegments((SegmentOfPlane3Y0Z)_planeObjects[0], (SegmentOfPlane3Y0Z)_planeObjects[1], frameCenter);
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
                    var ln = (SegmentOfPlane3Y0Z)o;
                    ln.Draw(blueprint);
                }
            }
        }
        public PlaneOfPlane3Y0Z CreateByThreePoint(Collection<IObject> obj)
        {
            return obj.Count != 3 ? null : new PlaneOfPlane3Y0Z((PointOfPlane3Y0Z)obj[0], (PointOfPlane3Y0Z)obj[1], (PointOfPlane3Y0Z)obj[2]);
        }
        public PlaneOfPlane3Y0Z CreateByLineAndPoint(LineOfPlane3Y0Z ln, PointOfPlane3Y0Z pt)
        {
            return new PlaneOfPlane3Y0Z(ln, pt);
        }
        public PlaneOfPlane3Y0Z CreateByParallelLines(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            return ln1.IsParallel(ln2) ? new PlaneOfPlane3Y0Z(ln1, ln2) : null;
        }
        public PlaneOfPlane3Y0Z CreateByCrossedLines(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2, Point frameCenter)
        {
            return ln1.IsIntersect(ln2, frameCenter) ? new PlaneOfPlane3Y0Z(ln1, ln2) : null;
        }
        public PlaneOfPlane3Y0Z CreateBySegmentAndPoint(SegmentOfPlane3Y0Z sg, PointOfPlane3Y0Z pt)
        {
            return new PlaneOfPlane3Y0Z(sg, pt);
        }
        public PlaneOfPlane3Y0Z CreateByParallelSegments(SegmentOfPlane3Y0Z sg1, SegmentOfPlane3Y0Z sg2)
        {
            return sg1.IsParallel(sg2) ? new PlaneOfPlane3Y0Z(sg1, sg2) : null;
        }
        public PlaneOfPlane3Y0Z CreateByCrossedSegments(SegmentOfPlane3Y0Z sg1, SegmentOfPlane3Y0Z sg2, Point frameCenter)
        {
            return sg1.IsIntersect(sg2, frameCenter) ? new PlaneOfPlane3Y0Z(sg1, sg2) : null;
        }
        public void SetBuildType(PlaneCreateType type)
        {
            _creationType = type;
        }
    }
}
