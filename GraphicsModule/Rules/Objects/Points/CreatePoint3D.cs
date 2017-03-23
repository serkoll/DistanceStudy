using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Enums;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание 3Д точки
    /// </summary>
    public class CreatePoint3D : ICreate
    {
        public Point3DCreateType BuidType = Point3DCreateType.By2PointsOfPlane;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            var source = Create(pt, frameCenter, can, settings, strg);
            if (source == null) return;
            strg.AddToCollection(source);
            strg.DrawLastAddedToObjects(settings, frameCenter, can.Graphics);
        }
        public Point3D Create(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage storage)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (storage.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                storage.TempPointsOfPlane.Add((IPointOfPlane)ptOfPlane);
                //storage.TempObjects.Add(ptOfPlane);
                ptOfPlane.Draw(settings, frameCenter, can.Graphics);
                return null;
            }
            if (ReferenceEquals(storage.TempObjects.First().GetType(), ptOfPlane.GetType())) return null;
            storage.TempPointsOfPlane.Add((IPointOfPlane)ptOfPlane);
            if (BuidType == Point3DCreateType.By3PointsOfPlane && storage.TempPointsOfPlane.Count != 3)
            {
                if(Point3D.Create(storage.TempPointsOfPlane, byte.Parse(BuidType.ToString())) == null)
                    storage.TempPointsOfPlane.RemoveAt(storage.TempPointsOfPlane.Count - 1);
                else
                    ptOfPlane.Draw(settings, frameCenter, can.Graphics);
                return null;
            }
            return Create(can, storage);
        }
        private Point3D Create(Canvas canvas, Storage storage)
        {
            var source = Point3D.Create(storage.TempPointsOfPlane, byte.Parse(BuidType.ToString()));
            if (source == null)
            {
                storage.TempPointsOfPlane.RemoveAt(storage.TempPointsOfPlane.Count - 1);
                canvas.Update(storage);
                return null;
            }
            source.SetName(((IObject)storage.TempPointsOfPlane.First()).GetName());
            storage.TempObjects.Clear();
            canvas.Update(storage);
            return null;
        }
    }
}
