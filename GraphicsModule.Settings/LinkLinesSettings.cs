using System;
using System.Drawing;
using System.Xml.Serialization;

namespace GraphicsModule.Configuration
{
    [Serializable]
    public class LinkLinesSettings
    {
        public LinkLinesSettings()
        {
            IsDraw = true;
            PenLinkLineX0YtoX = new Pen(Color.LightGreen, 0.3F);
            PenLinkLineX0YtoY = new Pen(Color.Blue, 0.3F);
            PenLinkLineX0ZtoX = new Pen(Color.LightGreen, 0.3F);
            PenLinkLineX0ZtoZ = new Pen(Color.Red, 0.3F);
            PenLinkLineY0ZtoY = new Pen(Color.Blue, 0.3F);
            PenLinkLineY0ZtoZ = new Pen(Color.Red, 0.3F);
            LinkXToBorderPi1 = true;
            LinkYToBorderPi1 = true;
            LinkXToBorderPi2 = true;
            LinkZToBorderPi2 = true;
            LinkYToBorderPi3 = true;
            LinkZToBorderPi3 = true;
            LinkCurveY3ToY1 = true;
            LinkCurveY1ToY3 = true;
        }
        public LinkLinesSettings(Pen selectedPen)
        {
            IsDraw = true;
            PenLinkLineX0YtoX = selectedPen;
            PenLinkLineX0YtoY = selectedPen;
            PenLinkLineX0ZtoX = selectedPen;
            PenLinkLineX0ZtoZ = selectedPen;
            PenLinkLineY0ZtoY = selectedPen;
            PenLinkLineY0ZtoZ = selectedPen;
            LinkXToBorderPi1 = true;
            LinkYToBorderPi1 = true;
            LinkXToBorderPi2 = true;
            LinkZToBorderPi2 = true;
            LinkYToBorderPi3 = true;
            LinkZToBorderPi3 = true;
            LinkCurveY3ToY1 = true;
            LinkCurveY1ToY3 = true;
        }
        public bool IsDraw { get; set; }
        [XmlIgnore]
        public Pen PenLinkLineX0YtoX { get; set; }
        [XmlIgnore]
        public Pen PenLinkLineX0YtoY { get; set; }
        [XmlIgnore]
        public Pen PenLinkLineX0ZtoX { get; set; }
        [XmlIgnore]
        public Pen PenLinkLineX0ZtoZ { get; set; }
        [XmlIgnore]
        public Pen PenLinkLineY0ZtoY { get; set; }
        [XmlIgnore]
        public Pen PenLinkLineY0ZtoZ { get; set; }
        [XmlElement("PenLinkLineX0YtoX")]
        public PenSerialize LinkLineX0YtoXtoXSerialize
        {
            get { return new PenSerialize(PenLinkLineX0YtoX);}
            set { PenLinkLineX0YtoX = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLinkLineX0YtoY")]
        public PenSerialize LinkLineX0YtoYSerialize
        {
            get { return new PenSerialize(PenLinkLineX0YtoY); }
            set { PenLinkLineX0YtoY = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLinkLineX0ZtoX")]
        public PenSerialize LinkLineX0ZtoXSerialize
        {
            get { return new PenSerialize(PenLinkLineX0ZtoX); }
            set { PenLinkLineX0ZtoX = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLinkLineX0ZtoZ")]
        public PenSerialize LinkLineX0ZtoZSerialize
        {
            get { return new PenSerialize(PenLinkLineX0ZtoZ); }
            set { PenLinkLineX0ZtoZ = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLinkLineY0ZtoY")]
        public PenSerialize LinkLineY0ZtoYSerialize
        {
            get { return new PenSerialize(PenLinkLineY0ZtoY); }
            set { PenLinkLineY0ZtoY = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLinkLineY0ZtoZ")]
        public PenSerialize LinkLineY0ZtoZSerialize
        {
            get { return new PenSerialize(PenLinkLineY0ZtoZ); }
            set { PenLinkLineY0ZtoZ = new Pen(value.Color, value.Width); }
        }
        public bool LinkPointToX { get; set; }
        public bool LinkPointToY { get; set; }
        public bool LinkPointToZ { get; set; }
        public bool LinkXToBorderPi1 { get; set; }
        public bool LinkYToBorderPi1 { get; set; }
        public bool LinkXToBorderPi2 { get; set; }
        public bool LinkZToBorderPi2 { get; set; }
        public bool LinkYToBorderPi3 { get; set; }
        public bool LinkZToBorderPi3 { get; set; }
        public bool LinkCurveY3ToY1 { get; set; }
        public bool LinkCurveY1ToY3 { get; set; }
    }
}
