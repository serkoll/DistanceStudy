using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;

namespace DrawG
{
    /// <summary>
    /// Обеспечивает доступ и управление отрисованными графическими объектами
    /// </summary>
    static class CollectionGraphicsObjects
    {
        /// <summary>
        /// Коллекция графическиъ объектов
        /// </summary>
        public static Collection<object> GraphicsObjectsCollection = new Collection<object>();
        /// <summary>
        /// Коллекция выбранных объектов
        /// </summary>
        public static Collection<object> GraphicsObjectsSelect = new Collection<object>();
        /// <summary>
        /// Коллекция скопированных объектов
        /// </summary>
        public static Collection<object> GraphicsObjectsCopy = new Collection<object>();
        public static Collection<object> GraphicsObjectsPaste = new Collection<object>();
        /// <summary>
        /// Коллекция объектов, подлежащих удалению
        /// </summary>
        public static Collection<object> GraphicsObjectsDelete = new Collection<object>();
        public static Collection<object> GraphicsObjectsSelectPointsOfPlane = new Collection<object>();
        /// <summary>
        /// Коллекция временных объектов
        /// </summary>
        public static Collection<object> GraphicsObjectsTempCollection = new Collection<object>();
        /// <summary>
        /// Очищает все коллекции
        /// </summary>
        public static void ClearAllCollections()
        {
            GraphicsObjectsCollection.Clear();
            GraphicsObjectsSelect.Clear();
            GraphicsObjectsCopy.Clear();
            GraphicsObjectsPaste.Clear();
            GraphicsObjectsDelete.Clear();
            GraphicsObjectsTempCollection.Clear();
        }
        /// <summary>
        /// Добавляет объект в коллекцию графическиъ объектов
        /// </summary>
        /// <param name="objectSource"></param>
        public static void AddToCollection(object objectSource)
        {
            GraphicsObjectsCollection.Add(objectSource);
        }
    }
}
