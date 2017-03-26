namespace GraphicsModule.Configuration.Access.Structures
{
    public struct LinesAccess
    {
        public bool IsLinesEnabled;
        public bool IsLine2DEnabled;
        public bool IsLine3DEnabled;
        public bool IsLineOfPlane1X0YEnabled;
        public bool IsLineOfPlane2X0ZEnabled;
        public bool IsLineOfPlane3Y0ZEnabled;
        public bool IsGenerateLine3DEnabled;
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
