using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeomObjects;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;


namespace DrawG
{
    /// <summary>
    /// Класс, содержащий свойства для задания и отрисовки 3D точки
    /// </summary>
    class PropertyPoint3D
    {
        public static Point3D Point3D_Var = new Point3D(); // Экземпляр 3D точки для отрисовки в Graphics

        public static PointOfPlan1X0Y PointOfPlan1_X0Y_Var = null; // Экземпляр горизонтальной проекции 3D точки для отрисовки в Grahpics
        public static PointOfPlan2X0Z PointOfPlan2_X0Z_Var = null; // Экземпляр фронтальной проекции 3D точки для отрисовки в Graphics
        public static PointOfPlan3Y0Z PointOfPlan3_Y0Z_Var = null; // Экземпляр профильной проекции 3D точки для отрисовки в Graphics

        public static PointDraw Draw_Point3D_Var = new PointDraw(); // Экземпляр класса инструментов отрисовки 3D точки в Graphics
        public static PointsPositionControl PointsPositionControl_Var = new PointsPositionControl();

        public static Pen Pen_PointPlan1X0Y = new Pen(Color.Green, 4);
        public static Pen Pen_PointPlan2X0Z = new Pen(Color.Red, 4);
        public static Pen Pen_PointPlan3Y0Z = new Pen(Color.Blue, 4);

        public static bool FlagPoint_Point3D = false;
        public static bool FlagPoint3D_CreateStop = false;

        /// <summary>
        /// Метод формирования 3D точки на основе указанных проекций
        /// </summary>
        /// <param name="PointProection_Source">Заданная проекция точки</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        public static void Create_Point3DByDrawProection(Point PointProection_Source, Point Frame2D_Centre)
        {
            Point3D Point3D_Sub = new Point3D();
            bool PointOfPlan1_X0Y_Flag = false;
            bool PointOfPlan2_X0Z_Flag = false;
            bool PointOfPlan3_Y0Z_Flag = false;
            ErrObject ErrorPoint3D_Sub = new ErrObject();
            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(PointProection_Source, Frame2D_Centre);
            if (ProectionObject_Var is PointOfPlan1X0Y)
            {
                PointOfPlan1_X0Y_Var = (PointOfPlan1X0Y)ProectionObject_Var;
                PointOfPlan1_X0Y_Flag = true;
            }
            else if (ProectionObject_Var is PointOfPlan2X0Z)
            {
                PointOfPlan2_X0Z_Var = (PointOfPlan2X0Z)ProectionObject_Var;
                PointOfPlan2_X0Z_Flag = true;
            }
            else if (ProectionObject_Var is PointOfPlan3Y0Z)
            {
                PointOfPlan3_Y0Z_Var = (PointOfPlan3Y0Z)ProectionObject_Var;
                PointOfPlan3_Y0Z_Flag = true;
            }
            Point3D_Var = Point3D_Sub.CreatePoint3DBy3Proections(PointOfPlan1_X0Y_Var, PointOfPlan2_X0Z_Var, PointOfPlan3_Y0Z_Var, ref ErrorPoint3D_Sub, false);
            if (ErrorPoint3D_Sub.Number == 1 || ErrorPoint3D_Sub.Number == 2 || ErrorPoint3D_Sub.Number == 3)
            {
                if (PointOfPlan1_X0Y_Flag)
                {
                    PointOfPlan1_X0Y_Var = null;
                }
                else if (PointOfPlan2_X0Z_Flag)
                {
                    PointOfPlan2_X0Z_Var = null;
                }
                else if (PointOfPlan3_Y0Z_Flag)
                {
                    PointOfPlan3_Y0Z_Var = null;
                }
            }

            if (Point3D_Var == null)
            {
                FlagPoint_Point3D = false;
            }
            else
            {
                FlagPoint3D_CreateStop = true;

                Point3D_Var.Point3DDraw = new PointDraw(Point3D_Var, ControlDraw.GridDraw_Var.GridCenter);
                Point3D_Var.Point3DDraw.Pen_Point1X0Y = Pen_PointPlan1X0Y;
                Point3D_Var.Point3DDraw.Pen_Point2X0Z = Pen_PointPlan2X0Z;
                Point3D_Var.Point3DDraw.Pen_Point3Y0Z = Pen_PointPlan3Y0Z;
                Point3D_Var.Point3DDraw.FlagDraw_PointPlan1X0Y = true;
                Point3D_Var.Point3DDraw.FlagDraw_PointPlan2X0Z = true;
                Point3D_Var.Point3DDraw.FlagDraw_PointPlan3Y0Z = true;

                PointOfPlan1_X0Y_Var = null;
                PointOfPlan2_X0Z_Var = null;
                PointOfPlan3_Y0Z_Var = null;
            }
        }
        /// <summary>
        /// Метод отрисовки временной точки, указывающей положение первой указанной проекции до момет=нта окончательного формирования 3D точки 
        /// </summary>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        public static void Draw_ProectionsTemp(Graphics Graphics_Source)
        {
            PointDraw Draw_Point3DProectionsTemp = new PointDraw();

            Draw_Point3DProectionsTemp.Pen_Point1X0Y = new Pen(Color.Gray, 2);
            Draw_Point3DProectionsTemp.Pen_Point2X0Z = new Pen(Color.Gray, 2);
            Draw_Point3DProectionsTemp.Pen_Point3Y0Z = new Pen(Color.Gray, 2);

            if (PointOfPlan1_X0Y_Var != null)
            {
                Draw_Point3DProectionsTemp.DrawPointProection(PointOfPlan1_X0Y_Var, (int)Draw_Point3DProectionsTemp.Pen_Point1X0Y.Width / 2, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PointOfPlan2_X0Z_Var != null)
            {
                Draw_Point3DProectionsTemp.DrawPointProection(PointOfPlan2_X0Z_Var, (int)Draw_Point3DProectionsTemp.Pen_Point2X0Z.Width / 2, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PointOfPlan3_Y0Z_Var != null)
            {
                Draw_Point3DProectionsTemp.DrawPointProection(PointOfPlan3_Y0Z_Var, (int)Draw_Point3DProectionsTemp.Pen_Point3Y0Z.Width / 2, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
        }
        /// <summary>
        /// Определяет вид проекции и формирует соответсвующую проекцию на плоскость X0Y на основе указанной точки
        /// </summary>
        /// <param name="PointProection_Source">Заданная точка</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        public static void PointToPointOfPlan1_X0Y(Point PointProection_Source, Point Frame2D_Centre)
        {
            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(PointProection_Source, Frame2D_Centre);
            if (ProectionObject_Var is PointOfPlan1X0Y)
            {
                PointOfPlan1_X0Y_Var = (PointOfPlan1X0Y)ProectionObject_Var;
                PointOfPlan1_X0Y_Var.Point3D_Draw = new PointDraw(PropertyPoint3D.PointOfPlan1_X0Y_Var, null, null, Frame2D_Centre);
            }
        }
        public static PointOfPlan1X0Y PointToPointOfPlan1X0Y(Point pointProjectionSource, Point frame2DCentre)
        {

            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(pointProjectionSource, frame2DCentre);
            if (ProectionObject_Var is PointOfPlan1X0Y)
            {
                var pointOfPlan1X0YVar = (PointOfPlan1X0Y)ProectionObject_Var;
                pointOfPlan1X0YVar.Point3D_Draw = new PointDraw(PropertyPoint3D.PointOfPlan1_X0Y_Var, null, null, frame2DCentre);
                return pointOfPlan1X0YVar;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Определяет вид проекции и формирует соответсвующую проекцию на плоскость X0Z на основе указанной точки
        /// </summary>
        /// <param name="PointProection_Source">Заданная точка</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        public static void PointToPointOfPlan2_X0Z(Point PointProection_Source, Point Frame2D_Centre)
        {
            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(PointProection_Source, Frame2D_Centre);
            if (ProectionObject_Var is PointOfPlan2X0Z)
            {
                PointOfPlan2_X0Z_Var = (PointOfPlan2X0Z)ProectionObject_Var;
                PointOfPlan2_X0Z_Var.Point3D_Draw = new PointDraw(null, PropertyPoint3D.PointOfPlan2_X0Z_Var, null, Frame2D_Centre);
            }
        }
        public static PointOfPlan2X0Z PointToPointOfPlan2X0Z(Point pointProjectionSource, Point frame2DCentre)
        {

            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(pointProjectionSource, frame2DCentre);
            if (ProectionObject_Var is PointOfPlan2X0Z)
            {
                var pointOfPlan2X0ZVar = (PointOfPlan2X0Z)ProectionObject_Var;
                pointOfPlan2X0ZVar.Point3D_Draw = new PointDraw(null, PropertyPoint3D.PointOfPlan2_X0Z_Var, null, frame2DCentre);
                return pointOfPlan2X0ZVar;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Определяет вид проекции и формирует соответсвующую проекцию на плоскость Y0Z на основе указанной точки
        /// </summary>
        /// <param name="PointProection_Source">Заданная точка</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        public static void PointToPointOfPlan3_Y0Z(Point PointProection_Source, Point Frame2D_Centre)
        {
            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(PointProection_Source, Frame2D_Centre);
            if (ProectionObject_Var is PointOfPlan3Y0Z)
            {
                PointOfPlan3_Y0Z_Var = (PointOfPlan3Y0Z)ProectionObject_Var;
                PointOfPlan3_Y0Z_Var.Point3D_Draw = new PointDraw(null, null, PropertyPoint3D.PointOfPlan3_Y0Z_Var, Frame2D_Centre);
            }
        }
        public static PointOfPlan3Y0Z PointToPointOfPlan3Y0Z(Point pointProjectionSource, Point frame2DCentre)
        {

            object ProectionObject_Var = Draw_Point3D_Var.TypeOf_ProectionByPoint(pointProjectionSource, frame2DCentre);
            if (ProectionObject_Var is PointOfPlan3Y0Z)
            {
                var pointOfPlan3Y0ZVar = (PointOfPlan3Y0Z)ProectionObject_Var;
                pointOfPlan3Y0ZVar.Point3D_Draw = new PointDraw(null, null, PropertyPoint3D.PointOfPlan3_Y0Z_Var, frame2DCentre);
                return pointOfPlan3Y0ZVar;
            }
            else
            {
                return null;
            }
        }

    }
}
