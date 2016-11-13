using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometryObjects
{
    public interface IObject
    {
        void Draw(DrawS st, Point frameCenter, Graphics graphics);
        bool IsSelected(Point mousecoords, float ptR, Point frameCenter, double distance);
    }
}
