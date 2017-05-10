using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule
{
    public class Storage
    {
        public Storage()
        {
            Objects = new List<IObject>();
            SelectedObjects = new List<IObject>();
            CopiedObjects = new List<IObject>();
            PastedObjects = new List<IObject>();
            DeletedObjects = new List<IObject>();
            TempObjects = new List<IObject>();
            TempLinesOfPlane = new List<IObject>();
        }
        public Storage(IList<IObject> objects)
        {
            Objects = objects;
            SelectedObjects = new List<IObject>();
            CopiedObjects = new List<IObject>();
            PastedObjects = new List<IObject>();
            DeletedObjects = new List<IObject>();
            TempObjects = new List<IObject>();
            TempLinesOfPlane = new List<IObject>();
        }
        public void ClearAllCollections()
        {
            Objects.Clear();
            SelectedObjects.Clear();
            CopiedObjects.Clear();
            PastedObjects.Clear();
            DeletedObjects.Clear();
            TempObjects.Clear();
        }
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
        public IList<IObject> Objects { get; }
        public IList<IObject> SelectedObjects { get; }
        public IList<IObject> CopiedObjects { get; }
        public IList<IObject> PastedObjects { get; }
        public IList<IObject> DeletedObjects { get; }
        public IList<IObject> TempObjects { get; }
        public IList<IPointOfPlane> TempPointsOfPlane { get; }
        public IList<IObject> TempLinesOfPlane { get; }
    }
}
