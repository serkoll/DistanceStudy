using System;
using System.Windows.Forms;

namespace GeometryObjects
{
    /// <summary>Класс для расчета параметров 3D точки</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Point3D : Point2D
    {
        //Переменные для работы с классами
        private PointDraw PointDraw_Var = new PointDraw();

        /// <summary>Инициализация нового экземпляра 3D точки</summary>
        /// <remarks>Исходные координаты точки: X=0; Y=0; Z=0</remarks>
        public Point3D() { new Point2D(); Z = 0; }//Конструктор, устанавливающий исходные значения координат 3D точки

        /// <summary>Инициализирует новый экземпляр 3D точки с указанными координатами</summary>
        /// <remarks></remarks>
        public Point3D(double X, double Y, double Z) { new Point2D(X, Y); this.Z = Z; }//Конструктор, устанавливающий пользовательские значения координат 3D точки

        /// <summary>Инициализирует новый экземпляр 3D точки</summary>
        /// <remarks></remarks>
        public Point3D(Point3D Point3D_Source) { new Point2D(Point3D_Source.X, Point3D_Source.Y); Z = Point3D_Source.Z; }//Конструктор, устанавливающий пользовательские значения координат 3D точки

        /// <summary>Преобразует 2D точку в 3D точку путем добавления третьей координаты</summary>
        /// <remarks></remarks>
        public Point3D(Point2D Point2D_Source, double Z_Value) { new Point2D(Point2D_Source.X, Point2D_Source.Y); Z = Z_Value; }//Конструктор преобразования двумерной точки в трехмерную, с установкой заданного значения третьей координаты (Z)

        /// <summary>Преобразует 2D точку в 3D точку путем добавления третьей координаты</summary>
        /// <remarks></remarks>
        public void TransformPoint2DTo3D(Point2D Point2D_Source, double Z_Value) { base.X = Point2D_Source.X; base.Y = Point2D_Source.Y; Z = Z_Value; }//Метод преобразования двумерной точки в трехмерную, с установкой заданного значения третьей координаты (Z)

        /// <summary>Преобразует 2D точку в 3D точку путем добавления третьей координаты, равной нулю</summary>
        /// <remarks>Координата Z=0</remarks>
        public void TransformPoint2DTo3D(Point2D Point2D_Source) { base.X = Point2D_Source.X; base.Y = Point2D_Source.Y; Z = 0; }//Метод преобразования двумерной точки в трехмерную,//с установкой значения третьей координаты (Z) по умолчанию равной нулю
        //MyClass.PointByCoordinates()

        /// <summary>Передвигает ранее заданную 3D точку
        /// (изменяет коодинаты на указанные величины по осям в 3D)
        /// </summary>
        /// <remarks>Point3D.X += dx; Point3D.Y += dy; Point3D.Z += dz</remarks>
        public void PointMove(double dx, double dy, double dz) { base.X += dx; base.Y += dy; Z += dz; }//Конструктор перемещения на указанные величины по осям в 3D 

        /// <summary>Получает или задает координату Z точки</summary>
        /// <remarks></remarks>
        public double Z { get; set; }

        /// <summary>Получает или задает 3D точку</summary>
        /// <remarks></remarks>
        public Point3D Point { get; set; }

        /// <summary>Получает или задает координаты проекции 3D точки на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlan1X0Y PointOfPlan1X0Y
        {
            get { PointOfPlan1X0Y Ptvar = new PointOfPlan1X0Y(base.X, base.Y); return Ptvar; }
            set { base.X = Point.X; base.Y = Point.Y; }
        } // Свойство проекции 3D точки на плоскость X0Y + Считывание значений координат проекции точки

        /// <summary>Получает или задает координаты проекции 3D точки на плоскость X0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlan2X0Z PointOfPlan2X0Z
        {
            get { PointOfPlan2X0Z PtVar = new PointOfPlan2X0Z(base.X, Z); return PtVar; }
            set { PointOfPlan2X0Z PtVar = new PointOfPlan2X0Z(Point.X, Point.Z); }
        }// Свойство проекции 3D точки на плоскость X0Z + Считывание значений координат проекции точки

        /// <summary>Получает или задает координаты проекции 3D точки на плоскость Y0Z пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlan3Y0Z PointOfPlan3Y0Z
        {
            get { PointOfPlan3Y0Z PtVar = new PointOfPlan3Y0Z(base.Y, Z); return PtVar; }
            set { PointOfPlan3Y0Z PtVar = new PointOfPlan3Y0Z(Point.Y, Point.Z); }
        }// Свойство проекции 3D точки на плоскость Y0Z + Считывание значений координат проекции точки

        public PointDraw Point3DDraw { get { return PointDraw_Var; } set { PointDraw_Var = value; } }

        /// <summary>Получает или задает координаты проекции 3D точки на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlan1X0Y PointOf1PlanX0Y(Point3D Point3D_Source) { PointOfPlan1X0Y PtVar = new PointOfPlan1X0Y(Point3D_Source.X, Point3D_Source.Y); return PtVar; }// Свойство проекции 3D точки на плоскость X0Y

        /// <summary>Возвращает проекцию 3D точки на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlan2X0Z PointOf2PlanX0Z(Point3D Point3D_Source) { PointOfPlan2X0Z PtVar = new PointOfPlan2X0Z(Point3D_Source.X, Point3D_Source.Z); return PtVar; }// Свойство проекции 3D точки на плоскость X0Y

        /// <summary>Возвращает проекцию 3D точки на плоскость X0Y пространственной системы координат</summary>
        /// <remarks></remarks>
        public PointOfPlan3Y0Z PointOf3PlanY0Z(Point3D Point3D_Source) { PointOfPlan3Y0Z PtVar = new PointOfPlan3Y0Z(Point3D_Source.Y, Point3D_Source.Z); return PtVar; }// Свойство проекции 3D точки на плоскость X0Y // PtVar.Y = Point.Y : PtVar.Z = Point.Z

        /// <summary>Конвертирует проекцию 3D точки в GeomObjects.Point2D</summary>
        /// <remarks></remarks>
        public Point2D ConvertPointOfPlanToPoint2D(PointOfPlan1X0Y Point_Source) { PointOfPlan1X0Y PtVar = new PointOfPlan1X0Y(); return PtVar.CnvPoint2D(Point_Source); }// Свойство проекции 3D точки на плоскость X0Y

        /// <summary>Конвертирует проекцию 3D точки в GeomObjects.Point2D</summary>
        /// <remarks></remarks>
        public Point2D ConvertPointOfPlanToPoint2D(PointOfPlan2X0Z Point_Source) { PointOfPlan2X0Z PtVar = new PointOfPlan2X0Z(); return PtVar.CnvPoint2D(Point_Source); }// Свойство проекции 3D точки на плоскость X0Z

        /// <summary> Конвертирует проекцию 3D точки в GeomObjects.Point2D</summary>
        /// <remarks></remarks>
        public Point2D ConvertPointOfPlanToPoint2D(PointOfPlan3Y0Z Point_Source) { PointOfPlan3Y0Z PtVar = new PointOfPlan3Y0Z(); return PtVar.CnvPoint2D(Point_Source); }// Свойство проекции 3D точки на плоскость Y0Z

        /// <summary> Задает 3D точку по трем (горизонтальной, фронтальной, и профильной) проекциям</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="pointPi2"> Фронтальная проекция 3D точки</param>
        /// <param name="pointPi3"> Профильная проекция 3D точки</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D </returns> 
        public Point3D CreatePoint3DBy3Proections(PointOfPlan1X0Y pointPi1, PointOfPlan2X0Z pointPi2, PointOfPlan3Y0Z pointPi3, ref ErrObject errorPoint3D, bool errorMsgBoxFlag)
        {//Функция задания 3D точки по 3-м проекциям без указания осей
            Point3D Point3DByProectVar = new Point3D();
            if (pointPi1 != null & pointPi2 != null & pointPi3 == null) { Point3DByProectVar = CreatePoint3DBy2Proections12(pointPi1, pointPi2, ref errorPoint3D, errorMsgBoxFlag); }
            else if (pointPi1 != null & pointPi2 == null & pointPi3 != null) { Point3DByProectVar = CreatePoint3DBy2Proections13(pointPi1, pointPi3, ref errorPoint3D, errorMsgBoxFlag); }
            else if (pointPi1 == null & pointPi2 != null & pointPi3 != null) { Point3DByProectVar = CreatePoint3DBy2Proections23(pointPi2, pointPi3, ref errorPoint3D, errorMsgBoxFlag); }
            else if (pointPi1 != null & pointPi2 != null & pointPi3 != null)
            {
                Point3DByProectVar = CreatePoint3DBy2Proections12(pointPi1, pointPi2, ref errorPoint3D, errorMsgBoxFlag);
                if (Point3DByProectVar == null) { return null; }//Контроль для проекций 1, 2
                Point3DByProectVar = CreatePoint3DBy2Proections13(pointPi1, pointPi3, ref errorPoint3D, errorMsgBoxFlag);
                if (Point3DByProectVar == null) { return null; }//Контроль для проекций 1, 3
                Point3DByProectVar = CreatePoint3DBy2Proections23(pointPi2, pointPi3, ref errorPoint3D, errorMsgBoxFlag);
                if (Point3DByProectVar == null) { return null; }//Контроль для проекций 2, 3
            }
            else
            {
                errorPoint3D.Number = 4;
                errorPoint3D.Description = "Ошибка задания координат пространственной точки: для задания координат пространственной точки необходимо задать координаты не менее двух ее проекций";
                if (errorMsgBoxFlag)
                {
                    MessageBox.Show(" " + "Для задания координат пространственной точки необходимо задать координаты не менее двух ее проекций", "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
            return Point3DByProectVar;
        }

        /// <summary> Задает 3D точку, заданную двумя (горизонтальной и фронтальной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="pointPi2"> Фронтальная проекция 3D точки</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D </returns>
        public Point3D CreatePoint3DBy2Proections12(PointOfPlan1X0Y pointPi1, PointOfPlan2X0Z pointPi2, ref ErrObject errorPoint3D, bool errorMsgBoxFlag)
        {//Функция задания 3D точки по 3-м проекциям без указания осей
            Point3D Point3DByProectVar = new Point3D();
            string PtProectionName, PtCoordName, CommentBefore, CommentAfter, CommentDownBefore, CommentDownAfter;
            CommentBefore = "Неверно заданы координаты"; CommentAfter = "проекций пространственной точки"; CommentDownBefore = "Значения координтат"; CommentDownAfter = "этих проекций должны быть равны";
            //Контроль первой и второй проекции
            if (pointPi1.X == pointPi2.X)
            {
                Point3DByProectVar.X = pointPi1.X;
                Point3DByProectVar.Y = pointPi1.Y;
                Point3DByProectVar.Z = pointPi2.Z;
                return Point3DByProectVar;
            }
            else
            {
                PtProectionName = "горизонтальной и фронтальной";
                PtCoordName = "X";
                errorPoint3D.Number = 1;
                errorPoint3D.Description = " " + CommentBefore + " " + PtProectionName + " " + CommentAfter + Environment.NewLine + " " + Environment.NewLine + " " + CommentDownBefore + " " + PtCoordName + " " + CommentDownAfter;
                if (errorMsgBoxFlag)
                {
                    MessageBox.Show(" " + CommentBefore + " " + PtProectionName + " " + CommentAfter + Environment.NewLine + " " + Environment.NewLine + " " + CommentDownBefore + " " + PtCoordName + " " + CommentDownAfter, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        /// <summary> Задает 3D точку, заданную двумя (горизонтальной и профильной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi1"> Горизонтальная проекция 3D точки</param>
        /// <param name="pointPi3"> Профильная проекция 3D точки</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D </returns>
        public Point3D CreatePoint3DBy2Proections13(PointOfPlan1X0Y pointPi1, PointOfPlan3Y0Z pointPi3, ref ErrObject errorPoint3D, bool errorMsgBoxFlag)
        { //Функция задания 3D точки по 3-м проекциям без указания осей
            Point3D Point3DByProectVar = new Point3D();
            string PtProectionName, PtCoordName, CommentBefore, CommentAfter, CommentDownBefore, CommentDownAfter;
            CommentBefore = "Неверно заданы координаты"; CommentAfter = "проекций пространственной точки"; CommentDownBefore = "Значения координтат"; CommentDownAfter = "этих проекций должны быть равны";
            //Контроль второй и третьей проекции + Контроль первой и третьей проекции
            if (pointPi1.Y == pointPi3.Y) { Point3DByProectVar.X = pointPi1.X; Point3DByProectVar.Y = pointPi1.Y; Point3DByProectVar.Z = pointPi3.Z; return Point3DByProectVar; }
            else
            {
                PtProectionName = "горизонтальной и профильной";
                PtCoordName = "Y";
                errorPoint3D.Number = 2;
                errorPoint3D.Description = " " + CommentBefore + " " + PtProectionName + " " + CommentAfter + Environment.NewLine + " " + Environment.NewLine + " " + CommentDownBefore + " " + PtCoordName + " " + CommentDownAfter;
                if (errorMsgBoxFlag)
                {
                    MessageBox.Show(" " + CommentBefore + " " + PtProectionName + " " + CommentAfter + Environment.NewLine + " " + Environment.NewLine + " " + CommentDownBefore + " " + PtCoordName + " " + CommentDownAfter, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        /// <summary> Задает 3D точку, заданную двумя (фронтальной и профильной) проекциями</summary>
        /// <remarks> При неправильном заднии проекций возвращает "Nothing" </remarks>
        /// <param name="pointPi2"> Фронтальня проекция 3D точки</param>
        /// <param name="pointPi3"> Профильная проекция 3D точки</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D </returns>
        public Point3D CreatePoint3DBy2Proections23(PointOfPlan2X0Z pointPi2, PointOfPlan3Y0Z pointPi3, ref ErrObject errorPoint3D, bool errorMsgBoxFlag)
        {//Функция задания 3D точки по 3-м проекциям без указания осей
            Point3D Point3DByProectVar = new Point3D();
            string PtProectionName, PtCoordName, CommentBefore, CommentAfter, CommentDownBefore, CommentDownAfter;
            CommentBefore = "Неверно заданы координаты"; CommentAfter = "проекций пространственной точки"; CommentDownBefore = "Значения координтат"; CommentDownAfter = "этих проекций должны быть равны";
            //Контроль второй и третьей проекции
            if (pointPi2.Z == pointPi3.Z) { Point3DByProectVar.X = pointPi2.X; Point3DByProectVar.Y = pointPi3.Y; Point3DByProectVar.Z = pointPi2.Z; return Point3DByProectVar; }
            else
            {
                PtProectionName = "фронтальной и профильной";
                PtCoordName = "Z";
                errorPoint3D.Number = 3;
                errorPoint3D.Description = " " + CommentBefore + " " + PtProectionName + " " + CommentAfter + Environment.NewLine + " " + Environment.NewLine + " " + CommentDownBefore + " " + PtCoordName + " " + CommentDownAfter;
                if (errorMsgBoxFlag)
                {
                    MessageBox.Show(" " + CommentBefore + " " + PtProectionName + " " + CommentAfter + Environment.NewLine + " " + Environment.NewLine + " " + CommentDownBefore + " " + PtCoordName + " " + CommentDownAfter, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        //-------------------- Задание  значений координат точки путем конвертирования текста и контроль соответсвия значению "Nothing" -----------------------


        /// <summary> Задает 3D точку, тремя координатами, представленными в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None"  </remarks>
        /// <param name="X_Text"> Значение первой координаты в формате "String"</param>
        /// <param name="Y_Text"> Значение второй координаты в формате "String"</param>
        /// <param name="Z_Text"> Значение третьей координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public Point3D CreatePoint3DByText(string X_Text, string Y_Text, string Z_Text, PointsPositionControl.CoordinateValue ProectionError)
        { //Контроль не заданных значений координат точки//Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"
            ProectionError = GeometryObjects.PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            bool Xbool = false, Ybool = false, Zbool = false;
            //Контроль наличия отрицательных координат
            if (X_Text == null) { Xbool = true; }
            if (Y_Text == null) { Ybool = true; }
            if (Z_Text == null) { Zbool = true; }
            //Контроль меток для ввода наименований координат в комментарий
            if (Xbool & Ybool & Zbool) { ProectionError = PointsPositionControl.CoordinateValue.XYZ; }
            else if (Xbool & Ybool & Zbool == false) { ProectionError = PointsPositionControl.CoordinateValue.XY; }
            else if (Xbool & Ybool == false & Zbool) { ProectionError = PointsPositionControl.CoordinateValue.XZ; }
            else if (Xbool == false & Ybool & Zbool) { ProectionError = PointsPositionControl.CoordinateValue.YZ; }
            else if (Xbool & Ybool == false & Zbool == false) { ProectionError = PointsPositionControl.CoordinateValue.X; }
            else if (Xbool == false & Ybool & Zbool == false) { ProectionError = PointsPositionControl.CoordinateValue.Y; }
            else if (Xbool == false & Ybool == false & Zbool) { ProectionError = PointsPositionControl.CoordinateValue.Z; } //Значения координат заданы
            else
            {
                ProectionError = GeometryObjects.PointsPositionControl.CoordinateValue.None;
                Point3D Point3DByTextVar = new Point3D(Convert.ToDouble(X_Text), Convert.ToDouble(Y_Text), Convert.ToDouble(Z_Text));
                return Point3DByTextVar;
            }//Точка для вывода
            return null;
        }

        /// <summary> Задает 3D точку, заданную тремя координатами в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None". Позволяет вставлять комментарии до и после индексов координат в MsgBox, возникающий в случае существования значения "Nothing"</remarks>
        /// <param name="X_Text"> Значение первой координаты в формате "String"</param>
        /// <param name="Y_Text"> Значение второй координаты в формате "String"</param>
        /// <param name="Z_Text"> Значение третьей координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <param name="CommentBefore"> Комментарий верхней строки перед индексами координат </param>
        /// <param name="CommentAfter"> Комментарий верхней строки после индексов координат </param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public Point3D CreatePoint3DByText(string X_Text, string Y_Text, string Z_Text, Enum ProectionError, string CommentBefore, string CommentAfter)
        {//Контроль не заданных значений координат точки//Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"
            //CommentBefore - комментарий перед именами координат; CommentAfter - комментарий после имен координат (с новой строки)
            Point3D Point3DByTextVar = new Point3D();//Точка для вывода
            PointsPositionControl.CoordinateValue CoordinateValueVar = PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            string CoordinateName = null;
            //Расчет метки
            Point3DByTextVar = CreatePoint3DByText(X_Text, Y_Text, Z_Text, CoordinateValueVar);
            //Контроль меток для ввода наименований координат в комментарий
            if (CoordinateValueVar == GeometryObjects.PointsPositionControl.CoordinateValue.XYZ) { CoordinateName = " X; Y; Z "; goto ManyCoord; }
            else if (CoordinateValueVar == PointsPositionControl.CoordinateValue.XY) { CoordinateName = " X; Y "; goto ManyCoord; }
            else if (CoordinateValueVar == PointsPositionControl.CoordinateValue.XZ) { CoordinateName = " X; Z "; goto ManyCoord; }
            else if (CoordinateValueVar == PointsPositionControl.CoordinateValue.YZ) { CoordinateName = " Y; Z "; goto ManyCoord; }
            else if (CoordinateValueVar == PointsPositionControl.CoordinateValue.X) { CoordinateName = " X "; goto OneCoord; }
            else if (CoordinateValueVar == PointsPositionControl.CoordinateValue.Y) { CoordinateName = " Y "; goto OneCoord; }
            else if (CoordinateValueVar == PointsPositionControl.CoordinateValue.Z) { CoordinateName = " Z "; goto OneCoord; }
            else { CoordinateValueVar = PointsPositionControl.CoordinateValue.None; ProectionError = CoordinateValueVar; return Point3DByTextVar; }//Значения координат заданы
        ManyCoord://Контроль комментария на случай отсутствия внешнего значения (для нескольких координат)
            if (CommentBefore == null) { CommentBefore = "Отсутсвуют значения координат"; }
            if (CommentAfter == null) { CommentAfter = "Для построения точки должны быть заданы значения всех координат"; }
            MessageBox.Show(" " + CommentBefore + "" + CoordinateName + Environment.NewLine + " " + CommentAfter, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error); ProectionError = CoordinateValueVar;
            return Point3DByTextVar;
        OneCoord://Контроль комментария на случай отсутствия внешнего значения (для одной координаты)
            if (CommentBefore == null) { CommentBefore = "Отсутсвует значение координаты"; }
            if (CommentAfter == null) { CommentAfter = "Для построения точки должны быть заданы значения всех координат"; }
            MessageBox.Show(" " + CommentBefore + "" + CoordinateName + Environment.NewLine + " " + CommentAfter, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error); ProectionError = CoordinateValueVar;
            return Point3DByTextVar;
        }

        /// <summary> Задает 3D точку, заданную тремя координатами в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None". Позволяет вставлять комментарий в MsgBox, возникающий в случае существования значения "Nothing"</remarks>
        /// <param name="X_Text"> Значение первой координаты в формате "String"</param>
        /// <param name="Y_Text"> Значение второй координаты в формате "String"</param>
        /// <param name="Z_Text"> Значение третьей координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <param name="Comment"> Комментарий для пояснения ошибки, возникающей в случае отсутсвия значений параметров</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public Point3D CreatePoint3DByText(string X_Text, string Y_Text, string Z_Text, Enum ProectionError, string Comment)
        {//Контроль не заданных значений координат точки//Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"
            //Comment - пользовательский комментраий, выводимый в MsgBox при отсутствии значений координат точки
            Point3D Point3DByTextVar = new Point3D();//Точка для вывода
            PointsPositionControl.CoordinateValue CoordinateValueVar = GeometryObjects.PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            //Контроль комментария на случай отсутствия внешнего значения (для нескольких координат)
            if (Comment == null) { Point3DByTextVar = CreatePoint3DByText(X_Text, Y_Text, Z_Text, CoordinateValueVar, Comment, Comment); ProectionError = CoordinateValueVar; return Point3DByTextVar; }
            else { Point3DByTextVar = CreatePoint3DByText(X_Text, Y_Text, Z_Text, CoordinateValueVar); MessageBox.Show(Comment, "Контроль ввода координат", MessageBoxButtons.OK, MessageBoxIcon.Error); }//Расчет точки и метки
            ProectionError = CoordinateValueVar;
            return Point3DByTextVar;
        }

        /// <summary> Задает 3D точку, заданную тремя координатами в текстовом формате </summary>
        /// <remarks> При корректном задании значений параметров проекций возвращает значение перечислителя: 0 = "CoordinateValue.None". Позволяет включать\отключать MsgBox, возникающий в случае существования значения "Nothing"</remarks>
        /// <param name="X_Text"> Значение первой координаты в формате "String"</param>
        /// <param name="Y_Text"> Значение второй координаты в формате "String"</param>
        /// <param name="Z_Text"> Значение третьей координаты в формате "String"</param>
        /// <param name="ProectionError"> Значение перечислителя, указывающего индексы координат, для которых отсутствуют значения параметров</param>
        /// <param name="MsgBoxShow"> MessagerBox с комментарием, возникающей в случае отсутсвия значений параметров</param>
        /// <returns> BaseGeometryYVP.GeomObjects.Point3D; в случае отсутсвия значений параметров возвращает возвращает "Nothing" и номер перечислителя "CoordinateValue", указывающего индексы координат, для которых не заданы значения, т.е. имеющие строковое значение "Nothing"</returns>
        public Point3D CreatePoint3DByText(string X_Text, string Y_Text, string Z_Text, Enum ProectionError, bool MsgBoxShow)
        {//Контроль не заданных значений координат точки//Возвращает метку, соответсвующую координатам, для которых значения координат соответсвуют значению "Nothing"//MsgBoxShow включает или отключает MsgBox
            Point3D Point3DByTextVar = new Point3D();//Точка для вывода
            PointsPositionControl.CoordinateValue CoordinateValueVar = PointsPositionControl.CoordinateValue.None;//Исходное значение нумератора
            string CommentVar = null;
            //Включение MsgBox
            if (MsgBoxShow == true) { ProectionError = CoordinateValueVar; Point3DByTextVar = CreatePoint3DByText(X_Text, Y_Text, Z_Text, CoordinateValueVar, CommentVar, CommentVar); }//Расчет точки и метки c отображением MsgBox
            else { ProectionError = CoordinateValueVar; Point3DByTextVar = CreatePoint3DByText(X_Text, Y_Text, Z_Text, CoordinateValueVar); }//Расчет точки и метки без отображения MsgBox
            return Point3DByTextVar;
        }
        /// <summary>Возвращает расстояние от начала координат до 3D точки</summary>
        /// <remarks>По умолчанию начало координат в точке (0; 0; 0)</remarks>
        public double PointLength()
        {
            return Math.Abs(base.X) + Math.Abs(base.Y) + Math.Abs(Z);
        }
        /// <summary>Возвращает расстояние от ранее заданной 3D точки до 3D точки, заданной указанными координатами</summary>
        /// <remarks>По умолчанию ранее заданная 3D точка имеет координаты (0; 0; 0)</remarks>
        public double PointDistantion(double x, double y, double z)
        {
            return Math.Sqrt((base.X - x) * (base.X - x) + (base.Y - y) * (base.Y - y) + (Z - z) * (Z - z));
        }

        /// <summary>Возвращает расстояние от ранее заданной 3D точки до указанной 3D точки</summary>
        /// <remarks>По умолчанию ранее заданная 3D точка имеет координаты (0; 0; 0)</remarks>
        public double PointDistantion(Point3D pt)
        {
            return Math.Sqrt((base.X - pt.X) * (base.X - pt.X) + (base.Y - pt.Y) * (base.Y - pt.Y) + (Z - pt.Z) * (Z - pt.Z));
        }

        /// <summary>Возвращает расстояние от первой 3D точки до второй 3D точки</summary>
        /// <remarks></remarks>
        public double PointDistantion(Point3D Point1, Point3D Point2)
        {
            double d = (Point1.X - Point2.X) * (Point1.X - Point2.X) +
                       (Point1.Y - Point2.Y) * (Point1.Y - Point2.Y) +
                       (Point1.Z - Point2.Z) * (Point1.Z - Point2.Z);
            return Math.Sqrt(d);
        }
        /// <summary>Возвращает значение "TRUE", если совпадают заданные точки</summary>
        /// <remarks></remarks>
        public bool PointsIsPoints(Point3D Point1, Point3D Point2)
        {
            return (PointsIsPoints(Point1, Point2) && (Math.Abs(Point1.Z - Point2.Z) <= base.SolveError)) ? true : false;
        }
        /// <summary>Возвращает значение "TRUE", если все точки заданного массива совпадают</summary>
        /// <remarks></remarks>
        public bool PointsIsPoints(Point3D[] Points)
        {
            bool BoolVar = false;
            for (int i = 0; i < Points.GetUpperBound(0) - 1; i++)
            {
                if (i == Points.GetUpperBound(0)) break;
                if (PointsIsPoints(Points[i], Points[i + 1]))
                {
                    BoolVar = true;
                }
                else
                {
                    BoolVar = false;
                    break;
                }
            }
            return BoolVar;
        }
    }
}

