using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Enums;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Points
{
    /// <summary>
    /// Создание 3Д точки
    /// </summary>
    public class CreatePoint3D : ICreate
    {
        private Point3DCreateType BuildType = Point3DCreateType.By2PointsOfPlane;

        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var source = Create(pt, blueprint);
            if (source == null)
                return;

            blueprint.Storage.AddToCollection(source);
            blueprint.Update();
        }

        public Point3D Create(Point pt, Blueprint blueprint)
        {
            return Create(pt, blueprint.CoordinateSystemCenterPoint, blueprint);
        }

        public Point3D Create(Point pt, Point frameCenter, Blueprint blueprint)
        {
            var ptOfPlane = pt.ToPointOfPlane(frameCenter);
            if (ptOfPlane == null)
            {
                return null;
            }

            var tempObjects = blueprint.Storage.TempObjects;
            if (tempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                tempObjects.Add(ptOfPlane);
                ptOfPlane.Draw(blueprint);
                return null;
            }

            if (ReferenceEquals(tempObjects.First().GetType(), ptOfPlane.GetType()))
            {
                return null;
            }

            tempObjects.Add(ptOfPlane);

            if (BuildType == Point3DCreateType.By3PointsOfPlane && tempObjects.Count != 3)
            {
                if (ObjectsCreator.Point3D().Create(tempObjects.Cast<IPointOfPlane>().ToList(), (byte)BuildType) == null)
                {
                    tempObjects.RemoveAt(tempObjects.Count - 1);
                }
                else
                {
                    ptOfPlane.Draw(blueprint);
                }
                return null;
            }

            var source = ObjectsCreator.Point3D().Create(tempObjects.Cast<IPointOfPlane>().ToList(), (byte)BuildType);
            if (source == null)
            {
                tempObjects.RemoveAt(tempObjects.Count - 1);
                blueprint.Update();
                return null;
            }

            source.Name = tempObjects.First().Name;
            tempObjects.Clear();
            return source;
        }
    }
}
