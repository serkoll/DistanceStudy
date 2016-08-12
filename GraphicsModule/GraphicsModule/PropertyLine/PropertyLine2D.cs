using System.Drawing;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Класс, содержащий свойства для задания и отрисовки линии
    /// </summary>
    static class PropertyLine2D
    {
        public static Line2D Line2DVar = null;

        public static Color LineColor = Color.Black; //Цвет линии для отрисовки
        public static Color PointsColor = Color.Black; //Цвет точек для отрисовки
        public static int PointsDiametre = 3; //Диаметр точки для отрисовки

        //public static LineDraw DrawLine2D = new LineDraw(); // Экземпляр класса инструментов отрисовки 3D точки в Graphics

        public static bool LineFlag = false;
        public static bool LineStopCreate = false;

        public static void CreateLine2D(Point pointSource)
        {
            if (!LineFlag)
            {
                Line2DVar = new Line2D();
                Line2DVar.Point_0.X = pointSource.X;
                Line2DVar.Point_0.Y = pointSource.Y;
                LineFlag = true;
            }
            else
            {
                Line2DVar.Point_1.X = pointSource.X;
                Line2DVar.Point_1.Y = pointSource.Y;
                LineFlag = false;
                PropertyLine2D.LineStopCreate = true;
            }
        }
        public static void DrawTempPoint(Point pointTempSource, ref Graphics graphicsSource)
        {
            Pen pen = new Pen(PropertyPoint.Color_Point, PropertyPoint.Diametre_Point);
            graphicsSource.DrawEllipse(pen, (int)(pointTempSource.X - PropertyPoint.Diametre_Point / 2), (int)(pointTempSource.Y - PropertyPoint.Diametre_Point / 2), (int)(PropertyPoint.Diametre_Point), (int)(PropertyPoint.Diametre_Point));
        }

        public static void DrawTempPointWithLinkLine(Point pointTempSource, ref Graphics graphicsSource)
        {
            Pen pen = new Pen(PropertyPoint.Color_Point, PropertyPoint.Diametre_Point);
            graphicsSource.DrawEllipse(pen, (int)(pointTempSource.X - PropertyPoint.Diametre_Point / 2), (int)(pointTempSource.Y - PropertyPoint.Diametre_Point / 2), (int)(PropertyPoint.Diametre_Point), (int)(PropertyPoint.Diametre_Point));
        }
    }
}
