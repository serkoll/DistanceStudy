using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using GraphicsModule.Configuration.Access;

namespace GraphicsModule.Configuration
{
    [Serializable]
    public class Settings
    {
        public Settings()
        {
            BackgroundColor = Color.White;
            Grid = new GridSettings();
            Axis = new AxisSettings();
            Drawing = new DrawSettings();
            Access = new PrimitivesAccess();
            DrawingSelected = new DrawSettings(new Pen(Brushes.Orange, 4), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), 2, 1, new Font("Times New Roman", 6, FontStyle.Bold), new SolidBrush(Color.Black));
        }
        public Settings(AxisSettings axis, GridSettings grid, DrawSettings drawing, DrawSettings drawingSelected)
        {
            BackgroundColor = Color.White;
            Grid = grid;
            Axis = axis;
            Drawing = drawing;
            DrawingSelected = drawingSelected;
            Access = new PrimitivesAccess();
        }
        public void Serialize(string fileName)
        {
            var xmlFormat = new XmlSerializer(typeof(Settings));
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
            }
        }
        public Settings Deserialize(string fileName)
        {
            var xmlFormat = new XmlSerializer(typeof(Settings));
            using (Stream fStream = new FileStream(fileName,
                FileMode.Open, FileAccess.Read, FileShare.None))
            {
                return (Settings)xmlFormat.Deserialize(fStream);
            }
        }
        [XmlIgnore]
        public Color BackgroundColor { get; set; }
        [XmlElement("BackgroundColor")]
        public string ColorXHtml
        {
            get { return ColorTranslator.ToHtml(BackgroundColor); }
            set { BackgroundColor = ColorTranslator.FromHtml(value); }
        }
        public PrimitivesAccess Access { get; set; }
        public GridSettings Grid { get; set; }
        public AxisSettings Axis { get; set; }
        public DrawSettings Drawing { get; set; }
        public DrawSettings DrawingSelected { get; set; }
    }
}
