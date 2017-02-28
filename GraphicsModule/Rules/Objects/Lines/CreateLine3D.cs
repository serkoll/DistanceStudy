using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;
using GraphicsModule.Geometry.Interfaces;
using System.Collections.ObjectModel;
using GraphicsModule.Geometry;

namespace GraphicsModule.Rules.Objects.Lines
{
    /// <summary>
    /// Создание 3D линии
    /// </summary>
    public class CreateLine3D : ICreate
    {
        private IObject _tempLineOfPlane;
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                if (_tempLineOfPlane == null)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    if (IsInOnePlane(_tempLineOfPlane, ptOfPlane)) return;
                    if (!IsOnLinkLine(_tempLineOfPlane, ptOfPlane)) return;
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
            }
            else
            {
                if (ReferenceEquals(strg.TempObjects[0].GetType(), ptOfPlane.GetType()) &&
                    (_tempLineOfPlane == null))
                {
                    strg.TempObjects.Add(ptOfPlane);
                    _tempLineOfPlane = CreateLineOfPlane(strg.TempObjects, setting, frameCenter, can);
                    _tempLineOfPlane.SetName(strg.TempObjects[0].GetName());
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    _tempLineOfPlane.Draw(setting, frameCenter, can.Graphics);
                }
                else if (IsOnLinkLine(_tempLineOfPlane, ptOfPlane))
                {
                    strg.TempObjects.Add(ptOfPlane);
                    if (
                        !IsLine3DCreatable(_tempLineOfPlane,
                            CreateLineOfPlane(strg.TempObjects, setting, frameCenter, can), setting, frameCenter,
                            can)) return;
                    _source.SetName(_tempLineOfPlane.GetName());
                    strg.TempObjects.Clear();
                    _tempLineOfPlane = null;
                    strg.Objects.Add(_source);
                    can.Update(strg);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
            }
        }

        protected bool IsLine3DCreatable(IObject ln1, IObject ln2, DrawS st, Point frameCenter, Canvas.Canvas can)
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

        protected IObject CreateLineOfPlane(Collection<IObject> obj, DrawS st, Point frameCenter, Canvas.Canvas can)
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
            return lnproj.Point0.X == ptproj.X || lnproj.Point1.X == ptproj.X;
        }

        protected bool IsOnLinkLine13(LineOfPlane1X0Y lnproj, PointOfPlane3Y0Z ptproj)
        {
            return lnproj.Point0.Y == ptproj.Y || lnproj.Point1.Y == ptproj.Y;
        }

        protected bool IsOnLinkLine21(LineOfPlane2X0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            return lnproj.Point0.X == ptproj.X || lnproj.Point1.X == ptproj.X;
        }

        protected bool IsOnLinkLine23(LineOfPlane2X0Z lnproj, PointOfPlane3Y0Z ptproj)
        {
            return lnproj.Point0.Z == ptproj.Z || lnproj.Point1.Z == ptproj.Z;
        }

        protected bool IsOnLinkLine31(LineOfPlane3Y0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            return lnproj.Point0.Y == ptproj.Y || lnproj.Point1.Y == ptproj.Y;
        }

        protected bool IsOnLinkLine32(LineOfPlane3Y0Z lnproj, PointOfPlane2X0Z ptproj)
        {
            return lnproj.Point0.Z == ptproj.Z || lnproj.Point1.Z == ptproj.Z;
        }

        #endregion
    }
}
