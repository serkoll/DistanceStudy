using System.Collections.ObjectModel;
using System.Drawing;
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
using GraphicsModule.Settings;


namespace GraphicsModule.Rules.Objects.Planes
{
    public class CreatePlane2D : ICreate, ICreatePlanes
    {
        private byte _creationType;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            switch (_creationType)
            {
                case 0:
                    CreateBy3Point(pt, frameCenter, can, setting, strg);
                    break;
                case 1:
                    CreateByLinePoint(pt, frameCenter, can, setting, strg);
                    break;
                case 2:
                    CreateByParallelLines(pt, frameCenter, can, setting, strg);
                    break;
                case 3:
                    CreateByIntersectedLines(pt, frameCenter, can, setting, strg);
                    break;
            }
        }
        private void CreateBy3Point(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var tmpobj = new CreatePoint2D().Create(pt, frameCenter, can, setting, strg);
            tmpobj.Draw(setting, frameCenter, can.Graphics);
            _planeObjects.Add(tmpobj);
            if (_planeObjects.Count != 3) return;
            var source = CreateBy3Point(_planeObjects);
            var nameparams = _planeObjects[0].GetName();
            source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
            _planeObjects.Clear();
            strg.AddToCollection(source);
            can.Update(strg);
        }
        private void CreateByLinePoint(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
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
                var source = CreateByLinePoint((Line2D)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateBySegmentPoint(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
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
                var source = CreateByLinePoint((Line2D)_planeObjects[0], tmpobj);
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByParallelLines(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
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
            if (_planeObjects.Count != 2) return;
            var source = CreateByIntersectedLines((Line2D)_planeObjects[0], (Line2D)_planeObjects[1]);
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
        public Plane2D CreateBy3Point(Collection<IObject> obj)
        {
            return obj.Count != 3 ? null : new Plane2D((Point2D)obj[0], (Point2D)obj[1], (Point2D)obj[2]);
        }
        public Plane2D CreateByLinePoint(Line2D ln, Point2D pt)
        {
            return new Plane2D(ln, pt);
        }
        public Plane2D CreateBySegmentPoint(Segment2D sg, Point2D pt)
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
        public Plane2D CreateByIntersectedLines(Line2D ln1, Line2D ln2)
        {
            return Analyze.LinesPos.Intersection(ln1, ln2) ? new Plane2D(ln1, ln2) : null;
        }
        public Plane2D CreateByIntersectedLines(Segment2D sg1, Segment2D sg2)
        {
            return Analyze.SegmentPos.Intersection(sg1, sg2) ? new Plane2D(sg1, sg2) : null;
        }
        public void SetBuildType(PlaneBuildType type)
        {
            _creationType = (byte)type;
        }
    }
}
