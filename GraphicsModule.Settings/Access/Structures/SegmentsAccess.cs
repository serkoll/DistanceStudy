using System;

namespace GraphicsModule.Configuration.Access.Structures
{
    [Serializable]
    public class SegmentsAccess
    {
        public bool IsSegmentsEnabled { get; set; }
        public bool IsSegment2DEnabled { get; set; }
        public bool IsSegment3DEnabled { get; set; }
        public bool IsSegmentOfPlane1X0YEnabled { get; set; }
        public bool IsSegmentOfPlane2X0ZEnabled { get; set; }
        public bool IsSegmentOfPlane3Y0ZEnabled { get; set; }
        public bool IsGenerateSegment3DEnabled { get; set; }
        public SegmentsAccess()
        {
            IsSegmentsEnabled =
                IsSegment2DEnabled =
                    IsSegment3DEnabled =
                        IsSegmentOfPlane1X0YEnabled =
                            IsSegmentOfPlane2X0ZEnabled =
                                IsSegmentOfPlane3Y0ZEnabled = IsGenerateSegment3DEnabled = true;
        }
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
