using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.CoordinateSystem;

namespace GraphicsModule.Geometry
{
    /// <summary>
    /// Фон чертежа
    /// </summary>
    public class Background : IDisposable
    {
        /// <summary>
        /// Инициализирует фон чертежа
        /// </summary>
        /// <param name="centerSystemPoint">Центр системы координат</param>
        /// <param name="settings">Настройки графического редактора</param>
        /// <param name="pictureBox">Целевой PictureBox</param>
        public Background(Point centerSystemPoint, Settings settings, PictureBox pictureBox)
        {
            if (settings == null)
            {
                var msg = "Настройки редактора не инициализированы";
                throw new ArgumentNullException(nameof(settings), msg);
            }
            if (pictureBox == null)
            {
                var msg = "PictureBox не инициализирован";
                throw new ArgumentNullException(nameof(pictureBox), msg);
            }

            Bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height, PixelFormat.Format24bppRgb);
            Bitmap.MakeTransparent();
            using (var graphics = Graphics.FromImage(Bitmap))
            {
                Axis = new Axis(centerSystemPoint, graphics);
                Grid = new Grid(settings.Grid, centerSystemPoint, graphics);
                Draw(settings, graphics);
            }
        }

        private void Draw(Settings settings, Graphics graphics)
        {
            Grid.DrawGrid(settings.Grid, graphics);
            Axis.DrawAxis(settings.Axis, graphics);
        }

        #region IDisposable

        public void Dispose()
        {
            Bitmap?.Dispose();
        }

        #endregion

        /// <summary>
        /// Bitmap фона
        /// </summary>
        public Bitmap Bitmap { get; }

        /// <summary>
        /// Координатные оси
        /// </summary>
        public Axis Axis { get; }

        /// <summary>
        /// Сетка
        /// </summary>
        public Grid Grid { get; }
    }
}
