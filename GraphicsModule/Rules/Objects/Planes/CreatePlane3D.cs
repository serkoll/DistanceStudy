using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Enums;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Planes;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Rules.Objects.Lines;
using GraphicsModule.Rules.Objects.Points;

namespace GraphicsModule.Rules.Objects.Planes
{
    public class CreatePlane3D : ICreate, ICreatePlanes
    {
        private PlaneCreateType _creationType;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        private CreateLine3D _createLine = new CreateLine3D();
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            switch (_creationType)
            {
                case PlaneCreateType.ThreePoints:
                    {
                        CreateByThreePoint(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
                case PlaneCreateType.LineAndPoint:
                    {
                        CreateByLineAndPoint(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
                case PlaneCreateType.ParallelLines:
                    {
                        CreateByParallelLines(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
                case PlaneCreateType.CrossedLines:
                    {
                        //CreateByCrossedLines(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
                case PlaneCreateType.SegmentAndPoint:
                    {
                        //CreateByPointAndSegment(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
                case PlaneCreateType.ParallelSegments:
                    {
                        //CreateByParallelSegments(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
                case PlaneCreateType.CrossedSegments:
                    {
                        //CreateByCrossedSegments(pt, frameCenter, canvas, settings, storage);
                        break;
                    }
            }
        }
        private void PlaneObjectsDraw(DrawSettings settings, Point frameCenter, Canvas can)
        {
            if (_planeObjects.Count == 0) return;
            foreach (var o in _planeObjects)
            {
                o.Draw(settings, frameCenter, can.Graphics);
            }
        }
        private void CreateByThreePoint(Point pt, Point frameCenter, Canvas can, DrawSettings settings, Storage strg)
        {
            var tmpobj = new CreatePoint3D().Create(pt, frameCenter, can, settings, strg);
            if (tmpobj == null) return;
            _planeObjects.Add(tmpobj);
            PlaneObjectsDraw(settings, frameCenter, can);
            if (_planeObjects.Count != 3) return;
            var source = CreateByThreePoint(_planeObjects);
            var nameparams = _planeObjects[0].Name;
            source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
            _planeObjects.Clear();
            strg.AddToCollection(source);
            can.Update(strg);
        }
        private void CreateByLineAndPoint(Point pt, Point frameCenter, Canvas can, DrawSettings settings, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = _createLine.Create(pt, frameCenter, can, settings, strg);
                if (tmpobj == null) return;
                can.Update(strg);
                _planeObjects.Add(tmpobj);
                PlaneObjectsDraw(settings, frameCenter, can);
            }
            else
            {
                var tmpobj = new CreatePoint3D().Create(pt, frameCenter, can, settings, strg);
                if (tmpobj == null)
                {
                    PlaneObjectsDraw(settings, frameCenter, can);
                    return;
                }
                var source = CreateByLineAndPoint((Line3D)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects.First().Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByParallelLines(Point pt, Point frameCenter, Canvas can, DrawSettings settings, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = _createLine.Create(pt, frameCenter, can, settings, strg);
                if (_planeObjects.Count != 0)
                {
                    var line3D = (Line3D)_planeObjects.First();
                    if(_createLine.TempLineOfPlane != null && Analyze.LinesPosition.Parallelism(line3D, _createLine.TempLineOfPlane))
                    {
                        _createLine.TempLineOfPlane = null;
                        can.Update(strg);
                        PlaneObjectsDraw(settings, frameCenter, can);
                    }
                }
                if (tmpobj != null)
                {
                    _planeObjects.Add(tmpobj);
                    PlaneObjectsDraw(settings, frameCenter, can);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelLines((Line3D)_planeObjects[0], (Line3D)_planeObjects[1]);
            if (source != null)
            {
                var nameparams = _planeObjects[0].Name;
                source.Name = new Name(@"p", nameparams.Dx, nameparams.Dy);
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
            else
            {
                _planeObjects.RemoveAt(1);
                can.Update(strg);
                foreach (var o in _planeObjects)
                {
                    var ln = (Line3D)o;
                    ln.Draw(settings, frameCenter, can.Graphics);
                }
            }
        }
        //private void CreateByCrossedLines(Point pt, Point frameCenter, Canvas.Canvas canvas, DrawS settings, Storage storage)
        //{
        //    if (_planeObjects.Count < 2)
        //    {
        //        var tmpobj = new CreateLineOfPlane1X0Y().Create(pt, frameCenter, canvas, settings, storage);
        //        if (tmpobj != null)
        //        {
        //            tmpobj.Draw(settings, frameCenter, canvas.Graphics);
        //            _planeObjects.Add(tmpobj);
        //        }
        //    }
        //    if (_planeObjects.Count != 2) return;
        //    var source = CreateByCrossedLines((LineOfPlane1X0Y)_planeObjects[0], (LineOfPlane1X0Y)_planeObjects[1], frameCenter);
        //    if (source != null)
        //    {
        //        var nameparams = _planeObjects[0].GetName();
        //        source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
        //        _planeObjects.Clear();
        //        storage.AddToCollection(source);
        //        canvas.Update(storage);
        //    }
        //    else
        //    {
        //        _planeObjects.RemoveAt(1);
        //        canvas.Update(storage);
        //        foreach (var o in _planeObjects)
        //        {
        //            var ln = (LineOfPlane1X0Y)o;
        //            ln.Draw(settings, frameCenter, canvas.Graphics);
        //        }
        //    }
        //}
        //private void CreateByPointAndSegment(Point pt, Point frameCenter, Canvas.Canvas canvas, DrawS settings, Storage storage)
        //{
        //    if (_planeObjects.Count == 0)
        //    {
        //        var tmpobj = new CreateSegmentOfPlane1X0Y().Create(pt, frameCenter, canvas, settings, storage);
        //        if (tmpobj == null) return;
        //        tmpobj.Draw(settings, frameCenter, canvas.Graphics);
        //        _planeObjects.Add(tmpobj);
        //    }
        //    else
        //    {
        //        var tmpobj = new CreatePointOfPlane1X0Y().Create(pt, frameCenter, canvas, settings, storage);
        //        var source = CreateByPointAndSegment((SegmentOfPlane1X0Y)_planeObjects[0], tmpobj);
        //        var nameparams = _planeObjects[0].GetName();
        //        source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
        //        _planeObjects.Clear();
        //        storage.AddToCollection(source);
        //        canvas.Update(storage);
        //    }
        //}
        //private void CreateByParallelSegments(Point pt, Point frameCenter, Canvas.Canvas canvas, DrawS settings, Storage storage)
        //{
        //    if (_planeObjects.Count < 2)
        //    {
        //        var tmpobj = new CreateSegmentOfPlane1X0Y().Create(pt, frameCenter, canvas, settings, storage);
        //        if (tmpobj != null)
        //        {
        //            tmpobj.Draw(settings, frameCenter, canvas.Graphics);
        //            _planeObjects.Add(tmpobj);
        //        }
        //    }
        //    if (_planeObjects.Count != 2) return;
        //    var source = CreateByParallelSegments((SegmentOfPlane1X0Y)_planeObjects[0], (SegmentOfPlane1X0Y)_planeObjects[1]);
        //    if (source != null)
        //    {
        //        var nameparams = _planeObjects[0].GetName();
        //        source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
        //        _planeObjects.Clear();
        //        storage.AddToCollection(source);
        //        canvas.Update(storage);
        //    }
        //    else
        //    {
        //        _planeObjects.RemoveAt(1);
        //        canvas.Update(storage);
        //        foreach (var o in _planeObjects)
        //        {
        //            var ln = (SegmentOfPlane1X0Y)o;
        //            ln.Draw(settings, frameCenter, canvas.Graphics);
        //        }
        //    }
        //}
        //private void CreateByCrossedSegments(Point pt, Point frameCenter, Canvas.Canvas canvas, DrawS settings, Storage storage)
        //{
        //    if (_planeObjects.Count < 2)
        //    {
        //        var tmpobj = new CreateSegmentOfPlane1X0Y().Create(pt, frameCenter, canvas, settings, storage);
        //        if (tmpobj != null)
        //        {
        //            tmpobj.Draw(settings, frameCenter, canvas.Graphics);
        //            _planeObjects.Add(tmpobj);
        //        }
        //    }
        //    if (_planeObjects.Count != 2) return;
        //    var source = CreateByCrossedSegments((SegmentOfPlane1X0Y)_planeObjects[0], (SegmentOfPlane1X0Y)_planeObjects[1], frameCenter);
        //    if (source != null)
        //    {
        //        var nameparams = _planeObjects[0].GetName();
        //        source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
        //        _planeObjects.Clear();
        //        storage.AddToCollection(source);
        //        canvas.Update(storage);
        //    }
        //    else
        //    {
        //        _planeObjects.RemoveAt(1);
        //        canvas.Update(storage);
        //        foreach (var o in _planeObjects)
        //        {
        //            var ln = (SegmentOfPlane1X0Y)o;
        //            ln.Draw(settings, frameCenter, canvas.Graphics);
        //        }
        //    }
        //}
        public Plane3D CreateByThreePoint(Collection<IObject> obj)
        {
            return obj.Count != 3 ? null : new Plane3D((Point3D)obj[0], (Point3D)obj[1], (Point3D)obj[2]);
        }
        public Plane3D CreateByLineAndPoint(Line3D ln, Point3D pt)
        {
            return new Plane3D(ln, pt);
        }
        public Plane3D CreateByParallelLines(Line3D ln1, Line3D ln2)
        {
            return Analyze.LinesPosition.Parallelism(ln1, ln2) ? new Plane3D(ln1, ln2) : null;
        }
        //public Plane3D CreateByCrossedLines(Line3D ln1, Line3D ln2, Point frameCenter)
        //{
        //    return Analyze.LinesPosition.Crossing(ln1, ln2, frameCenter) ? new Plane3D(ln1, ln2) : null;
        //}
        //public Plane3D CreateByPointAndSegment(Segment3D sg, Point3D pt)
        //{
        //    return new Plane3D(sg, pt);
        //}
        //public Plane3D CreateByParallelSegments(Segment3D sg1, Segment3D sg2)
        //{
        //    return Analyze.LinesPosition.Parallelism(sg1, sg2) ? new Plane3D(sg1, sg2) : null;
        //}
        //public Plane3D CreateByCrossedSegments(Segment3D sg1, Segment3D sg2, Point frameCenter)
        //{
        //    return Analyze.LinesPosition.Crossing(sg1, sg2, frameCenter) ? new Plane3D(sg1, sg2) : null;
        //}
        public void SetBuildType(PlaneCreateType type)
        {
            _creationType = type;
        }
    }
}
