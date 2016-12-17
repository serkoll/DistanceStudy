using System;
using System.Drawing;
using System.Xml.Serialization;

namespace GraphicsModule.Settings
{
    [Serializable]
    public class PenSerialize
    {
        [XmlIgnore]
        public Pen Pen { get; set; }
        [XmlIgnore]
        public Color Color { get; set; }
        [XmlElement("Color")]
        public string ColorHtml
        {
            get { return ColorTranslator.ToHtml(Color); }
            set { Color = ColorTranslator.FromHtml(value); }
        }
        public float Width { get; set; }

        public PenSerialize()
        {
            Color = Color.Black;
            Width = 1;
        }
        public PenSerialize(Pen pen)
        {
            Color = pen.Color;
            Width = pen.Width;
        }
    }
}
