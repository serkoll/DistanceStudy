using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsModule.Settings.Cursors
{
    class AddOnPoint:Cursor
    {
        readonly List<Point> _addOnPts=new List<Point>(); 

        public AddOnPoint()
        {
            _addOnPts.Add(new Point(0, Convert.ToInt32(0.25 * 5 * Math.Sqrt(2))));
            _addOnPts.Add(new Point(-5/2,0));
            _addOnPts.Add(new Point(0, -Convert.ToInt32(0.25 * 5 * Math.Sqrt(2))));
            _addOnPts.Add(new Point(5/2,0));
        }

        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            GraphicsPath gp = new GraphicsPath();
            Matrix tr1 = new Matrix();
            gp.AddPolygon(_addOnPts.ToArray());
            tr1.Translate(Convert.ToInt32(1*x/2), Convert.ToInt32(1*y/2));
            gp.Transform(tr1);
            g.DrawPath(new Pen(new SolidBrush(color), 2), gp);
        }
    }
}
