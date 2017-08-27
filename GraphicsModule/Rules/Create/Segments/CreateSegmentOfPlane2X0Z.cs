﻿using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateSegmentOfPlane2X0Z : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var obj = Create(pt, blueprint);
            if (obj == null)
                return;

            blueprint.Storage.AddToCollection(obj);
            blueprint.Update();
        }

        public SegmentOfPlane2X0Z Create(Point pt, Blueprint blueprint)
        {
            return Create(pt, blueprint.CoordinateSystemCenterPoint, blueprint);
        }

        private SegmentOfPlane2X0Z Create(Point pt, Point frameCenter, Blueprint blueprint)
        {
            if (!PointOfPlane2X0Z.IsCreatable(pt, frameCenter))
                return null;

            var ptOfPlane = new PointOfPlane2X0Z(pt, frameCenter);
            var tempObjects = blueprint.Storage.TempObjects;
            if (tempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                tempObjects.Add(ptOfPlane);
                blueprint.Storage.DrawLastAddedToTempObjects();
                return null;
            }

            if (ptOfPlane.IsCoincides((PointOfPlane2X0Z)tempObjects.First()))
                return null;

            ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
            var source = new SegmentOfPlane2X0Z((PointOfPlane2X0Z) tempObjects.First(), ptOfPlane);
            tempObjects.Clear();
            return source;
        }
    }
}
