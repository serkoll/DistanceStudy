using SolidWorks.Interop.sldworks;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Background;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.SolidworksInteraction
{
    public class SldWorksInteraction
    {
        private SldWorks _swApp;
        private IModelDoc2 _swModel;
        public SldWorksInteraction()
        {
        }
        public bool Connect()
        {
            try
            {
                _swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
                return true;
            }
            catch(COMException)
            {
                return false;
            }   
        }
        public void SetActiveDocument()
        {
            if (_swApp.IActiveDoc == null)
                _swApp.NewPart();
            _swModel = _swApp.IActiveDoc2;
        }
        public void ImportCollectionToActiveDoc(Collection<IObject> objects, Settings.DrawS ds)
        {
            if (objects.Count == 0) return;
            //_swModel.Extension.SelectByID2("", "FACE", -3.14573861840017E-02, 1.44077058280914E-02, 0.03, false, 0, null, 0);
            _swModel.SketchManager.Insert3DSketch(true);
            foreach (IObject obj in objects)
            {
                if (obj.GetType() == typeof(Point3D))
                {
                    var point = (Point3D)obj;
                    _swModel.SketchManager.CreatePoint(point.X, point.Y, point.Z);
                    //_swModel.SketchManager.CreateCircleByRadius(point.X, point.Y, point.Z, ds.RadiusPoints*10);
                    //_swModel.SketchManager.RotateOrCopy3DAboutXYZ(false, 0, false, 0, 0, 0, 0, 360, 0);
                }
                if(obj.GetType() == typeof(Segment3D))
                {
                    var segment = (Segment3D)obj;
                    _swModel.SketchManager.CreateLine(segment.Point0.X, segment.Point0.Y, segment.Point0.Z, segment.Point1.X, segment.Point1.Y, segment.Point1.Z);
                }
            }
            _swModel.ClearSelection2(true);
        }
        public void ImportAxis(Axis axis)
        {
            _swModel.Extension.SelectByID2("", "FACE", -3.14573861840017E-02, 1.44077058280914E-02, 0.03, false, 0, null, 0);
            _swModel.SketchManager.Insert3DSketch(true);
            _swModel.SketchManager.CreatePoint(axis.FinitePoints[0].X, axis.FinitePoints[0].Y, 0);
            _swModel.SketchManager.CreatePoint(axis.FinitePoints[0].X, axis.FinitePoints[0].Y, 0);
            _swModel.SketchManager.CreatePoint(axis.FinitePoints[0].X, axis.FinitePoints[0].Y, 0);
            _swModel.SketchManager.CreatePoint(axis.FinitePoints[0].X, axis.FinitePoints[0].Y, 0);
            _swModel.ClearSelection2(true);
        }
        public void ImportGrid(Grid grid)
        {
            _swModel.Extension.SelectByID2("", "FACE", -3.14573861840017E-02, 1.44077058280914E-02, 0.03, false, 0, null, 0);
            _swModel.SketchManager.Insert3DSketch(true);
            for (int i = 0; i < grid.Knots.GetLength(0); i++)
            {
                for (int j = 0; j < grid.Knots.GetLength(1); j++)
                {
                    _swModel.SketchManager.CreatePoint(grid.Knots[i,j].X, grid.Knots[i,j].Y, 0);
                }
            }
            _swModel.ClearSelection2(true);
        }
    }
}
