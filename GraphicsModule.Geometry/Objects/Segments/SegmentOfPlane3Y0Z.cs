﻿using System;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Segments
{
    /// <summary>Класс для расчета параметров проекции 3D линии на Y0Z плоскость проекций</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class SegmentOfPlane3Y0Z : ISegmentOfPlane
    {
        public PointOfPlane3Y0Z Point0 { get; set; }
        public PointOfPlane3Y0Z Point1 { get; set; }
        public Name Name { get; set; }
        public double Ky { get; set; }
        public double Kz { get; set; }
        public SegmentOfPlane3Y0Z(PointOfPlane3Y0Z pt0, PointOfPlane3Y0Z pt1)
        {
            Point0 = pt0;
            Point1 = pt1;
            Ky = pt1.Y - pt0.Y;
            Kz = pt1.Z - pt0.Z;

        }
        public SegmentOfPlane3Y0Z(Segment3D line)
        {
            Point0.Y = line.Point0.Y;
            Point0.Z = line.Point0.Z;
            Point1.Y = line.Point1.Y;
            Point1.Z = line.Point1.Z;
        }
        public void Draw(DrawSettings settings, Point framecenter, Graphics g)
        {
            Point0.Draw(settings, framecenter, g);
            Point1.Draw(settings, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, settings.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, settings.RadiusPoints, framecenter);
            g.DrawLine(settings.PenLineOfPlane3Y0Z, new PointF(pt0.X + settings.RadiusPoints, pt0.Y + settings.RadiusPoints),
                                              new PointF(pt1.X + settings.RadiusPoints, pt1.Y + settings.RadiusPoints));
        }
        public void DrawSegmentOnly(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.DrawPointsOnly(st, framecenter, g);
            Point1.DrawPointsOnly(st, framecenter, g);
            var pt0 = DeterminePosition.ForPointProjection(Point0, st.RadiusPoints, framecenter);
            var pt1 = DeterminePosition.ForPointProjection(Point1, st.RadiusPoints, framecenter);
            g.DrawLine(st.PenLineOfPlane3Y0Z, new PointF(pt0.X + st.RadiusPoints, pt0.Y + st.RadiusPoints),
                                              new PointF(pt1.X + st.RadiusPoints, pt1.Y + st.RadiusPoints));
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            var sg = DeterminePosition.ForSegmentProjection(this, frameCenter);
            return Analyze.Analyze.SegmentsPosition.IncidenceOfPoint(mscoords, sg, 35 * distance);
        }
        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name name)
        {
            Name = new Name(name);
            Name.Value += "'''";
            Point0.Name = Name;
            Point1.Name = Name;
        }
    }
}
