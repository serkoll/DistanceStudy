using System;
using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Geometry.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry;

namespace GraphicsModule.Rules.Objects.Lines
{
    /// <summary>
    /// Создание 3D линии
    /// </summary>
    public class CreateLine3D : ICreate
    {
        public ILineOfPlane TempLineOfPlane;
        private Line3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas canvas, DrawSettings settings, Storage storage)
        {
            var obj = Create(pt, frameCenter, canvas, settings, storage);
            if (obj == null) return;
            storage.AddToCollection(obj);
            canvas.Update(storage);
        }
        public Line3D Create(Point pt, Point frameCenter, Canvas can, DrawSettings setting, Storage strg)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                if (TempLineOfPlane == null)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return null;
                }
                if (IsInOnePlane(TempLineOfPlane, ptOfPlane)) return null;
                if (!IsOnLinkLine(TempLineOfPlane, ptOfPlane)) return null;
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return null;
            }
            if (ReferenceEquals(strg.TempObjects.First().GetType(), ptOfPlane.GetType()) && (TempLineOfPlane == null))
            {
                strg.TempObjects.Add(ptOfPlane);
                TempLineOfPlane = CreateLineOfPlane(strg.TempObjects, setting, frameCenter, can);
                TempLineOfPlane.SetName(strg.TempObjects.First().GetName());
                strg.TempObjects.Clear();
                can.Update(strg);
                TempLineOfPlane.Draw(setting, frameCenter, can.Graphics);
                return null;
            }
            if (!IsOnLinkLine(TempLineOfPlane, ptOfPlane)) return null;
            strg.TempObjects.Add(ptOfPlane);
            if (!IsLine3DCreatable(TempLineOfPlane, CreateLineOfPlane(strg.TempObjects, setting, frameCenter, can), setting, frameCenter, can)) return null;
            _source.SetName(TempLineOfPlane.GetName());
            strg.TempObjects.Clear();
            TempLineOfPlane = null;
            return _source;
        }

        protected bool IsLine3DCreatable(IObject ln1, IObject ln2, DrawSettings st, Point frameCenter, Canvas can)
        {
            if (ln1 == null) return false;
            if (ln1.GetType() == typeof(LineOfPlane1X0Y) && ln2.GetType() == typeof(LineOfPlane2X0Z))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln1, (LineOfPlane2X0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane1X0Y) && ln2.GetType() == typeof(LineOfPlane3Y0Z))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln1, (LineOfPlane3Y0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane2X0Z) && ln2.GetType() == typeof(LineOfPlane1X0Y))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln2, (LineOfPlane2X0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane2X0Z) && ln2.GetType() == typeof(LineOfPlane3Y0Z))
            {
                _source = new Line3D((LineOfPlane2X0Z)ln1, (LineOfPlane3Y0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;

            }
            if (ln1.GetType() == typeof(LineOfPlane3Y0Z) && ln2.GetType() == typeof(LineOfPlane1X0Y))
            {
                _source = new Line3D((LineOfPlane1X0Y)ln2, (LineOfPlane3Y0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            if (ln1.GetType() == typeof(LineOfPlane3Y0Z) && ln2.GetType() == typeof(LineOfPlane2X0Z))
            {
                _source = new Line3D((LineOfPlane2X0Z)ln2, (LineOfPlane3Y0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            return false;
        }

        protected ILineOfPlane CreateLineOfPlane(Collection<IObject> obj, DrawSettings st, Point frameCenter, Canvas can)
        {
            if (obj[0].GetType() == typeof(PointOfPlane1X0Y))
            {
                var source = new LineOfPlane1X0Y((PointOfPlane1X0Y)obj[0], (PointOfPlane1X0Y)obj[1]);
                source.CalculatePointsForDraw(frameCenter, can.PlaneX0Y);
                return source;
            }
            if (obj[0].GetType() == typeof(PointOfPlane2X0Z))
            {
                var source = new LineOfPlane2X0Z((PointOfPlane2X0Z)obj[0], (PointOfPlane2X0Z)obj[1]);
                source.CalculatePointsForDraw(frameCenter, can.PlaneX0Z);
                return source;
            }
            else
            {
                var source = new LineOfPlane3Y0Z((PointOfPlane3Y0Z)obj[0], (PointOfPlane3Y0Z)obj[1]);
                source.CalculatePointsForDraw(frameCenter, can.PlaneY0Z);
                return source;
            }
        }

        protected bool IsInOnePlane(IObject lnproj, IObject ptproj)
        {
            if (lnproj.GetType() == typeof(LineOfPlane1X0Y) && ptproj.GetType() == typeof(PointOfPlane1X0Y))
            {
                return true;
            }
            if (lnproj.GetType() == typeof(LineOfPlane2X0Z) && ptproj.GetType() == typeof(PointOfPlane2X0Z))
            {
                return true;
            }
            if (lnproj.GetType() == typeof(LineOfPlane3Y0Z) && ptproj.GetType() == typeof(PointOfPlane3Y0Z))
            {
                return true;
            }
            return false;
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
