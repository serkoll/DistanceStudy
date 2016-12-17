using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Points;

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
            if((_swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application")) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void SetActiveDocument()
        {
            if (_swApp.IActiveDoc == null)
                _swApp.NewPart();
            _swModel = _swApp.IActiveDoc2;
        }
        public void ImportCollectionToActiveDoc(Collection<IObject> objects )
        {
            _swModel.Extension.SelectByID2("", "FACE", -3.14573861840017E-02, 1.44077058280914E-02, 0.03, false, 0, null, 0);
            _swModel.SketchManager.InsertSketch(true); //вставил эскиз в режиме редактирования 
            foreach (IObject obj in objects)
            {
                if(obj.GetType() == typeof(Point3D))
                {
                    var point = (Point3D)obj;
                    _swModel.SketchManager.CreatePoint(point.X, point.Y, point.Z);
                }
            }
        }
    }
}
