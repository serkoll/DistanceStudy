﻿using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects.Segments
{
    public class CreateSegmentOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
        }
        public SegmentOfPlane1X0Y Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (!PointOfPlane1X0Y.Creatable(pt, frameCenter)) return null;
            var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (Analyze.PointPos.Coincidence((PointOfPlane1X0Y)strg.TempObjects[0],
                new PointOfPlane1X0Y(pt, frameCenter))) return null;
            var source = new SegmentOfPlane1X0Y((PointOfPlane1X0Y)strg.TempObjects[0],
                new PointOfPlane1X0Y(pt, frameCenter));
            source.SetName(strg.TempObjects[0].GetName());
            strg.TempObjects.Clear();
            return source;
        }
    }
}
