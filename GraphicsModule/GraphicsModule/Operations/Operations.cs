﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Выбор объекта и добавление в коллекцию выбранных объектов
    /// </summary>
    class SelectObject : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.Objects)
            {
                if (obj.IsSelected(mousecoords, can.st.SelectedDrawS.RadiusPoints, can.Grid.Center, 5))
                {
                    strg.SelectedObjects.Add(obj);
                    can.ReDraw(strg);
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
        public void Execute(Point mousecoords, Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, can.st.SelectedDrawS.RadiusPoints, can.Grid.Center, 5) && (type[1].Name == "IPointOfPlane"))
                {
                    strg.SelectedObjects.Add(obj);
                    can.ReDraw(strg);
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
        public void Execute(Point mousecoords, Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, can.st.SelectedDrawS.RadiusPoints, can.Grid.Center, 5) && (type[1].Name == "ILineOfPlane"))
                {
                    strg.SelectedObjects.Add(obj);
                    can.ReDraw(strg);
                    return;
                }
            }
        }
    }
    class SelectSegmentOfPlane : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.Objects)
            {
                var type = obj.GetType().GetInterfaces();
                if (obj.IsSelected(mousecoords, can.st.SelectedDrawS.RadiusPoints, can.Grid.Center, 5) && (type[1].Name == "ISegmentOfPlane"))
                {
                    strg.SelectedObjects.Add(obj);
                    can.ReDraw(strg);
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
        public void Execute(Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.SelectedObjects)
            {
                strg.Objects.Remove(obj);
            }
            strg.SelectedObjects.Clear();
            can.ReDraw(strg);
        }
    }
    /// <summary>
    /// Стереть
    /// </summary>
    class Erase : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.Objects)
            {
                if (obj.IsSelected(mousecoords, can.st.SelectedDrawS.RadiusPoints, can.Grid.Center, 5))
                {
                    strg.Objects.Remove(obj);
                    can.ReDraw(strg);
                    return;
                }
            }
        }
    }
    class Copy : IOperation
    {
        public void Execute(Point mousecoords, Storage strg, Canvas can)
        {
            foreach (IObject obj in strg.Objects)
            {
                if (obj.IsSelected(mousecoords, can.st.SelectedDrawS.RadiusPoints, can.Grid.Center, 5))
                {
                    strg.CopiedObjects.Add(obj);
                    can.ReDraw(strg);
                    return;
                }
            }

        }
    }
}