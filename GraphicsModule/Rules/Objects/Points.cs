using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects
{
    /// <summary>
    /// Создание 2Д точки
    /// </summary>
    public class CreatePoint2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            strg.AddToCollection(Create(pt, frameCenter, can, setting, strg));
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }

        public Point2D Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var source = new Point2D(pt);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
    /// <summary>
    /// Создание проекции точки на плоскость X0Y
    /// </summary>
    public class CreatePointOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var source = Create(pt, frameCenter, can, setting, strg);
            if (source == null) return;
            strg.AddToCollection(source);
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }

        public PointOfPlane1X0Y Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane1X0Y.Creatable(pt, frameCenter)) return null;
            var source = new PointOfPlane1X0Y(pt, frameCenter);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
    /// <summary>
    /// Создание проекции точки на плоскость X0Z
    /// </summary>
    public class CreatePointOfPlane2X0Z : ICreate
    {
        private PointOfPlane2X0Z _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane2X0Z.Creatable(pt, frameCenter)) return;
            _source = new PointOfPlane2X0Z(pt, frameCenter);
            _source.SetName(GraphicsControl.NmGenerator.Generate());
            strg.AddToCollection(_source);
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }
    }
    /// <summary>
    /// Создание проекции точки на плоскость Y0Z
    /// </summary>
    public class CreatePointOfPlane3Y0Z : ICreate
    {
        private PointOfPlane3Y0Z _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane3Y0Z.Creatable(pt, frameCenter)) return;
            _source = new PointOfPlane3Y0Z(pt, frameCenter);
            _source.SetName(GraphicsControl.NmGenerator.Generate());
            strg.AddToCollection(_source);
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }
    }
    /// <summary>
    /// Создание 3Д точки
    /// </summary>
    public class CreatePoint3D : ICreate
    {
        private Point3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
            }
            else
            {
                if (ReferenceEquals(strg.TempObjects[0].GetType(), ptOfPlane.GetType()))
                {
                    ptOfPlane.SetName(strg.TempObjects[0].GetName());
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return;
                }
                strg.TempObjects.Add(ptOfPlane);
                if ((_source = Point3D.Create(strg.TempObjects)) != null)
                {
                    _source.SetName(strg.TempObjects[0].GetName());
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    strg.TempObjects.RemoveAt(strg.TempObjects.Count - 1);
                }
            }
        }
    }
    /// <summary>
    /// Генерация 3D точки
    /// </summary>
    public class GeneratePoint3D : ICreate
    {
        private Point3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            new SelectPointOfPlane().Execute(pt, strg, can);
            if (strg.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(strg.SelectedObjects[0].GetType(), strg.SelectedObjects[1].GetType()))
                {
                    strg.SelectedObjects.Remove(strg.SelectedObjects[0]);
                    can.Update(strg);
                    return;
                }
                if ((_source = Point3D.Create(strg.SelectedObjects)) != null)
                {
                    strg.Objects.Remove(strg.SelectedObjects[0]);
                    strg.Objects.Remove(strg.SelectedObjects[1]);
                    _source.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.SelectedObjects.Clear();
                    can.Update(strg);
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    strg.SelectedObjects.RemoveAt(strg.SelectedObjects.Count - 1);
                    can.Update(strg);
                }
            }
            else
            {
                can.Update(strg);
            }
        }
    }

}
