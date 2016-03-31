using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;

namespace DrawG
{
    /// <summary>
    /// Класс, содержащий инструменты задания и отрисовки ЛИНИЙ СВЯЗИ
    /// </summary>
    class LinkLine_G
    {
        private Point3D Point3D_LLG = new Point3D(); // Экземпляр 3D точки для отрисовки в Graphics
        private Line3D Line3D_LLG = new Line3D();
        private DrawObjectsToGraphics ObjectsDraw_LLG = new DrawObjectsToGraphics(); // Экземпляр инструментов для отрисовки объектов в Graphics


        public bool ShowLinkLine_XYZ_Flag = true; //Метка включения ЛИНИЙ СВЯЗИ (любых)
        public bool LinLineXoY_toX_Flag_LLG = true; //Метка включения ЛИНИЙ СВЯЗИ (от горизонтальной проекции  до оси Х)
        public bool LinLineXoY_toY_Flag_LLG = true; //Метка включения ЛИНИЙ СВЯЗИ (от горизонтальной проекции точки до оси Y)
        /// <summary>
        /// Задает сетку на поверхности Graphics с учетом установленных по умолчанию параметров шага по вертикали и горизонтали, радиуса и цвета узловых точек сетки
        /// </summary>
        /// <param name="Graphics_Source">Заданная поверхность рисования</param>
        /// <remarks>Расчитывает и задает сетку с учетом размеров заданной поверхности рисования Graphics</remarks>
        public void LinkLineToGrpahics_Add(Graphics Graphics_Source)
        {

            //Подключение отображения сетки и (или) осей системы координат
            //1. Контроль существования заданного поля рисования
            if (Graphics_Source == null) return;



            Point3D_LLG.Point3DDraw.Pen_LinkLineXoY_toX = new Pen(Color.LightGreen, 0.3F);
            Point3D_LLG.Point3DDraw.Pen_LinkLineXoY_toY = new Pen(Color.Blue, 0.3F);
            Point3D_LLG.Point3DDraw.Pen_LinkLineXoZ_toX = new Pen(Color.LightGreen, 0.3F);
            Point3D_LLG.Point3DDraw.Pen_LinkLineXoZ_toZ = new Pen(Color.Red, 0.3F);
            Point3D_LLG.Point3DDraw.Pen_LinkLineYoZ_toY = new Pen(Color.Blue, 0.3F);
            Point3D_LLG.Point3DDraw.Pen_LinkLineYoZ_toZ = new Pen(Color.Red, 0.3F);

            Line3D_LLG.Line_Draw.PenLinkLineXoYtoX = new Pen(Color.LightGreen, 0.3F);
            Line3D_LLG.Line_Draw.PenLinkLineXoYtoY = new Pen(Color.Blue, 0.3F);
            Line3D_LLG.Line_Draw.PenLinkLineXoZtoX = new Pen(Color.LightGreen, 0.3F);
            Line3D_LLG.Line_Draw.PenLinkLineXoZtoZ = new Pen(Color.Red, 0.3F);
            Line3D_LLG.Line_Draw.PenLinkLineYoZtoY = new Pen(Color.Blue, 0.3F);
            Line3D_LLG.Line_Draw.PenLinkLineYoZtoZ = new Pen(Color.Red, 0.3F);

            Line3D_LLG.Line_Draw.SetPensValue();

            for (int i = 0; i < CollectionGraphicsObjects.GraphicsObjectsCollection.Count; i++)
            {
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is Point3D)
                {
                    Point3D_LLG.Point3DDraw.DrawLinkLine((Point3D)CollectionGraphicsObjects.GraphicsObjectsCollection[i], ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is PointOfPlan1X0Y)
                {
                    Point3D_LLG.Point3DDraw.DrawLinkLine((PointOfPlan1X0Y)CollectionGraphicsObjects.GraphicsObjectsCollection[i], true, true, true, true, true, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is PointOfPlan2X0Z)
                {
                    Point3D_LLG.Point3DDraw.DrawLinkLine((PointOfPlan2X0Z)CollectionGraphicsObjects.GraphicsObjectsCollection[i], true, true, true, true, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is PointOfPlan3Y0Z)
                {
                    Point3D_LLG.Point3DDraw.DrawLinkLine((PointOfPlan3Y0Z)CollectionGraphicsObjects.GraphicsObjectsCollection[i], true, true, true, true, true, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is LineOfPlan1X0Y)
                {
                    Line3D_LLG.Line_Draw.DrawLinkLine((LineOfPlan1X0Y)CollectionGraphicsObjects.GraphicsObjectsCollection[i], true, true, true, true, true, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is LineOfPlan2X0Z)
                {
                    Line3D_LLG.Line_Draw.DrawLinkLine((LineOfPlan2X0Z)CollectionGraphicsObjects.GraphicsObjectsCollection[i], true, true, true, true, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
                if (CollectionGraphicsObjects.GraphicsObjectsCollection[i] is LineOfPlan3Y0Z)
                {
                    Line3D_LLG.Line_Draw.DrawLinkLine((LineOfPlan3Y0Z)CollectionGraphicsObjects.GraphicsObjectsCollection[i], true, true, true, true, true, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
                }
            }
            if (PropertyPoint3D.PointOfPlan1_X0Y_Var != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyPoint3D.PointOfPlan1_X0Y_Var, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyPoint3D.PointOfPlan2_X0Z_Var != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyPoint3D.PointOfPlan2_X0Z_Var, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyPoint3D.PointOfPlan3_Y0Z_Var != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyPoint3D.PointOfPlan3_Y0Z_Var, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyLine3D.Point0OfPlan1X0Y != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyLine3D.Point0OfPlan1X0Y, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyLine3D.Point0OfPlan2X0Z != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyLine3D.Point0OfPlan2X0Z, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyLine3D.Point0OfPlan3Y0Z != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyLine3D.Point0OfPlan3Y0Z, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }

            if (PropertyLineProjections.Point0LineOfPlan1X0Y != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyLineProjections.Point0LineOfPlan1X0Y, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyLineProjections.Point0LineOfPlan2X0Z != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyLineProjections.Point0LineOfPlan2X0Z, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            if (PropertyLineProjections.Point0LineOfPlan3Y0Z != null)
            {
                Point3D_LLG.Point3DDraw.DrawLinkLine(PropertyLineProjections.Point0LineOfPlan3Y0Z, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toX_Flag_LLG, LinLineXoY_toY_Flag_LLG, LinLineXoY_toY_Flag_LLG, ControlDraw.GridDraw_Var.GridCenter, ref Graphics_Source);
            }
            PropertyPoint3D.Draw_ProectionsTemp(Graphics_Source); //Отрисовка точек проекций
        }
    }
}
