﻿using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Lines
{
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane1X0Y : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, blueprint, settings, storage);
            if (obj == null)
            {
                return;
            }
            storage.AddToCollection(obj);
            blueprint.Update(storage);
        }
        public LineOfPlane1X0Y Create(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings setting, Storage strg)
        {
            if (!PointOfPlane1X0Y.IsCreatable(pt, frameCenter))
            {
                return null;
            }

            var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(blueprint);
                return null;
            }

            if (ptOfPlane.IsCoincides((PointOfPlane1X0Y) strg.TempObjects.First()))
            {
                return null;
            }

            var source = new LineOfPlane1X0Y((PointOfPlane1X0Y) strg.TempObjects.First(), ptOfPlane, blueprint.PlaneX0Y)
            {
                Name = strg.TempObjects.First().Name
            };

            strg.TempObjects.Clear();
            return source;
        }
    }
}
