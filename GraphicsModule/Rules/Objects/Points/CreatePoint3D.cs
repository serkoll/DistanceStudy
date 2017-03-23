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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            var source = Create(pt, frameCenter, can, setting, strg);
            if (source == null) return;
            strg.AddToCollection(source);
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }
        public Point3D Create(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempPointsOfPlane.Add((IPointOfPlane)ptOfPlane);
                //strg.TempObjects.Add(ptOfPlane);
                ptOfPlane.Draw(setting, );
                return null;
            }
            if (ReferenceEquals(strg.TempObjects.First().GetType(), ptOfPlane.GetType())) return null;
            strg.TempPointsOfPlane.Add((IPointOfPlane)ptOfPlane);
            switch (BuidType)
            {
                case Point3DCreateType.By2PointsOfPlane:
                    {
                        if(Point3D.IsCreatable(strg.TempPointsOfPlane))
                        break;
                    }
                case Point3DCreateType.By3PointsOfPlane:
                    {
                        break;
                    }
            }
            if (source != null)
            {
                source.SetName(strg.TempObjects[0].GetName());
                strg.TempObjects.Clear();
                can.Update(strg);
                return source;
            }
            strg.TempObjects.RemoveAt(strg.TempObjects.Count - 1);
            return null;
        }
    }
}
