namespace GraphicsModule.Configuration.Access.Structures
{
    public struct SegmentsAccess
    {
        public bool IsSegmentsEnabled;
        public bool IsSegment2DEnabled;
        public bool IsSegment3DEnabled;
        public bool IsSegmentOfPlane1X0YEnabled;
        public bool IsSegmentOfPlane2X0ZEnabled;
        public bool IsSegmentOfPlane3Y0ZEnabled;
        public bool IsGenerateSegment3DEnabled;
        public SegmentsAccess(bool segmentsEnabled, bool segment2DEnabled, bool segment3DEnabled, bool segmentOfPlane1X0YEnabled,
            bool segmentOfPlane2X0ZEnabled, bool segmentOfPlane3Y0ZEnabled, bool generateSegment3DEnabled)
        {
            IsSegmentsEnabled = segmentsEnabled;
            IsSegment2DEnabled = segment2DEnabled;
            IsSegment3DEnabled = segment3DEnabled;
            IsSegmentOfPlane1X0YEnabled = segmentOfPlane1X0YEnabled;
            IsSegmentOfPlane2X0ZEnabled = segmentOfPlane2X0ZEnabled;
            IsSegmentOfPlane3Y0ZEnabled = segmentOfPlane3Y0ZEnabled;
            IsGenerateSegment3DEnabled = generateSegment3DEnabled;
        }
    }
}
