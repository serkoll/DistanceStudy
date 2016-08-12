using System.Windows.Forms;
using System.Drawing;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Содержит методы отрисовки графических объектов в PictureBox с помощью инструментов класса ObjectsDrawToGraphics
    /// </summary>
    class DrawObjectsToPictureBox
    {
        public static DrawExternalObjects OutObjects_Var = new DrawExternalObjects(); //Инструменты отрисовки внешних графических объектов

        public static Graphics GraphicsBack; //Поверхность рисования, содержащая графические объекты фона (сетки, осей и т.д.)
        public static Bitmap BitmapBack; //Bitmap объектов фона
        public static Image ImageBack; //Картинка поверхности рисования с объектами фона
        public static Color BackColor; //Цвет фона поверхности рисования

        public static Graphics GraphicsActive; //Поверхность рисования активных объектов
        public static Bitmap BitmapActive; //Bitmap активных объектов

        public static int pictureBoxWidth;
        public static int pictureBoxHeight;

        public ColorMode Mode_Color = ColorMode.None; //Перечеслитель режимов изменения цвета при работе с графическими объектами

        public enum ColorMode
        {
            None,
            ObjectColor
        }

        public static Tools_DrawObjects Tool_DrawObject = Tools_DrawObjects.None;
        public enum Tools_DrawObjects
        {
            None,
            SetPoint,
            SetLine,
            SetPointInLine,
            SetSpline,

            //Добавление (отрисовка) 3D графических объектов 
            SetPoint3D, //Точка 3D
            SetPoint3DByPointOfPlan, //Точка 3D
            SetProectionPoint3D, //Одна проекция 3D точки
            SetPointPlan1X0Y, //Горизонтальная проекция 3D точки
            SetPointPlan2X0Z, //Фронтальная проекция 3D точки
            SetPointPlan3Y0Z, //Профильная проекция 3D точки
            SetProectionLine3D, //Одна проекция 3D отрезка
            SetLine3D, //Отрезок 3D
            SetLinePlan1X0Y,
            SetLinePlan2X0Z,
            SetLinePlan3Y0Z,
            SetPointInLine3D, //Точка 3D на отрезке 3D?
            SetSpline3D, //'Сплайн 3D

            //----- Выбор графических объектов -----
            SelectObject,
            SelectPointOfPlan,


            //----- Выделение графических объектов -----
            CopyPoint,
            CopyLine,
            CopyPointInLine,
            CopytSpline,

            //----- Вставка графических объектов -----
            PastePoint,
            PasteLine,
            PastePointInLine,
            PastetSpline,

            //----- Удаление графических объектов -----
            DeleteSelectObjects, //Стереть выбранные объект
            DeleteObjects, //Стереть объект

            DeletePoint,
            DeleteLine,
            DeletePointInLine,
            DeleteSpline,

            //----- Поворот графических объектов -----
            Rotate,

            //----- Перемещение графических объектов -----
            Move,

            //----- Поиск графических объектов -----
            Finding,

            //----- Подсветка графических объектов -----
            //ObjectColor

            //----- Очищение всех графических объектов -----
            Cleen,
            GetCleenColor
        }
        /// <summary>
        /// Добавляет точку, указанный курсором на PictureBox, в коллекцию графических объектов с перерисовкой всех объектов, находящихся в коллекции
        /// </summary>
        /// <param name="pictureBoxSource">Заданный PictureBox, в котором отрисовываются объекты Graphics</param>
        public static void AddToCollectionAndDraw(PictureBox pictureBoxSource)
        {
            Point PointVar = new Point();

            if (Tool_DrawObject == Tools_DrawObjects.SetPoint)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                CollectionsGraphicsObjects.AddToCollection(PointVar);
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetPoint3D)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                PropertyPoint3D.Create_Point3DByDrawProection(PointVar, DrawOperations.GridDraw_Var.GridCenter);
                if (PropertyPoint3D.FlagPoint3D_CreateStop)
                {
                    CollectionsGraphicsObjects.AddToCollection(PropertyPoint3D.Point3D_Var);
                    PropertyPoint3D.Point3D_Var = null;
                }
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetPointPlan1X0Y)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                PropertyPoint3D.PointToPointOfPlan1_X0Y(PointVar, DrawOperations.GridDraw_Var.GridCenter);
                CollectionsGraphicsObjects.AddToCollection(PropertyPoint3D.PointOfPlan1_X0Y_Var);
                PropertyPoint3D.PointOfPlan1_X0Y_Var = null;
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetPointPlan2X0Z)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                PropertyPoint3D.PointToPointOfPlan2_X0Z(PointVar, DrawOperations.GridDraw_Var.GridCenter);
                CollectionsGraphicsObjects.AddToCollection(PropertyPoint3D.PointOfPlan2_X0Z_Var);
                PropertyPoint3D.PointOfPlan2_X0Z_Var = null;
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetPointPlan3Y0Z)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                PropertyPoint3D.PointToPointOfPlan3_Y0Z(PointVar, DrawOperations.GridDraw_Var.GridCenter);
                CollectionsGraphicsObjects.AddToCollection(PropertyPoint3D.PointOfPlan3_Y0Z_Var);
                PropertyPoint3D.PointOfPlan3_Y0Z_Var = null;
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetProectionPoint3D)
            {
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetLine)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                PropertyLine2D.CreateLine2D(PointVar);
                PropertyLine2D.DrawTempPoint(PointVar, ref GraphicsActive);
                if (PropertyLine2D.LineStopCreate)
                {
                    CollectionsGraphicsObjects.AddToCollection(PropertyLine2D.Line2DVar);
                    PropertyLine2D.Line2DVar = null;
                    PropertyLine2D.LineStopCreate = false;
                }
            }

            else if (Tool_DrawObject == Tools_DrawObjects.SetLine3D)
            {
                PointVar = (Point)DrawOperations.UserMouseClick;
                PropertyLine3D.CreateLine3DByDrawProjection(PointVar, DrawOperations.GridDraw_Var.GridCenter);
                if (PropertyLine3D.FlagLine3DCreateStop)
                {
                    CollectionsGraphicsObjects.AddToCollection(PropertyLine3D.Line3D);
                    PropertyLine3D.Line3D = null;
                }
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetLinePlan1X0Y)
            {
                var point = PropertyPoint3D.PointToPointOfPlan1X0Y((Point)DrawOperations.UserMouseClick, DrawOperations.GridDraw_Var.GridCenter);
                CollectionsGraphicsObjects.AddToTempCollection(point);
                if (CollectionsGraphicsObjects.GraphicsObjectsTempCollection.Count == 1)
                {
                    PropertyLineProjections.DrawTempPointProjection((PointOfPlan1X0Y)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[0], GraphicsActive);
                }
                if (CollectionsGraphicsObjects.GraphicsObjectsTempCollection.Count == 2)
                {
                    CollectionsGraphicsObjects.AddToCollection(new LineOfPlan1X0Y((PointOfPlan1X0Y)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[0],
                                                                                 (PointOfPlan1X0Y)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[1]));
                    CollectionsGraphicsObjects.ClearTempCollection();
                }
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetLinePlan2X0Z)
            {
                var point = PropertyPoint3D.PointToPointOfPlan2X0Z((Point)DrawOperations.UserMouseClick, DrawOperations.GridDraw_Var.GridCenter);
                CollectionsGraphicsObjects.AddToTempCollection(point);
                if (CollectionsGraphicsObjects.GraphicsObjectsTempCollection.Count == 1)
                {
                    PropertyLineProjections.DrawTempPointProjection((PointOfPlan2X0Z)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[0], GraphicsActive);
                }
                if (CollectionsGraphicsObjects.GraphicsObjectsTempCollection.Count == 2)
                {
                    CollectionsGraphicsObjects.AddToCollection(new LineOfPlan2X0Z((PointOfPlan2X0Z)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[0],
                                                                                 (PointOfPlan2X0Z)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[1]));
                    CollectionsGraphicsObjects.ClearTempCollection();
                }
            }
            else if (Tool_DrawObject == Tools_DrawObjects.SetLinePlan3Y0Z)
            {
                var point = PropertyPoint3D.PointToPointOfPlan3Y0Z((Point)DrawOperations.UserMouseClick, DrawOperations.GridDraw_Var.GridCenter);
                CollectionsGraphicsObjects.AddToTempCollection(point);
                if (CollectionsGraphicsObjects.GraphicsObjectsTempCollection.Count == 1)
                {
                    PropertyLineProjections.DrawTempPointProjection((PointOfPlan3Y0Z)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[0], GraphicsActive);
                }
                if (CollectionsGraphicsObjects.GraphicsObjectsTempCollection.Count == 2)
                {
                    CollectionsGraphicsObjects.AddToCollection(new LineOfPlan3Y0Z((PointOfPlan3Y0Z)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[0],
                                                                                 (PointOfPlan3Y0Z)CollectionsGraphicsObjects.GraphicsObjectsTempCollection[1]));
                    CollectionsGraphicsObjects.ClearTempCollection();
                }
            }
            DrawObjectsToGraphics.ObjectCollectionToGraphics_Add(CollectionsGraphicsObjects.GraphicsObjectsCollection.Count, PropertyPoint.Color_Point, CollectionsGraphicsObjects.GraphicsObjectsCollection, ref GraphicsActive);
            pictureBoxSource.Image = (Image)BitmapActive.Clone();
            pictureBoxSource.Refresh();
        }
        /// <summary>
        /// Выбирает графический объект с помощью указания курсором и меняет его цвет
        /// </summary>
        /// <param name="MaxDistanceToObject">Расстояние от курсора до объекта, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        public static void ObjectGraphicsSelectAndFire(double MaxDistanceToObject, PictureBox PictureBox_Source)
        {
            CollectionGraphicsObjectsTools.SelectObjectToCollection((Point)DrawOperations.UserMouseClick, MaxDistanceToObject);
            if (CollectionsGraphicsObjects.GraphicsObjectsSelect.Count == 0)
            {
                return;
            }
            DrawObjectsToGraphics.HighlightObjectByCursor(CollectionsGraphicsObjects.GraphicsObjectsSelect[CollectionsGraphicsObjects.GraphicsObjectsSelect.Count - 1], DrawOperations.Color_SelectPoint, PictureBox_Source.PointToClient(Control.MousePosition), MaxDistanceToObject, GraphicsActive);
            PictureBox_Source.Image = (Image)BitmapActive.Clone();
            PictureBox_Source.Refresh();
        }
        /// <summary>
        /// Выбирает проекции точки с помощью указания курсором. При выборе проекции точки изменяет ее цвет.
        /// </summary>
        /// <param name="Distance_CursorToPointOfPlane">Расстояние от курсора до проекции точки, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы проекции точки</param>
        public static void ObjectGraphics_SelectAndFirePointOfPlane(double Distance_CursorToPointOfPlane, PictureBox PictureBox_Source)
        {
            CollectionGraphicsObjectsTools.ObjectG_SelectToCollectionPointOfPlane((Point)DrawOperations.UserMouseClick, Distance_CursorToPointOfPlane);
            if (CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count == 0)
            {
                return;
            }
            DrawObjectsToGraphics.HighlightObjectByCursor(CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count - 1], DrawOperations.Color_SelectPoint, PictureBox_Source.PointToClient(Control.MousePosition), Distance_CursorToPointOfPlane, GraphicsActive);
            PictureBox_Source.Image = (Image)BitmapActive.Clone();
            PictureBox_Source.Refresh();
        }
        /// <summary>
        /// Удалить все объекты
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        /// <param name="PictureBox_Back"></param>
        public static void ObjectGraphics_ClearAll(PictureBox PictureBox_Source, PictureBox PictureBox_Back)
        {
            CollectionsGraphicsObjects.ClearAllCollections();
            PropertyPoint3D.PointOfPlan1_X0Y_Var = null;
            PropertyPoint3D.PointOfPlan2_X0Z_Var = null;
            PropertyPoint3D.PointOfPlan3_Y0Z_Var = null;
            Tool_DrawObject = Tools_DrawObjects.None;
            BitmapActive = (Bitmap)BitmapBack.Clone();
            GraphicsActive = Graphics.FromImage(BitmapActive);
            PictureBox_Source.Image = (Image)BitmapActive.Clone();
            PictureBox_Source.Refresh();
            PictureBox_Back.Image = (Image)BitmapBack.Clone();
            PictureBox_Back.Refresh();
        }
        /// <summary>
        /// Удаляет (стирает) примитив из коллекции, перерисовывает Graphics, а Graphics в заданном PictureBox
        /// </summary>
        /// <param name="Distance_CursorToObject">Расстояние от курсора до объекта, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисовываются объекты Graphics</param>
        /// <param name="PictureBox_Back"></param>
        public static void ObjectGraphics_DeleteFromCollectionAndRedraw(double Distance_CursorToObject, PictureBox PictureBox_Source, PictureBox PictureBox_Back)
        {
            Point CursorPoint_Var = (Point)DrawOperations.UserMouseClick;
            CollectionGraphicsObjectsTools.SelectObjectToCollection(CursorPoint_Var, Distance_CursorToObject);
            CollectionGraphicsObjectsTools.DeleteObjectsFromCollection(CollectionsGraphicsObjects.GraphicsObjectsSelect, CollectionsGraphicsObjects.GraphicsObjectsDelete, CollectionsGraphicsObjects.GraphicsObjectsCollection);
            DrawObjectsToGraphics.ReFreshCollection(CollectionsGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, ref BitmapActive, ref BitmapBack, ref GraphicsActive);
            if (DrawOperations.LinkLine_Var.ShowLinkLine_XYZ_Flag)
            {
                DrawOperations.LinkLine_Var.LinkLineToGrpahics_Add(GraphicsActive);
            }
            PictureBox_Source.Image = (Image)BitmapActive.Clone();
            PictureBox_Source.Refresh();
            PictureBox_Back.Image = (Image)BitmapBack.Clone();
            PictureBox_Back.Refresh();
        }
        /// <summary>
        /// Удаляет заранее выбранные графические объекты, записанные в коллекцию ObjectsGraphics_Select.
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        /// <param name="PictureBox_Back"></param>
        public static void DeleteObjectsFromCollectionAndRedraw(PictureBox PictureBox_Source, PictureBox PictureBox_Back)
        {
            if ((CollectionsGraphicsObjects.GraphicsObjectsSelect.Count == 0) || (CollectionsGraphicsObjects.GraphicsObjectsCollection.Count == 0))
            {
                return;
            }
            CollectionGraphicsObjectsTools.DeleteObjectsFromCollection(CollectionsGraphicsObjects.GraphicsObjectsSelect, CollectionsGraphicsObjects.GraphicsObjectsDelete, CollectionsGraphicsObjects.GraphicsObjectsCollection);
            DrawObjectsToGraphics.ReFreshCollection(CollectionsGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, ref BitmapActive, ref BitmapBack, ref GraphicsActive);
            if (DrawOperations.LinkLine_Var.ShowLinkLine_XYZ_Flag)
            {
                DrawOperations.LinkLine_Var.LinkLineToGrpahics_Add(GraphicsActive);
            }
            PictureBox_Source.Image = (Image)BitmapActive.Clone();
            PictureBox_Source.Refresh();
            PictureBox_Back.Image = (Image)BitmapBack.Clone();
            PictureBox_Back.Refresh();
        }
        /// <summary>
        /// Создает фона с объектами фона на картинке заданного PictureBox
        /// </summary>
        /// <param name="pb1">Заданный PictureBox, в котором отрисовываются графические объекты</param>
        /// <param name="pb2"></param>
        public static void GraphicsBack_Create(PictureBox pb1, PictureBox pb2)
        {
            DrawObjectsToGraphics.GraphicsBack_Create(DrawOperations.GridDraw_Var.GridFlagDraw, DrawOperations.AxisDraw_Var.showAxisXYZ, ref GraphicsBack);
            DrawObjectsToGraphics.GraphicsBack_Create(DrawOperations.GridDraw_Var.GridFlagDraw, DrawOperations.AxisDraw_Var.showAxisXYZ, ref GraphicsActive);
            pb1.Image = (Image)BitmapActive.Clone();
            pb1.Refresh();
            pb2.Image = (Image)BitmapBack.Clone();
            pb2.Refresh();
        }
        /// <summary>
        /// Добавляет объекты фона на картинку заданного PictureBox
        /// </summary>
        /// <param name="pb1">Заданный PictureBox, в котором отрисовываются графические объекты</param>
        /// <param name="pb2"></param>
        public static void GraphicsBack_Add(PictureBox pb1, PictureBox pb2)
        {
            DrawObjectsToGraphics.GraphicsBack_Add(DrawOperations.GridDraw_Var.GridFlagDraw, DrawOperations.AxisDraw_Var.showAxisXYZ, ref GraphicsActive, ref GraphicsBack);
            pb1.Image = (Image)BitmapActive.Clone();
            pb1.Refresh();
            pb2.Image = (Image)BitmapBack.Clone();
            pb2.Refresh();
        }
        /// <summary>
        /// Удаляет объекты фона из картинки заданного PictureBox
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисовываются графические объекты</param>
        /// <param name="PictureBox_Back"></param>
        public static void GraphicsBack_Clear(PictureBox PictureBox_Source, PictureBox PictureBox_Back)
        {
            DrawObjectsToGraphics.GraphicsBack_Clear(DrawOperations.GridDraw_Var.GridFlagDraw, DrawOperations.AxisDraw_Var.showAxisXYZ, ref GraphicsBack);
            BitmapActive = (Bitmap)BitmapBack.Clone();
            GraphicsActive = Graphics.FromImage(BitmapActive);
            if (CollectionsGraphicsObjects.GraphicsObjectsCollection.Count == 0) { } else DrawObjectsToGraphics.ReFreshCollection(CollectionsGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, GraphicsActive);
            if (CollectionsGraphicsObjects.GraphicsObjectsSelect.Count == 0) { } else DrawObjectsToGraphics.ReFreshCollection(CollectionsGraphicsObjects.GraphicsObjectsSelect, DrawOperations.Color_SelectPoint, GraphicsActive);
            if (DrawOperations.LinkLine_Var.ShowLinkLine_XYZ_Flag)
            {
                DrawOperations.LinkLine_Var.LinkLineToGrpahics_Add(GraphicsActive);
            }
            PictureBox_Source.Image = (Bitmap)BitmapActive.Clone();
            PictureBox_Source.Refresh();
            PictureBox_Back.Image = (Bitmap)BitmapBack.Clone();
            PictureBox_Back.Refresh();
        }
    }
}
