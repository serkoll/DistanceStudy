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
        [XmlIgnore]
        public Color BackgroundColor { get; set; }
        [XmlElement("BackgroundColor")]
        public string ColorXHtml
        {
            get { return ColorTranslator.ToHtml(BackgroundColor); }
            set { BackgroundColor = ColorTranslator.FromHtml(value); }
        }
        public PrimitivesAccess PrimitivesAcces { get; set; }
        public GridSettings GridSettings { get; set; }
        public AxisSettings AxisSettings { get; set; }
        public DrawSettings DrawSettings { get; set; }
        public DrawSettings SelectedDrawSettings { get; set; }
        public Settings()
        {
            BackgroundColor = Color.White;
            GridSettings = new GridSettings();
            AxisSettings = new AxisSettings();
            DrawSettings = new DrawSettings();
            PrimitivesAcces = new PrimitivesAccess();
            SelectedDrawSettings = new DrawSettings(new Pen(Brushes.Orange, 4), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), 2, 1, new Font("Times New Roman", 6, FontStyle.Bold), new SolidBrush(Color.Black));
        }
        public Settings(AxisSettings axisSettings, GridSettings gridSettings, DrawSettings drawSettings, DrawSettings selectedDrawSettings)
        {
            BackgroundColor = Color.White;
            GridSettings = gridSettings;
            AxisSettings = axisSettings;
            DrawSettings = drawSettings;
            SelectedDrawSettings = selectedDrawSettings;
            PrimitivesAcces = new PrimitivesAccess();
        }
        public void Serialize(string fileName)
        {
            var xmlFormat = new XmlSerializer(typeof(Settings));
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
                fStream.Close();
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
    }
}
