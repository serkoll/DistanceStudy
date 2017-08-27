using System.Collections.ObjectModel;
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
    public class CreatePlaneOfPlane1X0Y : ICreate, ICreatePlanes
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
                        CreateByPointAndSegment(pt, blueprint.CoordinateSystemCenterPoint, blueprint, blueprint.Settings.Drawing, blueprint.Storage);
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
            var tmpobj = new CreatePointOfPlane1X0Y().Create(pt, blueprint);
            if(tmpobj == null) return;
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
                var tmpobj = new CreateLineOfPlane1X0Y().Create(pt, blueprint);
                if (tmpobj == null) return;
                tmpobj.Draw(blueprint);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePointOfPlane1X0Y().Create(pt, blueprint);
                var source = CreateByLineAndPoint((LineOfPlane1X0Y)_planeObjects[0], tmpobj);
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
                var tmpobj = new CreateLineOfPlane1X0Y().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelLines((LineOfPlane1X0Y)_planeObjects[0], (LineOfPlane1X0Y)_planeObjects[1]);
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
                    var ln = (LineOfPlane1X0Y) o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByCrossedLines(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLineOfPlane1X0Y().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedLines((LineOfPlane1X0Y)_planeObjects[0], (LineOfPlane1X0Y)_planeObjects[1], frameCenter);
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
                    var ln = (LineOfPlane1X0Y) o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByPointAndSegment(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateSegmentOfPlane1X0Y().Create(pt, blueprint);
                if (tmpobj == null) return;
                tmpobj.Draw(blueprint);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePointOfPlane1X0Y().Create(pt, blueprint);
                var source = CreateByPointAndSegment((SegmentOfPlane1X0Y)_planeObjects[0], tmpobj);
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
                var tmpobj = new CreateSegmentOfPlane1X0Y().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelSegments((SegmentOfPlane1X0Y)_planeObjects[0], (SegmentOfPlane1X0Y)_planeObjects[1]);
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
                    var ln = (SegmentOfPlane1X0Y)o;
                    ln.Draw(blueprint);
                }
            }
        }
        private void CreateByCrossedSegments(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateSegmentOfPlane1X0Y().Create(pt, blueprint);
                if (tmpobj != null)
                {
                    tmpobj.Draw(blueprint);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedSegments((SegmentOfPlane1X0Y)_planeObjects[0], (SegmentOfPlane1X0Y)_planeObjects[1], frameCenter);
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
                    var ln = (SegmentOfPlane1X0Y)o;
                    ln.Draw(blueprint);
                }
            }
        }

        public PlaneOfPlane1X0Y CreateByThreePoint(Collection<IObject> obj)
        {
            //TODO: govnokod popravit
            return obj.Count != 3 ? null : new PlaneOfPlane1X0Y((PointOfPlane1X0Y)obj[0], (PointOfPlane1X0Y)obj[1], (PointOfPlane1X0Y)obj[2]);
        }
        public PlaneOfPlane1X0Y CreateByLineAndPoint(LineOfPlane1X0Y ln, PointOfPlane1X0Y pt)
        {
            return new PlaneOfPlane1X0Y(ln, pt);
        }
        public PlaneOfPlane1X0Y CreateByParallelLines(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2)
        {
            return ln1.IsParallel(ln2) ? new PlaneOfPlane1X0Y(ln1, ln2) : null;
        }
        public PlaneOfPlane1X0Y CreateByCrossedLines(LineOfPlane1X0Y ln1, LineOfPlane1X0Y ln2, Point frameCenter)
        {
            return ln1.IsIntersect(ln2, frameCenter) ? new PlaneOfPlane1X0Y(ln1, ln2) : null;
        }
        public PlaneOfPlane1X0Y CreateByPointAndSegment(SegmentOfPlane1X0Y sg, PointOfPlane1X0Y pt)
        {
            return new PlaneOfPlane1X0Y(sg, pt);
        }
        public PlaneOfPlane1X0Y CreateByParallelSegments(SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2)
        {
            return sg1.IsParallel(sg2) ? new PlaneOfPlane1X0Y(sg1, sg2) : null;
        }
        public PlaneOfPlane1X0Y CreateByCrossedSegments(SegmentOfPlane1X0Y sg1, SegmentOfPlane1X0Y sg2, Point frameCenter)
        {
            return sg1.IsIntersect(sg1, frameCenter) ? new PlaneOfPlane1X0Y(sg1, sg2) : null;
        }
        public void SetBuildType(PlaneCreateType type)
        {
            _creationType = type;
        }
    }
}
