﻿using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Points
{
    /// <summary>
    /// Создание проекции точки на плоскость X0Z
    /// </summary>
    public class CreatePointOfPlane3Y0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var source = Create(pt, blueprint);
            if (source == null)
            {
                return;
            }
            blueprint.Storage.AddToCollection(source);
            blueprint.Storage.DrawLastAddedToObjects();
        }
        public PointOfPlane3Y0Z Create(Point pt, Blueprint blueprint)
        {
            return PointOfPlane3Y0Z.IsCreatable(pt, blueprint.CoordinateSystemCenterPoint) 
                ? new PointOfPlane3Y0Z(pt, blueprint.CoordinateSystemCenterPoint) { Name = GraphicsControl.NamesGenerator.Generate() } 
                : null;
        }
    }
}
