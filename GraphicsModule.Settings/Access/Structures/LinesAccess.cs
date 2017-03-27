using System;

namespace GraphicsModule.Configuration.Access.Structures
{
    [Serializable]
    public class LinesAccess
    {
        public bool IsLinesEnabled { get; set; }
        public bool IsLine2DEnabled { get; set; }
        public bool IsLine3DEnabled { get; set; }
        public bool IsLineOfPlane1X0YEnabled { get; set; }
        public bool IsLineOfPlane2X0ZEnabled { get; set; }
        public bool IsLineOfPlane3Y0ZEnabled { get; set; }
        public bool IsGenerateLine3DEnabled { get; set; }
        public LinesAccess(bool linesEnabled, bool line2DEnabled, bool line3DEnabled, bool lineOfPlane1X0YEnabled,
            bool lineOfPlane2X0ZEnabled, bool lineOfPlane3Y0ZEnabled, bool generateLine3DEnabled)
        {
            IsLinesEnabled = linesEnabled;
            IsLine2DEnabled = line2DEnabled;
            IsLine3DEnabled = line3DEnabled;
            IsLineOfPlane1X0YEnabled = lineOfPlane1X0YEnabled;
            IsLineOfPlane2X0ZEnabled = lineOfPlane2X0ZEnabled;
            IsLineOfPlane3Y0ZEnabled = lineOfPlane3Y0ZEnabled;
            IsGenerateLine3DEnabled = generateLine3DEnabled;
        }
    }
}
