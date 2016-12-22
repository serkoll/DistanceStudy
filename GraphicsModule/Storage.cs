using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Settings;

namespace GraphicsModule
{
    /// <summary>
    /// Обеспечивает доступ и управление отрисованными графическими объектами
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Коллекция графическиъ объектов
        /// </summary>
        public Collection<IObject> Objects { get; set; }
        /// <summary>
        /// Коллекция выбранных объектов
        /// </summary>
        public Collection<IObject> SelectedObjects { get; set; }
        /// <summary>
        /// Коллекция скопированных объектов
        /// </summary>
        public Collection<IObject> CopiedObjects { get; set; }
        /// <summary>
        /// Коллекция вставленных объектов
        /// </summary>
        public Collection<IObject> PastedObjects { get; set; }
        /// <summary>
        /// Коллекция объектов, подлежащих удалению
        /// </summary>
        public Collection<IObject> DeletedObjects { get; set; }
        /// <summary>
        /// Коллекция временных объектов
        /// </summary>
        public Collection<IObject> TempObjects { get; set; }
        public Storage()
        {
            Objects = new Collection<IObject>();
            SelectedObjects = new Collection<IObject>();
            CopiedObjects = new Collection<IObject>();
            PastedObjects = new Collection<IObject>();
            DeletedObjects = new Collection<IObject>();
            TempObjects = new Collection<IObject>();
        }

        public Storage(Collection<IObject> objects)
        {
            Objects = new Collection<IObject>(objects);
            SelectedObjects = new Collection<IObject>();
            CopiedObjects = new Collection<IObject>();
            PastedObjects = new Collection<IObject>();
            DeletedObjects = new Collection<IObject>();
            TempObjects = new Collection<IObject>();
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
        public void DrawObjects(Settings.Settings st, Point frameCenter, Graphics g)
        {
            foreach(IObject ob in Objects)
            {
                ob.Draw(st.DrawS, frameCenter, g);
            }
            foreach (IObject ob in TempObjects)
            {
                ob.Draw(st.DrawS, frameCenter, g);
            }
            foreach (IObject ob in SelectedObjects)
            {
                ob.Draw(st.SelectedDrawS, frameCenter, g);
            }
            foreach (IObject ob in DeletedObjects)
            {
                ob.Draw(st.SelectedDrawS, frameCenter, g);
            }
        }
        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию объектов
        /// </summary>
        /// <param name="st"></param>
        /// <param name="frameCenter"></param>
        /// <param name="g"></param>
        public void DrawLastAddedToObjects(DrawS st, Point frameCenter, Graphics g)
        {
            Objects[Objects.Count - 1].Draw(st, frameCenter, g);
        }
        /// <summary>
        /// Отрисовывает последний добавленный объект в коллекцию временных объектов
        /// </summary>
        /// <param name="st"></param>
        /// <param name="frameCenter"></param>
        /// <param name="g"></param>
        public void DrawLastAddedToTempObjects(DrawS st, Point frameCenter, Graphics g)
        {
            TempObjects[TempObjects.Count - 1].Draw(st, frameCenter, g);
        }
    }
}
