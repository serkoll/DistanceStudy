namespace GraphicsModule.Configuration.Access.Structures
{
    public struct PointsAccess
    {
        public bool IsPointsEnabled;
        public bool IsPoint2DEnabled;
        public bool IsPoint3DEnabled;
        public bool IsPointOfPlane1X0YEnabled;
        public bool IsPointOfPlane2X0ZEnabled;
        public bool IsPointOfPlane3Y0ZEnabled;
        public bool IsGeneratePoint3DEnabled;
        public PointsAccess(bool pointsEnabled, bool point2DEnabled, bool point3DEnabled, bool pointOfPlane1X0YEnabled,
            bool pointOfPlane2X0ZEnabled, bool pointOfPlane3Y0ZEnabled, bool generatePoint3DEnabled)
        {
            IsPointsEnabled = pointsEnabled;
            IsPoint2DEnabled = point2DEnabled;
            IsPoint3DEnabled = point3DEnabled;
            IsPointOfPlane1X0YEnabled = pointOfPlane1X0YEnabled;
            IsPointOfPlane2X0ZEnabled = pointOfPlane2X0ZEnabled;
            IsPointOfPlane3Y0ZEnabled = pointOfPlane3Y0ZEnabled;
            IsGeneratePoint3DEnabled = generatePoint3DEnabled;
        }
    }
}
