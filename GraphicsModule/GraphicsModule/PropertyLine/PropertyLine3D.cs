using System.Drawing;
using GeometryObjects;



namespace GraphicsModule
{
    /// <summary>
    /// Класс, содержащий свойства для задания и отрисовки 3D прямой
    /// </summary>
    static class PropertyLine3D
    {
        public static Line3D Line3D = new Line3D(); //экземпляр 3D прямой для отрисовки в Graphics
        public static Point Point0 = new Point();
        public static Point Point1 = new Point();
        public static LineOfPlan1X0Y LineOfPlan1X0YVar = null; // Экземпляр горизонтальной проекции 3D прямой для отрисовки в Graphics
        public static LineOfPlan2X0Z LineOfPlan2X0ZVar = null; // Экземпляр фронтальной проекции 3D прямой для отрисовки в Graphics
        public static LineOfPlan3Y0Z LineOfPlan3Y0ZVar = null; // Экземпляр профильной проекции 3D точки для отрисовки в Graphics

        public static PointOfPlan1X0Y Point0OfPlan1X0Y = null;
        public static PointOfPlan1X0Y Point1OfPlan1X0Y = null;

        public static PointOfPlan2X0Z Point0OfPlan2X0Z = null;
        public static PointOfPlan2X0Z Point1OfPlan2X0Z = null;

        public static PointOfPlan3Y0Z Point0OfPlan3Y0Z = null;
        public static PointOfPlan3Y0Z Point1OfPlan3Y0Z = null;

        public static LineDraw LineDraw3D = new LineDraw();

        public static Pen PenLineOfPlan1X0Y = new Pen(Color.Green, 2);
        public static Pen PenLineOfPlan2X0Z = new Pen(Color.Red, 2);
        public static Pen PenLineOfPlan3Y0Z = new Pen(Color.Blue, 2);

        public static bool FlagLine3D = false;
        public static bool FlagLine3DCreateStop = false;
        /// <summary>
        /// Рассчитывает ширину и высоту квадранта в зависимости от размеров PictureBox
        /// </summary>
        /// <param name="pictureBoxWidth">Ширина PictureBox</param>
        /// <param name="pictureBoxHeight">Высота PictureBox</param>
        /// <param name="frame2DCentre">Центр системы координат</param>
        /// <param name="quadrantNumber">Номер квадранта</param>
        /// <returns>Ширина и высота квадаранта</returns>
        public static int[] CalculateQuadrantWidthHeight(int pictureBoxWidth, int pictureBoxHeight, Point frame2DCentre, int quadrantNumber)
        {
            switch (quadrantNumber)
            {
                case 1:
                case 2: return new int[]
                {
                    frame2DCentre.X,
                    frame2DCentre.Y
                };
                case 3: return new int[]
                {
                    pictureBoxWidth - frame2DCentre.X,
                    frame2DCentre.Y
                };
                default: return null;
            }
        }

        public static void CreateLine3DByDrawProjection(Point pointProjectionSource, Point frame2DCentre)
        {
            var Line3DVar = new Line3D();
            var point03D = new Point3D();
            bool pointOfPlan1X0YFlag = false;
            bool pointOfPlan2X0ZFlag = false;
            bool pointOfPlan3Y0ZFlag = false;
            bool lineOfPlan1X0YFlag = false;
            bool lineOfPlan2X0ZFlag = false;
            bool lineOfPlan3Y0ZFlag = false;
            ErrObject errorLine3D = new ErrObject();
            object pointProjection = point03D.Point3DDraw.TypeOf_ProectionByPoint(pointProjectionSource, frame2DCentre);
            if (pointProjection is PointOfPlan1X0Y)
            {
                if(Point0OfPlan1X0Y == null)
                {
                    Point0OfPlan1X0Y = (PointOfPlan1X0Y)pointProjection;
                    pointOfPlan1X0YFlag = true;
                }
                else
                {
                    LineOfPlan1X0YVar = new LineOfPlan1X0Y(Point0OfPlan1X0Y, (PointOfPlan1X0Y)pointProjection);
                    lineOfPlan1X0YFlag = true;
                }
            }
            if (pointProjection is PointOfPlan2X0Z)
            {
                if (Point0OfPlan2X0Z == null)
                {
                    Point0OfPlan2X0Z = (PointOfPlan2X0Z)pointProjection;
                    pointOfPlan1X0YFlag = true;
                }
                else
                {
                    LineOfPlan2X0ZVar = new LineOfPlan2X0Z(Point0OfPlan2X0Z, (PointOfPlan2X0Z)pointProjection);
                    lineOfPlan2X0ZFlag = true;
                }
            }
            if (pointProjection is PointOfPlan3Y0Z)
            {
                if (Point0OfPlan3Y0Z == null)
                {
                    Point0OfPlan3Y0Z = (PointOfPlan3Y0Z)pointProjection;
                    pointOfPlan3Y0ZFlag = true;
                }
                else
                {
                    LineOfPlan3Y0ZVar = new LineOfPlan3Y0Z(Point0OfPlan3Y0Z, (PointOfPlan3Y0Z)pointProjection);
                    lineOfPlan3Y0ZFlag = true;
                }
            }
            var it = CheckPointProjectionsForLine();
            if (it == 1)
            {
                Point0OfPlan1X0Y = null;
            }
            else if(it == 2)
            {
                Point0OfPlan2X0Z = null;
            }
            else if(it == 3)
            {
                Point0OfPlan3Y0Z = null;
            }

            Line3D = Line3DVar.CreateLine3DBy3Projections(LineOfPlan1X0YVar, LineOfPlan2X0ZVar, LineOfPlan3Y0ZVar, ref errorLine3D, false);
            if (errorLine3D.Number == 1 || errorLine3D.Number == 2 || errorLine3D.Number == 3)
            {
                if (lineOfPlan1X0YFlag)
                {
                    LineOfPlan1X0YVar = null;
                }
                else if (lineOfPlan1X0YFlag)
                {
                    LineOfPlan2X0ZVar = null;
                }
                else if (lineOfPlan1X0YFlag)
                {
                    LineOfPlan3Y0ZVar = null;
                }
            }

            if (Line3D == null)
            {
                FlagLine3D = false;
            }
            else
            {
                FlagLine3DCreateStop = true;

                Line3D.Line_Draw = new LineDraw(Line3D, 
                                                PropertyPoint3D.Pen_PointPlan1X0Y, 
                                                PropertyPoint3D.Pen_PointPlan2X0Z, 
                                                PropertyPoint3D.Pen_PointPlan3Y0Z,
                                                PenLineOfPlan1X0Y,
                                                PenLineOfPlan2X0Z,
                                                PenLineOfPlan3Y0Z,
                                                DrawOperations.GridDraw_Var.GridCenter);
                Line3D.Line_Draw.FlagDrawPointPlan1X0Y = true;
                Line3D.Line_Draw.FlagDrawPointPlan2X0Z = true;
                Line3D.Line_Draw.FlagDrawPointPlan3Y0Z = true;
                Point0OfPlan1X0Y = null;
                Point0OfPlan2X0Z = null;
                Point0OfPlan3Y0Z = null;
                LineOfPlan1X0YVar = null;
                LineOfPlan2X0ZVar = null;
                LineOfPlan3Y0ZVar = null;
            }
        }
        public static void DrawTempPointsProjections(Graphics graphicsSource)
        {
            var drawPoint3DProectionsTemp = new PointDraw();

            drawPoint3DProectionsTemp.Pen_Point1X0Y = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.Pen_Point2X0Z = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.Pen_Point3Y0Z = new Pen(Color.Gray, 2);

            int Radius_PointProection = 2;

            if (Point0OfPlan1X0Y != null)
            {
                drawPoint3DProectionsTemp.DrawPointProection(Point0OfPlan1X0Y, Radius_PointProection, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
            }
            if (Point0OfPlan2X0Z != null)
            {
                drawPoint3DProectionsTemp.DrawPointProection(Point0OfPlan2X0Z, Radius_PointProection, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
            }
            if (Point0OfPlan3Y0Z != null)
            {
                drawPoint3DProectionsTemp.DrawPointProection(Point0OfPlan3Y0Z, Radius_PointProection, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
            }
        }
        public static void DrawTempPointProjection(PointOfPlan1X0Y PointOfPlan1X0YProjection, Graphics graphicsSource)
        {
            var drawPoint3DProectionsTemp = new PointDraw();
            drawPoint3DProectionsTemp.Pen_Point1X0Y = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.DrawPointProection(PointOfPlan1X0YProjection, 2, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
        }
        public static void DrawTempPointProjection(PointOfPlan2X0Z PointOfPlan2X0ZProjection, Graphics graphicsSource)
        {
            var drawPoint3DProectionsTemp = new PointDraw();
            drawPoint3DProectionsTemp.Pen_Point2X0Z = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.DrawPointProection(PointOfPlan2X0ZProjection, 2, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
        }
        public static void DrawTempPointProjection(PointOfPlan3Y0Z PointOfPlan3Y0ZProjection, Graphics graphicsSource)
        {
            var drawPoint3DProectionsTemp = new PointDraw();
            drawPoint3DProectionsTemp.Pen_Point3Y0Z = new Pen(Color.Gray, 2);
            drawPoint3DProectionsTemp.DrawPointProection(PointOfPlan3Y0ZProjection, 2, DrawOperations.GridDraw_Var.GridCenter, ref graphicsSource);
        }
        public static void DrawTempLineProjections(Graphics graphicsSource)
        {
            var drawLine3DProectionsTemp = new LineDraw();

            //drawLine3DProectionsTemp.SetPensValue();
            //drawLine3DProectionsTemp.PenPointsX0Y = PropertyPoint3D.Pen_PointPlan1X0Y;
            //drawLine3DProectionsTemp.PenPointsX0Z = PropertyPoint3D.Pen_PointPlan2X0Z;
            //drawLine3DProectionsTemp.PenPointsY0Z = PropertyPoint3D.Pen_PointPlan3Y0Z;

            //int radiusOfPointsLineProections = 2;



            if (LineOfPlan1X0YVar != null)
            {
                drawLine3DProectionsTemp = new LineDraw(LineOfPlan1X0YVar, null, null,
                                                     PropertyPoint3D.Pen_PointPlan1X0Y, null, null,
                                                     PropertyLine3D.PenLineOfPlan1X0Y, null, null,
                                                     DrawOperations.GridDraw_Var.GridCenter);
                DrawObjectsToGraphics.DrawLine3D(drawLine3DProectionsTemp.LineOfPlan1X0YPositionByFrame,
                           drawLine3DProectionsTemp.LineOfPlan1X0YPositionByPicture,
                           drawLine3DProectionsTemp.PenLineX0Y, drawLine3DProectionsTemp.PenPointsX0Y,
                           DrawOperations.GridDraw_Var.GridCenter,
                           new Point(0, DrawOperations.GridDraw_Var.GridCenter.Y),
                           1,
                           ref graphicsSource);
            }
            if (LineOfPlan2X0ZVar != null)
            {
                drawLine3DProectionsTemp = new LineDraw(null, LineOfPlan2X0ZVar, null,
                                                      null, PropertyPoint3D.Pen_PointPlan2X0Z, null,
                                                      null, PropertyPoint3D.Pen_PointPlan2X0Z, null,
                                                      DrawOperations.GridDraw_Var.GridCenter);
                DrawObjectsToGraphics.DrawLine3D(drawLine3DProectionsTemp.LineOfPlan2X0ZPositionByFrame,
                           drawLine3DProectionsTemp.LineOfPlan2X0ZPositionByPicture,
                           drawLine3DProectionsTemp.PenLineX0Z, drawLine3DProectionsTemp.PenPointsX0Z,
                           DrawOperations.GridDraw_Var.GridCenter,
                           new Point(0, 0),
                           2,
                           ref graphicsSource);
            }
            if (LineOfPlan3Y0ZVar != null)
            {
                drawLine3DProectionsTemp = new LineDraw(null, null, LineOfPlan3Y0ZVar,
                                                      null, null, PropertyPoint3D.Pen_PointPlan3Y0Z,
                                                      null, null, PropertyLine3D.PenLineOfPlan3Y0Z,
                                                      DrawOperations.GridDraw_Var.GridCenter);
                DrawObjectsToGraphics.DrawLine3D(drawLine3DProectionsTemp.LineOfPlan3Y0ZPositionByFrame,
                           drawLine3DProectionsTemp.LineOfPlan3Y0ZPositionByPicture,
                           drawLine3DProectionsTemp.PenLineY0Z, drawLine3DProectionsTemp.PenPointsY0Z,
                           DrawOperations.GridDraw_Var.GridCenter,
                           new Point(DrawOperations.GridDraw_Var.GridCenter.X, 0),
                           3,
                           ref graphicsSource);
            }
        }


        public static void Line2DToLineOfPlan1X0Y(Line2D lineProectionSource, Point frame2DCentre)
        {
            object proectionObject = LineDraw3D.CreateProectionByLine2D(lineProectionSource, frame2DCentre);
            {
                LineOfPlan1X0YVar = (LineOfPlan1X0Y)proectionObject;
                LineOfPlan1X0YVar.Line_Draw = new LineDraw(PropertyLine3D.LineOfPlan1X0YVar, null, null, frame2DCentre);
            }
        }

        public static void Line2DToLineOfPlan2X0Z(Line2D lineProectionSource, Point frame2DCentre)
        {
            object proectionObject = LineDraw3D.CreateProectionByLine2D(lineProectionSource, frame2DCentre);
            {
                LineOfPlan2X0ZVar = (LineOfPlan2X0Z)proectionObject;
                LineOfPlan2X0ZVar.Line_Draw = new LineDraw(null, PropertyLine3D.LineOfPlan2X0ZVar, null, frame2DCentre);
            }
        }

        public static void Line2DToLineOfPlan3Y0Z(Line2D lineProectionSource, Point frame2DCentre)
        {
            object proectionObject = LineDraw3D.CreateProectionByLine2D(lineProectionSource, frame2DCentre);
            {
                LineOfPlan3Y0ZVar = (LineOfPlan3Y0Z)proectionObject;
                LineOfPlan3Y0ZVar.Line_Draw = new LineDraw(null, null, PropertyLine3D.LineOfPlan3Y0ZVar, frame2DCentre);
            }
        }
        /// <summary>
        /// Проверяем координаты
        /// </summary>
        /// <returns></returns>
        public static int CheckPointProjectionsForLine()
        {
            var point3Dtemp = new Point3D();
            var errObj = new ErrObject();
            if (Point0OfPlan1X0Y != null && LineOfPlan1X0YVar == null && (LineOfPlan2X0ZVar != null || LineOfPlan3Y0ZVar != null))
            {
                if (LineOfPlan2X0ZVar != null)
                {
                    var temp = point3Dtemp.CreatePoint3DBy2Proections12(Point0OfPlan1X0Y, LineOfPlan2X0ZVar.Point_0, ref errObj, false);
                    if (temp != null) return 4;
                    temp = point3Dtemp.CreatePoint3DBy2Proections12(Point0OfPlan1X0Y, LineOfPlan2X0ZVar.Point_1, ref errObj, false);
                    if (temp == null) return 1;
                    else return 4;
                }
                else 
                {
                    var temp = point3Dtemp.CreatePoint3DBy2Proections13(Point0OfPlan1X0Y, LineOfPlan3Y0ZVar.Point_0, ref errObj, false);
                    if (temp != null) return 4;
                    temp = point3Dtemp.CreatePoint3DBy2Proections13(Point0OfPlan1X0Y, LineOfPlan3Y0ZVar.Point_1, ref errObj, false);
                    if (temp == null) return 1;
                    else return 4;
                }
            }
            else if (Point0OfPlan2X0Z != null && LineOfPlan2X0ZVar == null && (LineOfPlan1X0YVar != null || LineOfPlan3Y0ZVar != null))
            {
                if (LineOfPlan1X0YVar != null)
                {
                    var temp = point3Dtemp.CreatePoint3DBy2Proections12(LineOfPlan1X0YVar.Point_0, Point0OfPlan2X0Z, ref errObj, false);
                    if (temp != null) return 4;
                    temp = point3Dtemp.CreatePoint3DBy2Proections12(LineOfPlan1X0YVar.Point_1, Point0OfPlan2X0Z, ref errObj, false);
                    if (temp == null) return 2;
                    else return 4;
                }
                else
                {
                    var temp = point3Dtemp.CreatePoint3DBy2Proections23(Point0OfPlan2X0Z, LineOfPlan3Y0ZVar.Point_0, ref errObj, false);
                    if (temp != null) return 4;
                    temp = point3Dtemp.CreatePoint3DBy2Proections23(Point0OfPlan2X0Z, LineOfPlan3Y0ZVar.Point_1, ref errObj, false);
                    if (temp == null) return 2;
                    else return 4;
                }
            }
            else if (Point0OfPlan3Y0Z != null && LineOfPlan3Y0ZVar == null && (LineOfPlan1X0YVar != null || LineOfPlan2X0ZVar != null))
            {
                if (LineOfPlan1X0YVar != null)
                {
                    var temp = point3Dtemp.CreatePoint3DBy2Proections13(LineOfPlan1X0YVar.Point_0, Point0OfPlan3Y0Z, ref errObj, false);
                    if (temp != null) return 4;
                    temp = point3Dtemp.CreatePoint3DBy2Proections13(LineOfPlan1X0YVar.Point_1, Point0OfPlan3Y0Z, ref errObj, false);
                    if (temp == null) return 3;
                    else return 4;
                }
                else
                {
                    var temp = point3Dtemp.CreatePoint3DBy2Proections23(LineOfPlan2X0ZVar.Point_0, Point0OfPlan3Y0Z, ref errObj, false);
                    if (temp != null) return 4;
                    temp = point3Dtemp.CreatePoint3DBy2Proections23(LineOfPlan2X0ZVar.Point_1, Point0OfPlan3Y0Z, ref errObj, false);
                    if (temp == null) return 3;
                    else return 4;
                }
            }
            else return 5;
        }
    }
}
