﻿using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Points
{
    /// <summary>
    /// Создание проекции точки на плоскость X0Z
    /// </summary>
    public class CreatePointOfPlane2X0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Drawing drawing, DrawSettings settings, Storage storage)
        {
            var source = Create(pt, frameCenter, drawing, settings, storage);
            if (source == null)
            {
                return;
            }
            storage.AddToCollection(source);
            storage.DrawLastAddedToObjects(settings, frameCenter, drawing.Graphics);
        }
        public PointOfPlane2X0Z Create(Point pt, Point frameCenter, Drawing can, DrawSettings setting, Storage strg)
        {
            return PointOfPlane2X0Z.IsCreatable(pt, frameCenter) 
                ? new PointOfPlane2X0Z(pt, frameCenter) { Name = GraphicsControl.NamesGenerator.Generate() } 
                : null;
        }
    }
}