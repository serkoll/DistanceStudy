﻿using System;
using GraphicsModule.Configuration.Access.Structures;

namespace GraphicsModule.Configuration.Access
{
    [Serializable]
    public class PrimitivesAccess
    {
        public PrimitivesAccess(GeneralAccess general, PointsAccess points, LinesAccess lines, SegmentsAccess segments, PlanesAccess planes)
        {
            General = general;
            Points = points;
            Lines = lines;
            Segments = segments;
            Planes = planes;
        }
        public PrimitivesAccess()
        {
            General = new GeneralAccess(true, true, true, true, true, true);
            Points = new PointsAccess(true, true, true, true, true, true, true);
            Lines = new LinesAccess(true, true, true, true, true, true, true);
            Segments = new SegmentsAccess(true, true, true, true, true, true, true);
            Planes = new PlanesAccess(true, true, true, true, true, true, true);
        }
        public GeneralAccess General { get; set; }
        public PointsAccess Points { get; }
        public LinesAccess Lines { get; }
        public SegmentsAccess Segments { get; }
        public PlanesAccess Planes { get; }

    }
}
