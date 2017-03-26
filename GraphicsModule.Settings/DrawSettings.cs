using System;
using System.Drawing;
using System.Xml.Serialization;

namespace GraphicsModule.Configuration
{
    [Serializable]
    public class DrawSettings
    {
        [XmlIgnore]
        public Pen PenPoints { get; set; }
        [XmlIgnore]
        public Pen PenLine2D { get; set; }
        [XmlIgnore]
        public Pen PenLineOfPlane1X0Y { get; set; }
        [XmlIgnore]
        public Pen PenLineOfPlane2X0Z { get; set; }
        [XmlIgnore]
        public Pen PenLineOfPlane3Y0Z { get; set; }
        [XmlElement("PenPoints")]
        public PenSerialize PenPointsSerialize
        {
            get { return new PenSerialize(PenPoints); }
            set { PenPoints = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLine2D")]
        public PenSerialize PenLine2DSerialize
        {
            get { return new PenSerialize(PenLine2D); }
            set { PenLine2D = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLineOfPlane1X0Y")]
        public PenSerialize PenLineOfPlane1X0YSerialize
        {
            get { return new PenSerialize(PenLineOfPlane1X0Y); }
            set { PenLineOfPlane1X0Y = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLineOfPlane2X0Z")]
        public PenSerialize PenLineOfPlane2X0ZSerialize
        {
            get { return new PenSerialize(PenLineOfPlane2X0Z); }
            set { PenLineOfPlane2X0Z = new Pen(value.Color, value.Width); }
        }
        [XmlElement("PenLineOfPlane3Y0Z")]
        public PenSerialize PenLineOfPlane3Y0ZSerialize
        {
            get { return new PenSerialize(PenLineOfPlane3Y0Z); }
            set { PenLineOfPlane3Y0Z = new Pen(value.Color, value.Width); }
        }
        public int RadiusPoints { get; set; }
        public int RadiusLines { get; set; }
        public LinkLinesSettings LinkLinesSettings { get; set; }
        [XmlIgnore]
        public Font TextFont { get; set; }
        [XmlIgnore]
        public Brush TextBrush { get; set; }
        public DrawSettings()
        {
            RadiusPoints = 2;
            RadiusLines = 1;
            PenPoints = new Pen(Brushes.Black, RadiusPoints * 2);
            PenLine2D = new Pen(Brushes.Black, RadiusLines);
            PenLineOfPlane1X0Y = new Pen(Brushes.LightGreen, RadiusLines);
            PenLineOfPlane2X0Z = new Pen(Brushes.Red, RadiusLines);
            PenLineOfPlane3Y0Z = new Pen(Brushes.Blue, RadiusLines);
            TextFont = new Font("Times New Roman", 14, FontStyle.Regular);
            TextBrush = new SolidBrush(Color.Black);
            LinkLinesSettings = new LinkLinesSettings();
        }
        public DrawSettings(Pen pnPoints, Pen pnLine2D, Pen pnLn1, Pen pnLn2, Pen pnLn3, int rPoints, int rLines, Font fText, Brush tBrush)
        {
            RadiusPoints = rPoints;
            RadiusLines = rLines;
            PenPoints = pnPoints;
            PenLine2D = pnLine2D;
            PenLineOfPlane1X0Y = pnLn1;
            PenLineOfPlane2X0Z = pnLn2;
            PenLineOfPlane3Y0Z = pnLn3;
            LinkLinesSettings = new LinkLinesSettings(pnLine2D);
            TextFont = fText;
            TextBrush = tBrush;
        }
    }
}
