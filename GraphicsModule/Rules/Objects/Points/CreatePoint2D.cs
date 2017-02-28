﻿using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Создание 2Д точки
    /// </summary>
    public class CreatePoint2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            strg.AddToCollection(Create(pt, frameCenter, can, setting, strg));
            strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
        }

        public Point2D Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var source = new Point2D(pt);
            source.SetName(GraphicsControl.NmGenerator.Generate());
            return source;
        }
    }
}