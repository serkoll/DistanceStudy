using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Enums;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Planes;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;
using GraphicsModule.Rules.Objects.Lines;
using GraphicsModule.Rules.Objects.Points;
using GraphicsModule.Rules.Objects.Segments;


namespace GraphicsModule.Rules.Objects.Planes
{
    public class CreatePlane2D : ICreate, ICreatePlanes
    {
        private PlaneCreateType _creationType;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            switch (_creationType)
            {
                case PlaneCreateType.ThreePoints:
                    CreateByThreePoint(pt, frameCenter, can, settings, strg);
                    break;
                case PlaneCreateType.LineAndPoint:
                    CreateByLineAndPoint(pt, frameCenter, can, settings, strg);
                    break;
                case PlaneCreateType.ParallelLines:
                    CreateByParallelLines(pt, frameCenter, can, settings, strg);
                    break;
                case PlaneCreateType.CrossedLines:
                    CreateByCrossedLines(pt, frameCenter, can, settings, strg);
                    break;
                case PlaneCreateType.SegmentAndPoint:
                    CreateByPointAndSegment(pt, frameCenter, can, settings, strg);
                    break;
                case PlaneCreateType.ParallelSegments:
                    CreateByParallelSegments(pt, frameCenter, can, settings, strg);
                    break;
                case PlaneCreateType.CrossedSegments:
                    CreateByCrossedSegments(pt, frameCenter, can, settings, strg);
                    break;
            }
        }
        private void CreateByThreePoint(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            var tmpobj = new CreatePoint2D().Create(pt, frameCenter, can, setting, strg);
            tmpobj.Draw(setting, frameCenter, can.Graphics);
            _planeObjects.Add(tmpobj);
            if (_planeObjects.Count != 3) return;
            var source = CreateByThreePoint(_planeObjects);
            var nameparams = _planeObjects[0].GetName();
            source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
            _planeObjects.Clear();
            strg.AddToCollection(source);
            can.Update(strg);
        }
        private void CreateByLineAndPoint(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateLine2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj == null) return;
                tmpobj.Draw(setting, frameCenter, can.Graphics);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePoint2D().Create(pt, frameCenter, can, setting, strg);
                var source = CreateByLineAndPoint((Line2D)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByPointAndSegment(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateSegment2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj == null) return;
                tmpobj.Draw(setting, frameCenter, can.Graphics);
                _planeObjects.Add(tmpobj);
            }
            else
            {
                var tmpobj = new CreatePoint2D().Create(pt, frameCenter, can, setting, strg);
                var source = CreateByPointAndSegment((Segment2D)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByParallelLines(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLine2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj == null) return;
                tmpobj.Draw(setting, frameCenter, can.Graphics);
                _planeObjects.Add(tmpobj);
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelLines((Line2D)_planeObjects[0], (Line2D)_planeObjects[1]);
            if (source == null)
            {
                _planeObjects.RemoveAt(1);
                can.Update(strg);
                foreach (var o in _planeObjects)
                {
                    var ln = (Line2D)o;
                    ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
            else
            {
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByParallelSegments(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateSegment2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj == null) return;
                tmpobj.Draw(setting, frameCenter, can.Graphics);
                _planeObjects.Add(tmpobj);
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByParallelSegments((Segment2D)_planeObjects[0], (Segment2D)_planeObjects[1]);
            if (source == null)
            {
                _planeObjects.RemoveAt(1);
                can.Update(strg);
                foreach (var o in _planeObjects)
                {
                    var ln = (Segment2D)o;
                    ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
            else
            {
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByCrossedLines(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
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
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedLines((Line2D)_planeObjects[0], (Line2D)_planeObjects[1]);
            if (source == null)
            {
                _planeObjects.RemoveAt(1);
                can.Update(strg);
                foreach (var o in _planeObjects)
                {
                    var ln = (Line2D)o;
                    ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
            else
            {
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByCrossedSegments(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateSegment2D().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count != 2) return;
            var source = CreateByCrossedSegments((Segment2D)_planeObjects[0], (Segment2D)_planeObjects[1]);
            if (source == null)
            {
                _planeObjects.RemoveAt(1);
                can.Update(strg);
                foreach (var o in _planeObjects)
                {
                    var ln = (Segment2D)o;
                    ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
            else
            {
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        public Plane2D CreateByThreePoint(Collection<IObject> obj)
        {
            return obj.Count != 3 ? null : new Plane2D((Point2D)obj[0], (Point2D)obj[1], (Point2D)obj[2]);
        }
        public Plane2D CreateByLineAndPoint(Line2D ln, Point2D pt)
        {
            return new Plane2D(ln, pt);
        }
        public Plane2D CreateByPointAndSegment(Segment2D sg, Point2D pt)
        {
            return new Plane2D(sg, pt);
        }
        public Plane2D CreateByParallelLines(Line2D ln1, Line2D ln2)
        {
            return Analyze.LinesPos.Parallelism(ln1, ln2) ? new Plane2D(ln1, ln2) : null;
        }
        public Plane2D CreateByParallelSegments(Segment2D sg1, Segment2D sg2)
        {
            return Analyze.SegmentPos.Parallelism(sg1, sg2) ? new Plane2D(sg1, sg2) : null;
        }
        public Plane2D CreateByCrossedLines(Line2D ln1, Line2D ln2)
        {
            return Analyze.LinesPos.Crossing(ln1, ln2) ? new Plane2D(ln1, ln2) : null;
        }
        public Plane2D CreateByCrossedSegments(Segment2D sg1, Segment2D sg2)
        {
            return Analyze.SegmentPos.Crossing(sg1, sg2) ? new Plane2D(sg1, sg2) : null;
        }
        public void SetBuildType(PlaneCreateType type)
        {
            _creationType = type;
        }
    }
}
