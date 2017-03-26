using System;
using System.Drawing;
using System.Xml.Serialization;

namespace GraphicsModule.Configuration
{
    [Serializable]
    public class GridSettings
    {
        public int StepOfWidth { get; set; }
        public int StepOfHeight { get; set; }
        public int PointsSize { get; set; }
        [XmlIgnore]
        public Color PointsColor { get; set; }
        [XmlElement("PointsColor")]
        public string ColorXHtml
        {
            get { return ColorTranslator.ToHtml(PointsColor); }
            set { PointsColor = ColorTranslator.FromHtml(value); }
        }
        public bool IsDraw { get; set; }
        public GridSettings()
        {
            StepOfWidth = 10;
            StepOfHeight = 10;
            PointsSize = 1;
            PointsColor = Color.Black;
            IsDraw = true;
        }
    }
}
