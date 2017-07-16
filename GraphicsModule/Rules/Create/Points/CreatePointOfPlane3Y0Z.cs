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
    public class CreatePointOfPlane3Y0Z : ICreate
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
        public PointOfPlane3Y0Z Create(Point pt, Point frameCenter, Drawing can, DrawSettings setting, Storage strg)
        {
            return PointOfPlane3Y0Z.IsCreatable(pt, frameCenter) 
                ? new PointOfPlane3Y0Z(pt, frameCenter) { Name = GraphicsControl.NamesGenerator.Generate() } 
                : null;
        }
    }
}