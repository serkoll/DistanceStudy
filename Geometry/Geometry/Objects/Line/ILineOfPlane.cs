using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GeometryObjects
{
    interface ILineOfPlane
    {
        void DrawLineOnly(DrawS st, Point framecenter, Graphics g);
    }
}
