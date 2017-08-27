using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Extensions;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Create.Lines
{
    /// <summary>
    /// Создание 3D линии
    /// </summary>
    public class CreateLine3D : ICreate
    {
        public ILineOfPlane TempLineOfPlane;
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Blueprint blueprint)
        {
            var obj = Create(pt, blueprint);
            if (obj == null) return;
            blueprint.Storage.AddToCollection(obj);
            blueprint.Update();
        }

        public Line3D Create(Point pt, Blueprint blueprint)
        {
            return Create(pt, blueprint.CoordinateSystemCenterPoint, blueprint.Settings.Drawing, blueprint.Storage, blueprint);
        }

        private Line3D Create(Point pt, Point frameCenter, DrawSettings settings, Storage storage, Blueprint blueprint)
        {
            var ptOfPlane = pt.ToPointOfPlane(frameCenter);
            var tempObjects = storage.TempObjects;
            if (tempObjects.Count == 0)
            {
                if (TempLineOfPlane == null)
                {
                    ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                    tempObjects.Add(ptOfPlane);
                    storage.DrawLastAddedToTempObjects(blueprint);
                    return null;
                }
                if (IsInOnePlane(TempLineOfPlane, ptOfPlane))
                    return null;
                if (!IsOnLinkLine(TempLineOfPlane, ptOfPlane))
                    return null;

                tempObjects.Add(ptOfPlane);
                storage.DrawLastAddedToTempObjects(blueprint);
                return null;
            }

            if (ReferenceEquals(tempObjects.First().GetType(), ptOfPlane.GetType()) && TempLineOfPlane == null)
            {
                ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
                tempObjects.Add(ptOfPlane);
                TempLineOfPlane = CreateLineOfPlane(tempObjects, settings, frameCenter, blueprint);
                tempObjects.Clear();
                blueprint.Update();
                TempLineOfPlane.Draw(blueprint);
                return null;
            }
            if (!IsOnLinkLine(TempLineOfPlane, ptOfPlane))
                return null;

            ptOfPlane.Name = GraphicsControl.NamesGenerator.Generate();
            tempObjects.Add(ptOfPlane);

            if (!IsLine3DCreatable(TempLineOfPlane, CreateLineOfPlane(tempObjects, settings, frameCenter, blueprint), settings, frameCenter, blueprint))
                return null;

            tempObjects.Clear();
            TempLineOfPlane = null;
            return _source;
        }

        protected bool IsLine3DCreatable(IObject ln1, IObject ln2, DrawSettings st, Point frameCenter, Blueprint blueprint)
        {
            if (ln1 == null) return false;
            if (ln1.GetType() == typeof(LineOfPlane1X0Y) && ln2.GetType() == typeof(LineOfPlane2X0Z))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln1, (LineOfPlane2X0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane1X0Y) && ln2.GetType() == typeof(LineOfPlane3Y0Z))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln1, (LineOfPlane3Y0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane2X0Z) && ln2.GetType() == typeof(LineOfPlane1X0Y))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln2, (LineOfPlane2X0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane2X0Z) && ln2.GetType() == typeof(LineOfPlane3Y0Z))
            {
                _source = new Line3D((LineOfPlane2X0Z)ln1, (LineOfPlane3Y0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                return true;

            }
            if (ln1.GetType() == typeof(LineOfPlane3Y0Z) && ln2.GetType() == typeof(LineOfPlane1X0Y))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln2, (LineOfPlane3Y0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane3Y0Z) && ln2.GetType() == typeof(LineOfPlane2X0Z))
            {
                _source = new Line3D((LineOfPlane2X0Z)ln2, (LineOfPlane3Y0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, blueprint.PlaneX0Y, blueprint.PlaneX0Z, blueprint.PlaneY0Z);
                return true;
            }
            return false;
        }

        protected ILineOfPlane CreateLineOfPlane(IList<IObject> obj, DrawSettings st, Point frameCenter, Blueprint blueprint)
        {
            if (obj[0].GetType() == typeof(PointOfPlane1X0Y))
            {
                return new LineOfPlane1X0Y((PointOfPlane1X0Y)obj[0], (PointOfPlane1X0Y)obj[1]);
            }
            if (obj[0].GetType() == typeof(PointOfPlane2X0Z))
            {
                return new LineOfPlane2X0Z((PointOfPlane2X0Z)obj[0], (PointOfPlane2X0Z)obj[1]);
            }
            return new LineOfPlane3Y0Z((PointOfPlane3Y0Z)obj[0], (PointOfPlane3Y0Z)obj[1]);
        }

        protected bool IsInOnePlane(IObject lnproj, IObject ptproj)
        {
            return (lnproj.GetType() == typeof(LineOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
                   || (lnproj.GetType() == typeof(LineOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
                   || (lnproj.GetType() == typeof(LineOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane3Y0Z));
        }

        protected bool IsOnLinkLine(IObject lnproj, IObject ptproj)
        {
            if (lnproj.GetType() == typeof(LineOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
            {
                return IsOnLinkLine12((LineOfPlane1X0Y)lnproj, (PointOfPlane2X0Z)ptproj);
            }
            if (lnproj.GetType() == typeof(LineOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane3Y0Z))
            {
                return IsOnLinkLine13((LineOfPlane1X0Y)lnproj, (PointOfPlane3Y0Z)ptproj);
            }
            if (lnproj.GetType() == typeof(LineOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
            {
                return IsOnLinkLine21((LineOfPlane2X0Z)lnproj, (PointOfPlane1X0Y)ptproj);
            }
            if (lnproj.GetType() == typeof(LineOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane3Y0Z))
            {
                return IsOnLinkLine23((LineOfPlane2X0Z)lnproj, (PointOfPlane3Y0Z)ptproj);
            }
            if (lnproj.GetType() == typeof(LineOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
            {
                return IsOnLinkLine31((LineOfPlane3Y0Z)lnproj, (PointOfPlane1X0Y)ptproj);
            }
            if (lnproj.GetType() == typeof(LineOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
            {
                return IsOnLinkLine32((LineOfPlane3Y0Z)lnproj, (PointOfPlane2X0Z)ptproj);
            }
            return false;
        }

        #region IsOnLinkLine

        protected bool IsOnLinkLine12(LineOfPlane1X0Y lnproj, PointOfPlane2X0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.X - ptproj.X) < tolerance || Math.Abs(lnproj.Point1.X - ptproj.X) < tolerance;
        }

        protected bool IsOnLinkLine13(LineOfPlane1X0Y lnproj, PointOfPlane3Y0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Y - ptproj.Y) < tolerance || Math.Abs(lnproj.Point1.Y - ptproj.Y) < tolerance;
        }

        protected bool IsOnLinkLine21(LineOfPlane2X0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.X - ptproj.X) < tolerance || Math.Abs(lnproj.Point1.X - ptproj.X) < tolerance;
        }

        protected bool IsOnLinkLine23(LineOfPlane2X0Z lnproj, PointOfPlane3Y0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Z - ptproj.Z) < tolerance || Math.Abs(lnproj.Point1.Z - ptproj.Z) < tolerance;
        }

        protected bool IsOnLinkLine31(LineOfPlane3Y0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Y - ptproj.Y) < tolerance || Math.Abs(lnproj.Point1.Y - ptproj.Y) < tolerance;
        }

        protected bool IsOnLinkLine32(LineOfPlane3Y0Z lnproj, PointOfPlane2X0Z ptproj)
        {
            const double tolerance = 0.001;
            return Math.Abs(lnproj.Point0.Z - ptproj.Z) < tolerance || Math.Abs(lnproj.Point1.Z - ptproj.Z) < tolerance;
        }
        #endregion
    }
}
