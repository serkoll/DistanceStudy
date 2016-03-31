using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;

namespace DrawG {
    /// <summary>
    /// Содержит методы отрисовки графических объектов в PictureBox с помощью инструментов класса ObjectsDrawToGraphics
    /// </summary>
    class DrawObjectsToPictureBox {
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

        public enum ColorMode {
            None,
            ObjectColor
        }

        public static Tools_DrawObjects Tool_DrawObject = Tools_DrawObjects.None;
        public enum Tools_DrawObjects {
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

            if (Tool_DrawObject == Tools_DrawObjects.SetPoint) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                CollectionGraphicsObjects.AddToCollection(PointVar);
            } else if (Tool_DrawObject == Tools_DrawObjects.SetPoint3D) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                PropertyPoint3D.Create_Point3DByDrawProection(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                if (PropertyPoint3D.FlagPoint3D_CreateStop) {
                    CollectionGraphicsObjects.AddToCollection(PropertyPoint3D.Point3D_Var);
                    PropertyPoint3D.Point3D_Var = null;
                }
            } else if (Tool_DrawObject == Tools_DrawObjects.SetProectionPoint3D) {
            } else if (Tool_DrawObject == Tools_DrawObjects.SetLine) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                PropertyLine2D.CreateLine2D(PointVar);
                PropertyLine2D.DrawTempPoint(PointVar, ref GraphicsActive);
                if (PropertyLine2D.LineStopCreate) {
                    CollectionGraphicsObjects.AddToCollection(PropertyLine2D.Line2DVar);
                    PropertyLine2D.Line2DVar = null;
                    PropertyLine2D.LineStopCreate = false;
                }
            } else if (Tool_DrawObject == Tools_DrawObjects.SetPointPlan1X0Y) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                PropertyPoint3D.PointToPointOfPlan1_X0Y(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                CollectionGraphicsObjects.AddToCollection(PropertyPoint3D.PointOfPlan1_X0Y_Var);
                PropertyPoint3D.PointOfPlan1_X0Y_Var = null;
            } else if (Tool_DrawObject == Tools_DrawObjects.SetPointPlan2X0Z) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                PropertyPoint3D.PointToPointOfPlan2_X0Z(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                CollectionGraphicsObjects.AddToCollection(PropertyPoint3D.PointOfPlan2_X0Z_Var);
                PropertyPoint3D.PointOfPlan2_X0Z_Var = null;
            } else if (Tool_DrawObject == Tools_DrawObjects.SetPointPlan3Y0Z) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                PropertyPoint3D.PointToPointOfPlan3_Y0Z(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                CollectionGraphicsObjects.AddToCollection(PropertyPoint3D.PointOfPlan3_Y0Z_Var);
                PropertyPoint3D.PointOfPlan3_Y0Z_Var = null;
            } else if (Tool_DrawObject == Tools_DrawObjects.SetLine3D) {
                if (!PropertyLine2D.LineStopCreate) {
                    PropertyLine3D.Point0 = (Point)ControlDraw.UserMouseClick;
                    PropertyLine2D.LineStopCreate = true;
                    PropertyLine3D.DrawTempPointsProjections(GraphicsActive);
                } else {
                    PropertyLine3D.Point1 = (Point)ControlDraw.UserMouseClick;
                    PropertyLine3D.CreateLine3DByDrawProjection(PropertyLine3D.Point0, PropertyLine3D.Point1, ControlDraw.GridDraw_Var.GridCenter);
                    PropertyLine3D.DrawTempLineProjections(GraphicsActive);
                    PropertyLine2D.LineStopCreate = false;
                }
                if (PropertyPoint3D.FlagPoint3D_CreateStop) {
                    CollectionGraphicsObjects.AddToCollection(PropertyPoint3D.Point3D_Var);
                    PropertyPoint3D.Point3D_Var = null;
                }
            } else if (Tool_DrawObject == Tools_DrawObjects.SetLinePlan1X0Y) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                if (!PropertyLineProjections.FlagCreateOrNotLineOfPlan1X0Y) {
                    PropertyLineProjections.Point0LineOfPlan1X0Y = PropertyPoint3D.PointToPointOfPlan1X0Y(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                    if (PropertyLineProjections.Point0LineOfPlan1X0Y == null) {
                    } else {
                        PropertyLineProjections.FlagCreateOrNotLineOfPlan1X0Y = true;
                        PropertyLineProjections.DrawTempPointsProjections(GraphicsActive);
                    }
                } else {
                    PropertyLineProjections.Point1LineOfPlan1X0Y = PropertyPoint3D.PointToPointOfPlan1X0Y(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                    if (PropertyLineProjections.Point1LineOfPlan1X0Y == null) {
                        PropertyLineProjections.FlagCreateOrNotLineOfPlan1X0Y = false;
                        PropertyLineProjections.Point0LineOfPlan1X0Y = null;
                        PropertyLineProjections.Point1LineOfPlan1X0Y = null;
                    } else {
                        PropertyLineProjections.TempLineOfPlan1X0Y = new LineOfPlan1X0Y(PropertyLineProjections.Point0LineOfPlan1X0Y,
                                                                                        PropertyLineProjections.Point1LineOfPlan1X0Y);
                        CollectionGraphicsObjects.AddToCollection(PropertyLineProjections.TempLineOfPlan1X0Y);
                        PropertyLineProjections.FlagCreateOrNotLineOfPlan1X0Y = false;
                        PropertyLineProjections.Point0LineOfPlan1X0Y = null;
                        PropertyLineProjections.Point1LineOfPlan1X0Y = null;
                        PropertyLineProjections.TempLineOfPlan1X0Y = null;
                    }
                }
            } else if (Tool_DrawObject == Tools_DrawObjects.SetLinePlan2X0Z) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                if (!PropertyLine2D.LineStopCreate) {
                    PropertyLine3D.Point0OfPlan2X0Z = PropertyPoint3D.PointToPointOfPlan2X0Z(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                    if (PropertyLine3D.Point0OfPlan2X0Z == null) {
                        PropertyLine2D.LineStopCreate = false;
                    } else {
                        PropertyLine2D.LineStopCreate = true;
                        PropertyLine3D.DrawTempPointsProjections(GraphicsActive);
                    }
                } else {
                    PropertyLine3D.Point1OfPlan2X0Z = PropertyPoint3D.PointToPointOfPlan2X0Z(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                    if (PropertyLine3D.Point1OfPlan2X0Z == null) {
                        PropertyLine2D.LineStopCreate = false;
                        PropertyLine3D.Point0OfPlan2X0Z = null;
                        PropertyLine3D.Point1OfPlan2X0Z = null;
                    } else {
                        PropertyLine3D.LineOfPlan2X0ZVar = new LineOfPlan2X0Z(PropertyLine3D.Point0OfPlan2X0Z, PropertyLine3D.Point1OfPlan2X0Z);
                        CollectionGraphicsObjects.AddToCollection(PropertyLine3D.LineOfPlan2X0ZVar);
                        PropertyLine2D.LineStopCreate = false;
                        PropertyLine3D.Point0OfPlan2X0Z = null;
                        PropertyLine3D.Point1OfPlan2X0Z = null;
                        PropertyLine3D.LineOfPlan2X0ZVar = null;
                    }
                }
            } else if (Tool_DrawObject == Tools_DrawObjects.SetLinePlan3Y0Z) {
                PointVar = (Point)ControlDraw.UserMouseClick;
                if (!PropertyLine2D.LineStopCreate) {
                    PropertyLine3D.Point0OfPlan3Y0Z = PropertyPoint3D.PointToPointOfPlan3Y0Z(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                    if (PropertyLine3D.Point0OfPlan3Y0Z == null) {
                        PropertyLine2D.LineStopCreate = false;
                    } else {
                        PropertyLine2D.LineStopCreate = true;
                        PropertyLine3D.DrawTempPointsProjections(GraphicsActive);
                    }
                } else {
                    PropertyLine3D.Point1OfPlan3Y0Z = PropertyPoint3D.PointToPointOfPlan3Y0Z(PointVar, ControlDraw.GridDraw_Var.GridCenter);
                    if (PropertyLine3D.Point1OfPlan3Y0Z == null) {
                        PropertyLine2D.LineStopCreate = false;
                        PropertyLine3D.Point0OfPlan3Y0Z = null;
                        PropertyLine3D.Point1OfPlan3Y0Z = null;
                    } else {
                        PropertyLine3D.LineOfPlan3Y0ZVar = new LineOfPlan3Y0Z(PropertyLine3D.Point0OfPlan3Y0Z, PropertyLine3D.Point1OfPlan3Y0Z);
                        CollectionGraphicsObjects.AddToCollection(PropertyLine3D.LineOfPlan3Y0ZVar);
                        PropertyLine2D.LineStopCreate = false;
                        PropertyLine3D.Point0OfPlan3Y0Z = null;
                        PropertyLine3D.Point1OfPlan3Y0Z = null;
                        PropertyLine3D.LineOfPlan3Y0ZVar = null;
                    }
                }
            }
            DrawObjectsToGraphics.ObjectCollectionToGraphics_Add(CollectionGraphicsObjects.GraphicsObjectsCollection.Count, PropertyPoint.Color_Point, CollectionGraphicsObjects.GraphicsObjectsCollection, ref GraphicsActive);
            pictureBoxSource.Image = (Image)BitmapActive.Clone();
            pictureBoxSource.Refresh();
        }
        /// <summary>
        /// Выбирает графический объект с помощью указания курсором и меняет его цвет
        /// </summary>
        /// <param name="Distance_CursorToObject">Расстояние от курсора до объекта, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="PictureBox_Source">Заданный PictureBox, в котором отрисованы графические объекты</param>
        public static void ObjectGraphics_SelectAndFire(double Distance_CursorToObject, PictureBox PictureBox_Source)
        {
            CollectionGraphicsObjectsTools.ObjectG_SelectToCollection((Point)ControlDraw.UserMouseClick, Distance_CursorToObject);
            if (CollectionGraphicsObjects.GraphicsObjectsSelect.Count == 0) {
                return;
            }
            DrawObjectsToGraphics.Object_FireByCursor(CollectionGraphicsObjects.GraphicsObjectsSelect[CollectionGraphicsObjects.GraphicsObjectsSelect.Count - 1], ControlDraw.Color_SelectPoint, PictureBox_Source.PointToClient(Control.MousePosition), Distance_CursorToObject, GraphicsActive);
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
            CollectionGraphicsObjectsTools.ObjectG_SelectToCollectionPointOfPlane((Point)ControlDraw.UserMouseClick, Distance_CursorToPointOfPlane);
            if (CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count == 0) {
                return;
            }
            DrawObjectsToGraphics.Object_FireByCursor(CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count - 1], ControlDraw.Color_SelectPoint, PictureBox_Source.PointToClient(Control.MousePosition), Distance_CursorToPointOfPlane, GraphicsActive);
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
            CollectionGraphicsObjects.ClearAllCollections();
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
            Point CursorPoint_Var = (Point)ControlDraw.UserMouseClick;
            CollectionGraphicsObjectsTools.ObjectG_SelectToCollection(CursorPoint_Var, Distance_CursorToObject);
            CollectionGraphicsObjectsTools.ObjectG_DeleteFromCollection(CollectionGraphicsObjects.GraphicsObjectsSelect, CollectionGraphicsObjects.GraphicsObjectsDelete, CollectionGraphicsObjects.GraphicsObjectsCollection);
            DrawObjectsToGraphics.ReFreshCollection(CollectionGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, ref BitmapActive, ref BitmapBack, ref GraphicsActive);
            if (ControlDraw.LinkLine_Var.ShowLinkLine_XYZ_Flag) {
                ControlDraw.LinkLine_Var.LinkLineToGrpahics_Add(GraphicsActive);
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
        public static void ObjectGraphics_DeleteFromCollectionAndRedraw(PictureBox PictureBox_Source, PictureBox PictureBox_Back)
        {
            if ((CollectionGraphicsObjects.GraphicsObjectsSelect.Count == 0) || (CollectionGraphicsObjects.GraphicsObjectsCollection.Count == 0)) {
                return;
            }
            CollectionGraphicsObjectsTools.ObjectG_DeleteFromCollection(CollectionGraphicsObjects.GraphicsObjectsSelect, CollectionGraphicsObjects.GraphicsObjectsDelete, CollectionGraphicsObjects.GraphicsObjectsCollection);
            DrawObjectsToGraphics.ReFreshCollection(CollectionGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, ref BitmapActive, ref BitmapBack, ref GraphicsActive);
            if (ControlDraw.LinkLine_Var.ShowLinkLine_XYZ_Flag) {
                ControlDraw.LinkLine_Var.LinkLineToGrpahics_Add(GraphicsActive);
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
            DrawObjectsToGraphics.GraphicsBack_Create(ControlDraw.GridDraw_Var.GridFlagDraw, ControlDraw.AxisDraw_Var.showAxisXYZ, ref GraphicsBack);
            DrawObjectsToGraphics.GraphicsBack_Create(ControlDraw.GridDraw_Var.GridFlagDraw, ControlDraw.AxisDraw_Var.showAxisXYZ, ref GraphicsActive);
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
            DrawObjectsToGraphics.GraphicsBack_Add(ControlDraw.GridDraw_Var.GridFlagDraw, ControlDraw.AxisDraw_Var.showAxisXYZ, ref GraphicsActive, ref GraphicsBack);
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
            DrawObjectsToGraphics.GraphicsBack_Clear(ControlDraw.GridDraw_Var.GridFlagDraw, ControlDraw.AxisDraw_Var.showAxisXYZ, ref GraphicsBack);
            BitmapActive = (Bitmap)BitmapBack.Clone();
            GraphicsActive = Graphics.FromImage(BitmapActive);
            if (CollectionGraphicsObjects.GraphicsObjectsCollection.Count == 0) { } else DrawObjectsToGraphics.ReFreshCollection(CollectionGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, GraphicsActive);
            if (CollectionGraphicsObjects.GraphicsObjectsSelect.Count == 0) { } else DrawObjectsToGraphics.ReFreshCollection(CollectionGraphicsObjects.GraphicsObjectsSelect, ControlDraw.Color_SelectPoint, GraphicsActive);
            if (ControlDraw.LinkLine_Var.ShowLinkLine_XYZ_Flag) {
                ControlDraw.LinkLine_Var.LinkLineToGrpahics_Add(GraphicsActive);
            }
            PictureBox_Source.Image = (Bitmap)BitmapActive.Clone();
            PictureBox_Source.Refresh();
            PictureBox_Back.Image = (Bitmap)BitmapBack.Clone();
            PictureBox_Back.Refresh();
        }
    }
}
