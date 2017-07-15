using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;

namespace GraphicsModule
{
    /// <summary>
    /// Чертеж
    /// </summary>
    public class Drawing : IDisposable
    {
        private Bitmap _bitmap;
        private Point _centerSystemPoint;

        /// <summary>
        /// Инициализация чертежа
        /// </summary>
        /// <param name="settings">Настройки графического редактора</param>
        /// <param name="pictureBox">Целевой PictureBox</param>
        public Drawing(Settings settings, PictureBox pictureBox)
        {
            if (pictureBox == null)
            {
                var msg = "PictureBox не инициализирован";
                throw new ArgumentNullException(nameof(pictureBox), msg);
            }
            if (settings == null)
            {
                var msg = "Настройки не инициализированы";
                throw new ArgumentNullException(nameof(settings), msg);
            }
            PictureBox = pictureBox;
            Settings = settings;
            CalculateBackground();
            InitializeGraphics();
            CalculatePlanes(Background.Axis.CoordinateSystemCenter);
            Refresh();
        }

        /// <summary>
        /// Рассчитывает фон полотна
        /// </summary>
        /// <remarks>Фоном являются сетка и оси</remarks>
        public void CalculateBackground()
        {
            _centerSystemPoint.X = PictureBox.ClientSize.Width / 2;
            _centerSystemPoint.Y = PictureBox.ClientSize.Height / 2;
            Background = new Background(_centerSystemPoint, Settings, PictureBox);
        }

        private void InitializeGraphics()
        {
            if (Background.Bitmap == null)
            {
                var msg = "Фон не инициализирован";
                throw new ArgumentNullException(nameof(Background), msg);
            }
            _bitmap = new Bitmap(Background.Bitmap);
            _bitmap.MakeTransparent();
            Graphics = Graphics.FromImage(_bitmap);
        }

        /// <summary>
        /// Перерисовывает чертеж
        /// </summary>
        public void Refresh()
        {
            PictureBox.Image = (Image)_bitmap.Clone();
            PictureBox.Refresh();
        }

        /// <summary>
        /// Пересчитывает фон чертежа и отрисовывает на нем графические объекты
        /// </summary>
        /// <param name="strg"></param>
        public void Update(Storage strg)
        {
            _bitmap?.Dispose();
            Graphics?.Dispose();

            InitializeGraphics();
            strg.DrawObjects(Settings, Background.Axis.CoordinateSystemCenter, Graphics);
            CalculatePlanes(Background.Axis.CoordinateSystemCenter);
            Refresh();
        }

        private void CalculatePlanes(Point centerPoint)
        {
            PlaneX0Y = new RectangleF(0, centerPoint.Y, centerPoint.X, centerPoint.Y);
            PlaneX0Z = new RectangleF(0, 0, centerPoint.X, centerPoint.Y);
            PlaneY0Z = new RectangleF(centerPoint.X, 0, centerPoint.X, centerPoint.Y);
        }

        #region IDisposable

        public void Dispose()
        {
            _bitmap?.Dispose();
            Graphics?.Dispose();
        }

        #endregion

        public PictureBox PictureBox { get; }

        /// <summary>
        /// Настройки графического редактора (в том числе настройки чертежа)
        /// </summary>
        public Settings Settings { get; }

        /// <summary>
        /// Фон чертежа
        /// </summary>
        public Background Background { get; private set; }

        /// <summary>
        /// Graphics чертежа
        /// </summary>
        public Graphics Graphics { get; private set; }

        /// <summary>
        /// Границы горизонтальной плоскости проекции
        /// </summary>
        public RectangleF PlaneX0Y { get; private set; }

        /// <summary>
        /// Границы фронтальной плоскости проекции
        /// </summary>
        public RectangleF PlaneX0Z { get; private set; }

        /// <summary>
        /// Границы горизонтальной плоскости проекции
        /// </summary>
        public RectangleF PlaneY0Z { get; private set; }

        /// <summary>
        /// Центр системы координат
        /// </summary>
        public Point CenterSystemPoint => _centerSystemPoint;
    }
}
