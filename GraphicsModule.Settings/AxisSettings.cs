using System;
using System.Drawing;
using System.Xml.Serialization;

namespace GraphicsModule.Configuration
{
    [Serializable]
    public class AxisSettings
    { 
        public int Width { get; set; }
        [XmlIgnore]
        public Color ColorX { get; set; }
        [XmlIgnore]
        public Color ColorY { get; set; }
        [XmlIgnore]
        public Color ColorZ { get; set; }
        [XmlElement("ColorX")]
        public string ColorXHtml
        {
            get { return ColorTranslator.ToHtml(ColorX); }
            set { ColorX = ColorTranslator.FromHtml(value); }
        }
        [XmlElement("ColorY")]
        public string ColorYHtml
        {
            get { return ColorTranslator.ToHtml(ColorY); }
            set { ColorY = ColorTranslator.FromHtml(value); }
        }
        [XmlElement("ColorZ")]
        public string ColorZHtml
        {
            get { return ColorTranslator.ToHtml(ColorY); }
            set { ColorY = ColorTranslator.FromHtml(value); }
        }
        public bool FlagDrawX { get; set; }
        public bool FlagDrawY { get; set; }
        public bool FlagDrawZ { get; set; }
        public bool IsDraw { get; set; }
        public AxisSettings()
        {
            Width = 1;
            ColorX = Color.Black;
            ColorY = Color.Black;
            ColorZ = Color.Black;
            FlagDrawX = true;
            FlagDrawY = true;
            FlagDrawZ = true;
            IsDraw = true;
        }
    }
}
