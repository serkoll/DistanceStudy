using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace GraphicsModule.Settings
{
    [Serializable]
    public class Settings
    {
        public GridS GridS { get; set; }
        public AxisS AxisS { get; set; }
        public DrawS DrawS { get; set; }
        public DrawS SelectedDrawS { get; set; }
        public Settings()
        {
            GridS = new GridS();
            AxisS = new AxisS();
            DrawS = new DrawS();
            SelectedDrawS = new DrawS(new Pen(Brushes.Orange, 4), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), new Pen(Brushes.Orange, 1), 2, 1);
        }
        public Settings(AxisS axisS, GridS gridS, DrawS drawS, DrawS selectedDrawS)
        {
            GridS = gridS;
            AxisS = axisS;
            DrawS = drawS;
            SelectedDrawS = selectedDrawS;
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
