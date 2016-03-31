using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeomObjects.Points
{
    /// <summary>Класс отрисовки точки </summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class PointDraw
    {
        //Экземпляры переменных для отрисовки точек в реальных координатах картинки
        private Point Point3DAxonometry_PositionByPicture_Var = new System.Drawing.Point();
        private Point PointPlan1X0Y_PositionByPicture_Var = new System.Drawing.Point();
        private Point PointPlan2X0Z_PositionByPicture_Var = new System.Drawing.Point();
        private Point PointPlan3Y0Z_PositionByPicture_Var = new System.Drawing.Point();
        //Экземпляры переменных для отрисовки точек с учетом корректировок их положения в зависимости от заданного центра картинки, толщины пера и др.
        private Point Point3D_Axonometry_PositionByFrame_Var = new System.Drawing.Point();
        private Point PointPlan1X0Y_PositionByFrame_Var = new System.Drawing.Point();
        private Point PointPlan2X0Z_PositionByFrame_Var = new System.Drawing.Point();
        private Point PointPlan3Y0Z_PositionByFrame_Var = new System.Drawing.Point();
        //Экземпляры переменных для отрисовки точек
        private Pen Pen_Point3D_Axonometry_Var = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_Point1X0Y_Var = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_Point2X0Z_Var = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_Point3Y0Z_Var = new System.Drawing.Pen(Color.Black, 1);

        private bool FlagDraw_PointPlan1X0Y_Cls = true;//Флаг необходимости отрисовки горизонтальной проекции
        private bool FlagDraw_PointPlan2X0Z_Cls = true;//Флаг необходимости отрисовки фронтальной проекции
        private bool FlagDraw_PointPlan3Y0Z_Cls = true;//Флаг необходимости отрисовки профильной проекции

        //Экземпляры переменных для отрисовки линий связи проекций 3D точки
        private Pen Pen_LinkLineXoY_toX_Cls = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_LinkLineXoY_toY_Cls = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_LinkLineXoZ_toX_Cls = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_LinkLineXoZ_toZ_Cls = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_LinkLineYoZ_toY_Cls = new System.Drawing.Pen(Color.Black, 1);
        private Pen Pen_LinkLineYoZ_toZ_Cls = new System.Drawing.Pen(Color.Black, 1);

        //---------------------------------- Конструкторы и методы ----------------------------------------

        /// <summary>Инициализация нового экземпляра PointDraw</summary>
        public PointDraw()
        {
            //Экземпляры переменных для отрисовки точек
            this.Point3DAxonometry_PositionByPicture = new System.Drawing.Point();
            this.PointPlan1X0Y_PositionByPicture = new System.Drawing.Point();
            this.PointPlan2X0Z_PositionByPicture = new System.Drawing.Point();
            this.PointPlan3Y0Z_PositionByPicture = new System.Drawing.Point();
            //Экземпляры переменных для отрисовки точек
            this.Point3D_Axonometry_PositionByFrame_Var = new System.Drawing.Point();
            this.PointPlan1X0Y_PositionByFrame = new System.Drawing.Point();
            this.PointPlan2X0Z_PositionByFrame = new System.Drawing.Point();
            this.PointPlan3Y0Z_PositionByFrame = new System.Drawing.Point();
        }

        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="Point3D_Source">Заданная 3D точка</param>
        /// <remarks></remarks>
        public PointDraw(GeomObjects.Points.Point3D Point3D_Source)
        {
            //Экземпляры переменных для отрисовки точек
            this.Point3DAxonometry_PositionByPicture = this.CnvPoint3D_ToAxonometryPoint(Point3D_Source);
            this.PointPlan1X0Y_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan1X0Y);
            this.PointPlan2X0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan2X0Z);
            this.PointPlan3Y0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan3Y0Z);
            //Экземпляры переменных для отрисовки точек
            this.Point3D_Axonometry_PositionByFrame_Var = new System.Drawing.Point();
            this.PointPlan1X0Y_PositionByFrame = new System.Drawing.Point();
            this.PointPlan2X0Z_PositionByFrame = new System.Drawing.Point();
            this.PointPlan3Y0Z_PositionByFrame = new System.Drawing.Point();

        }

        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="Point3D_Source">Заданная 3D точка</param>
        /// <remarks></remarks>
        public PointDraw(GeomObjects.Points.Point3D Point3D_Source, System.Drawing.Point FrameCentre_Source)
        {
            //Экземпляры переменных для отрисовки точек
            this.Point3DAxonometry_PositionByPicture = this.CnvPoint3D_ToAxonometryPoint(Point3D_Source);
            this.PointPlan1X0Y_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan1X0Y);
            this.PointPlan2X0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan2X0Z);
            this.PointPlan3Y0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan3Y0Z);

            //Скорректированные координаты точек отрисовки проекций 3D точки относительно положения заданной системы координат на изображении
            this.Point3D_Axonometry_PositionByFrame_Var = this.PointPositionCorrection(this.Point3DAxonometry_PositionByPicture, this.Pen_Point3D_Axonometry.Width, FrameCentre_Source);


            this.PointPlan1X0Y_PositionByFrame = this.PointPositionCorrection(this.PointPlan1X0Y_PositionByPicture, this.Pen_Point1X0Y.Width, FrameCentre_Source);
            this.PointPlan2X0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan2X0Z_PositionByPicture, this.Pen_Point2X0Z.Width, FrameCentre_Source);
            this.PointPlan3Y0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan3Y0Z_PositionByPicture, this.Pen_Point3Y0Z.Width, FrameCentre_Source);
        }



        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="Point3D_Source">Заданная 3D точка</param>
        /// <remarks></remarks>
        public PointDraw(GeomObjects.Points.Point3D Point3D_Source, int PointX0Y_Diametre, int PointX0Z_Diametre, int PointY0Z_Diametre, System.Drawing.Point FrameCentre_Source)
        {
            //Экземпляры переменных для отрисовки точек
            this.Point3DAxonometry_PositionByPicture = this.CnvPoint3D_ToAxonometryPoint(Point3D_Source);
            this.PointPlan1X0Y_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan1X0Y);
            this.PointPlan2X0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan2X0Z);
            this.PointPlan3Y0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(Point3D_Source.PointOfPlan3Y0Z);

            //Скорректированные координаты точек отрисовки проекций 3D точки относительно положения заданной системы координат на изображении
            this.Point3D_Axonometry_PositionByFrame_Var = this.PointPositionCorrection(this.Point3DAxonometry_PositionByPicture, PointX0Y_Diametre, FrameCentre_Source);
            this.PointPlan1X0Y_PositionByFrame = this.PointPositionCorrection(this.PointPlan1X0Y_PositionByPicture, PointX0Y_Diametre, FrameCentre_Source);
            this.PointPlan2X0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan2X0Z_PositionByPicture, PointX0Z_Diametre, FrameCentre_Source);
            this.PointPlan3Y0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan3Y0Z_PositionByPicture, PointY0Z_Diametre, FrameCentre_Source);

        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw по трем проекциям 3D точки
        /// </summary>
        /// <param name="PointOfPlan1_X0Y_Source">Заданная горизонтальная проекция 3D точки</param>
        /// <param name="PointOfPlan2_X0Z_Source">Заданная фронтальная проекция 3D точки</param>
        /// <param name="PointOfPlan3_Y0Z_Source">Заданная профильная проекция 3D точки</param>
        /// <remarks>В случае отсутсвия даннаых о проекции в качестве соответсвующего входного фактора следует установить значение "null"</remarks>
        public PointDraw(PointOfPlan1X0Y PointOfPlan1_X0Y_Source, PointOfPlan2X0Z PointOfPlan2_X0Z_Source, PointOfPlan3Y0Z PointOfPlan3_Y0Z_Source)
        {
            if (PointOfPlan1_X0Y_Source != null)
            {
                this.PointPlan1X0Y_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan1_X0Y_Source);
                this.PointPlan1X0Y_PositionByFrame = new System.Drawing.Point();
            }
            if (PointOfPlan2_X0Z_Source != null)
            {
                this.PointPlan2X0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan2_X0Z_Source);
                this.PointPlan2X0Z_PositionByFrame = new System.Drawing.Point();
            }
            if (PointOfPlan3_Y0Z_Source != null)
            {
                this.PointPlan3Y0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan3_Y0Z_Source);
                this.PointPlan3Y0Z_PositionByFrame = new System.Drawing.Point();
            }
        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="PointOfPlan1_X0Y_Source">Заданная горизонтальная проекция 3D точки</param>
        /// <param name="PointOfPlan2_X0Z_Source">Заданная фронтальная проекция 3D точки</param>
        /// <param name="PointOfPlan3_Y0Z_Source">Заданная профильная проекция 3D точки</param>
        /// <param name="FrameCentre_Source">Точка, соотвествующая центру заданной системе координат</param>
        public PointDraw(PointOfPlan1X0Y PointOfPlan1_X0Y_Source, PointOfPlan2X0Z PointOfPlan2_X0Z_Source, PointOfPlan3Y0Z PointOfPlan3_Y0Z_Source, System.Drawing.Point FrameCentre_Source)
        {
            if (PointOfPlan1_X0Y_Source != null)
            {
                this.PointPlan1X0Y_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan1_X0Y_Source);
                this.PointPlan1X0Y_PositionByFrame = this.PointPositionCorrection(this.PointPlan1X0Y_PositionByPicture, this.Pen_Point1X0Y.Width, FrameCentre_Source);
            }
            if (PointOfPlan2_X0Z_Source != null)
            {
                this.PointPlan2X0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan2_X0Z_Source);
                this.PointPlan2X0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan2X0Z_PositionByPicture, this.Pen_Point2X0Z.Width, FrameCentre_Source);
            }
            if (PointOfPlan3_Y0Z_Source != null)
            {
                this.PointPlan3Y0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan3_Y0Z_Source);
                this.PointPlan3Y0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan3Y0Z_PositionByPicture, this.Pen_Point3Y0Z.Width, FrameCentre_Source);
            }
        }
        /// <summary>
        /// Инициализация нового экземпляра PointDraw
        /// </summary>
        /// <param name="PointOfPlan1_X0Y_Source">Заданная горизонтальная проекция 3D точки</param>
        /// <param name="PointOfPlan2_X0Z_Source">Заданная фронтальная проекция 3D точки</param>
        /// <param name="PointOfPlan3_Y0Z_Source">Заданная профильная проекция 3D точки</param>
        /// <param name="PointX0Y_Diametre">Диаметр инструмента рисования горизонтальной проекции 3D точки</param>
        /// <param name="PointX0Z_Diametre">Диаметр инструмента рисования фронтальной проекции 3D точки</param>
        /// <param name="PointY0Z_Diametre">Диаметр инструмента рисования профильной проекции 3D точки</param>
        /// <param name="FrameCentre_Source">Точка, соотвествующая центру заданной системе координат</param>
        public PointDraw(PointOfPlan1X0Y PointOfPlan1_X0Y_Source, PointOfPlan2X0Z PointOfPlan2_X0Z_Source, PointOfPlan3Y0Z PointOfPlan3_Y0Z_Source, int PointX0Y_Diametre, int PointX0Z_Diametre, int PointY0Z_Diametre, System.Drawing.Point FrameCentre_Source)
        {
            if (PointOfPlan1_X0Y_Source != null)
            {
                this.PointPlan1X0Y_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan1_X0Y_Source);
                this.PointPlan1X0Y_PositionByFrame = this.PointPositionCorrection(this.PointPlan1X0Y_PositionByPicture, PointX0Y_Diametre, FrameCentre_Source);
            }
            if (PointOfPlan2_X0Z_Source != null)
            {
                this.PointPlan2X0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan2_X0Z_Source);
                this.PointPlan2X0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan2X0Z_PositionByPicture, PointX0Z_Diametre, FrameCentre_Source);
            }
            if (PointOfPlan3_Y0Z_Source != null)
            {
                this.PointPlan3Y0Z_PositionByPicture = this.CnvPoint3DProjection_ToPoint(PointOfPlan3_Y0Z_Source);
                this.PointPlan3Y0Z_PositionByFrame = this.PointPositionCorrection(this.PointPlan3Y0Z_PositionByPicture, PointY0Z_Diametre, FrameCentre_Source);
            }
        }

        //---------------------------------- Свойства ----------------------------------------

        /// <summary>
        /// Получает или задает координаты проекции 3D точки на плоскость аксонометрической системы координат
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Point Point3DAxonometry_PositionByPicture
        {//Свойство проекции 3D точки на плоскость X0Y
            get { return this.Point3DAxonometry_PositionByPicture_Var; }
            set { this.Point3DAxonometry_PositionByPicture_Var = value; }
        }

        /// <summary>
        /// Получает или задает координаты точки рисования для горизонтальной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Point PointPlan1X0Y_PositionByPicture
        {//Свойство точки рисования для горизонтальной проекции 3D точки 
            get { return this.PointPlan1X0Y_PositionByPicture_Var; }
            set { this.PointPlan1X0Y_PositionByPicture_Var = value; }
        }

        /// <summary>
        /// Получает или задает координаты точки рисования для фронтальной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Point PointPlan2X0Z_PositionByPicture
        {//Свойство точки рисования для фронтальной проекции 3D точки 
            get { return this.PointPlan2X0Z_PositionByPicture_Var; }
            set { this.PointPlan2X0Z_PositionByPicture_Var = value; }
        }

        /// <summary>
        /// Получает или задает координаты точки рисования для профильной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Point PointPlan3Y0Z_PositionByPicture
        {//Свойство точки рисования для профильной проекции 3D точки 
            get { return this.PointPlan3Y0Z_PositionByPicture_Var; }
            set { this.PointPlan3Y0Z_PositionByPicture_Var = value; }
        }

        /// <summary>
        /// Получает или задает скорректированные координаты проекции 3D точки на плоскость аксонометрической системы координат
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Возвращает или задает координаты точек с учетом корректировок их положения в зависимости от заданного центра картинки, толщины пера и др.</remarks>
        public System.Drawing.Point Point3D_Axonometry_PositionByFrame
        {//Свойство проекции 3D точки на плоскость X0Y
            get { return this.Point3D_Axonometry_PositionByFrame_Var; }
            set { this.Point3D_Axonometry_PositionByFrame_Var = value; }
        }

        /// <summary>
        /// Получает или задает скорректированные координаты точки рисования для горизонтальной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Возвращает или задает координаты точек с учетом корректировок их положения в зависимости от заданного центра картинки, толщины пера и др.</remarks>
        public System.Drawing.Point PointPlan1X0Y_PositionByFrame
        {//Свойство точки рисования для горизонтальной проекции 3D точки 
            get { return this.PointPlan1X0Y_PositionByFrame_Var; }
            set { this.PointPlan1X0Y_PositionByFrame_Var = value; }
        }

        /// <summary>
        /// Получает или задает скорректированные координаты точки рисования для фронтальной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Возвращает или задает координаты точек с учетом корректировок их положения в зависимости от заданного центра картинки, толщины пера и др.</remarks>
        public System.Drawing.Point PointPlan2X0Z_PositionByFrame
        {//Свойство точки рисования для фронтальной проекции 3D точки 
            get { return this.PointPlan2X0Z_PositionByFrame_Var; }
            set { this.PointPlan2X0Z_PositionByFrame_Var = value; }
        }

        /// <summary>
        /// Получает или задает скорректированные координаты точки рисования для профильной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>Возвращает или задает координаты точек с учетом корректировок их положения в зависимости от заданного центра картинки, толщины пера и др.</remarks>
        public System.Drawing.Point PointPlan3Y0Z_PositionByFrame
        {//Свойство точки рисования для профильной проекции 3D точки 
            get { return this.PointPlan3Y0Z_PositionByFrame_Var; }
            set { this.PointPlan3Y0Z_PositionByFrame_Var = value; }
        }


        /// <summary>
        /// Получает или задает параметры инструмента рисования аксонометрической проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_Point3D_Axonometry
        {//Свойство инструмента рисования аксонометрической проекции 3D точки 
            get { return this.Pen_Point3D_Axonometry_Var; }
            set { this.Pen_Point3D_Axonometry_Var = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования горизонтальной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_Point1X0Y
        {//Свойство инструмента рисования горизонтальной проекции 3D точки 
            get { return this.Pen_Point1X0Y_Var; }
            set { this.Pen_Point1X0Y_Var = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования фронтальной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_Point2X0Z
        {//Свойство инструмента рисования фронтальной проекции 3D точки 
            get { return this.Pen_Point2X0Z_Var; }
            set { this.Pen_Point2X0Z_Var = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования профильной проекции 3D точки 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_Point3Y0Z
        {//Свойство инструмента рисования профильной проекции 3D точки 
            get { return this.Pen_Point3Y0Z_Var; }
            set { this.Pen_Point3Y0Z_Var = value; }
        }

        /// <summary>
        /// Получает или задает флаг необходимости отрисовки горизонтальной проекции
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool FlagDraw_PointPlan1X0Y
        {//Свойство флага рисования горизонтальной проекции 3D точки 
            get { return this.FlagDraw_PointPlan1X0Y_Cls; }
            set { this.FlagDraw_PointPlan1X0Y_Cls = value; }
        }

        /// <summary>
        /// Получает или задает флаг необходимости отрисовки фронтальной проекции
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool FlagDraw_PointPlan2X0Z
        {//Свойство флага рисования фронтальной проекции 3D точки 
            get { return this.FlagDraw_PointPlan2X0Z_Cls; }
            set { this.FlagDraw_PointPlan2X0Z_Cls = value; }
        }

        /// <summary>
        /// Получает или задает флаг необходимости отрисовки профильной проекции
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool FlagDraw_PointPlan3Y0Z
        {//Свойство флага рисования профильной проекции 3D точки 
            get { return this.FlagDraw_PointPlan3Y0Z_Cls; }
            set
            {
                this.FlagDraw_PointPlan3Y0Z_Cls = value;
            }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования вертикальной линии связи горизонтальной проекции 3D точки (направленной к оси X)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_LinkLineXoY_toX
        {//Свойство инструмента рисования вертикальной линии связи горизонтальной проекции 3D точки (направленной к оси X)
            get { return this.Pen_LinkLineXoY_toX_Cls; }
            set { this.Pen_LinkLineXoY_toX_Cls = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования горизонтальной линии связи, дуги и вертикальной линии связи (для P3) горизонтальной проекции 3D точки (направленных к оси Y)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_LinkLineXoY_toY
        {//Свойство инструмента рисования горизонтальной линии связи, дуги и вертикальной линии связи (для P3) горизонтальной проекции 3D точки (направленных к оси Y)
            get { return this.Pen_LinkLineXoY_toY_Cls; }
            set { this.Pen_LinkLineXoY_toY_Cls = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования вертикальной линий связи фронтальной проекции 3D точки (направленной к оси X)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_LinkLineXoZ_toX
        {//Свойство инструмента рисования вертикальной линий связи фронтальной проекции 3D точки (направленной к оси X)
            get { return this.Pen_LinkLineXoZ_toX_Cls; }
            set { this.Pen_LinkLineXoZ_toX_Cls = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования горизонтальной линий связи фронтальной проекции 3D точки (направленной к оси Z)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_LinkLineXoZ_toZ
        {//Свойство инструмента рисования горизонтальной линий связи фронтальной проекции 3D точки (направленной к оси Z)
            get { return this.Pen_LinkLineXoZ_toZ_Cls; }
            set { this.Pen_LinkLineXoZ_toZ_Cls = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования вертикальной линий связи профильной проекции 3D точки (направленной к оси Y)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_LinkLineYoZ_toY
        {//Свойство инструмента рисования вертикальной линий связи профильной проекции 3D точки (направленной к оси Y)
            get { return this.Pen_LinkLineYoZ_toY_Cls; }
            set { this.Pen_LinkLineYoZ_toY_Cls = value; }
        }

        /// <summary>
        /// Получает или задает параметры инструмента рисования горизонтальной линий связи профильной проекции 3D точки (направленной к оси Z)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Pen Pen_LinkLineYoZ_toZ
        {//Свойство инструмента рисования горизонтальной линий связи профильной проекции 3D точки (направленной к оси Z)
            get { return this.Pen_LinkLineYoZ_toZ_Cls; }
            set { this.Pen_LinkLineYoZ_toZ_Cls = value; }
        }

        //======================== Функции преобразования объектов BaseGeometryYVP.GeomObjects.Point3D в System.Drawing.Point ========================
        //-------------------------- Функции преобразования без корректировки центра системы координат и пера для рисования --------------------------

        /// <summary>
        /// Конвертирует заданную проекцию 3D точки на плоскость X0Y в System.Drawing.Point
        /// </summary>
        /// <param name="PointProjection">Заданная проекция 3D точки на плоскость X0Y</param>
        /// <returns>Point.X = -PointOfPlan1_X0Y.X; Point.Y = PointOfPlan1_X0Y.Y</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0 и расположено не в крайней или угловой точке изображения</remarks>
        public System.Drawing.Point CnvPoint3DProjection_ToPoint(GeomObjects.Points.PointOfPlan1X0Y PointProjection)
        {
            System.Drawing.Point PointVar = new System.Drawing.Point(-(int)PointProjection.X, (int)PointProjection.Y);
            return PointVar;
        }

        /// <summary>
        /// Конвертирует заданную проекцию 3D точки на плоскость X0Z в System.Drawing.Point
        /// </summary>
        /// <param name="PointProjection">Заданная проекция 3D точки на плоскость X0Z</param>
        /// <returns>Point.X = -PointOfPlan2_X0Z.X; Point.Y = -PointOfPlan2_X0Z.Z</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0 и расположено не в крайней или угловой точке изображения</remarks>
        public System.Drawing.Point CnvPoint3DProjection_ToPoint(GeomObjects.Points.PointOfPlan2X0Z PointProjection)
        {
            System.Drawing.Point PointVar = new System.Drawing.Point(-(int)PointProjection.X, -(int)PointProjection.Z);
            return PointVar;
        }

        /// <summary>
        /// Конвертирует заданную проекцию 3D точки на плоскость Y0Z в System.Drawing.Point
        /// </summary>
        /// <param name="PointProjection">Заданная проекция 3D точки на плоскость Y0Z</param>
        /// <returns>Point.X = PointOfPlan2_Y0Z.Y; Point.Y = -PointOfPlan2_Y0Z.Z</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0 и расположено не в крайней или угловой точке изображения</remarks>
        public System.Drawing.Point CnvPoint3DProjection_ToPoint(GeomObjects.Points.PointOfPlan3Y0Z PointProjection)
        {
            System.Drawing.Point PointVar = new System.Drawing.Point((int)PointProjection.Y, -(int)PointProjection.Z);
            return PointVar;
        }

        // ''' <summary></summary>
        /// <summary>
        /// Преобразует точку формата BaseGeometryYVP.GeomObjects.Point2D в System.Drawing.Point
        /// </summary>
        /// <param name="Point2D_Source">Заданная 2D точка</param>
        /// <returns>Point.X = Point2D_Source.X; Point.Y = Point2D_Source.Y</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0</remarks>
        public System.Drawing.Point CnvPoint2D_ToPoint(GeomObjects.Points.Point2D Point2D_Source)
        {//Преобразует точку формата BaseGeometryYVP.GeomObjects.Point2D в System.Drawing.Point
            System.Drawing.Point PtVar = new System.Drawing.Point((int)Point2D_Source.X, (int)Point2D_Source.Y);
            return PtVar;
        }

        /// <summary>
        /// Преобразует точку формата BaseGeometryYVP.GeomObjects.Point2D в System.Drawing.PointF
        /// </summary>
        /// <param name="Point2D_Source">Заданная 2D точка</param>
        /// <returns>PointF.X = Point2D_Source.X; PointF.Y = Point2D_Source.Y</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0</remarks>
        public System.Drawing.PointF CnvPoint2D_ToPointF(GeomObjects.Points.Point2D Point2D_Source)
        {//Преобразует точку формата BaseGeometryYVP.GeomObjects.Point2D в System.Drawing.PointF
            System.Drawing.PointF PtVar = new System.Drawing.PointF((float)Point2D_Source.X, (float)Point2D_Source.Y);
            return PtVar;
        }

        /// <summary>
        /// Преобразует точку формата BaseGeometryYVP.GeomObjects.Point(3D) в System.Drawing.Point (аксонометричекую проекцию)
        /// </summary>
        /// <param name="Point3D_Source">Заданная 3D точка</param>
        /// <returns></returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0</remarks>
        public System.Drawing.Point CnvPoint3D_ToAxonometryPoint(GeomObjects.Points.Point3D Point3D_Source)
        {//Преобразует точку формата BaseGeometryYVP.GeomObjects.Point(3D) в System.Drawing.PointF
            System.Drawing.Point PtVar = new System.Drawing.Point();
            double x2d1; double y2d1;
            //Пересчет координат с 2D систему
            x2d1 = (Point3D_Source.X - Point3D_Source.Y) * System.Math.Cos(Math.PI / 6);
            y2d1 = Point3D_Source.Z - (Point3D_Source.X + Point3D_Source.Y) * System.Math.Cos(Math.PI / 3);
            PtVar.X = (int)x2d1; PtVar.Y = (int)y2d1;
            return PtVar;
        }

        /// <summary>
        /// Преобразует точку формата BaseGeometryYVP.GeomObjects.Point(3D) в System.Drawing.PointF (аксонометричекую проекцию)
        /// </summary>
        /// <param name="Point3D_Source">Заданная 3D точка</param>
        /// <returns></returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0</remarks>
        public System.Drawing.PointF CnvPoint3D_ToAxonometryPointF(GeomObjects.Points.Point3D Point3D_Source)
        {//Преобразует точку формата BaseGeometryYVP.GeomObjects.Point(3D) в System.Drawing.PointF
            System.Drawing.PointF PtVar = new System.Drawing.PointF();
            double x2d1; double y2d1;
            //Пересчет координат с 2D систему
            x2d1 = (Point3D_Source.X - Point3D_Source.Y) * System.Math.Cos(Math.PI / 6);
            y2d1 = Point3D_Source.Z - (Point3D_Source.X + Point3D_Source.Y) * System.Math.Cos(Math.PI / 3);
            PtVar.X = (float)x2d1; PtVar.Y = (float)y2d1;
            return PtVar;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------- Функции преобразования с корректировкой центра системы координат и пера для рисования --------------------------

        /// <summary>
        /// Коррректирует положение заданной точки с учетом заданного центра системы координат и радиуса точки
        /// </summary>
        /// <param name="Point3D_Source">Заданная точка</param>
        /// <param name="Point_Radius">Заданный радиус точки (равен ширине объекта "System.Drawing.Pen")</param>
        /// <param name="FrameCentre_Source">Заданный центр системы координат</param>
        /// <returns></returns>
        /// <remarks>Возвращает точку со скорректированными координатами в зависимости от положения заданного центра системы координат и радиуса точки</remarks>
        public System.Drawing.Point PointPositionCorrection(Point Point3D_Source, float Point_Radius, Point FrameCentre_Source)
        {//Преобразует точку формата BaseGeometryYVP.GeomObjects.Point(3D) в System.Drawing.PointF
            System.Drawing.Point PtVar = new System.Drawing.Point();
            PtVar.X = Point3D_Source.X + FrameCentre_Source.X - (int)Point_Radius;
            PtVar.Y = Point3D_Source.Y + FrameCentre_Source.Y - (int)Point_Radius;
            return PtVar;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //===================== Функции обратных преобразований без корректировки центра системы координат и пера для рисования ======================
        //...


        //---------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------- Преобразование System.Drawing.PointF и System.Drawing.Point в BaseGeometryYVP.GeomObjects.... ----------------------

        /// <summary>
        /// Конвертирует точку, заданную в формате System.Drawing.Point в проекцию 3D точки на плоскость X0Y 
        /// </summary>
        /// <param name="Point_Source">Точка, заданная в формате System.Drawing.Point</param>
        /// <returns>PointOfPlan1_X0Y.X = -Point_Source.X; PointOfPlan1_X0Y.Y = Point_Source.Y</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0 и расположено не в крайней или угловой точке изображения. 
        /// Не проверяет корректность координат возвращаемой проекции точки для формирования 3D точки.</remarks>
        public GeomObjects.Points.PointOfPlan1X0Y CnvPoint_ToPointOfPlan1_X0Y(System.Drawing.Point Point_Source)
        {
            GeomObjects.Points.PointOfPlan1X0Y PointVar = new GeomObjects.Points.PointOfPlan1X0Y(-Point_Source.X, Point_Source.Y);
            return PointVar;
        }

        /// <summary>
        /// Конвертирует точку, заданную в формате System.Drawing.Point в проекцию 3D точки на плоскость X0Z
        /// </summary>
        /// <param name="Point_Source">Точка, заданная в формате System.Drawing.Point</param>
        /// <returns>PointOfPlan2_X0Z.X = -Point_Source.X; PointOfPlan2_X0Z.Z = -Point_Source.Y</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0 и расположено не в крайней или угловой точке изображения. 
        /// Не проверяет корректность координат возвращаемой проекции точки для формирования 3D точки.</remarks>
        public GeomObjects.Points.PointOfPlan2X0Z CnvPoint_ToPointOfPlan2_X0Z(System.Drawing.Point Point_Source)
        {
            GeomObjects.Points.PointOfPlan2X0Z PointVar = new GeomObjects.Points.PointOfPlan2X0Z(-Point_Source.X, -Point_Source.Y);
            return PointVar;
        }

        /// <summary>
        /// Конвертирует точку, заданную в формате System.Drawing.Point в проекцию 3D точки на плоскость Y0Z
        /// </summary>
        /// <param name="Point_Source">Точка, заданная в формате System.Drawing.Point</param>
        /// <returns>PointOfPlan3_Y0Z.Y = Point_Source.X; PointOfPlan3_Y0Z.Z = Point_Source.Y</returns>
        /// <remarks>Для отрисовки точки начало системы координат определяется координатами X=0; Y=0 и расположено не в крайней или угловой точке изображения. 
        /// Не проверяет корректность координат возвращаемой проекции точки для формирования 3D точки</remarks>
        public GeomObjects.Points.PointOfPlan3Y0Z CnvPoint_ToPointOfPlan3_Y0Z(System.Drawing.Point Point_Source)
        {
            GeomObjects.Points.PointOfPlan3Y0Z PointVar = new GeomObjects.Points.PointOfPlan3Y0Z(Point_Source.X, -Point_Source.Y);
            return PointVar;
        }

        /// <summary>
        /// Конвертирует точку формата System.Drawing.Point в BaseGeometryYVP.GeomObjects.Point2D
        /// </summary>
        /// <param name="Point_Source">Точка, заданная в формате System.Drawing.Point</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public GeomObjects.Points.Point2D CnvPoint_ToPoint2D(System.Drawing.Point Point_Source)
        {
            //Преобразует точку формата BaseGeometryYVP.GeomObjects.Point2D в System.Drawing.Point
            GeomObjects.Points.Point2D PtVar = new GeomObjects.Points.Point2D();
            PtVar.X = (int)Point_Source.X; PtVar.Y = (int)Point_Source.Y;
            return PtVar;
        }

        /// <summary>
        /// Конвертирует точку формата System.Drawing.PointF в BaseGeometryYVP.GeomObjects.Point2D
        /// </summary>
        /// <param name="PointF_Source">Точка, заданная в формате System.Drawing.PointF</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public GeomObjects.Points.Point2D CnvPointF_ToPoint2D(System.Drawing.PointF PointF_Source)
        {
            //Преобразует точку формата BaseGeometryYVP.GeomObjects.Point2D в System.Drawing.PointF
            GeomObjects.Points.Point2D PtVar = new GeomObjects.Points.Point2D();
            PtVar.X = (float)PointF_Source.X; PtVar.Y = (float)PointF_Source.Y;
            return PtVar;
        }

        //======================================================================================================================
        /// <summary>
        /// Определяет тип проекции (квадрант системы координат Монжа) 3D точки, к которой принадлежит заданная (отрисованная) точка
        /// </summary>
        /// <param name="PointProection_Source">Заданная (отриосванная) точка проекции</param>
        /// <param name="Frame2D_Centre">Заданный центр системы координат</param>
        /// <returns>Возвращает проекцию 3D точки, соответвующую плоскости проекций системы координат Монжа, в которой находится заданная (отрисованная) точка</returns>
        /// <remarks></remarks>
        public object TypeOf_ProectionByPoint(System.Drawing.Point PointProection_Source, System.Drawing.Point Frame2D_Centre)
        {
            Point PointVar = new Point();
            GeomObjects.Points.PointOfPlan1X0Y PointOfPlan1_X0Y_FunVar = new GeomObjects.Points.PointOfPlan1X0Y();
            //Экземпляр горизонтальной проекции 3D точки для отрисовки в Graphics
            GeomObjects.Points.PointOfPlan2X0Z PointOfPlan2_X0Z_FunVar = new GeomObjects.Points.PointOfPlan2X0Z();
            //Экземпляр горизонтальной проекции 3D точки для отрисовки в Graphics
            GeomObjects.Points.PointOfPlan3Y0Z PointOfPlan3_Y0Z_FunVar = new GeomObjects.Points.PointOfPlan3Y0Z();
            //Экземпляр горизонтальной проекции 3D точки для отрисовки в Graphics
            PointVar.X = PointProection_Source.X - Frame2D_Centre.X;
            PointVar.Y = PointProection_Source.Y - Frame2D_Centre.Y;
            //Расчет координат указанной точки в заданной системе координат
            //FrontView() '(2-й квадрант)
            if (PointVar.X <= 0 & PointVar.Y <= 0) { 
                PointOfPlan2_X0Z_FunVar.X = -PointVar.X; 
                PointOfPlan2_X0Z_FunVar.Z = -PointVar.Y; 
                return PointOfPlan2_X0Z_FunVar; }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D точки в базисе Монжа//GorizontalView() '(3-й квадрант)
            else if (PointVar.X <= 0 & PointVar.Y >= 0) { 
                PointOfPlan1_X0Y_FunVar.X = -PointVar.X; 
                PointOfPlan1_X0Y_FunVar.Y = PointVar.Y; 
                return PointOfPlan1_X0Y_FunVar; }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D точки в базисе Монжа//ProfileView '(1-й квадрант)
            else if (PointVar.X >= 0 & PointVar.Y <= 0) { 
                PointOfPlan3_Y0Z_FunVar.Y = PointVar.X; 
                PointOfPlan3_Y0Z_FunVar.Z = -PointVar.Y; 
                return PointOfPlan3_Y0Z_FunVar; }//"-" добавлен для задания реальной (имеющей только положительные координаты) 3D точки в базисе Монжа//None '(4-й квадрант)
            else { return null; }//MessageBox.Show("Здесь рисовать нельзя")
        }

        //================================================================ Методы отрисовки проекций 3D точки =============================================================

        /// <summary>
        /// Отрисовка заданной проекции 3D точки, расположенной на Горизонтальной плоскости проекций (Pi1) системы координат Монжа
        /// </summary>
        /// <param name="PointXoY_Sourse">Заданная проекция точки</param>
        /// <param name="PointRadius">Заданный радиус точки, которая будет отрисована</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Поверхность для отрисовки</param>
        /// <remarks>Положение центра точки корректируется в зависимости от центра системы координат Монжа и заданного радиуса точки</remarks>
        public void DrawPointProection(GeomObjects.Points.PointOfPlan1X0Y PointXoY_Sourse, int PointRadius, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            System.Drawing.Point PointProjection_Temp = new System.Drawing.Point();
            PointProjection_Temp = this.PointPositionCorrection(this.CnvPoint3DProjection_ToPoint(PointXoY_Sourse), PointRadius, Frame2D_Centre);
            Graphics_Source.DrawPie(Pen_Point1X0Y_Var, Convert.ToInt32(PointProjection_Temp.X), Convert.ToInt32(PointProjection_Temp.Y), PointRadius * 2 + 1, PointRadius * 2 + 1, 0, 360);
        }

        /// <summary>
        /// Отрисовка заданной проекции 3D точки, расположенной на Фронтальной плоскости проекций (Pi2) системы координат Монжа
        /// </summary>
        /// <param name="PointXoY_Sourse">Заданная проекция точки</param>
        /// <param name="PointRadius">Заданный радиус точки, которая будет отрисована</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Поверхность для отрисовки</param>
        /// <remarks>Положение центра точки корректируется в зависимости от центра системы координат Монжа и заданного радиуса точки</remarks>
        public void DrawPointProection(GeomObjects.Points.PointOfPlan2X0Z PointXoY_Sourse, int PointRadius, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            System.Drawing.Point PointProjection_Temp = new System.Drawing.Point();
            PointProjection_Temp = this.PointPositionCorrection(this.CnvPoint3DProjection_ToPoint(PointXoY_Sourse), PointRadius, Frame2D_Centre);
            Graphics_Source.DrawPie(Pen_Point2X0Z, Convert.ToInt32(PointProjection_Temp.X), Convert.ToInt32(PointProjection_Temp.Y), PointRadius * 2 + 1, PointRadius * 2 + 1, 0, 360);
        }

        /// <summary>
        ///  Отрисовка заданной проекции 3D точки, расположенной на Профильной плоскости проекций (Pi3) системы координат Монжа
        /// </summary>
        /// <param name="PointXoY_Sourse">Заданная проекция точки</param>
        /// <param name="PointRadius">Заданный радиус точки, которая будет отрисована</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Поверхность для отрисовки</param>
        /// <remarks>Положение центра точки корректируется в зависимости от центра системы координат Монжа и заданного радиуса точки</remarks>
        public void DrawPointProection(GeomObjects.Points.PointOfPlan3Y0Z PointXoY_Sourse, int PointRadius, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            System.Drawing.Point PointProjection_Temp = new System.Drawing.Point();
            PointProjection_Temp = this.PointPositionCorrection(this.CnvPoint3DProjection_ToPoint(PointXoY_Sourse), PointRadius, Frame2D_Centre);
            Graphics_Source.DrawPie(Pen_Point3Y0Z, Convert.ToInt32(PointProjection_Temp.X), Convert.ToInt32(PointProjection_Temp.Y), PointRadius * 2 + 1, PointRadius * 2 + 1, 0, 360);
        }

        //================================================================ Методы отрисовки линий связи =============================================================

        /// <summary>
        /// Отрисовка линий связи из проекции точки, расположенной на Горизонтальной плоскости проекций (Pi1) системы координат Монжа
        /// </summary>
        /// <param name="PointXoY_Sourse">Заданная проекция точки</param>
        /// <param name="LinkPointToX">Метка включения вертикального участка линии связи, проходящего от заданной проекции точки до горизонтальной оси X горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="LinkPointToY">Метка включения горизонтального участка линии связи, проходящего от заданной проекции точки до вертикальной оси Y горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="LinkXToBorderPi2">Метка включения вертикального участка линии связи, проходящего от горизонтальной оси X до верхней границы фронтальной плоскости проекций (Pi2)</param>
        /// <param name="LinkYToBorderPi3">Метка включения вертикального участка линии связи, проходящего от горизонтальной оси Y профильной плоскости проекций (Pi3) до верхней границы профильной плоскости проекций (Pi3)</param>
        /// <param name="LinkCurveY1ToY3">Метка включения участка линии связи - дуги, проходящей от вертикальной оси Y горизонтальной плоскости проекций (Pi1) до горизонтальной оси Y профильной плоскости проекций (Pi3)</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Поверхность для отрисовки</param>
        /// <remarks>Отрисовывает линии связи, исходящие от заданной проекции точки до границ области рисования</remarks>
        public void DrawLinkLine(PointOfPlan1X0Y PointXoY_Sourse, bool LinkPointToX, bool LinkPointToY, bool LinkXToBorderPi2, bool LinkYToBorderPi3, bool LinkCurveY1ToY3, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            //Отрисовка линий связи Горизонтальной проекции
            //Контроль нулевого значения координаты X Горизонтальной проекции точки
            //Проекция точки инцидентна оси X, следовательно отрисовка линий связи не требуется (обрабатывается ошибка существования нулевой ширины и высоты прямоугольника, в который вписывается дуга окружности)
            if (PointXoY_Sourse.Y == 0) { return; }
            if (LinkPointToX == true) //Контроль включения линии связи от проекции точки до оси X
            {//Горизонтальная (от Pi1 к Pi3) - Часть 1: отрезок от заданной точки до оси X
                Graphics_Source.DrawLine(this.Pen_LinkLineXoY_toX, Convert.ToInt32(Frame2D_Centre.X - PointXoY_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y + PointXoY_Sourse.Y), Convert.ToInt32(Frame2D_Centre.X - PointXoY_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y));
            }
            if (LinkXToBorderPi2 == true)//Контроль включения линии связи от оси X до верхней границы плоскости проекций Pi2
            {//Горизонтальная (от Pi1 к Pi3) - Часть 2: отрезок от оси X до верхней границы области рисования (верхней границы плоскости проекций Pi2)
                Graphics_Source.DrawLine(this.Pen_LinkLineXoY_toX, Convert.ToInt32(Frame2D_Centre.X - PointXoY_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y), Convert.ToInt32(Frame2D_Centre.X - PointXoY_Sourse.X), -Convert.ToInt32(2 * Frame2D_Centre.Y + 20));
            }
            if (LinkPointToY == true)//Контроль включения линии связи от проекции точки до оси Y
            { //Горизонтальная (от Pi1 к Pi3) - Часть 3: отрезок от заданной точки до вертикальной оси Y (оси Y плоскости проекций Pi1)
                Graphics_Source.DrawLine(this.Pen_LinkLineXoY_toY, Convert.ToInt32(Frame2D_Centre.X - PointXoY_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y + PointXoY_Sourse.Y), Convert.ToInt32(Frame2D_Centre.X), Convert.ToInt32(Frame2D_Centre.Y + PointXoY_Sourse.Y));
            }
            if (LinkCurveY1ToY3 == true)//Контроль включения линии связи (дуги) от вертикальной оси Y плоскости Pi1 до горизонтальной оси Y плоскости Pi3
            {//Горизонтальная (от Pi1 к Pi3) - Часть 4: дуга от вертикальной оси Y до горизонтальной оси Y
                //Graphics_Source.DrawRectangle(PenLine, CInt(Frame2D_Centre.X) - CInt(PointXoY_Sourse.Y), CInt(Frame2D_Centre.X) - CInt(PointXoY_Sourse.Y), CInt(2 * PointXoY_Sourse.Y) + 1, CInt(2 * PointXoY_Sourse.Y)) 'Прямоугольник, в который вписана окружность
                Graphics_Source.DrawArc(this.Pen_LinkLineXoY_toY, Convert.ToInt32(Frame2D_Centre.X) - Convert.ToInt32(PointXoY_Sourse.Y), Convert.ToInt32(Frame2D_Centre.Y) - Convert.ToInt32(PointXoY_Sourse.Y), Convert.ToInt32(2 * PointXoY_Sourse.Y), Convert.ToInt32(2 * PointXoY_Sourse.Y), 0, 90);
            }
            if (LinkYToBorderPi3 == true) //Контроль включения линии связи от горизонтальной оси Y до верхней границы плоскости проекций Pi3
            {//Вертикальная (от Pi1 к Pi2) - Часть 5: отрезок от горизонтальной оси Y до границы области рисования (верхней границы плоскости проекций Pi3)
                Graphics_Source.DrawLine(this.Pen_LinkLineXoY_toY, Convert.ToInt32(Frame2D_Centre.X + PointXoY_Sourse.Y), Frame2D_Centre.Y, Convert.ToInt32(Frame2D_Centre.X + PointXoY_Sourse.Y), 0);
            }
        }

        /// <summary>
        /// Отрисовка линий связи из проекции точки, расположенной на Фронтальной плоскости проекций (Pi2) системы координат Монжа
        /// </summary>
        /// <param name="PointXoZ_Sourse">Заданная проекция точки</param>
        /// <param name="LinkPointToX">Метка включения вертикального участка линии связи, проходящего от заданной проекции точки до горизонтальной оси X фронтальной плоскости проекций (Pi2)</param>
        /// <param name="LinkPointToZ">Метка включения горизонтального участка линии связи, проходящего от заданной проекции точки до вертикальной оси Z фронтальной плоскости проекций (Pi2)</param>
        /// <param name="LinkXToBorderPi1">Метка включения вертикального участка линии связи, проходящего от горизонтальной оси X до нижней границы горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="LinkZToBorderPi3">Метка включения горизонтального участка линии связи, проходящего от вертикальной оси Z до правой границы профильной плоскости проекций (Pi3)</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Поверхность для отрисовки</param>
        /// <remarks>Отрисовывает линии связи, исходящие от заданной проекции точки до границ области рисования</remarks>
        public void DrawLinkLine(PointOfPlan2X0Z PointXoZ_Sourse, bool LinkPointToX, bool LinkPointToZ, bool LinkXToBorderPi1, bool LinkZToBorderPi3, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            //Отрисовка линий связи Фронтальной проекции
            if (LinkPointToX == true)//Контроль включения линии связи от проекции точки до оси X
            {//Вертикальная (от Pi2 к Pi1) - Часть 1: от точки до оси X
                Graphics_Source.DrawLine(this.Pen_LinkLineXoZ_toX, Convert.ToInt32(Frame2D_Centre.X - PointXoZ_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y - PointXoZ_Sourse.Z), Convert.ToInt32(Frame2D_Centre.X - PointXoZ_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y));
            }
            if (LinkXToBorderPi1 == true)//Контроль включения линии связи от оси X до нижней границы плоскости проекций Pi1
            {//Вертикальная (от Pi2 к Pi1) - Часть 2: от оси X до границы Pi1
                Graphics_Source.DrawLine(this.Pen_LinkLineXoZ_toX, Convert.ToInt32(Frame2D_Centre.X - PointXoZ_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y), Convert.ToInt32(Frame2D_Centre.X - PointXoZ_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y - PointXoZ_Sourse.Z) + Convert.ToInt32(Frame2D_Centre.Y * 2 + 20));
            }
            if (LinkPointToZ == true)//Контроль включения линии связи от проекции точки до оси Z
            {//Горизонтальная (от Pi2 к Pi3) - Часть 3: от точки до оси Z
                Graphics_Source.DrawLine(this.Pen_LinkLineXoZ_toZ, Convert.ToInt32(Frame2D_Centre.X - PointXoZ_Sourse.X), Convert.ToInt32(Frame2D_Centre.Y - PointXoZ_Sourse.Z), Convert.ToInt32(Frame2D_Centre.X), Convert.ToInt32(Frame2D_Centre.Y - PointXoZ_Sourse.Z));
            }
            if (LinkZToBorderPi3 == true)//Контроль включения линии связи от оси Z правой до границы плоскости проекций Pi3
            {//Горизонтальная (от Pi2 к Pi3) - Часть 4: от оси Z до границы Pi3
                Graphics_Source.DrawLine(this.Pen_LinkLineXoZ_toZ, Convert.ToInt32(Frame2D_Centre.X), Convert.ToInt32(Frame2D_Centre.Y - PointXoZ_Sourse.Z), Convert.ToInt32(Frame2D_Centre.X - PointXoZ_Sourse.X) + Convert.ToInt32(Frame2D_Centre.X * 2 + 20), Convert.ToInt32(Frame2D_Centre.Y - PointXoZ_Sourse.Z));
            }
        }

        /// <summary>
        /// Отрисовка линий связи из проекции точки, расположенной на Профильной плоскости проекции (Pi3) системы координат Монжа
        /// </summary>
        /// <param name="PointYoZ_Sourse">Заданная проекция точки</param>
        /// <param name="LinkPointToY">Метка включения вертикального участка линии связи, проходящего от заданной проекции точки до оси горизонтальной Y профильной плоскости проекций (Pi3)</param>
        /// <param name="LinkPointToZ">Метка включения горизонтального участка линии связи, проходящего от заданной проекции точки до вертикальной оси Z профильной плоскости проекций (Pi3)</param>
        /// <param name="LinkYToBorderPi1">Метка включения горизонтального участка линии связи, проходящего от вертикальной оси Y горизонтальной плоскости проекций (Pi1) до левой границы горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="LinkZToBorderPi2">Метка включения горизонтального участка линии связи, проходящего от вертикальной оси Z фронтальной плоскости проекций (Pi2) до левой границы фронтальной плоскости проекций (Pi2)</param>
        /// <param name="LinkCurveY3ToY1">Метка включения участка линии связи - дуги, проходящей от горизонтальной оси Y профильной плоскости проекций (Pi3) до вертикальной оси Y горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Поверхность для отрисовки</param>
        /// <remarks>При нулевом значении координаты Y заданной проекции точки линии связи не отрисовываются</remarks>
        public void DrawLinkLine(PointOfPlan3Y0Z PointYoZ_Sourse, bool LinkPointToY, bool LinkPointToZ, bool LinkYToBorderPi1, bool LinkZToBorderPi2, bool LinkCurveY3ToY1, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            //Отрисовка линий связи Профильной проекции
            //Контроль нулевого значения координаты Y Горизонтальной проекции точки
            //Проекция точки инцидентна оси X, следовательно отрисовка линий связи не требуется (обрабатывается ошибка существования нулевой ширины и высоты прямоугольника, в который вписывается дуга окружности)
            if (PointYoZ_Sourse.Y == 0) { return; }
            //В отличие от отключенных условий заменены координаты центра X на Y и наоборот
            if (LinkPointToZ == true) //Контроль включения линии связи от проекции точки до оси Z
            {//Горизонтальная (от Pi3 к Pi2) - часть 1: отрезок от заданной точки до оси Z на Pi2
                Graphics_Source.DrawLine(this.Pen_LinkLineYoZ_toZ, Convert.ToInt32(Frame2D_Centre.X + PointYoZ_Sourse.Y), Convert.ToInt32(Frame2D_Centre.Y - PointYoZ_Sourse.Z), Convert.ToInt32(Frame2D_Centre.X), Convert.ToInt32(Frame2D_Centre.Y - PointYoZ_Sourse.Z));
            }
            if (LinkPointToY == true)//Контроль включения линии связи от проекции точки до оси Y
            {
                Graphics_Source.DrawLine(this.Pen_LinkLineYoZ_toY, Convert.ToInt32(Frame2D_Centre.X + PointYoZ_Sourse.Y), Convert.ToInt32(Frame2D_Centre.Y - PointYoZ_Sourse.Z), Convert.ToInt32(Frame2D_Centre.X + PointYoZ_Sourse.Y), Convert.ToInt32(Frame2D_Centre.Y));
                //Вертикальная (от Pi3 к Pi2) - часть 2: отрезок от заданной точки до оси Y на Pi3
            }
            if (LinkCurveY3ToY1 == true)//Контроль включения линии связи (дуги) от проекции горизонтальной оси Y плоскости Pi3 до вертикальной оси Y плоскости Pi1 
            {    //Часть 3: дуга (от Pi3 к Pi1)  от точки пересечения с горизонтальной осью Y до вертикальной оси Y
                //Graphics_Source.DrawRectangle(PenLine, CInt(Frame2D_Centre.X) - CInt(PointYoZ_Sourse.Y), CInt(Frame2D_Centre.Y) - CInt(PointYoZ_Sourse.Y), CInt(2 * PointYoZ_Sourse.Y) + 1, CInt(2 * PointYoZ_Sourse.Y)) 'Прямоугольник, в который вписана окружность
                Graphics_Source.DrawArc(this.Pen_LinkLineYoZ_toY, Convert.ToInt32(Frame2D_Centre.X) - Convert.ToInt32(PointYoZ_Sourse.Y), Convert.ToInt32(Frame2D_Centre.Y) - Convert.ToInt32(PointYoZ_Sourse.Y), Convert.ToInt32(2 * PointYoZ_Sourse.Y), Convert.ToInt32(2 * PointYoZ_Sourse.Y), 0, 90);
            }
            //Дополнительно от осей до границ области отрисовки
            if (LinkYToBorderPi1 == true) //Контроль включения линии связи от оси Y до границы плоскости проекций Pi1
            { //Горизонтальная (от Pi3 к Pi2) - часть 4: отрезок от вертикальной оси Y на Pi1 до границы области рисования
                Graphics_Source.DrawLine(this.Pen_LinkLineYoZ_toY, Convert.ToInt32(Frame2D_Centre.X), Convert.ToInt32(Frame2D_Centre.Y + PointYoZ_Sourse.Y), 0, Convert.ToInt32(Frame2D_Centre.Y + PointYoZ_Sourse.Y));
            }
            if (LinkZToBorderPi2 == true)//Контроль включения линии связи от оси Z до границы плоскости проекций Pi2
            {//Горизонтальная (от Pi3 к Pi2) - часть 4: отрезок от заданной точки до оси Z на Pi2
                Graphics_Source.DrawLine(this.Pen_LinkLineYoZ_toZ, Convert.ToInt32(Frame2D_Centre.X), Convert.ToInt32(Frame2D_Centre.Y - PointYoZ_Sourse.Z), 0, Convert.ToInt32(Frame2D_Centre.Y - PointYoZ_Sourse.Z));
            }
        }

        /// <summary>
        /// Отрисовка линий связи из проекций точек, расположенных на Горизонтальной, Фронтальной, Профильной плоскостей проекций (Pi1, Pi2, Pi3) системы координат Монжа
        /// </summary>
        /// <param name="PointXoY_Sourse">Заданная проекция точки на Горизонтальной плоскости проекций (Pi1)</param>
        /// <param name="PointXoZ_Sourse">Заданная проекция точки на Фронтальной плоскости проекций (Pi2)</param>
        /// <param name="PointYoZ_Sourse">Заданная проекция точки на Профильной плоскости проекций (Pi3)</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Инструмент прорисовки линии</param>
        /// <remarks>Контролирует значение "Nothing" заданных проекций точек. Контролирует нулевые значения координат заданных проекций точек.
        ///  Исходя из результатов контроля осуществляет различную отрисовку линий связи.</remarks>
        public void DrawLinkLine(PointOfPlan1X0Y PointXoY_Sourse, PointOfPlan2X0Z PointXoZ_Sourse, PointOfPlan3Y0Z PointYoZ_Sourse, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            //Отрисовка линий связи
            //1. Контроль существования трех проекций точки
            //Горизонтальная, фронтальная и профильная проекция не существуют
            if (PointXoY_Sourse == null & PointXoZ_Sourse == null & PointYoZ_Sourse == null) { return; }
            //2. Контроль существования двух проекций точки
            else if (PointXoY_Sourse == null & PointXoZ_Sourse == null)//Горизонтальная и фронтальная проекции не существуют
            {
                this.DrawLinkLine(PointYoZ_Sourse, true, true, true, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Профильной проекции без ограничений
                return;
            }
            else if (PointXoY_Sourse == null & PointYoZ_Sourse == null) //Горизонтальная и профильная проекции не существуют
            {
                this.DrawLinkLine(PointXoZ_Sourse, true, true, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Фронтальной проекции без ограничений
                return;
            }
            else if (PointXoZ_Sourse == null & PointYoZ_Sourse == null)//Фронтальная и профильная проекции не существуют
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, true, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Горизонтальной проекции без ограничений
                return;
            }
            //3. Контроль существования одной проекции точки
            else if (PointXoY_Sourse == null) //Горизонтальная проекция не существует
            {
                this.DrawLinkLine(PointXoZ_Sourse, true, true, true, false, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от Z до правой границы Pi3)
                this.DrawLinkLine(PointYoZ_Sourse, true, true, true, false, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Z до левой границы Pi2)
                return;
            }
            else if (PointXoZ_Sourse == null)//Фронтальная проекция не существует
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, true, false, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от Y до верхней границы Pi3)
                this.DrawLinkLine(PointYoZ_Sourse, true, true, false, true, false, Frame2D_Centre, ref Graphics_Source);  //Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Y до левой границы Pi1 и дуга (для дуги устраняется повторная отрисовка))
                return;
            }
            else if (PointYoZ_Sourse == null) //Профильная проекция не существует
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, false, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от X до верхней границы Pi2)
                this.DrawLinkLine(PointXoZ_Sourse, true, true, false, true, Frame2D_Centre, ref Graphics_Source); //Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от X до нижней границы Pi1)
                return;
            }
            else
            {
            }
            //Горизонтальная, фронтальная и профильная проекция имеют нулевые значения координат
            if (PointXoY_Sourse.X == 0 & PointXoY_Sourse.Y == 0 & PointXoZ_Sourse.X == 0 & PointXoZ_Sourse.Z == 0 & PointYoZ_Sourse.Y == 0 & PointYoZ_Sourse.Z == 0) { return; }
            //2. Контроль равенства нулю координат двух проекций точки
            else if (PointXoY_Sourse.X == 0 & PointXoY_Sourse.Y == 0 & PointXoZ_Sourse.X == 0 & PointXoZ_Sourse.Z == 0)//Горизонтальная и фронтальная проекции имеют нулевые значения координат
            {
                this.DrawLinkLine(PointYoZ_Sourse, true, true, true, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Профильной проекции без ограничений
            }
            else if (PointXoY_Sourse.X == 0 & PointXoY_Sourse.Y == 0 & PointYoZ_Sourse.Y == 0 & PointYoZ_Sourse.Z == 0)//Горизонтальная и профильная проекции имеют нулевые значения координат
            {
                this.DrawLinkLine(PointXoZ_Sourse, true, true, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Фронтальной проекции без ограничений
            }
            else if (PointXoZ_Sourse.X == 0 & PointXoZ_Sourse.Z == 0 & PointYoZ_Sourse.Y == 0 & PointYoZ_Sourse.Z == 0)//Фронтальная и профильная проекции имеют нулевые значения координат
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, true, true, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Горизонтальной проекции без ограничений
            }
            //3. Контроль равенства нулю координат одной проекции точки
            else if (PointXoY_Sourse.X == 0 & PointXoY_Sourse.Y == 0)//Горизонтальная проекция имеет нулевые значения координат
            {
                this.DrawLinkLine(PointXoZ_Sourse, true, true, true, false, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от Z до правой границы Pi3)
                this.DrawLinkLine(PointYoZ_Sourse, true, true, true, false, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Z до левой границы Pi2)
            }
            else if (PointXoZ_Sourse.X == 0 & PointXoZ_Sourse.Z == 0)//Фронтальная проекция имеет нулевые значения координат
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, true, false, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от Y до верхней границы Pi3)
                this.DrawLinkLine(PointYoZ_Sourse, true, true, false, true, false, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Профильной проекции с ограничениями (не отображается связь от Y до левой границы Pi1 и дуга (для дуги устраняется повторная отрисовка))
            }
            else if (PointYoZ_Sourse.Y == 0 & PointYoZ_Sourse.Z == 0)//Профильная проекция имеет нулевые значения координат
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, false, true, true, Frame2D_Centre, ref Graphics_Source); //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображается связь от X до верхней границы Pi2)
                this.DrawLinkLine(PointXoZ_Sourse, true, true, false, true, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Фронтальной проекции с ограничениями (не отображается связь от X до нижней границы Pi1)
            }
            else
            //4. Все проекции не имеют нулевые значения координат
            {
                this.DrawLinkLine(PointXoY_Sourse, true, true, false, false, true, Frame2D_Centre, ref Graphics_Source); //Отрисовка линий связи Горизонтальной проекции без ограничений (не отображаются связи от осей до границ плоскотсей проекций)
                this.DrawLinkLine(PointXoZ_Sourse, true, true, false, false, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Фронтальной проекции с ограничениями (не отображаются связи от осей до границ плоскотсей проекций)
                this.DrawLinkLine(PointYoZ_Sourse, true, true, false, false, false, Frame2D_Centre, ref Graphics_Source);//Отрисовка линий связи Профильной проекции с ограничениями (не отображаются связи от осей до границ плоскотсей проекций и дуга (для дуги устраняется повторная отрисовка))
            }
        }

        /// <summary>
        /// Отрисовка линий связи, исходящих из трех проекций (Горизонтальной, Фронтальной и Профильной) заданной 3D точки
        /// </summary>
        /// <param name="Point3D_Sourse">Заданная 3D точка</param>
        /// <param name="Frame2D_Centre">Точка, определяющая положение начала системы координат Монжа</param>
        /// <param name="Graphics_Source">Инструмент прорисовки линии</param>
        /// <remarks>Контролирует значение "Nothing" заданных проекций точек. Контролирует нулевые значения координат заданных проекций точек.
        ///  Исходя из результатов контроля осуществляет различную отрисовку линий связи.</remarks>
        public void DrawLinkLine(Point3D Point3D_Sourse, Point Frame2D_Centre, ref Graphics Graphics_Source)
        {
            //Отрисовка линий связи для проекций 3D точки

            this.DrawLinkLine(Point3D_Sourse.PointOfPlan1X0Y, Point3D_Sourse.PointOfPlan2X0Z, Point3D_Sourse.PointOfPlan3Y0Z, Frame2D_Centre, ref Graphics_Source);
        }
    }
}