using System.Collections.ObjectModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using GraphicsModule.Controls;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.CreateObjects
{
    /// <summary>
    /// Создание 2Д линии
    /// </summary>
    public class CreateLine2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
            strg.DrawLastAddedToObjects(settings, frameCenter, can.Graphics);
        }

        public Line2D Create(Point pt, Point frameCenter, Canvas.Canvas can, DrawS settings, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(settings, frameCenter, can.Graphics);
            }
            else
            {
                if (Analyze.PointPos.Coincidence((Point2D)strg.TempObjects[0], new Point2D(pt))) return null;
                var source = new Line2D((Point2D)strg.TempObjects[0], new Point2D(pt), can.PicBox);
                source.SetName(strg.TempObjects[0].GetName());
                strg.TempObjects.Clear();
                return source;
            }
            return null;
        }
    }
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane1X0Y : ICreate
    {
        private LineOfPlane1X0Y _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane1X0Y.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    if (Analyze.PointPos.Coincidence((PointOfPlane1X0Y)strg.TempObjects[0],
                        new PointOfPlane1X0Y(pt, frameCenter))) return;
                    _source = new LineOfPlane1X0Y((PointOfPlane1X0Y)strg.TempObjects[0],
                        new PointOfPlane1X0Y(pt, frameCenter),
                        frameCenter, can.PlaneX0Y);
                    _source.SetName(strg.TempObjects[0].GetName());
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
            }
        }
    }

    /// <summary>
    /// Создание проекции линии на плоскость X0Z
    /// </summary>
    public class CreateLineOfPlane2X0Z : ICreate
    {
        private LineOfPlane2X0Z _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane2X0Z.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane2X0Z(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    if (Analyze.PointPos.Coincidence((PointOfPlane2X0Z)strg.TempObjects[0],
                        new PointOfPlane2X0Z(pt, frameCenter))) return;
                    _source = new LineOfPlane2X0Z((PointOfPlane2X0Z)strg.TempObjects[0],
                        new PointOfPlane2X0Z(pt, frameCenter),
                        frameCenter, can.PlaneX0Z);
                    _source.SetName(strg.TempObjects[0].GetName());
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
            }
        }
    }

    /// <summary>
    /// Создание проекции линии на плоскость Y0Z
    /// </summary>
    public class CreateLineOfPlane3Y0Z : ICreate
    {
        private LineOfPlane3Y0Z _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane3Y0Z.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    if (Analyze.PointPos.Coincidence((PointOfPlane3Y0Z)strg.TempObjects[0],
                        new PointOfPlane3Y0Z(pt, frameCenter))) return;
                    _source = new LineOfPlane3Y0Z((PointOfPlane3Y0Z)strg.TempObjects[0],
                        new PointOfPlane3Y0Z(pt, frameCenter),
                        frameCenter, can.PlaneY0Z);
                    _source.SetName(strg.TempObjects[0].GetName());
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.TempObjects.Clear();
                    can.Update(strg);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
            }
        }
    }

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

    public class GenerateLine3D : ICreate
    {
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            new SelectLineOfPlane().Execute(pt, strg, can);
            if (strg.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(strg.SelectedObjects[0].GetType(), strg.SelectedObjects[1].GetType()))
                {
                    strg.SelectedObjects.Remove(strg.SelectedObjects[0]);
                    can.Update(strg);
                    return;
                }
                if ((_source = Line3D.Create(strg.SelectedObjects)) != null)
                {
                    _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                    strg.Objects.Remove(strg.SelectedObjects[0]);
                    strg.Objects.Remove(strg.SelectedObjects[1]);
                    strg.SelectedObjects.Clear();
                    can.Update(strg);
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    strg.SelectedObjects.RemoveAt(strg.SelectedObjects.Count - 1);
                    can.Update(strg);
                }
            }
            else
            {
                can.Update(strg);
            }
        }
    }
}
