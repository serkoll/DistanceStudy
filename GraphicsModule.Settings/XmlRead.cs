using System.Drawing;
using GraphicsModule.Settings.Cursors;

namespace GraphicsModule.Settings
{
    public class XmlRead
    {
        readonly SettingsXml _settings=new SettingsXml();

        public Cursor[] Cursors =
        {
            new AddOnPoint(), new Cross(), new Circle(), new Star(), new Envelope(), new Square(),
            new Triangle()
        };


        public Bitmap DrawFigure(Cursor[] cur, int index)
        {
            Bitmap bmp = new Bitmap(40, 40);
            cur[index].Draw(bmp.Width, bmp.Height, ColorTranslator.FromWin32(int.Parse(_settings.GetElement(index,"Cursor").Value)), Graphics.FromImage(bmp));
            return bmp;
        }

        public bool Axis1OnOff
        {
            get { return bool.Parse(_settings.GetElement(0, "Axis").Value); }
        }

        public bool Axis2OnOff
        {
            get { return bool.Parse(_settings.GetElement(1, "Axis").Value); }
        }

        public bool Axis3OnOff
        {
            get { return bool.Parse(_settings.GetElement(2, "Axis").Value); }
        }

        public string Axis1Name
        {
            get { return _settings.GetElement(3, "Axis").Value; }
        }

        public string Axis2Name
        {
            get { return _settings.GetElement(4, "Axis").Value; }
        }

        public string Axis3Name
        {
            get { return _settings.GetElement(5, "Axis").Value; }
        }

        public decimal AxisWidth
        {
            get { return decimal.Parse(_settings.GetElement(6, "Axis").Value); }
        }

        public Color AxisColor1
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(8, "Axis").Value)); }
        }

        public Color AxisColor2
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(9, "Axis").Value)); }
        }

        public Color AxisColor3
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(10, "Axis").Value)); }
        }

        public bool GridOnOff
        {
            get { return bool.Parse(_settings.GetElement(0, "Grid").Value); }
        }

        public decimal GridPointsSize
        {
            get { return decimal.Parse(_settings.GetElement(1, "Grid").Value); }
        }

        public double GridStepX
        {
            get { return double.Parse(_settings.GetElement(3, "Grid").Value); }
        }

        public double GridStepY
        {
            get { return double.Parse(_settings.GetElement(4, "Grid").Value); }
        }

        public Color GridColor
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(5, "Grid").Value)); }
        }

        public Color Point3DFirstPlaneColor
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(0, "Point3D").Value)); }
        }

        public Color Point3DSecondPlaneColor
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(1, "Point3D").Value)); }
        }

        public Color Point3DThirdPlaneColor
        {
            get { return ColorTranslator.FromWin32(int.Parse(_settings.GetElement(2, "Point3D").Value)); }
        }

        public string Point3DFirstPlaneName
        {
            get { return _settings.GetElement(6, "Point3D").Value; }
        }

        public string Point3DSecondPlaneName
        {
            get { return _settings.GetElement(7, "Point3D").Value; }
        }

        public string Point3DThirdPlaneName
        {
            get { return _settings.GetElement(8, "Point3D").Value; }
        }
    }
}
