﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule
{
    /// <summary>
    /// Обеспечивает доступ и управление отрисованными графическими объектами
    /// </summary>
    public class Storage
    {
        public Storage()
        {
            Objects = new Collection<IObject>();
            SelectedObjects = new Collection<IObject>();
            CopiedObjects = new Collection<IObject>();
            PastedObjects = new Collection<IObject>();
            DeletedObjects = new Collection<IObject>();
            TempObjects = new Collection<IObject>();
            TempLinesOfPlane = new Collection<IObject>();
        }
        /// <summary>
        /// Очищает все коллекции
        /// </summary>
        public void ClearAllCollections()
        {
            Objects.Clear();
            SelectedObjects.Clear();
            CopiedObjects.Clear();
            PastedObjects.Clear();
            DeletedObjects.Clear();
            TempObjects.Clear();
        }

        /// <summary>
        /// Добавляет объект в коллекцию графическиъ объектов
        /// </summary>
        /// <param name="source"></param>
        public void AddToCollection(IObject source)
        {
            if (source != null)
            {
                Objects.Add(source);
            }
        }
        /// <summary>
        /// Отрисовывает все коллекции объектов
        /// </summary>
        /// <param name="st">Настройки</param>
        /// <param name="frameCenter">Центр системы координат</param>
        /// <param name="g">Целевой Graphics</param>
        public void DrawObjects(Settings st, Point frameCenter, Graphics g)
        {
            foreach(var ob in Objects)
            {
                ob.Draw(st.DrawSettings, frameCenter, g);
            }
            foreach (var ob in TempObjects)
            {
                ob.Draw(st.DrawSettings, frameCenter, g);
            }
            foreach (var ob in SelectedObjects)
            {
                ob.Draw(st.SelectedDrawSettings, frameCenter, g);
            }
            foreach (var ob in DeletedObjects)
            {
                ob.Draw(st.SelectedDrawSettings, frameCenter, g);
            }
        }
        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию объектов
        /// </summary>
        /// <param name="st"></param>
        /// <param name="frameCenter"></param>
        /// <param name="g"></param>
        public void DrawLastAddedToObjects(DrawSettings st, Point frameCenter, Graphics g)
        {
            Objects.Last().Draw(st, frameCenter, g);
        }
        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию временных объектов
        /// </summary>
        /// <param name="st"></param>
        /// <param name="frameCenter"></param>
        /// <param name="g"></param>
        public void DrawLastAddedToTempObjects(DrawSettings st, Point frameCenter, Graphics g)
        {
            TempObjects.Last().Draw(st, frameCenter, g);
        }

        public void ClearTempCollections()
        {
            TempObjects.Clear();
            TempLinesOfPlane.Clear();
        }
        public Collection<IObject> Objects { get; set; }
        public Collection<IObject> SelectedObjects { get; set; }
        public Collection<IObject> CopiedObjects { get; set; }
        public Collection<IObject> PastedObjects { get; set; }
        public Collection<IObject> DeletedObjects { get; set; }
        public Collection<IObject> TempObjects { get; set; }
        public IList<IPointOfPlane> TempPointsOfPlane { get; }
        public Collection<IObject> TempLinesOfPlane { get; set; }
    }
}
