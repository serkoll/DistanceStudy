using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Enums;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Geometry;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание 3Д точки
    /// </summary>
    public class CreatePoint3D : ICreate
    {
        public Point3DCreateType BuildType = Point3DCreateType.By2PointsOfPlane;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            var source = Create(pt, frameCenter, canvas, settings, storage);
            if (source == null) return;
            storage.AddToCollection(source);
            storage.TempObjects.Clear();
            canvas.Update(storage);
        }
        public Point3D Create(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (storage.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                storage.TempObjects.Add(ptOfPlane);
                ptOfPlane.Draw(settings, frameCenter, canvas.Graphics);
                return null;
            }
            if (ReferenceEquals(storage.TempObjects.First().GetType(), ptOfPlane.GetType())) return null;
            storage.TempObjects.Add(ptOfPlane);
            if (BuildType == Point3DCreateType.By3PointsOfPlane && storage.TempObjects.Count != 3)
            {
                if(Point3D.Create(storage.TempObjects, (byte)BuildType) == null)
                    storage.TempObjects.RemoveAt(storage.TempObjects.Count - 1);
                else
                    ptOfPlane.Draw(settings, frameCenter, canvas.Graphics);
                return null;
            }
            var source = Point3D.Create(storage.TempObjects, (byte)BuildType);
            if (source == null)
            {
                storage.TempObjects.RemoveAt(storage.TempObjects.Count - 1);
                canvas.Update(storage);
                return null;
            }
            source.Name = storage.TempObjects.First().Name;
            return source;
        }
    }
}
