using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GraphicsModule
{
    /// <summary>
    /// Класс для работы с поверхностью рисования Graphics
    /// </summary>
    class GraphicsTools
    {
        /// <summary>
        /// Инициируется поверхность рисования
        /// </summary>
        /// <param name="Graphics_Source">Заданная (не определенная поверхность рисования</param>
        /// <remarks>Исходная ширина идлина поверхности равны 200</remarks>
        public static void CreateGraphics(ref Graphics Graphics_Source)
        {
            Bitmap bmp = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
            Graphics_Source = Graphics.FromImage(bmp);
        }
        /// <summary>
        /// Инициируется поверхность рисования
        /// </summary>
        /// <param name="GraphicsWidth">Длина поверхности рисования</param>
        /// <param name="GraphicsHeight">Ширина поверхности рисования</param>
        /// <param name="Graphics_Source">Заданая (не определенная) поверхность</param>
        public static void CreateGraphics(int GraphicsWidth, int GraphicsHeight, ref Graphics Graphics_Source)
        {
            Bitmap bmp=new Bitmap(GraphicsWidth ,GraphicsHeight , PixelFormat.Format32bppArgb);
            Graphics_Source=Graphics.FromImage(bmp);
        }
        /// <summary>
        /// Создает объект (экземпляр) Graphics на основе заданного изображения
        /// </summary>
        /// <param name="Image_Source">Заданное изображения</param>
        /// <param name="Graphics_Source">Исходна поверхность рисования</param>
        /// <remarks>При значении заданного изображения null создает новое изображение размером 200 x 200 пикселей</remarks>
        public static void CreateGraphicsByImage(Bitmap Image_Source, out Graphics Graphics_Source)
        {
            if(Image_Source == null)
            {
                Image_Source = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
                Graphics_Source = Graphics.FromImage(Image_Source);
            }
            else
            {
                Graphics_Source = Graphics.FromImage(Image_Source);
            }
        }
        /// <summary>
        /// Создает изображение с заданными размерами
        /// </summary>
        /// <param name="ImageWidth">Длина</param>
        /// <param name="ImageHeight">Ширина</param>
        /// <returns></returns>
        public Bitmap CreateImage(int ImageWidth, int ImageHeight)
        {
            return new Bitmap(ImageWidth, ImageHeight, PixelFormat.Format32bppArgb);
        }
        /// <summary>
        /// Инициируется поверхность рисования
        /// </summary>
        /// <param name="Bitmap_Source">Поверхность рисования типа Bitmap</param>
        /// <param name="Graphics_Source">Заданая (не определенная) поверхность</param>
        /// <returns>Не записывает в заданный Bitmap_Source информацию о графических объектах Graphics_Source</returns>
        public Bitmap CreateBitmapByGraphics(Bitmap Bitmap_Source, ref Graphics Graphics_Source)
        {
            return new Bitmap(Bitmap_Source.Width, Bitmap_Source.Height, Graphics_Source);
        }
        /// <summary>
        /// Очищает заданный PictureBox (с возможностью восстановления объектов Graphics)
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox</param>
        /// <remarks>При очищении задает исходный фон PictureBox.
        /// При этом не очищает используемый для отрисовки объектов Graphics и может его восстановить с помощью метода  PictureBox.Refresh().</remarks>
        public void ClearPictureBox( PictureBox PictureBox_Source)
        {
            PictureBox_Source.CreateGraphics().Clear(PictureBox_Source.BackColor);
        }
        /// <summary>
        /// Очищает заданный PictureBox (полностью)
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox</param>
        /// <param name="Graphics_Source">Заданная поверхность рисования Graphics</param>
        /// <remarks>Полностью очищает PictureBox.Image и Graphics без возможности восстановления существовавших графических объектов.
        /// При очищении задает исходный фон PictureBox.</remarks>
        public void ClearPictureBox( PictureBox PictureBox_Source, ref Graphics Graphics_Source)
        {
            Graphics_Source.Clear(PictureBox_Source.BackColor);
            PictureBox_Source.CreateGraphics().Clear(PictureBox_Source.BackColor);
        }
    }
}
