using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Segments
{
    /// <summary>
    /// Создание 3D линии
    /// </summary>
    public class CreateSegment3D : ICreate
    {
        private IObject _tempLineOfPlane;
        private Segment3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Blueprint blueprint, DrawSettings settings, Storage storage)
        {
            var ptOfPlane = pt.ToPointOfPlane(frameCenter);
            if (storage.TempObjects.Count == 0)
            {
                if (_tempLineOfPlane == null)
                {
                    ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                    storage.TempObjects.Add(ptOfPlane);
                    storage.DrawLastAddedToTempObjects(blueprint);
                }
                else
                {
                    if (IsInOnePlane(_tempLineOfPlane, ptOfPlane)) return;
                    if (!IsOnLinkLine(_tempLineOfPlane, ptOfPlane)) return;
                    storage.TempObjects.Add(ptOfPlane);
                    storage.DrawLastAddedToTempObjects(blueprint);
                }
            }
            else
            {
                if (ReferenceEquals(storage.TempObjects[0].GetType(), ptOfPlane.GetType()) && _tempLineOfPlane == null)
                {
                    storage.TempObjects.Add(ptOfPlane);
                    _tempLineOfPlane = CreateSegmentOfPlane(storage.TempObjects, settings, frameCenter, blueprint);
                    _tempLineOfPlane.Name = storage.TempObjects[0].Name;
                    storage.TempObjects.Clear();
                    blueprint.Update(storage);
                    _tempLineOfPlane.Draw(blueprint);
                }
                else if (IsOnLinkLine(_tempLineOfPlane, ptOfPlane))
                {
                    storage.TempObjects.Add(ptOfPlane);
                    if (!IsSegment3DCreatable(_tempLineOfPlane, CreateSegmentOfPlane(storage.TempObjects, settings, frameCenter, blueprint), settings, frameCenter, blueprint)) return;
                    _source.Name = _tempLineOfPlane.Name;
                    storage.TempObjects.Clear();
                    _tempLineOfPlane = null;
                    storage.Objects.Add(_source);
                    blueprint.Update(storage);
                    storage.DrawLastAddedToObjects(blueprint);
                }
            }
        }
        protected bool IsSegment3DCreatable(IObject ln1, IObject ln2, DrawSettings st, Point frameCenter, Blueprint blueprint)
        {
            if (ln1.GetType() == typeof(SegmentOfPlane1X0Y) && ln2.GetType() == typeof(SegmentOfPlane2X0Z))
            {
                _source = new Segment3D((SegmentOfPlane1X0Y)ln1, (SegmentOfPlane2X0Z)ln2);
                return true;
            }
            if (ln1.GetType() == typeof(SegmentOfPlane1X0Y) && ln2.GetType() == typeof(SegmentOfPlane3Y0Z))
            {
                _source = new Segment3D((SegmentOfPlane1X0Y)ln1, (SegmentOfPlane3Y0Z)ln2);
                return true;
            }
            if (ln1.GetType() == typeof(SegmentOfPlane2X0Z) && ln2.GetType() == typeof(SegmentOfPlane1X0Y))
            {
                _source = new Segment3D((SegmentOfPlane1X0Y)ln2, (SegmentOfPlane2X0Z)ln1);
                return true;
            }
            if (ln1.GetType() == typeof(SegmentOfPlane2X0Z) && ln2.GetType() == typeof(SegmentOfPlane3Y0Z))
            {
                _source = new Segment3D((SegmentOfPlane2X0Z)ln1, (SegmentOfPlane3Y0Z)ln2);
                return true;

            }
            if (ln1.GetType() == typeof(SegmentOfPlane3Y0Z) && ln2.GetType() == typeof(SegmentOfPlane1X0Y))
            {
                _source = new Segment3D((SegmentOfPlane1X0Y)ln2, (SegmentOfPlane3Y0Z)ln1);
                return true;
            }
            if (ln1.GetType() == typeof(SegmentOfPlane3Y0Z) && ln2.GetType() == typeof(SegmentOfPlane2X0Z))
            {
                _source = new Segment3D((SegmentOfPlane2X0Z)ln2, (SegmentOfPlane3Y0Z)ln1);
                return true;
            }
            return false;
        }
        protected IObject CreateSegmentOfPlane(IList<IObject> obj, DrawSettings st, Point frameCenter, Blueprint blueprint)
        {
            if (obj[0].GetType() == typeof(PointOfPlane1X0Y))
            {
                return new SegmentOfPlane1X0Y((PointOfPlane1X0Y)obj[0], (PointOfPlane1X0Y)obj[1]);
            }
            if (obj[0].GetType() == typeof(PointOfPlane2X0Z))
            {
                return new SegmentOfPlane2X0Z((PointOfPlane2X0Z)obj[0], (PointOfPlane2X0Z)obj[1]);
            }
            return new SegmentOfPlane3Y0Z((PointOfPlane3Y0Z)obj[0], (PointOfPlane3Y0Z)obj[1]);
        }
        protected bool IsInOnePlane(IObject lnproj, IObject ptproj)
        {
            if (lnproj.GetType() == typeof(SegmentOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
            {
                return true;
            }
            if (lnproj.GetType() == typeof(SegmentOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
            {
                return true;
            }
            return lnproj.GetType() == typeof(SegmentOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane3Y0Z);
        }
        protected bool IsOnLinkLine(IObject lnproj, IObject ptproj)
        {
            if (lnproj.GetType() == typeof(SegmentOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
            {
                return IsOnLinkLine12((SegmentOfPlane1X0Y)lnproj, (PointOfPlane2X0Z)ptproj);
            }
            if (lnproj.GetType() == typeof(SegmentOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane3Y0Z))
            {
                return IsOnLinkLine13((SegmentOfPlane1X0Y)lnproj, (PointOfPlane3Y0Z)ptproj);
            }
            if (lnproj.GetType() == typeof(SegmentOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
            {
                return IsOnLinkLine21((SegmentOfPlane2X0Z)lnproj, (PointOfPlane1X0Y)ptproj);
            }
            if (lnproj.GetType() == typeof(SegmentOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane3Y0Z))
            {
                return IsOnLinkLine23((SegmentOfPlane2X0Z) lnproj, (PointOfPlane3Y0Z) ptproj);
            }
            if (lnproj.GetType() == typeof(SegmentOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
            {
                return IsOnLinkLine31((SegmentOfPlane3Y0Z)lnproj, (PointOfPlane1X0Y)ptproj);
            }
            if (lnproj.GetType() == typeof(SegmentOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
            {
                return IsOnLinkLine32((SegmentOfPlane3Y0Z)lnproj, (PointOfPlane2X0Z)ptproj);
            }
            return false;
        }

        #region IsOnLinkLine
        protected bool IsOnLinkLine12(SegmentOfPlane1X0Y lnproj, PointOfPlane2X0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.X - ptproj.X) < tolerance || Math.Abs(lnproj.Point1.X - ptproj.X) < tolerance;
        }
        protected bool IsOnLinkLine13(SegmentOfPlane1X0Y lnproj, PointOfPlane3Y0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Y - ptproj.Y) < tolerance || Math.Abs(lnproj.Point1.Y - ptproj.Y) < tolerance;
        }
        protected bool IsOnLinkLine21(SegmentOfPlane2X0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.X - ptproj.X) < tolerance || Math.Abs(lnproj.Point1.X - ptproj.X) < tolerance;
        }
        protected bool IsOnLinkLine23(SegmentOfPlane2X0Z lnproj, PointOfPlane3Y0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Z - ptproj.Z) < tolerance || Math.Abs(lnproj.Point1.Z - ptproj.Z) < tolerance;
        }
        protected bool IsOnLinkLine31(SegmentOfPlane3Y0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Y - ptproj.Y) < tolerance || Math.Abs(lnproj.Point1.Y - ptproj.Y) < tolerance;
        }
        protected bool IsOnLinkLine32(SegmentOfPlane3Y0Z lnproj, PointOfPlane2X0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Z - ptproj.Z) < tolerance || Math.Abs(lnproj.Point1.Z - ptproj.Z) < tolerance;
        }
        #endregion
    }
}
