using System;

namespace GraphicsModule.Configuration.Access.Structures
{
    [Serializable]
    public class PointsAccess
    {
        public bool IsPointsEnabled { get; set; }
        public bool IsPoint2DEnabled { get; set; }
        public bool IsPoint3DEnabled { get; set; }
        public bool IsPointOfPlane1X0YEnabled { get; set; }
        public bool IsPointOfPlane2X0ZEnabled { get; set; }
        public bool IsPointOfPlane3Y0ZEnabled { get; set; }
        public bool IsGeneratePoint3DEnabled { get; set; }
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
