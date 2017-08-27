using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsModule.Geometry.Interfaces;

namespace GraphicsModule.Geometry
{
    public class Storage
    {
        private Blueprint _blueprint;

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

        public Storage(Blueprint blueprint)
        {
            Blueprint = blueprint;
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
        public void DrawObjects()
        {
            foreach(var ob in Objects)
            {
                ob.Draw(Blueprint);
            }
            foreach (var ob in TempObjects)
            {
                ob.Draw(Blueprint);
            }
            foreach (var ob in SelectedObjects)
            {
                ob.Draw(Blueprint);
            }
            foreach (var ob in DeletedObjects)
            {
                ob.Draw(Blueprint);
            }
        }

        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию объектов //TODO: починить рекурсивной ссылкой
        /// </summary>
        public void DrawLastAddedToObjects()
        {
            Objects.Last().Draw(Blueprint);
        }

        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию временных объектов
        /// </summary>
        public void DrawLastAddedToTempObjects()
        {
            TempObjects.Last().Draw(Blueprint);
        }

        public void ClearTempCollections()
        {
            TempObjects.Clear();
            TempLinesOfPlane.Clear();
        }

        public Blueprint Blueprint
        {
            get
            {
                return _blueprint;
            }
            set
            {
                if (_blueprint != null)
                {
                    var msg = "Для указанного хранилища объектов чертеж уже задан";
                    throw new ArgumentException(msg, nameof(Blueprint));
                }
                _blueprint = value;
            }
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
