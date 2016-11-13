using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometryObjects
{
    public interface IPointOfPlane
    {
        void Draw(Pen pen, float poitRaduis, Point frameCenter, Graphics graphics);
    }
}
