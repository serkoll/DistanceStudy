using System.Drawing;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Interfaces;

namespace GraphicsModule
{
    /// <summary>
    /// Выбор объекта и добавление в коллекцию выбранных объектов
    /// </summary>
    class SelectObject : IOperation
    {
        public void Execute(Point mousecoords, Blueprint blueprint)
        {
            foreach (var obj in blueprint.Storage.Objects)
            {
                if (obj.IsSelected(mousecoords, blueprint.CoordinateSystemCenterPoint, 5))
                {
                    blueprint.Storage.SelectedObjects.Add(obj);
                    blueprint.Update();
                    return;
                }
            }
        }
    }
    /// <summary>
    /// Выбор только проекции точки и добавление в коллекцию выбранных объектов
    /// </summary>
    class SelectPointOfPlane : IOperation
    {
        //TODO: исправить вызов
        public void Execute(Point mousecoords, Blueprint blueprint)
        {
            foreach (var obj in blueprint.Storage.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if(type.Length < 2) continue;
                if (obj.IsSelected(mousecoords, blueprint.CoordinateSystemCenterPoint, 5) && type[1] == typeof(IPointOfPlane))
                {
                    blueprint.Storage.SelectedObjects.Add(obj);
                    blueprint.Update();
                    return;
                }
            }
        }
    }
    /// <summary>
    /// Выбор только проекции линии и добавление в коллекцию выбранных объектов
    /// </summary>
    class SelectLineOfPlane : IOperation
    {
        public void Execute(Point mousecoords, Blueprint blueprint)
        {
            foreach (IObject obj in blueprint.Storage.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, blueprint.CoordinateSystemCenterPoint, 5) && type[1].Name == "ILineOfPlane")
                {
                    blueprint.Storage.SelectedObjects.Add(obj);
                    blueprint.Update();
                    return;
                }
            }
        }
    }
    class SelectSegmentOfPlane : IOperation
    {
        public void Execute(Point mousecoords, Blueprint blueprint)
        {
            foreach (var obj in blueprint.Storage.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, blueprint.CoordinateSystemCenterPoint, 5) && type[1].Name == "ISegmentOfPlane")
                {
                    blueprint.Storage.SelectedObjects.Add(obj);
                    blueprint.Update();
                    return;
                }
            }
        }
    }
    /// <summary>
    /// Удаление выбранных объектов
    /// </summary>
    class DeleteSelected
    {
        public void Execute(Blueprint blueprint)
        {
            foreach (IObject obj in blueprint.Storage.SelectedObjects)
            {
                blueprint.Storage.Objects.Remove(obj);
            }
            blueprint.Storage.SelectedObjects.Clear();
            blueprint.Update();
        }
    }
    /// <summary>
    /// Стереть
    /// </summary>
    class Erase : IOperation
    {
        public void Execute(Point mousecoords, Blueprint blueprint)
        {
            foreach (IObject obj in blueprint.Storage.Objects)
            {
                if (obj.IsSelected(mousecoords, blueprint.CoordinateSystemCenterPoint, 5))
                {
                    blueprint.Storage.Objects.Remove(obj);
                    blueprint.Update();
                    return;
                }
            }
        }
    }
    class Copy : IOperation
    {
        public void Execute(Point mousecoords, Blueprint blueprint)
        {
            foreach (IObject obj in blueprint.Storage.Objects)
            {
                if (obj.IsSelected(mousecoords, blueprint.CoordinateSystemCenterPoint, 5))
                {
                    blueprint.Storage.CopiedObjects.Add(obj);
                    blueprint.Update();
                    return;
                }
            }
        }
    }
}
