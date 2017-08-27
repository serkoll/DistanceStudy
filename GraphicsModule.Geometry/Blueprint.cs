using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;

namespace GraphicsModule.Geometry
{
    /// <summary>
    /// Чертеж
    /// </summary>
    public class Blueprint : IDisposable
    {
        private Bitmap _bitmap;
        private Point _coordinateSystemCenterPoint;

        /// <summary>
        /// Инициализация чертежа
        /// </summary>
        /// <param name="settings">Настройки графического редактора</param>
        /// <param name="pictureBox">Целевой PictureBox</param>
        public Blueprint(Settings settings, PictureBox pictureBox)
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
            Storage = new Storage(this);
            CalculateBackground();
            InitializeGraphics();
            Refresh();
        }

        /// <summary>
        /// Инициализация чертежа
        /// </summary>
        /// <param name="settings">Настройки графического редактора</param>
        /// <param name="storage"></param>
        /// <param name="pictureBox">Целевой PictureBox</param>
        public Blueprint(Settings settings, Storage storage, PictureBox pictureBox)
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

            if (storage == null)
            {
                var msg = "Ошибка при инициализации хранилища данных";
                throw new ArgumentNullException(nameof(storage), msg);
            }

            PictureBox = pictureBox;
            Settings = settings;
            Storage = storage;
            CalculateBackground();
            InitializeGraphics();
            Refresh();
        }

        /// <summary>
        /// Рассчитывает фон полотна
        /// </summary>
        /// <remarks>Фоном являются сетка и оси</remarks>
        public void CalculateBackground()
        {
            _coordinateSystemCenterPoint.X = PictureBox.ClientSize.Width / 2;
            _coordinateSystemCenterPoint.Y = PictureBox.ClientSize.Height / 2;
            Background = new Background(_coordinateSystemCenterPoint, Settings, PictureBox);
            InitializePlanes(_coordinateSystemCenterPoint);
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
        public void Update()
        {
            _bitmap?.Dispose();
            Graphics?.Dispose();

            InitializeGraphics();
            Storage.DrawObjects();
            InitializePlanes(Background.Axis.CoordinateSystemCenter);
            Refresh();
        }

        private void InitializePlanes(Point centerPoint)
        {
            PlaneX0Y = new Rectangle(0, centerPoint.Y, centerPoint.X, centerPoint.Y);
            PlaneX0Z = new Rectangle(0, 0, centerPoint.X, centerPoint.Y);
            PlaneY0Z = new Rectangle(centerPoint.X, 0, centerPoint.X, centerPoint.Y);
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
        public Rectangle PlaneX0Y { get; private set; }

        /// <summary>
        /// Границы фронтальной плоскости проекции
        /// </summary>
        public Rectangle PlaneX0Z { get; private set; }

        /// <summary>
        /// Границы горизонтальной плоскости проекции
        /// </summary>
        public Rectangle PlaneY0Z { get; private set; }

        /// <summary>
        /// Центр системы координат
        /// </summary>
        public Point CoordinateSystemCenterPoint => _coordinateSystemCenterPoint;

        /// <summary>
        /// Хранилище объектов чертежа
        /// </summary>
        public Storage Storage { get; }
    }
}
