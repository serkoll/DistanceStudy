using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Planes;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects
{
    public class CreatePlane2D : ICreate
    {
        public byte CreationType { get; set; } = 0;
        private Collection<IObject> _planeObjects = new Collection<IObject>();
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            switch (CreationType)
            {
                case 0:
                    {
                        var tmpobj = new CreatePoint2D().Create(pt, frameCenter, can, setting, strg);
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
                        break;
                    }
                case 1:
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
                            var source = CreateByLinePoint((Line2D) _planeObjects[0], tmpobj);
                            source.SetName(new Name(@"p", 0, 0));
                            _planeObjects.Clear();
                            strg.AddToCollection(source);
                            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                        }
                        break;
                    }
            }
        }
        public Plane2D CreateBy3Point(Collection<IObject> obj)
        {
            if (obj.Count != 3) return null;
            return new Plane2D((Point2D)obj[0], (Point2D)obj[1], (Point2D)obj[2]);
        }
        public Plane2D CreateByLinePoint(Line2D ln, Point2D pt)
        {
            return new Plane2D(ln, pt);
        }
    }
}
