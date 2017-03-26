using GraphicsModule.Configuration.Access.Structures;

namespace GraphicsModule.Configuration.Access
{
    public class PrimitivesAccess
    {
        public PointsAccess Points { get; }
        public LinesAccess Lines { get; }
        public SegmentsAccess Segments { get; }
        public PlanesAccess Planes { get; }

        public PrimitivesAccess(PointsAccess points, LinesAccess lines, SegmentsAccess segments, PlanesAccess planes)
        {
            Points = points;
            Lines = lines;
            Segments = segments;
            Planes = planes;
        }
    }
}
