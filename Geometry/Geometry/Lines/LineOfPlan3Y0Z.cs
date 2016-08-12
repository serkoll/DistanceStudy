namespace GeometryObjects
{
    /// <summary>Класс для расчета параметров проекции 3D линии на Y0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class LineOfPlan3Y0Z
    {
        // = Nothing
        private LineDraw LineDraw_Cls = new LineDraw();

        //Базовая точка прямой
        private GeometryObjects.PointOfPlan3Y0Z Point_0_Cls = new GeometryObjects.PointOfPlan3Y0Z();
        //Вторая точка прямой
        private GeometryObjects.PointOfPlan3Y0Z Point_1_Cls = new GeometryObjects.PointOfPlan3Y0Z();

        //Для задания точности расчетов
        private Line2D Line2D_Cls = new Line2D();

        //====================================================================================================
        //================== Конструкторы инициализации параметров двумерной проекции прямой по заданным условиям ==================

        /// <summary>Инициализация нового экземпляра двумерной проекции точки</summary>
        /// <remarks></remarks>
        public LineOfPlan3Y0Z()
        {
            //Конструктор, устанавливающий исходные значения базовой и второй точек линии
        }

        /// <summary>Инициализирует новый экземпляр двумерной проекции прямой по заданным проекциям базовой и второй точек</summary>
        /// <remarks></remarks>
        public LineOfPlan3Y0Z(Point3D Point_0, Point3D Point_1)
        {
            this.Point_0.Y = Point_0.Y;
            this.Point_0.Z = Point_0.Z;
            this.Point_1.Y = Point_1.Y;
            this.Point_1.Z = Point_1.Z;
        }

        /// <summary>Инициализирует новый экземпляр двумерной проекции прямой по заданным проекциям базовой и второй точек</summary>
        /// <remarks></remarks>
        public LineOfPlan3Y0Z(GeometryObjects.PointOfPlan3Y0Z Point_0, GeometryObjects.PointOfPlan3Y0Z Point_1)
        {
            this.Point_0 = Point_0;
            this.Point_1 = Point_1;
        }

        /// <summary>Инициализирует новый экземпляр двумерной проекции точки</summary>
        /// <remarks></remarks>
        public LineOfPlan3Y0Z(Line3D Line_Source)
        {
            Point_0.Y = Line_Source.Point_0.Y;
            Point_0.Z = Line_Source.Point_0.Z;
            Point_1.Y = Line_Source.Point_1.Y;
            Point_1.Z = Line_Source.Point_1.Z;
        }

        /// <summary>Получает или задает проекцию базовой точки прямой</summary>
        /// <remarks></remarks>
        public GeometryObjects.PointOfPlan3Y0Z Point_0
        {
            // Считывание значения X
            get { return Point_0_Cls; }
            set { Point_0_Cls = value; }
        }

        /// <summary>Получает или задает проекцию второй точки прямой</summary>
        /// <remarks></remarks>
        public GeometryObjects.PointOfPlan3Y0Z Point_1
        {
            // Считывание значения X
            get { return Point_1_Cls; }
            set { Point_1_Cls = value; }
        }

        /// <summary>Получает или задает точность расчета двумерных проекций прямых</summary>
        /// <remarks>Значение по умолчанию 0,001</remarks>
        public double SolveError
        {
            // Свойство значения точности расчета
            // Считывание значения точности расчета
            get { return Line2D_Cls.SolveError; }
            // Установка значения точности расчета
            set { Line2D_Cls.SolveError = value; }
        }

        /// <summary>
        /// Получает или задает инструменты для отрисовки прямой
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public LineDraw Line_Draw
        {
            //Считывание значений
            get { return LineDraw_Cls; }
            set { LineDraw_Cls = value; }
        }

        //====================================================================================================
        //================== Методы ввода-вывода (расчета) параметров двумерной проекции прямой по заданным условиям ==================

        /// <summary>Конвертирует заданную проекцию прямой на плоскость X0Y в GeomObjects.Line2D</summary>
        /// <param name="LineProjection">Заданная прекция прямой</param>
        /// <remarks></remarks>
        public Line2D CnvLine2D(LineOfPlan3Y0Z LineProjection)
        {
            Line2D LineCalc = new Line2D(Point_0_Cls.CnvPoint2D(LineProjection.Point_0), Point_1_Cls.CnvPoint2D(LineProjection.Point_1));
            return LineCalc;
        }

    }
}
