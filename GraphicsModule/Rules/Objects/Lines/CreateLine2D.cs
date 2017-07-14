﻿using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Lines
{
    public class CreateLine2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, canvas, settings, storage);
            if (obj == null) return;
            storage.AddToCollection(obj);
            canvas.Update(storage);
        }
        public Line2D Create(Point pt, Point frameCenter, Canvas can, DrawSettings settings, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(settings, frameCenter, can.Graphics);
            }
            else
            {
                if (Analyze.PointsPosition.Coincidence((Point2D)strg.TempObjects.First(), new Point2D(pt))) return null;
                var source = new Line2D((Point2D)strg.TempObjects.First(), new Point2D(pt), can.PictureBox);
                source.Name = strg.TempObjects.First().Name;
                strg.TempObjects.Clear();
                return source;
            }
            return null;
        }
    }
}