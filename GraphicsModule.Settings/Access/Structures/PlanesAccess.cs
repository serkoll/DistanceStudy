using System;

namespace GraphicsModule.Configuration.Access.Structures
{
    [Serializable]
    public class PlanesAccess
    {
        public bool IsPlanesEnabled { get; set; }
        public bool IsPlane2DEnabled { get; set; }
        public bool IsPlane3DEnabled { get; set; }
        public bool IsPlaneOfPlane1X0YEnabled { get; set; }
        public bool IsPlaneOfPlane2X0ZEnabled { get; set; }
        public bool IsPlaneOfPlane3Y0ZEnabled { get; set; }
        public bool IsGeneratePlane3DEnabled { get; set; }

        public PlanesAccess()
        {
            IsPlanesEnabled =
                IsPlane2DEnabled =
                    IsPlane3DEnabled =
                        IsPlaneOfPlane1X0YEnabled =
                            IsPlaneOfPlane2X0ZEnabled = IsPlaneOfPlane3Y0ZEnabled = IsGeneratePlane3DEnabled = true;
        }
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
