using System;
using GeometryObjects;
using System.Drawing;
using System.Collections.ObjectModel;


namespace GraphicsModule
{
    /// <summary>
    /// Класс инструментов для отрисовки графических объектов с помощью Graphics
    /// </summary>
    class DrawObjectsToGraphics
    {
        public static Point2D Point2D_Var = new Point2D(); //Экземпляр 2D точки
        public static Point3D Point3D_Var = new Point3D(); //Экземпляр 3D точки
        public static PointDraw Point3D_Draw_Var = new PointDraw(); //Экземпляр 3D точки для отрисовки в Graphics
        public static LineDraw LineDraw3D = new LineDraw();
        public static Color BackColor { get; set; }
        /// <summary>
        /// Добавляет объекты фона на заданную поверхность фона
        /// </summary>
        /// <param name="GridFlag">Метка включения сетки</param>
        /// <param name="AxisFlag">Метка включения осей</param>
        /// <param name="Grahpics_Source">Заданная поверхность рисования для создания подложки (фона)</param>
        /// <remarks>Очищает заданную поверхность фона GraphicsBack_Source</remarks>
        public static void GraphicsBack_Create(bool GridFlag, bool AxisFlag, ref Graphics Grahpics_Source)
        {
            GraphicsBack_Clear(Grahpics_Source);
            if (GridFlag)
            {
                DrawOperations.GridDraw_Var.CreateGridToGraphics(Grahpics_Source);
            }
            if (AxisFlag)
            {
                DrawOperations.AxisDraw_Var.AxisCalculationByGrid(DrawOperations.GridDraw_Var.GridKnots);
                DrawOperations.AxisDraw_Var.AddAxisToGraphics(DrawOperations.GridDraw_Var.GridCenter, Grahpics_Source);
            }
        }
        /// <summary>
        /// Добавляет объекты фона на заданную поверхность фона
        /// </summary>
        /// <param name="Grid_FlagDraw">Метка включения сетки</param>
        /// <param name="Axis_FlagDraw">Метка включения осей</param>
        /// <param name="Grahpics_Source">Заданная поверхность рисования для создания подложки (фона)</param>
        public static void GraphicsBack_Add(bool Grid_FlagDraw, bool Axis_FlagDraw, ref Graphics Grahpics_Source)
        {
            if (Grid_FlagDraw)
            {
                DrawOperations.GridDraw_Var.CreateGridToGraphics(Grahpics_Source);
            }
            if (Axis_FlagDraw)
            {
                DrawOperations.AxisDraw_Var.AxisCalculationByGrid(DrawOperations.GridDraw_Var.GridKnots);
                DrawOperations.AxisDraw_Var.AddAxisToGraphics(DrawOperations.GridDraw_Var.GridCenter, Grahpics_Source);
            }
        }
        /// <summary>
        /// Добавляет объекты фона на заданную поверхность фона на основе картинки активных объектов (Добавляет объекты фона к картинке отрисованных активных объектов)
        /// </summary>
        /// <param name="Grid_FlagDraw">Метка включения сетки</param>
        /// <param name="Axis_FlagDraw">Метка включения осей</param>
        /// <param name="GraphicsActive_Source">Поверхность рисования активных объектов, отрисованных с или без объектов фона</param>
        /// <param name="GraphicsBack_Source">Заданная поверхность рисования для создания подложки (фона)</param>
        /// <remarks>Создает картинку фона без активных объектов</remarks>
        public static void GraphicsBack_Add(bool Grid_FlagDraw, bool Axis_FlagDraw, ref Graphics GraphicsActive_Source, ref Graphics GraphicsBack_Source)
        {
            if (Grid_FlagDraw)
            {
                DrawOperations.GridDraw_Var.CreateGridToGraphics(GraphicsBack_Source);
                DrawOperations.GridDraw_Var.CreateGridToGraphics(GraphicsActive_Source);
            }
            if (Axis_FlagDraw)
            {
                DrawOperations.AxisDraw_Var.AxisCalculationByGrid(DrawOperations.GridDraw_Var.GridKnots);
                DrawOperations.AxisDraw_Var.AddAxisToGraphics(DrawOperations.GridDraw_Var.GridCenter, GraphicsBack_Source);
                DrawOperations.AxisDraw_Var.AddAxisToGraphics(DrawOperations.GridDraw_Var.GridCenter, GraphicsActive_Source);
            }
        }
        /// <summary>
        /// Очищает полностью заданный GraphicsBase от всех объектов
        /// </summary>
        /// <param name="g">Заданный GraphicsBase</param>
        /// <remarks>При очищении задает исходный фон поверхности рисования.</remarks>
        public static void GraphicsBack_Clear(Graphics g)
        {
            g.Clear(BackColor);
        }
        /// <summary>
        /// Удаляет объекты фона и перерисовывает активные объекты
        /// </summary>
        /// <param name="Grid_FlagDraw">Метка включения сетки</param>
        /// <param name="Axis_FlagDraw">Метка включения осей</param>
        /// <param name="GraphicsBack_Source">Заданная поверхность рисования для создания подложки (фона)</param>
        public static void GraphicsBack_Clear(bool Grid_FlagDraw, bool Axis_FlagDraw, ref Graphics GraphicsBack_Source)
        {
            GraphicsBack_Clear(GraphicsBack_Source);
            if (Grid_FlagDraw)
            {
                DrawOperations.GridDraw_Var.CreateGridToGraphics(GraphicsBack_Source);
            }
            if (Axis_FlagDraw)
            {
                DrawOperations.AxisDraw_Var.AxisCalculationByGrid(DrawOperations.GridDraw_Var.GridKnots);
                DrawOperations.AxisDraw_Var.AddAxisToGraphics(DrawOperations.GridDraw_Var.GridCenter, GraphicsBack_Source);
            }
        }
        /// <summary>
        /// Отрисовывает все типы объектов коллекции примитивов в Graphics, а Graphics в заданном PictureBox без очистки фона
        /// </summary>
        /// <param name="GraphicObjcet_Number">Заданная коллекция графических объектов</param>
        /// <param name="Point_Color"></param>
        /// <param name="CollectionOfGraphicObjcets_Source"></param>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        /// <remarks>Отрисовываются объекты коллекции ObjectsGraphics_Collection, заданной по умолчанию</remarks>
        public static void ObjectCollectionToGraphics_Add(int GraphicObjcet_Number, Color Point_Color, Collection<object> CollectionOfGraphicObjcets_Source, ref Graphics Graphics_Source)
        {
            if (CollectionOfGraphicObjcets_Source.Count == 0) return;
            if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "Point")
            {
                var PointTemp = (Point)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawPoint2D(PointTemp.X, PointTemp.Y, Point_Color, PropertyPoint.Diametre_Point, Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "Point3D")
            {
                var temp = (Point3D)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawPoint3DToXYXZYZ(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "PointOfPlan1X0Y")
            {
                var temp = (PointOfPlan1X0Y)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawPointOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "PointOfPlan2X0Z")
            {
                var temp = (PointOfPlan2X0Z)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawPointOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "PointOfPlan3Y0Z")
            {
                var temp = (PointOfPlan3Y0Z)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawPointOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "Line2D")
            {
                var temp = (Line2D)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawLine2D(Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_0), Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_1), PropertyLine2D.LineColor, Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "Line3D")
            {
                var temp = (Line3D)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawLine3DToXYXZYZ(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "LineOfPlan1X0Y")
            {
                var temp = (LineOfPlan1X0Y)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawLineOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "LineOfPlan2X0Z")
            {
                var temp = (LineOfPlan2X0Z)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawLineOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            else if (CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1].GetType().Name == "LineOfPlan3Y0Z")
            {
                var temp = (LineOfPlan3Y0Z)CollectionOfGraphicObjcets_Source[GraphicObjcet_Number - 1];
                DrawLineOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
        }
        /// <summary>
        ///  Отрисовывает все объекты коллекции примитивов в Graphics, а Graphics в заданном PictureBox без очистки фона
        /// </summary>
        /// <param name="CollectionOfGraphicObjects_Source">Заданная коллекция графических объектов</param>
        /// <param name="Point_Color"></param>
        /// <param name="BitmapActive_Source">Заданная картинка с объектами и цветом фона</param>
        /// <param name="BitmapBack_Source"></param>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        /// <remarks>Отрисовываются объекты коллекции ObjectsGraphics_Collection, заданной по умолчанию</remarks>
        public static void ReFreshCollection(Collection<object> CollectionOfGraphicObjects_Source, Color Point_Color, ref Bitmap BitmapActive_Source, ref Bitmap BitmapBack_Source, ref Graphics Graphics_Source)
        {
            BitmapActive_Source = (Bitmap)BitmapBack_Source.Clone();
            Graphics_Source = Graphics.FromImage(BitmapActive_Source);
            Point Point_Var = new Point();
            if (CollectionOfGraphicObjects_Source.Count == 0)
            {
                return;
            }

            for (int i = 0; i < CollectionOfGraphicObjects_Source.Count; i++)
            {
                if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Point")
                {
                    Point_Var = (Point)CollectionOfGraphicObjects_Source[i];
                    DrawPoint2D(Point_Var.X, Point_Var.Y, Point_Color, PropertyPoint.Diametre_Point, Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Point3D")
                {
                    Point3D temp = (Point3D)CollectionOfGraphicObjects_Source[i];
                    DrawPoint3DToXYXZYZ(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "PointOfPlan1X0Y")
                {
                    PointOfPlan1X0Y temp = (PointOfPlan1X0Y)CollectionOfGraphicObjects_Source[i];
                    DrawPointOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "PointOfPlan2X0Z")
                {
                    PointOfPlan2X0Z temp = (PointOfPlan2X0Z)CollectionOfGraphicObjects_Source[i];
                    DrawPointOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "PointOfPlan3Y0Z")
                {
                    PointOfPlan3Y0Z temp = (PointOfPlan3Y0Z)CollectionOfGraphicObjects_Source[i];
                    DrawPointOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Line2D")
                {
                    var temp = (Line2D)CollectionOfGraphicObjects_Source[i];
                    DrawLine2D(Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_0), Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_1), PropertyLine2D.LineColor, Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Line3D")
                {
                    var temp = (Line3D)CollectionOfGraphicObjects_Source[i];
                    DrawLine3DToXYXZYZ(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "LineOfPlan1X0Y")
                {
                    var temp = (LineOfPlan1X0Y)CollectionOfGraphicObjects_Source[i];
                    DrawLineOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "LineOfPlan2X0Z")
                {
                    var temp = (LineOfPlan2X0Z)CollectionOfGraphicObjects_Source[i];
                    DrawLineOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "LineOfPlan3Y0Z")
                {
                    var temp = (LineOfPlan3Y0Z)CollectionOfGraphicObjects_Source[i];
                    DrawLineOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
            }

        }
        /// <summary>
        /// Отрисовывает все объекты коллекции примитивов в Graphics, а Graphics в заданном PictureBox без очистки фона
        /// </summary>
        /// <param name="CollectionOfGraphicObjects_Source">Заданная коллекция графических объектов</param>
        /// <param name="Point_Color"></param>
        /// <param name="graphicsSource">Заданная поверхность рисования</param>
        /// <remarks>Отрисовываются объекты коллекции ObjectsGraphics_Collection, заданной по умолчанию</remarks>
        public static void ReFreshCollection(Collection<object> CollectionOfGraphicObjects_Source, Color Point_Color, Graphics graphicsSource)
        {
            var pointDraw = new PointDraw();
            Point Point_Var = new Point();

            if ((CollectionOfGraphicObjects_Source.Count == 0))
            {
                return;
            }

            for (int i = 0; i < CollectionOfGraphicObjects_Source.Count; i++)
            {
                if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Point")
                {
                    Point_Var = (Point)CollectionOfGraphicObjects_Source[i];
                    DrawPoint2D(Point_Var.X, Point_Var.Y, Point_Color, PropertyPoint.Diametre_Point, graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Point3D")
                {
                    Point3D temp = (Point3D)CollectionOfGraphicObjects_Source[i];
                    DrawPoint3DToXYXZYZ(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "PointOfPlan1X0Y")
                {
                    PointOfPlan1X0Y temp = (PointOfPlan1X0Y)CollectionOfGraphicObjects_Source[i];
                    DrawPointOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "PointOfPlan2X0Z")
                {
                    PointOfPlan2X0Z temp = (PointOfPlan2X0Z)CollectionOfGraphicObjects_Source[i];
                    DrawPointOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "PointOfPlan3Y0Z")
                {
                    PointOfPlan3Y0Z temp = (PointOfPlan3Y0Z)CollectionOfGraphicObjects_Source[i];
                    DrawPointOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Line2D")
                {
                    var temp = (Line2D)CollectionOfGraphicObjects_Source[i];
                    DrawLine2D(Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_0), Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_1), PropertyLine2D.LineColor, graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "Line3D")
                {
                    var temp = (Line3D)CollectionOfGraphicObjects_Source[i];
                    DrawLine3DToXYXZYZ(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "LineOfPlan1X0Y")
                {
                    var temp = (LineOfPlan1X0Y)CollectionOfGraphicObjects_Source[i];
                    DrawLineOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "LineOfPlan2X0Z")
                {
                    var temp = (LineOfPlan2X0Z)CollectionOfGraphicObjects_Source[i];
                    DrawLineOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
                else if (CollectionOfGraphicObjects_Source[i].GetType().Name == "LineOfPlan3Y0Z")
                {
                    var temp = (LineOfPlan3Y0Z)CollectionOfGraphicObjects_Source[i];
                    DrawLineOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
                }
            }
        }
        /// <summary>
        /// Отрисовка одной заданной точки в заданной поверхности рисования Graphics
        /// </summary>
        /// <param name="X">Координата X заданной точки</param>
        /// <param name="Y">Координата Y заданной точки</param>
        /// <param name="Pen">Заданное перо для рисования</param>
        /// <param name="GraphicsSource">Заданная поверхность рисования</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public static void DrawPoint2D(double X, double Y, Pen Pen, Graphics GraphicsSource)
        {
            GraphicsSource.DrawEllipse(Pen, (int)(X - Pen.Width / 2), (int)(Y - Pen.Width / 2), Pen.Width, Pen.Width);
        }
        /// <summary>
        /// Отрисовка одной заданной точки в заданной поверхности рисования Graphics
        /// </summary>
        /// <param name="X">Координата X заданной точки</param>
        /// <param name="Y">Координата Y заданной точки</param>
        /// <param name="PointColor">Цвет заданной точки</param>
        /// <param name="PointDiametre">Диаметр заданной точки</param>
        /// <param name="GraphicsSource">Заданная поверхность рисования</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public static void DrawPoint2D(double X, double Y, Color PointColor, double PointDiametre, Graphics GraphicsSource)
        {
            Pen Pens = new Pen(PointColor, (float)PointDiametre);
            GraphicsSource.DrawEllipse(Pens, (int)(X - PointDiametre / 2), (int)(Y - PointDiametre / 2), (int)(PointDiametre), (int)(PointDiametre));
        }
        /// <summary>
        /// Отрисовка одной заданной точки в заданной поверхности рисования Graphics
        /// </summary>
        /// <param name="Point2Source">Заданная 2D точка</param>
        /// <param name="PointColor">Цвет заданной точки</param>
        /// <param name="PointDiametre">Диаметр заданной точки</param>
        /// <param name="GraphicsSource">Заданная поверхность рисования</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public static void DrawPoint2D(Point Point2Source, Color PointColor, double PointDiametre, Graphics GraphicsSource)
        {
            Pen Pens = new Pen(PointColor, (float)PointDiametre);
            GraphicsSource.DrawEllipse(Pens, (int)(Point2Source.X - PointDiametre / 2), (int)(Point2Source.Y - PointDiametre / 2), (int)(PointDiametre), (int)(PointDiametre));
        }
        /// <summary>
        /// Отрисовка одной заданной точки в заданной поверхности рисования Graphics
        /// </summary>
        /// <param name="Points2DSource">Заданная 2D точка</param>
        /// <param name="Pen">Заданное перо для рисования</param>
        /// <param name="Frame2DCenter">Заданный центр системы координат</param>
        /// <param name="GraphicsSource">Заданная поверхность рисования</param>
        /// <remarks>Начало координат для отриосвки задается параметром "Frame2D_Centre"</remarks>
        public static void DrawPoint2D(Point Points2DSource, Pen Pen, Point Frame2DCenter, Graphics GraphicsSource)
        {
            Points2DSource.X = (int)(Frame2DCenter.X + Points2DSource.X - Pen.Width / 2);
            Points2DSource.Y = (int)(Frame2DCenter.Y + Points2DSource.Y - Pen.Width / 2);
            GraphicsSource.DrawPie(Pen, Points2DSource.X, Points2DSource.Y, Pen.Width, Pen.Width, 0, 360);
        }
        /// <summary>
        /// Отрисовка одной заданной точки в заданной поверхности рисования Graphics
        /// </summary>
        /// <param name="Point_Source">Заданная 2D точка</param>
        /// <param name="Point_Pen">Заданное перо для рисования</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        /// <remarks>Начало координат для отриосвки задается параметром "Frame2D_Centre"</remarks>
        public static void DrawPoint3D(Point Point_Source, Pen Point_Pen, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            Graphics_Source.DrawPie(Point_Pen, Point_Source.X, Point_Source.Y, Point_Pen.Width, Point_Pen.Width, 0, 360);
        }
        /// <summary>
        /// Отрисовка горизонтальной, фронтальной и профильной проекций пространственной точки 
        /// </summary>
        /// <param name="Point3D_Source"></param>
        /// <param name="Frame2D_Centre"></param>
        /// <param name="PointXoY_Pen"></param>
        /// <param name="PointXoZ_Pen"></param>
        /// <param name="PointYoZ_Pen"></param>
        /// <param name="Graphics_Source"></param>
        public static void DrawPoint3DToXYXZYZ(Point3D Point3D_Source, Point Frame2D_Centre, Pen PointXoY_Pen, Pen PointXoZ_Pen, Pen PointYoZ_Pen, ref Graphics Graphics_Source)
        {
            //Отрисовка горизонтальной проекции
            DrawPoint3D(Point3D_Source.Point3DDraw.PointPlan1X0Y_PositionByFrame, PointXoY_Pen, Frame2D_Centre, ref Graphics_Source);
            //Отрисовка фронтальной проекции
            DrawPoint3D(Point3D_Source.Point3DDraw.PointPlan2X0Z_PositionByFrame, PointXoZ_Pen, Frame2D_Centre, ref Graphics_Source);
            //Отрисовка профильной проекции
            DrawPoint3D(Point3D_Source.Point3DDraw.PointPlan3Y0Z_PositionByFrame, PointYoZ_Pen, Frame2D_Centre, ref Graphics_Source);
        }
        /// <summary>
        /// Отрисовка горизонтальной, фронтальной и профильной проекций пространственной точки
        /// </summary>
        /// <param name="Point3D_Source"></param>
        /// <param name="Frame2D_Centre"></param>
        /// <param name="Graphics_Source"></param>
        public static void DrawPoint3DToXYXZYZ(Point3D Point3D_Source, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            //Отрисовка горизонтальной проекции
            if (Point3D_Source.Point3DDraw.FlagDraw_PointPlan1X0Y)
            {
                DrawPoint3D(Point3D_Source.Point3DDraw.PointPlan1X0Y_PositionByFrame, Point3D_Source.Point3DDraw.Pen_Point1X0Y, Frame2D_Centre, ref Graphics_Source);
            }
            //Отрисовка фронтальной проекции
            if (Point3D_Source.Point3DDraw.FlagDraw_PointPlan2X0Z)
            {
                DrawPoint3D(Point3D_Source.Point3DDraw.PointPlan2X0Z_PositionByFrame, Point3D_Source.Point3DDraw.Pen_Point2X0Z, Frame2D_Centre, ref Graphics_Source);
            }
            //Отрисовка профильной проекции
            if (Point3D_Source.Point3DDraw.FlagDraw_PointPlan3Y0Z)
            {
                DrawPoint3D(Point3D_Source.Point3DDraw.PointPlan3Y0Z_PositionByFrame, Point3D_Source.Point3DDraw.Pen_Point3Y0Z, Frame2D_Centre, ref Graphics_Source);
            }
        }
        /// <summary>
        /// Отрисовка горизонтальной проекции точки
        /// </summary>
        /// <param name="pointofPlanSource">Горизонтальная проекция точки</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawPointOfPlan1X0Y(PointOfPlan1X0Y pointofPlanSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            pointofPlanSource.Point3D_Draw = new PointDraw(pointofPlanSource, null, null,
                                                           PropertyPoint3D.Pen_PointPlan1X0Y, null, null,
                                                           frame2DCentre);
            DrawPoint3D(pointofPlanSource.Point3D_Draw.PointPlan1X0Y_PositionByFrame, pointofPlanSource.Point3D_Draw.Pen_Point1X0Y, frame2DCentre, ref graphicsSource);
        }
        /// <summary>
        /// Отрисовка фронтальной проекции точки
        /// </summary>
        /// <param name="pointofPlanSource">Фронтальная проекция точки</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawPointOfPlan2X0Z(PointOfPlan2X0Z pointofPlanSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            pointofPlanSource.Point3D_Draw = new PointDraw(null, pointofPlanSource, null, 
                                                           null, PropertyPoint3D.Pen_PointPlan2X0Z, null,
                                                           frame2DCentre);
            DrawPoint3D(pointofPlanSource.Point3D_Draw.PointPlan2X0Z_PositionByFrame, pointofPlanSource.Point3D_Draw.Pen_Point2X0Z, frame2DCentre, ref graphicsSource);
        }
        /// <summary>
        /// Отрисовка профильной проекции точки
        /// </summary>
        /// <param name="pointofPlanSource">Профильная проекция точки</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawPointOfPlan3Y0Z(PointOfPlan3Y0Z pointofPlanSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            pointofPlanSource.Point3D_Draw = new PointDraw(null, null, pointofPlanSource,
                                                           null, null, PropertyPoint3D.Pen_PointPlan3Y0Z,
                                                           frame2DCentre);
            DrawPoint3D(pointofPlanSource.Point3D_Draw.PointPlan3Y0Z_PositionByFrame, pointofPlanSource.Point3D_Draw.Pen_Point3Y0Z, frame2DCentre, ref graphicsSource);
        }
        /// <summary>
        /// Отрисовывает прямую в поверхности рисования Graphics
        /// </summary>
        /// <param name="pointFirst">Начальная точка прямой</param>
        /// <param name="pointEnd">Вторая точка прямой</param>
        /// <param name="LineColor">Цвет прямой</param>
        /// <param name="PointDiametre">Диаметр точек прямой</param>
        /// <param name="GraphicsSource">Заданная поверхность рисования</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public static void DrawLine2D(Point pointFirst, Point pointEnd, Color LineColor, Graphics GraphicsSource)
        {
            DrawPoint2D(pointFirst, PropertyPoint.Color_Point, PropertyPoint.Diametre_Point, GraphicsSource);
            DrawPoint2D(pointEnd, PropertyPoint.Color_Point, PropertyPoint.Diametre_Point, GraphicsSource);

            Pen pen = new Pen(LineColor, 1);
            Point[] pointsToDrawLine = LineDraw.CalculatePointsToDrawLineInPictureBox(pointFirst, pointEnd, DrawObjectsToPictureBox.pictureBoxWidth, DrawObjectsToPictureBox.pictureBoxHeight);
            GraphicsSource.DrawLine(pen, pointsToDrawLine[0], pointsToDrawLine[1]);
        }
        public static void DrawLine2D(Point pointFirst, Point pointEnd, Color LineColor, Color PointColor, Graphics GraphicsSource)
        {
            DrawPoint2D(pointFirst, PointColor, PropertyPoint.Diametre_Point+1, GraphicsSource);
            DrawPoint2D(pointEnd, PointColor, PropertyPoint.Diametre_Point+1, GraphicsSource);

            Pen pen = new Pen(LineColor, 1);
            Point[] pointsToDrawLine = LineDraw.CalculatePointsToDrawLineInPictureBox(pointFirst, pointEnd, DrawObjectsToPictureBox.pictureBoxWidth, DrawObjectsToPictureBox.pictureBoxHeight);
            GraphicsSource.DrawLine(pen, pointsToDrawLine[0], pointsToDrawLine[1]);
        }
        public static void DrawLine3DToXYXZYZ(Line3D line3DSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            //Отрисовка горизонтальной проекции
            if (line3DSource.Line_Draw.FlagDrawPointPlan1X0Y)
            {
                DrawLine3D(line3DSource.Line_Draw.LineOfPlan1X0YPositionByFrame, line3DSource.Line_Draw.LineOfPlan1X0YPositionByPicture, line3DSource.Line_Draw.PenLineX0Y,line3DSource.Line_Draw.PenPointsX0Y, frame2DCentre, new Point(0, frame2DCentre.Y), 1, ref graphicsSource);
            }
            //Отрисовка фронтальной проекции
            if (line3DSource.Line_Draw.FlagDrawPointPlan2X0Z)
            {
                DrawLine3D(line3DSource.Line_Draw.LineOfPlan2X0ZPositionByFrame, line3DSource.Line_Draw.LineOfPlan2X0ZPositionByPicture, line3DSource.Line_Draw.PenLineX0Z, line3DSource.Line_Draw.PenPointsX0Z, frame2DCentre, new Point(0, 0), 2, ref graphicsSource);
            }
            //Отрисовка профильной проекции
            if (line3DSource.Line_Draw.FlagDrawPointPlan3Y0Z)
            {
                DrawLine3D(line3DSource.Line_Draw.LineOfPlan3Y0ZPositionByFrame, line3DSource.Line_Draw.LineOfPlan3Y0ZPositionByPicture, line3DSource.Line_Draw.PenLineY0Z, line3DSource.Line_Draw.PenPointsY0Z, frame2DCentre, new Point(frame2DCentre.X, 0), 3, ref graphicsSource);
            }
        }
        /// <summary>
        /// Отрисовывает горизонтальную проекцию прямой
        /// </summary>
        /// <param name="lineOfPlanSource">Горизонтальная проекция прямой</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawLineOfPlan1X0Y(LineOfPlan1X0Y lineOfPlanSource, Point frame2DCentre, ref Graphics graphicsSource)
        {

            lineOfPlanSource.Line_Draw = new LineDraw(lineOfPlanSource, null, null, 
                                                      PropertyPoint3D.Pen_PointPlan1X0Y, null, null, 
                                                      PropertyLine3D.PenLineOfPlan1X0Y, null, null, 
                                                      frame2DCentre);
            DrawLine3D(lineOfPlanSource.Line_Draw.LineOfPlan1X0YPositionByFrame, 
                       lineOfPlanSource.Line_Draw.LineOfPlan1X0YPositionByPicture,
                       lineOfPlanSource.Line_Draw.PenLineX0Y, lineOfPlanSource.Line_Draw.PenPointsX0Y, 
                       frame2DCentre, 
                       new Point(0, frame2DCentre.Y), 
                       1,
                       ref graphicsSource);
        }
        /// <summary>
        /// Отрисовывает профильную проекцию прямой
        /// </summary>
        /// <param name="lineOfPlanSource">Профильная проекция прямой</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawLineOfPlan2X0Z(LineOfPlan2X0Z lineOfPlanSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            lineOfPlanSource.Line_Draw = new LineDraw(null, lineOfPlanSource, null,
                                                      null, PropertyPoint3D.Pen_PointPlan2X0Z, null,                                                     
                                                      null, PropertyLine3D.PenLineOfPlan2X0Z, null,
                                                      frame2DCentre);
            DrawLine3D(lineOfPlanSource.Line_Draw.LineOfPlan2X0ZPositionByFrame, lineOfPlanSource.Line_Draw.LineOfPlan2X0ZPositionByPicture, lineOfPlanSource.Line_Draw.PenLineX0Z, lineOfPlanSource.Line_Draw.PenPointsX0Z, frame2DCentre, new Point(0, 0), 2, ref graphicsSource);
        }
        /// <summary>
        /// Отрисовывает фронтальную проекцию прямой
        /// </summary>
        /// <param name="lineOfPlanSource">Фронтальная проекция прямой</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawLineOfPlan3Y0Z(LineOfPlan3Y0Z lineOfPlanSource, Point frame2DCentre, ref Graphics graphicsSource)
        {
            lineOfPlanSource.Line_Draw = new LineDraw(null, null, lineOfPlanSource, 
                                                      null, null, PropertyPoint3D.Pen_PointPlan3Y0Z,
                                                      null, null, PropertyLine3D.PenLineOfPlan3Y0Z,
                                                      frame2DCentre);
            DrawLine3D(lineOfPlanSource.Line_Draw.LineOfPlan3Y0ZPositionByFrame, lineOfPlanSource.Line_Draw.LineOfPlan3Y0ZPositionByPicture, lineOfPlanSource.Line_Draw.PenLineY0Z, lineOfPlanSource.Line_Draw.PenPointsY0Z, frame2DCentre, new Point(frame2DCentre.X, 0), 3, ref graphicsSource);
        }
        public static void DrawLineOfPlan1X0Y(LineOfPlan1X0Y lineOfPlanSource, Point frame2DCentre, Pen PointPen, Pen LinePen, ref Graphics graphicsSource)
        {

            lineOfPlanSource.Line_Draw = new LineDraw(lineOfPlanSource, null, null,
                                                      PointPen, null, null,
                                                      LinePen, null, null,
                                                      frame2DCentre);
            DrawLine3D(lineOfPlanSource.Line_Draw.LineOfPlan1X0YPositionByFrame,
                       lineOfPlanSource.Line_Draw.LineOfPlan1X0YPositionByPicture,
                       LinePen, PointPen,
                       frame2DCentre,
                       new Point(0, frame2DCentre.Y),
                       1,
                       ref graphicsSource);
        }
        /// <summary>
        /// Отрисовывает профильную проекцию прямой
        /// </summary>
        /// <param name="lineOfPlanSource">Профильная проекция прямой</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawLineOfPlan2X0Z(LineOfPlan2X0Z lineOfPlanSource, Point frame2DCentre, Pen PointPen, Pen LinePen, ref Graphics graphicsSource)
        {
            lineOfPlanSource.Line_Draw = new LineDraw(null, lineOfPlanSource, null,
                                                      null, PointPen, null,
                                                      null, LinePen, null,
                                                      frame2DCentre);
            DrawLine3D(lineOfPlanSource.Line_Draw.LineOfPlan2X0ZPositionByFrame, lineOfPlanSource.Line_Draw.LineOfPlan2X0ZPositionByPicture, LinePen, PointPen, frame2DCentre, new Point(0, 0), 2, ref graphicsSource);
        }
        /// <summary>
        /// Отрисовывает фронтальную проекцию прямой
        /// </summary>
        /// <param name="lineOfPlanSource">Фронтальная проекция прямой</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawLineOfPlan3Y0Z(LineOfPlan3Y0Z lineOfPlanSource, Point frame2DCentre, Pen PointPen, Pen LinePen, ref Graphics graphicsSource)
        {
            lineOfPlanSource.Line_Draw = new LineDraw(null, null, lineOfPlanSource,
                                                      null, null, PointPen,
                                                      null, null, LinePen,
                                                      frame2DCentre);
            DrawLine3D(lineOfPlanSource.Line_Draw.LineOfPlan3Y0ZPositionByFrame, lineOfPlanSource.Line_Draw.LineOfPlan3Y0ZPositionByPicture, LinePen, PointPen, frame2DCentre, new Point(frame2DCentre.X, 0), 3, ref graphicsSource);
        }
        /// <summary>
        /// Отрисовывает прямую, ограниченную заданным квадрантом системы координат
        /// </summary>
        /// <param name="lineSourcePositionByFrame">Прямая для отрисовки</param>
        /// <param name="linePen">Цвет линии прямой</param>
        /// <param name="pointsPen">Цвет точек прямой</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="coordsPointStart">Координаты верхнего левого угла квадранта</param>
        /// <param name="graphicsSource">Поверхность рисования</param>
        public static void DrawLine3D(Line2D lineSourcePositionByFrame, Line2D lineSourceOriginalPosition, Pen linePen, Pen pointsPen, Point frame2DCentre, Point coordsPointStart, int cNumber, ref Graphics graphicsSource)
        {
            int[] pbSize = PropertyLine3D.CalculateQuadrantWidthHeight(DrawObjectsToPictureBox.pictureBoxWidth, DrawObjectsToPictureBox.pictureBoxHeight, frame2DCentre, cNumber);
            Point[] pointsToDrawLine = LineDraw.CalculatePointsToDrawLineInPictureBox(Point3D_Draw_Var.CnvPoint2D_ToPoint(lineSourceOriginalPosition.Point_0), Point3D_Draw_Var.CnvPoint2D_ToPoint(lineSourceOriginalPosition.Point_1), pbSize[0], pbSize[1], coordsPointStart);
            graphicsSource.DrawPie(pointsPen, Point3D_Draw_Var.CnvPoint2D_ToPoint(lineSourcePositionByFrame.Point_0).X, Point3D_Draw_Var.CnvPoint2D_ToPoint(lineSourcePositionByFrame.Point_0).Y, (int)pointsPen.Width, (int)pointsPen.Width, 0, 360);
            graphicsSource.DrawPie(pointsPen, Point3D_Draw_Var.CnvPoint2D_ToPoint(lineSourcePositionByFrame.Point_1).X, Point3D_Draw_Var.CnvPoint2D_ToPoint(lineSourcePositionByFrame.Point_1).Y, (int)pointsPen.Width, (int)pointsPen.Width, 0, 360);
            graphicsSource.DrawLine(linePen, pointsToDrawLine[0], pointsToDrawLine[1]);
        }
        /// <summary>
        /// Подсветка в Graphics графического объекта при приближении или установке на него курсора
        /// </summary>
        /// <param name="Point_ColorNew">Заданный цвет для перерисовки графичекого объекта</param>
        /// <param name="CursorPoint">Точка, определяющая текущее положение курсора</param>
        /// <param name="Distance_CursorToObject">Заданное расстояние от курсора до объекта, по достижении которого изменяется цвет объекта</param>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        public static void Object_FireByCursor(Color Point_ColorNew, Point CursorPoint, double Distance_CursorToObject, Graphics Graphics_Source)
        {
            Point PointCursor_Var = new Point(CursorPoint.X, CursorPoint.Y);
            Point Point_Var = new Point();

            for (int i = 0; i < CollectionsGraphicsObjects.GraphicsObjectsCollection.Count; i++)
            {
                Point_Var = (Point)CollectionsGraphicsObjects.GraphicsObjectsSelect[i];
                double len = Math.Sqrt((PointCursor_Var.X - Point_Var.X) ^ 2 + (PointCursor_Var.Y - Point_Var.Y) ^ 2);
                if (len < Distance_CursorToObject)
                {
                    DrawPoint2D(Point_Var.X, Point_Var.Y, Point_ColorNew, PropertyPoint.Diametre_Point + 1, Graphics_Source);
                }
            }
        }
        /// <summary>
        /// Подсветка в Graphics графического объекта при приближении или установке на него курсора
        /// </summary>
        /// <param name="Point_Color">Заданный цвет для перерисовки графичекого объекта</param>
        /// <param name="CursorPoint">Точка, определяющая текущее положение курсора</param>
        /// <param name="Distance_CursorToObject">Заданное расстояние от курсора до объекта, по достижении которого изменяется цвет объекта</param>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        public static void ObjectFireByCursor(Color Point_Color, Point CursorPoint, double Distance_CursorToObject, Graphics Graphics_Source)
        {
            Point PointCursor_Var = new Point(CursorPoint.X, CursorPoint.Y);

            Point Point_Var = new Point();
            for (int i = 0; i < CollectionsGraphicsObjects.GraphicsObjectsCollection.Count; i++)
            {
                Point_Var = (Point)CollectionsGraphicsObjects.GraphicsObjectsCollection[i];
                double len = Math.Sqrt((PointCursor_Var.X - Point_Var.X) ^ 2 + (PointCursor_Var.Y - Point_Var.Y) ^ 2);
                if (len < Distance_CursorToObject)
                {
                    DrawPoint2D(Point_Var.X, Point_Var.Y, Point_Color, 3, Graphics_Source);
                }
                else
                {
                    DrawPoint2D(Point_Var.X, Point_Var.Y, Color.Yellow, 3, Graphics_Source);
                }

            }
        }
        /// <summary>
        /// Подсветка в Graphics графического объекта при приближении или установке на него курсора
        /// </summary>
        /// <param name="Object_Source">Заданный объект для которого производится подсветка</param>
        /// <param name="Point_ColorNew">Заданный цвет для перерисовки графичекого объекта</param>
        /// <param name="CursorPont">Точка, определяющая текущее положение курсора</param>
        /// <param name="Distance_CursorToObject">Заданное расстояние от курсора до объекта, по достижении которого изменяется цвет объекта</param>
        /// <param name="graphicsSource">Заданная поверхность рисования</param>
        public static void HighlightObjectByCursor(object Object_Source, Color Point_ColorNew, Point CursorPont, double Distance_CursorToObject, Graphics graphicsSource)
        {
            Point Point_Var = new Point();
            if (Object_Source is Point)
            {
                Point temp = (Point)Object_Source;
                DrawPoint2D(temp.X, temp.Y, Point_ColorNew, PropertyPoint.Diametre_Point + 1, graphicsSource);
            }
            else if (Object_Source is Point3D)
            { }
            else if (Object_Source is PointOfPlan1X0Y)
            {
                PointOfPlan1X0Y temp = (PointOfPlan1X0Y)Object_Source;
                Point_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(PropertyPoint3D.Draw_Point3D_Var.CnvPoint3DProjection_ToPoint(temp), 0, DrawOperations.GridDraw_Var.GridCenter);
                DrawPoint2D(Point_Var.X, Point_Var.Y, Point_ColorNew, PropertyPoint.Diametre_Point + 1, graphicsSource);
            }
            else if (Object_Source is PointOfPlan2X0Z)
            {
                PointOfPlan2X0Z temp = (PointOfPlan2X0Z)Object_Source;
                Point_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(PropertyPoint3D.Draw_Point3D_Var.CnvPoint3DProjection_ToPoint(temp), 0, DrawOperations.GridDraw_Var.GridCenter);
                DrawPoint2D(Point_Var.X, Point_Var.Y, Point_ColorNew, PropertyPoint.Diametre_Point + 1, graphicsSource);
            }
            else if (Object_Source is PointOfPlan3Y0Z)
            {
                PointOfPlan3Y0Z temp = (PointOfPlan3Y0Z)Object_Source;
                Point_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(PropertyPoint3D.Draw_Point3D_Var.CnvPoint3DProjection_ToPoint(temp), 0, DrawOperations.GridDraw_Var.GridCenter);
                DrawPoint2D(Point_Var.X, Point_Var.Y, Point_ColorNew, PropertyPoint.Diametre_Point + 1, graphicsSource);
            }
            else if (Object_Source.GetType().Name == "Line2D")
            {
                var temp = (Line2D)Object_Source;
                DrawLine2D(Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_0), Point3D_Draw_Var.CnvPoint2D_ToPoint(temp.Point_1), Color.Orange, Color.Orange, graphicsSource);
            }
            else if (Object_Source.GetType().Name == "LineOfPlan1X0Y")
            {
                var temp = (LineOfPlan1X0Y)Object_Source;
                DrawLineOfPlan1X0Y(temp, DrawOperations.GridDraw_Var.GridCenter, new Pen(Color.Orange, 4), new Pen(Color.Orange, 1), ref graphicsSource);
            }
            else if (Object_Source.GetType().Name == "LineOfPlan2X0Z")
            {
                var temp = (LineOfPlan2X0Z)Object_Source;
                DrawLineOfPlan2X0Z(temp, DrawOperations.GridDraw_Var.GridCenter, new Pen(Color.Orange, 4), new Pen(Color.Orange, 1), ref graphicsSource);
            }
            else if (Object_Source.GetType().Name == "LineOfPlan3Y0Z")
            {
                var temp = (LineOfPlan3Y0Z)Object_Source;
                DrawLineOfPlan3Y0Z(temp, DrawOperations.GridDraw_Var.GridCenter, new Pen(Color.Orange, 4), new Pen(Color.Orange, 1), ref graphicsSource);
            }
        }
    }
}
