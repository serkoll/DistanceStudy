using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Enums;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Planes;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Rules.Objects.Lines;
using GraphicsModule.Rules.Objects.Points;

namespace GraphicsModule.Rules.Objects.Planes
{
    public class CreatePlaneOfPlane3Y0Z : ICreate, ICreatePlanes
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
            var tmpobj = new CreatePointOfPlane3Y0Z().Create(pt, frameCenter, can, setting, strg);
            tmpobj.Draw(setting, frameCenter, can.Graphics);
            _planeObjects.Add(tmpobj);
            if (_planeObjects.Count == 3)
            {
                var source = CreateBy3Point(_planeObjects);
                var nameparams = _planeObjects[0].GetName();
                source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                _planeObjects.Clear();
                strg.AddToCollection(source);
                can.Update(strg);
            }
        }
        private void CreateByLinePoint(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count == 0)
            {
                var tmpobj = new CreateLineOfPlane3Y0Z().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            else
            {
                var tmpobj = new CreatePointOfPlane3Y0Z().Create(pt, frameCenter, can, setting, strg);
                var source = CreateByLinePoint((LineOfPlane3Y0Z)_planeObjects[0], tmpobj);
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
                var tmpobj = new CreateLineOfPlane3Y0Z().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count == 2)
            {
                var source = CreateByParallelLines((LineOfPlane3Y0Z)_planeObjects[0], (LineOfPlane3Y0Z)_planeObjects[1]);
                if (source != null)
                {
                    var nameparams = _planeObjects[0].GetName();
                    source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                    _planeObjects.Clear();
                    strg.AddToCollection(source);
                    can.Update(strg);
                }
                else
                {
                    _planeObjects.RemoveAt(1);
                    can.Update(strg);
                    foreach (LineOfPlane3Y0Z ln in _planeObjects)
                        ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
        }
        private void CreateByIntersectedLines(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (_planeObjects.Count < 2)
            {
                var tmpobj = new CreateLineOfPlane3Y0Z().Create(pt, frameCenter, can, setting, strg);
                if (tmpobj != null)
                {
                    tmpobj.Draw(setting, frameCenter, can.Graphics);
                    _planeObjects.Add(tmpobj);
                }
            }
            if (_planeObjects.Count == 2)
            {
                var source = CreateByIntersectedLines((LineOfPlane3Y0Z)_planeObjects[0], (LineOfPlane3Y0Z)_planeObjects[1], frameCenter);
                if (source != null)
                {
                    var nameparams = _planeObjects[0].GetName();
                    source.SetName(new Name(@"p", nameparams.Dx, nameparams.Dy));
                    _planeObjects.Clear();
                    strg.AddToCollection(source);
                    can.Update(strg);
                }
                else
                {
                    _planeObjects.RemoveAt(1);
                    can.Update(strg);
                    foreach (LineOfPlane3Y0Z ln in _planeObjects)
                        ln.Draw(setting, frameCenter, can.Graphics);
                }
            }
        }
        public PlaneOfPlane3Y0Z CreateBy3Point(Collection<IObject> obj)
        {
            return obj.Count != 3 ? null : new PlaneOfPlane3Y0Z((PointOfPlane3Y0Z)obj[0], (PointOfPlane3Y0Z)obj[1], (PointOfPlane3Y0Z)obj[2]);
        }
        public PlaneOfPlane3Y0Z CreateByLinePoint(LineOfPlane3Y0Z ln, PointOfPlane3Y0Z pt)
        {
            return new PlaneOfPlane3Y0Z(ln, pt);
        }
        public PlaneOfPlane3Y0Z CreateByParallelLines(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2)
        {
            return Analyze.LinesPos.Parallelism(ln1, ln2) ? new PlaneOfPlane3Y0Z(ln1, ln2) : null;
        }
        public PlaneOfPlane3Y0Z CreateByIntersectedLines(LineOfPlane3Y0Z ln1, LineOfPlane3Y0Z ln2, Point frameCenter)
        {
            return Analyze.LinesPos.Intersection(ln1, ln2, frameCenter) ? new PlaneOfPlane3Y0Z(ln1, ln2) : null;
        }
        public void SetBuildType(PlaneBuildType type)
        {
            _creationType = (byte)type;
        }
    }
}
