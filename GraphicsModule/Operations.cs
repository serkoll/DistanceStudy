using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Interfaces;

namespace GraphicsModule
{
    /// <summary>
    /// Выбор объекта и добавление в коллекцию выбранных объектов
    /// </summary>
    class SelectObject : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Drawing can)
        {
            foreach (var obj in strg.Objects)
            {
                if (obj.IsSelected(mousecoords, can.Settings.SelectedDrawSettings.RadiusPoints, can.CenterSystemPoint, 5))
                {
                    strg.SelectedObjects.Add(obj);
                    can.Update(strg);
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
        public void Execute(Point mousecoords, Storage strg, Drawing can)
        {
            foreach (var obj in strg.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if(type.Length < 2) continue;
                if (obj.IsSelected(mousecoords, can.Settings.SelectedDrawSettings.RadiusPoints, can.CenterSystemPoint, 5) && type[1] == typeof(IPointOfPlane))
                {
                    strg.SelectedObjects.Add(obj);
                    can.Update(strg);
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
        public void Execute(Point mousecoords, Storage strg, Drawing can)
        {
            foreach (IObject obj in strg.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, can.Settings.SelectedDrawSettings.RadiusPoints, can.CenterSystemPoint, 5) && type[1].Name == "ILineOfPlane")
                {
                    strg.SelectedObjects.Add(obj);
                    can.Update(strg);
                    return;
                }
            }
        }
    }
    class SelectSegmentOfPlane : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Drawing can)
        {
            foreach (IObject obj in strg.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, can.Settings.SelectedDrawSettings.RadiusPoints, can.CenterSystemPoint, 5) && type[1].Name == "ISegmentOfPlane")
                {
                    strg.SelectedObjects.Add(obj);
                    can.Update(strg);
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
        public void Execute(Storage strg, Drawing can)
        {
            foreach (IObject obj in strg.SelectedObjects)
            {
                strg.Objects.Remove(obj);
            }
            strg.SelectedObjects.Clear();
            can.Update(strg);
        }
    }
    /// <summary>
    /// Стереть
    /// </summary>
    class Erase : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Drawing can)
        {
            foreach (IObject obj in strg.Objects)
            {
                if (obj.IsSelected(mousecoords, can.Settings.SelectedDrawSettings.RadiusPoints, can.CenterSystemPoint, 5))
                {
                    strg.Objects.Remove(obj);
                    can.Update(strg);
                    return;
                }
            }
        }
    }
    class Copy : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Drawing can)
        {
            foreach (IObject obj in strg.Objects)
            {
                if (obj.IsSelected(mousecoords, can.Settings.SelectedDrawSettings.RadiusPoints, can.CenterSystemPoint, 5))
                {
                    strg.CopiedObjects.Add(obj);
                    can.Update(strg);
                    return;
                }
            }
        }
    }
}
