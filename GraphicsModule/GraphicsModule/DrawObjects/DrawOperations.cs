using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;

namespace GraphicsModule
{
    /// <summary>
    /// Класс инструментов управления отрисовкой графических объектов посредством работы с формой
    /// </summary>
    static class DrawOperations
    {
        public static GraphicsTools GraphicsTools_Var = new GraphicsTools(); //Инструменты работы с Graphics
        public static Grid GridDraw_Var = new Grid(); //Переменная для работы с классом инструментов расчета и отображения СЕТКИ
        public static Axis AxisDraw_Var = new Axis(); //Переменная для работы с классом инструментов расчета и отображения ОСЕЙ
        public static LinkLine LinkLine_Var = new LinkLine(); //Переменная для работы с классом инструментов расчета и отображения ЛИНИЙ СВЯЗИ

        public static object UserMouseClick = null; //Переменная фиксирующая положение курсора (постоянно обнуляется после завершения текущей операции) (задается при нажатии мыши)
        public static object UserMouseUp = null; //Переменная фиксирующая положение курсора (постоянно обнуляется после завершения текущей операции) (задается при отпуске клавиши мыши)

        public static Color Color_SelectPoint = Color.Red; //Цвет выбранной точки


        public static int MaxDistantionToObject = 5;//Переменные, которые будут отнесены в форму настроек по умолчанию

        /// <summary>
        /// Удалить все объекты
        /// </summary>
        /// <param name="pb1">Заданный PictureBox, в котором отрисованы графические объекты</param>
        /// <param name="pb2">PictureBox фона</param>
        public static void Objects_ClearAll(PictureBox pb1, PictureBox pb2)
        {
            DrawObjectsToPictureBox.ObjectGraphics_ClearAll(pb1, pb2); //Полная очистка Graphics, PictureBox и всех коллекций

        }
        /// <summary>
        /// Добавляет объект в место, указанное курсором
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        public static void Objects_DrawAndAdd(PictureBox PictureBox_Source)
        {
            DrawObjectsToPictureBox.AddToCollectionAndDraw(PictureBox_Source);
            UserMouseClick = null;
        }
        /// <summary>
        /// Выбирает графический объект с помощью указания курсором. При выборе объекта изменяет его цвет
        /// </summary>
        /// <param name="pictureboxSource">Заданный PictureBox, в котором отрисованы графические объекты</param>
        public static void SelectAndLightObjects(PictureBox pictureboxSource)
        {
            DrawObjectsToPictureBox.ObjectGraphicsSelectAndFire(MaxDistantionToObject, pictureboxSource);
        }
        /// <summary>
        /// Выбирает графический объект с помощью указания курсором. При выборе объекта изменяет его цвет.
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        public static void Objects_SelectAndFirePointOfPlane(PictureBox PictureBox_Source)
        {
            DrawObjectsToPictureBox.ObjectGraphics_SelectAndFirePointOfPlane(MaxDistantionToObject, PictureBox_Source);
        }
        /// <summary>
        /// Удаляет графические объекты, указанные курсором в заданном PictureBox
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        /// <param name="PictureBox_Back"></param>
        public static void Objects_SelectAndDelete(PictureBox PictureBox_Source, PictureBox PictureBox_Back)
        {
            DrawObjectsToPictureBox.ObjectGraphics_DeleteFromCollectionAndRedraw(MaxDistantionToObject, PictureBox_Source, PictureBox_Back);
            DrawOperations.UserMouseClick = null;
        }
        /// <summary>
        /// Удаляет заранее выбранные графические объекты, записанные в коллекцию ObjectsGraphics_Select.
        /// </summary>
        /// <param name="pictureboxSource">Заданный PictureBox, в котором отрисованы графические объекты</param>
        /// <param name="pictureboxBack"></param>
        public static void DeleteSelectedObjects(PictureBox pictureboxSource, PictureBox pictureboxBack)
        {
            DrawObjectsToPictureBox.DeleteObjectsFromCollectionAndRedraw(pictureboxSource, pictureboxBack);
        }
        /// <summary>
        /// Включает или выключает элементs фона
        /// </summary>
        /// <param name="PictureBox_Source"></param>
        public static void ReFresh_GraphicsBase(PictureBox PictureBox_Source)
        {
            DrawObjectsToPictureBox.BitmapBack = (Bitmap)DrawObjectsToPictureBox.BitmapActive.Clone();
            DrawObjectsToPictureBox.BitmapBack.MakeTransparent();
            DrawObjectsToGraphics.GraphicsBack_Add(GridDraw_Var.GridFlagDraw, false, ref DrawObjectsToPictureBox.GraphicsBack);
            DrawObjectsToPictureBox.BitmapActive = (Bitmap)DrawObjectsToPictureBox.BitmapBack.Clone();
            PictureBox_Source.Image = (Bitmap)DrawObjectsToPictureBox.BitmapActive.Clone();
            PictureBox_Source.Refresh();
        }
        /// <summary>
        /// Включает или выключает элементs фона
        /// </summary>
        /// <param name="ActiveObjectsCollection_Source"></param>
        /// <param name="PictureBox_Source"></param>
        public static void ReFresh_GraphicsBaseAndActiveObjects(Collection<object> ActiveObjectsCollection_Source, PictureBox PictureBox_Source)
        {
            if (ActiveObjectsCollection_Source.Count == 0)
            {
                ReFresh_GraphicsBase(PictureBox_Source);
            }
        }
    }
}
