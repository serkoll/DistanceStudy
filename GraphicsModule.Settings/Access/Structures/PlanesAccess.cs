namespace GraphicsModule.Configuration.Access.Structures
{
    public struct PlanesAccess
    {
        public bool IsPlanesEnabled;
        public bool IsPlane2DEnabled;
        public bool IsPlane3DEnabled;
        public bool IsPlaneOfPlane1X0YEnabled;
        public bool IsPlaneOfPlane2X0ZEnabled;
        public bool IsPlaneOfPlane3Y0ZEnabled;
        public bool IsGeneratePlane3DEnabled;
        public PlanesAccess(bool planesEnabled, bool plane2DEnabled, bool plane3DEnabled, bool planeOfPlane1X0YEnabled,
            bool planeOfPlane2X0ZEnabled, bool planeOfPlane3Y0ZEnabled, bool generatePlane3DEnabled)
        {
            IsPlanesEnabled = planesEnabled;
            IsPlane2DEnabled = plane2DEnabled;
            IsPlane3DEnabled = plane3DEnabled;
            IsPlaneOfPlane1X0YEnabled = planeOfPlane1X0YEnabled;
            IsPlaneOfPlane2X0ZEnabled = planeOfPlane2X0ZEnabled;
            IsPlaneOfPlane3Y0ZEnabled = planeOfPlane3Y0ZEnabled;
            IsGeneratePlane3DEnabled = generatePlane3DEnabled;
        }
    }
}
