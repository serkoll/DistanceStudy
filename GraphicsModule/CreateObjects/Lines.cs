using System;
using System.Collections.ObjectModel;
using System.Drawing;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Line;
using GraphicsModule.Geometry.Objects.Point;
using GraphicsModule.Geometry.Settingss;
using GraphicsModule.Operations;

namespace GraphicsModule.CreateObjects
{
    /// <summary>
    /// Создание 2Д линии
    /// </summary>
    public class CreateLine2D : ICreate
    {
        private Line2D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);
            if (strg.TempObjects.Count == 0)
            {
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                return;
            }
            else
            {
                if (!Analyze.PointPos.Coincidence((Point2D)strg.TempObjects[0], new Point2D(pt)))
                {
                    _source = new Line2D((Point2D)strg.TempObjects[0], new Point2D(pt), can.pb);
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.TempObjects.Clear();
                    can.ReDraw(strg);
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
            }
        }
    }
    /// <summary>
    /// Создание проекции линии на плоскость X0Y
    /// </summary>
    public class CreateLineOfPlane1X0Y : ICreate
    {
        private LineOfPlane1X0Y _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane1X0Y.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane1X0Y(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return;
                }
                else
                {
                    if (!Analyze.PointPos.Coincidence((PointOfPlane1X0Y)strg.TempObjects[0], new PointOfPlane1X0Y(pt, frameCenter)))
                    {
                        _source = new LineOfPlane1X0Y((PointOfPlane1X0Y)strg.TempObjects[0], new PointOfPlane1X0Y(pt, frameCenter),
                                                       frameCenter, new Rectangle(0, can.pb.Height / 2, can.pb.Width / 2, can.pb.Height / 2));
                        strg.AddToCollection(_source);
                        _source = null;
                        strg.TempObjects.Clear();
                        can.ReDraw(strg);
                        strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                    }
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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane2X0Z.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane2X0Z(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return;
                }
                else
                {
                    if (!Analyze.PointPos.Coincidence((PointOfPlane2X0Z)strg.TempObjects[0], new PointOfPlane2X0Z(pt, frameCenter)))
                    {
                        _source = new LineOfPlane2X0Z((PointOfPlane2X0Z)strg.TempObjects[0], new PointOfPlane2X0Z(pt, frameCenter),
                                                      frameCenter, new Rectangle(0, 0, can.pb.Width / 2, can.pb.Height / 2));
                        strg.AddToCollection(_source);
                        _source = null;
                        strg.TempObjects.Clear();
                        can.ReDraw(strg);
                        strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                    }
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
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            if (PointOfPlane3Y0Z.Creatable(pt, frameCenter))
            {
                var ptOfPlane = new PointOfPlane3Y0Z(pt, frameCenter);
                if (strg.TempObjects.Count == 0)
                {
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return;
                }
                else
                {
                    if (!Analyze.PointPos.Coincidence((PointOfPlane3Y0Z)strg.TempObjects[0], new PointOfPlane3Y0Z(pt, frameCenter)))
                    {
                        _source = new LineOfPlane3Y0Z((PointOfPlane3Y0Z)strg.TempObjects[0], new PointOfPlane3Y0Z(pt, frameCenter),
                                                       frameCenter, new Rectangle(can.pb.Width / 2, 0, can.pb.Width / 2, can.pb.Height / 2));
                        strg.AddToCollection(_source);
                        _source = null;
                        strg.TempObjects.Clear();
                        can.ReDraw(strg);
                        strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Создание 3D линии
    /// </summary>
    public class CreateLine3D : ICreate
    {
        private IObject tempLineOfPlane = null;
        private Line3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            var ptOfPlane = TypeOf.PointOfPlane(pt, frameCenter);
            if (strg.TempObjects.Count == 0)
            {
                if (tempLineOfPlane == null)
                {
                    strg.TempObjects.Add(ptOfPlane);
                    strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                    return;
                }
                else
                {
                    if (IsInOnePlane(tempLineOfPlane, ptOfPlane)) return;
                    if (IsOnLinkLine(tempLineOfPlane, ptOfPlane))
                    {
                        strg.TempObjects.Add(ptOfPlane);
                        strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
                        return;
                    }
                }
            }
            else
            {
                if (Object.ReferenceEquals(strg.TempObjects[0].GetType(), ptOfPlane.GetType()) && (tempLineOfPlane == null))
                {
                    strg.TempObjects.Add(ptOfPlane);
                    tempLineOfPlane = CreateLineOfPlane(strg.TempObjects, setting, frameCenter, can);
                    strg.TempObjects.Clear();
                    can.ReDraw(strg);
                    tempLineOfPlane.Draw(setting, frameCenter, can.Graphics);
                    return;
                }
                else if(IsOnLinkLine(tempLineOfPlane, ptOfPlane))
                {
                    strg.TempObjects.Add(ptOfPlane);
                    if (IsLine3DCreatable(tempLineOfPlane, CreateLineOfPlane(strg.TempObjects, setting, frameCenter, can), setting, frameCenter, can))
                    {
                        strg.TempObjects.Clear();
                        tempLineOfPlane = null;
                        strg.Objects.Add(_source);
                        can.ReDraw(strg);
                        strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                    }
                }
            }
        }
        protected bool IsLine3DCreatable(IObject ln1, IObject ln2, DrawS st, Point frameCenter, Canvas can)
        {
            if(ln1.GetType().Name == "LineOfPlane1X0Y" && ln2.GetType().Name == "LineOfPlane2X0Z")
            {
                _source = new Line3D((LineOfPlane1X0Y)ln1, (LineOfPlane2X0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            else if (ln1.GetType().Name == "LineOfPlane1X0Y" && ln2.GetType().Name == "LineOfPlane3Y0Z")
            {
                _source = new Line3D((LineOfPlane1X0Y)ln1, (LineOfPlane3Y0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            else if (ln1.GetType().Name == "LineOfPlane2X0Z" && ln2.GetType().Name == "LineOfPlane1X0Y")
            {
                _source = new Line3D((LineOfPlane1X0Y)ln2, (LineOfPlane2X0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            else if (ln1.GetType().Name == "LineOfPlane2X0Z" && ln2.GetType().Name == "LineOfPlane3Y0Z")
            {
                _source = new Line3D((LineOfPlane2X0Z)ln1, (LineOfPlane3Y0Z)ln2);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;

            }
            else if (ln1.GetType().Name == "LineOfPlane3Y0Z" && ln2.GetType().Name == "LineOfPlane1X0Y")
            {
                _source = new Line3D((LineOfPlane1X0Y)ln2, (LineOfPlane3Y0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            else if (ln1.GetType().Name == "LineOfPlane3Y0Z" && ln2.GetType().Name == "LineOfPlane2X0Z")
            {
                _source = new Line3D((LineOfPlane2X0Z)ln2, (LineOfPlane3Y0Z)ln1);
                _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                return true;
            }
            else
            {
                return false;
            }
        }
        protected IObject CreateLineOfPlane(Collection<IObject> obj, DrawS st, Point frameCenter, Canvas can)
        {
            if (obj[0].GetType().Name == "PointOfPlane1X0Y")
            {
                var source = new LineOfPlane1X0Y((PointOfPlane1X0Y)obj[0], (PointOfPlane1X0Y)obj[1]);
                source.CalculatePointsForDraw(frameCenter, can.PlaneX0Y);
                return source;
            }
            else if (obj[0].GetType().Name == "PointOfPlane2X0Z")
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
            if (lnproj.GetType().Name == "LineOfPlane1X0Y" && ptproj.GetType().Name == "PointOfPlane1X0Y")
            {
                return true;
            }
            else if (lnproj.GetType().Name == "LineOfPlane2X0Z" && ptproj.GetType().Name == "PointOfPlane2X0Z")
            {
                return true;
            }
            else if (lnproj.GetType().Name == "LineOfPlane3Y0Z" && ptproj.GetType().Name == "PointOfPlane3Y0Z")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsOnLinkLine(IObject lnproj, IObject ptproj)
        {
            if (lnproj.GetType().Name == "LineOfPlane1X0Y" && ptproj.GetType().Name == "PointOfPlane2X0Z")
            {
                return IsOnLinkLine12((LineOfPlane1X0Y)lnproj, (PointOfPlane2X0Z)ptproj);
            }
            else if (lnproj.GetType().Name == "LineOfPlane1X0Y" && ptproj.GetType().Name == "PointOfPlane3Y0Z")
            {
                return IsOnLinkLine13((LineOfPlane1X0Y)lnproj, (PointOfPlane3Y0Z)ptproj);
            }
            else if (lnproj.GetType().Name == "LineOfPlane2X0Z" && ptproj.GetType().Name == "PointOfPlane1X0Y")
            {
                return IsOnLinkLine21((LineOfPlane2X0Z)lnproj, (PointOfPlane1X0Y)ptproj);
            }
            else if (lnproj.GetType().Name == "LineOfPlane2X0Z" && ptproj.GetType().Name == "PointOfPlane3Y0Z")
            {
                return IsOnLinkLine23((LineOfPlane2X0Z)lnproj, (PointOfPlane3Y0Z)ptproj);
            }
            else if (lnproj.GetType().Name == "LineOfPlane3Y0Z" && ptproj.GetType().Name == "PointOfPlane1X0Y")
            {
                return IsOnLinkLine31((LineOfPlane3Y0Z)lnproj, (PointOfPlane1X0Y)ptproj);
            }
            else if (lnproj.GetType().Name == "LineOfPlane3Y0Z" && ptproj.GetType().Name == "PointOfPlane2X0Z")
            {
                return IsOnLinkLine32((LineOfPlane3Y0Z)lnproj, (PointOfPlane2X0Z)ptproj);
            }
            else
                return false;
        }

        #region IsOnLinkLine
        protected bool IsOnLinkLine12(LineOfPlane1X0Y lnproj, PointOfPlane2X0Z ptproj)
        {
            if (lnproj.Point0.X == ptproj.X || lnproj.Point1.X == ptproj.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsOnLinkLine13(LineOfPlane1X0Y lnproj, PointOfPlane3Y0Z ptproj)
        {
            if (lnproj.Point0.Y == ptproj.Y || lnproj.Point1.Y == ptproj.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsOnLinkLine21(LineOfPlane2X0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            if (lnproj.Point0.X == ptproj.X || lnproj.Point1.X == ptproj.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsOnLinkLine23(LineOfPlane2X0Z lnproj, PointOfPlane3Y0Z ptproj)
        {
            if (lnproj.Point0.Z == ptproj.Z || lnproj.Point1.Z == ptproj.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsOnLinkLine31(LineOfPlane3Y0Z lnproj, PointOfPlane1X0Y ptproj)
        {
            if (lnproj.Point0.Y == ptproj.Y || lnproj.Point1.Y == ptproj.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsOnLinkLine32(LineOfPlane3Y0Z lnproj, PointOfPlane2X0Z ptproj)
        {
            if (lnproj.Point0.Z == ptproj.Z || lnproj.Point1.Z == ptproj.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
    public class GenerateLine3D: ICreate
    {
        private Line3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            new SelectLineOfPlane().Execute(pt, strg, can);
            if (strg.SelectedObjects.Count > 1)
            {
                if (Object.ReferenceEquals(strg.SelectedObjects[0].GetType(), strg.SelectedObjects[1].GetType()))
                {
                    strg.SelectedObjects.Remove(strg.SelectedObjects[0]);
                    can.ReDraw(strg);
                    return;
                }
                if ((_source = Line3D.Create(strg.SelectedObjects)) != null)
                {
                    _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                    strg.Objects.Remove(strg.SelectedObjects[0]);
                    strg.Objects.Remove(strg.SelectedObjects[1]);
                    strg.SelectedObjects.Clear();
                    can.ReDraw(strg);
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                    return;
                }
                else
                {
                    strg.SelectedObjects.RemoveAt(strg.SelectedObjects.Count - 1);
                    can.ReDraw(strg);
                    return;
                }
            }
            else
            {
                can.ReDraw(strg);
                return;
            }
        }
    }
}
