﻿using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Generate
{
    public class GenerateSegment3D : ICreate
    {
        private Segment3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            new SelectSegmentOfPlane().Execute(pt, storage, blueprint);
            if (storage.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(storage.SelectedObjects[0].GetType(), storage.SelectedObjects[1].GetType()))
                {
                    storage.SelectedObjects.Remove(storage.SelectedObjects[0]);
                    blueprint.Update(storage);
                    return;
                }
                if ((_source = ObjectsCreator.Segment3D().Create(storage.SelectedObjects.Cast<ISegmentOfPlane>().ToList())) != null)
                {
                    storage.Objects.Remove(storage.SelectedObjects[0]);
                    storage.Objects.Remove(storage.SelectedObjects[1]);
                    storage.SelectedObjects.Clear();
                    blueprint.Update(storage);
                    storage.AddToCollection(_source);
                    _source = null;
                    storage.DrawLastAddedToObjects(blueprint);
                }
                else
                {
                    storage.SelectedObjects.RemoveAt(storage.SelectedObjects.Count - 1);
                    blueprint.Update(storage);
                }
            }
            else
            {
                blueprint.Update(storage);
            }
        }
    }
}
