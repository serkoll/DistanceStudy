using System.Collections.Generic;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry
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
        /// <param name="blueprint"></param>
        public void DrawObjects(Blueprint blueprint)
        {
            foreach(var ob in Objects)
            {
                ob.Draw(blueprint);
            }
            foreach (var ob in TempObjects)
            {
                ob.Draw(blueprint);
            }
            foreach (var ob in SelectedObjects)
            {
                ob.Draw(blueprint);
            }
            foreach (var ob in DeletedObjects)
            {
                ob.Draw(blueprint);
            }
        }

        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию объектов //TODO: починить рекурсивной ссылкой
        /// </summary>
        /// <param name="blueprint"></param>
        public void DrawLastAddedToObjects(Blueprint blueprint)
        {
            Objects.Last().Draw(blueprint);
        }

        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию временных объектов
        /// </summary>
        /// <param name="blueprint"></param>
        public void DrawLastAddedToTempObjects(Blueprint blueprint)
        {
            TempObjects.Last().Draw(blueprint);
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
        public IList<IObject> TempLinesOfPlane { get; }
    }
}
