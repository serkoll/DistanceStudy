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
    /// Класс, содержащий свойства для задания и отрисовки временных проекций прямой
    /// </summary>
    static class PropertyLineProjections
    {
        /// <summary>
        /// Определяет, существует ли временная проекция прямой в плоскости X0Y
        /// </summary>
        /// <remarks>Горизонтальная проекция прямой</remarks>
        public static bool FlagExistenceOfLineOfPlan1X0Y = false;
        /// <summary>
        /// Определяет, существует ли временная проекция прямой в плоскости X0Z
        /// </summary>
        /// <remarks>Фронтальная проекция прямой</remarks>
        public static bool FlagExistenceOfLineOfPlan2X0Z = false;
        /// <summary>
        /// Определяет, существует ли временная проекция прямой в плоскости Y0Z
        /// </summary>
        /// <remarks>Профильная проекция прямой</remarks>
        public static bool FlagExistenceOfLineOfPlan3Y0Z = false;
        /// <summary>
        /// Определяет, активен ли процесс создания временной проекции прямой на плоскость X0Y
        /// </summary>
        public static bool FlagCreateOrNotLineOfPlan1X0Y = false;
        /// <summary>
        /// Определяет, активен ли процесс создания временной проекции прямой на плоскость X0Y
        /// </summary>
        public static bool FlagCreateOrNotLineOfPlan2X0Z = false;
        /// <summary>
        /// Определяет, активен ли процесс создания временной проекции прямой на плоскость X0Y
        /// </summary>
        public static bool FlagCreateOrNotLineOfPlan3Y0Z = false;

        /// <summary>
        /// Первая точка временной проекции прямой на плоскость X0Y
        /// </summary>
        public static PointOfPlan1X0Y Point0LineOfPlan1X0Y = null;
        /// <summary>
        /// Вторая точка временной проекции прямой на плоскость X0Y
        /// </summary>
        public static PointOfPlan1X0Y Point1LineOfPlan1X0Y = null;

        /// <summary>
        /// Первая точка временной проекции прямой на плоскость X0Z
        /// </summary>
        public static PointOfPlan2X0Z Point0LineOfPlan2X0Z = null;
        /// <summary>
        /// Вторая точка временной проекции прямой на плоскость X0Z
        /// </summary>
        public static PointOfPlan2X0Z Point1LineOfPlan2X0Z = null;

        /// <summary>
        /// Первая точка временной проекции прямой на плоскость Y0Z
        /// </summary>
        public static PointOfPlan3Y0Z Point0LineOfPlan3Y0Z = null;
        /// <summary>
        /// Вторая точка временной проекции прямой на плоскость Y0Z
        /// </summary>
        public static PointOfPlan3Y0Z Point1LineOfPlan3Y0Z = null;

        /// <summary>
        /// Временная проекция прямой на плоскость X0Y
        /// </summary>
        public static LineOfPlan1X0Y TempLineOfPlan1X0Y = null;
        /// <summary>
        /// Временная проекция прямой на плоскость X0Z
        /// </summary>
        public static LineOfPlan2X0Z TempLineOfPlan2X0Z = null;
        /// <summary>
        /// Временная проекция прямой на плоскость Y0Z
        /// </summary>
        public static LineOfPlan3Y0Z TempLineOfPlan3Y0Z = null;

        public static void DrawTempPointsProjections(Graphics graphicsSource)
        {
            var drawPoint3DProectionsTemp = new PointDraw();

            drawPoint3DProectionsTemp.Pen_Point1X0Y = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.Pen_Point2X0Z = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.Pen_Point3Y0Z = new Pen(Color.Gray, 2);

            int Radius_PointProection = 2;

            if (Point0LineOfPlan1X0Y != null)
            {
                drawPoint3DProectionsTemp.DrawPointProection(Point0LineOfPlan1X0Y, Radius_PointProection, ControlDraw.GridDraw_Var.GridCenter, ref graphicsSource);
            }
            if (Point0LineOfPlan2X0Z != null)
            {
                drawPoint3DProectionsTemp.DrawPointProection(Point0LineOfPlan2X0Z, Radius_PointProection, ControlDraw.GridDraw_Var.GridCenter, ref graphicsSource);
            }
            if (Point0LineOfPlan3Y0Z != null)
            {
                drawPoint3DProectionsTemp.DrawPointProection(Point0LineOfPlan3Y0Z, Radius_PointProection, ControlDraw.GridDraw_Var.GridCenter, ref graphicsSource);
            }
        }
    }
}
