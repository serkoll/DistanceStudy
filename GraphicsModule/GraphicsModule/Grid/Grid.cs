using System.Drawing;
using DrawYVP_DefaultSettings.System_G.GraphicsDraw;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Класс, содержащий инструменты задания и отрисовки СЕТКИ
    /// </summary>
    class Grid : GridCalculation
    {
        /// <summary>
        /// Массив узловых точек сетки
        /// </summary>
        public Point[,] GridKnots { get; set; }
        /// <summary>
        /// Размер сетки по высоте (координата Y в пространстве рисунка, направлена вниз)
        /// </summary>
        public int GridHeight { get; set; }
        /// <summary>
        /// Размер сетки по ширине (координата X в пространстве рисунка, направлена вправо)
        /// </summary>
        public int GridWidth { get; set; }
        /// <summary>
        /// Центральная точка сетки
        /// </summary>
        public Point GridCenter { get; set; }
        /// <summary>
        /// Переменная для работы с классом настроек СЕТКИ
        /// </summary>
        public Settings_Grid GridDefaultSetting = new Settings_Grid();
        /// <summary>
        /// Получает или задает шаг сетки по высоте (координата Y в пространстве рисунка)</summary>
        /// </summary>
        /// <remarks>По умолчанию равен 5</remarks>
        public int GridStepOfHeight
        {
            get
            {
                return (int)GridDefaultSetting.StepY;
            }
            set
            {
                GridDefaultSetting.StepY = GridStepOfHeight;
            }
        }
        /// <summary>
        /// Получает или задает шаг сетки по ширине (координата X в пространстве рисунка)
        /// </summary>
        /// <remarks>По умолчанию равен 5</remarks>
        public int GridStepOfWidth
        {
            get
            {
                return (int)GridDefaultSetting.StepX;
            }
            set
            {
                GridDefaultSetting.StepX = GridStepOfWidth;
            }
        }
        /// <summary>
        /// Получает значение переключателя сетки
        /// </summary>
        public bool GridFlagDraw
        {
            get
            {
                return GridDefaultSetting.FlagDraw;
            }
            set
            {
                GridDefaultSetting.FlagDraw = GridFlagDraw;
            }
        }
        /// <summary>
        /// Задает сетку на поверхности Graphics с учетом установленных по умолчанию параметров шага по вертикали и горизонтали, радиуса и цвета узловых точек сетки
        /// </summary>
        /// <param name="g">Заданная поверхность рисования</param>
        /// <remarks>Расчитывает и задает сетку с учетом размеров заданной поверхности рисования Graphics</remarks>
        public void CreateGridToGraphics(Graphics g)
        {
            if (GridHeight == 0 || GridWidth == 0)
            {
                GridHeight = (int)g.VisibleClipBounds.Size.Height;
                GridWidth = (int)g.VisibleClipBounds.Size.Width;
                GridKnots = CalculateGrid(GridHeight, GridWidth, GridStepOfHeight, GridStepOfWidth);
                GridCenter = CalculateGridCentre(GridKnots);
                DrawGrid(GridKnots, GridDefaultSetting.PointsColor, GridDefaultSetting.PointSize, g);
            }
            else
            {
                GridKnots = CalculateGrid(GridHeight, GridWidth, GridStepOfHeight, GridStepOfWidth);
                GridCenter = CalculateGridCentre(GridKnots);
                DrawGrid(GridKnots, GridDefaultSetting.PointsColor, GridDefaultSetting.PointSize, g);
            }
        }
        /// <summary>
        /// Задает сетку на поверхности Graphics
        /// </summary>
        /// <param name="StepOfHeight"></param>
        /// <param name="StepOfWidth"></param>
        /// <param name="Knots_R"></param>
        /// <param name="GridColor"></param>
        /// <param name="g"></param>
        public void CreateGridToGraphics(int StepOfHeight, int StepOfWidth, int Knots_R, Color GridColor, Graphics g)
        {
            GridStepOfHeight = StepOfHeight;
            GridStepOfWidth = StepOfWidth;
            if (GridHeight == 0 || GridWidth == 0)
            {
                GridHeight = (int)g.VisibleClipBounds.Size.Height;
                GridWidth = (int)g.VisibleClipBounds.Size.Width;
                GridKnots = CalculateGrid(GridHeight, GridWidth, GridStepOfHeight, GridStepOfWidth);
                GridCenter = CalculateGridCentre(GridKnots);
                DrawGrid(GridKnots, GridColor, Knots_R, g);
            }
            else
            {
                GridKnots = CalculateGrid(GridHeight, GridWidth, GridStepOfHeight, GridStepOfWidth);
                GridCenter = CalculateGridCentre(GridKnots);
                DrawGrid(GridKnots, GridColor, Knots_R, g);
            }
        }
        /// <summary>
        /// Задает сетку на поверхности Graphics
        /// </summary>
        /// <param name="GridKnotPoints">Заданный массив узловых точек сетки</param>
        /// <param name="KnotPointColor">Заданный цвет узловых точек сетки</param>
        /// <param name="KnotPointR">Размер узловых точек сетки</param>
        /// <param name="g">Заданная поверхность рисования</param>
        public void DrawGrid(Point[,] GridKnotPoints, Color KnotPointColor, int KnotPointR, Graphics g)
        {
            Point GridPoint = new Point();
            Pen Pens = new Pen(KnotPointColor, KnotPointR);
            for (int i = 0; i < GridKnotPoints.GetUpperBound(0); i++)
            {
                for (int j = 0; j < GridKnotPoints.GetUpperBound(1); j++)
                {
                    GridPoint = GetGridKnotPoint(GridKnotPoints, i, j);
                    g.DrawPie(Pens, GridPoint.X, GridPoint.Y, KnotPointR, KnotPointR, 0, 360);
                }
            }
        }
        /// <summary>
        /// Отрисовывает массив узловых точек сетки в заданном PictureBox
        /// </summary>
        /// <param name="GridKnotPoints">Заданный массив узловых точек сетки</param>
        /// <param name="pb">Заданный PictureBox</param>
        /// <param name="PointColor">Заданный цвет узловых точек сетки</param>
        /// <param name="PointR">Размер узловых точек сетки</param>
        public void DrawGrid(int[,] GridKnotPoints, System.Windows.Forms.PictureBox pb, Color PointColor, int PointR)
        {
            int CenterX, CenterY;
            Point GrPoint = new Point();
            Point[] GrPoints = new Point[GridKnotPoints.GetUpperBound(0)];
            Pen Pens = new Pen(PointColor, PointR);
            CenterX = pb.ClientRectangle.Width / 2;
            CenterY = pb.ClientRectangle.Height / 2;
            for (int i = 0; i < GridKnotPoints.GetUpperBound(0); i++)
            {
                GrPoint.X = (int)(CenterX + GridKnotPoints[i, 0]);
                GrPoint.Y = (int)(CenterY + GridKnotPoints[i, 1]);
                pb.CreateGraphics().DrawEllipse(Pens, (int)(GrPoint.X - PointR / 2), (int)(GrPoint.Y - PointR / 2), PointR, PointR);
            }
        }
        /// <summary>
        /// Задает массив узловых точек сетки в заданном Image
        /// </summary>
        /// <param name="GridKnotPoints">Заданный массив узловых точек сетки</param>
        /// <param name="Image_Source">Заданный Image</param>
        /// <param name="KnotPoint_Color">Заданный цвет узловых точек сетки</param>
        /// <param name="KnotPoint_R">Размер узловых точек сетки</param>
        public void DrawGrid(Point[,] GridKnotPoints, Image Image_Source, Color KnotPoint_Color, int KnotPoint_R)
        {
            Graphics Grid_Gr = Graphics.FromImage(Image_Source);
            Point GridPoint;
            Pen Pens = new Pen(KnotPoint_Color, KnotPoint_R);
            for (int i = 0; i < GridKnotPoints.GetUpperBound(0); i++)
            {
                for (int j = 0; j < GridKnotPoints.GetUpperBound(1); j++)
                {
                    GridPoint = GetGridKnotPoint(GridKnotPoints, i, j);
                    Grid_Gr.DrawPie(Pens, GridPoint.Y, GridPoint.X, KnotPoint_R, KnotPoint_R, 0, 360);
                }
            }
        }
    }
}
