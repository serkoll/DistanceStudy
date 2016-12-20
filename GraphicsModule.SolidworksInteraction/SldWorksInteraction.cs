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
        private const double k = 1000;
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
            catch (COMException)
            {
                return false;
            }
        }
        public void SetActiveDocument()
        {
            if (_swApp.IActiveDoc == null)
                _swApp.NewPart();
            _swModel = _swApp.IActiveDoc2;
            _swModel.SketchManager.Insert3DSketch(true);
            _swModel.SetAddToDB(false);
        }
        public void ImportCollectionToActiveDoc(Collection<IObject> objects, Settings.DrawS ds)
        {
            if (objects.Count == 0) return;
            foreach (IObject obj in objects)
            {
                if (obj.GetType() == typeof(Point3D))
                {
                    var point = (Point3D)obj;
                    _swModel.SketchManager.CreatePoint(point.X / k, point.Y / k, point.Z / k);
                }
                if (obj.GetType() == typeof(Segment3D))
                {
                    var segment = (Segment3D)obj;
                    _swModel.SketchManager.CreateLine(segment.Point0.X/ k, segment.Point0.Y / k, segment.Point0.Z / k, segment.Point1.X/ k, segment.Point1.Y / k, segment.Point1.Z / k);
                }
            }
        }
        public void ImportAxis(Axis axis)
        {
            _swModel.SketchManager.CreateLine(-axis.FinitePoints[1].X / k, 0, 0, axis.FinitePoints[1].X / k, 0, 0);
            _swModel.SketchManager.CreateLine(0, -axis.FinitePoints[3].Y / k, 0, 0, axis.FinitePoints[3].Y / k, 0);
            _swModel.SketchManager.CreateLine(0, 0, -axis.FinitePoints[3].Y / k, 0, 0, axis.FinitePoints[3].Y / k);
        }
        public void ImportGrid(Grid grid)
        {
            //for (int i = 0; i < grid.Knots.GetLength(0) / 2; i++)
            //{
            //    for (int j = 0; j < grid.Knots.GetLength(1) / 2; j++)
            //    {
            //        _swModel.SketchManager.CreatePoint((grid.Knots[i, j].X - grid.CenterPoint.X) / k, 0, (grid.Knots[i, j].Y - grid.CenterPoint.Y) / k);
            //    }
            //}
        }
    }
}
