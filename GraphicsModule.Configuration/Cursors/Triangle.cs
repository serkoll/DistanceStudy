using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsModule.Configuration.Cursors
{
    class Triangle:Cursor
    {
        readonly List<Point> _trianglePoints=new List<Point>();

        public Triangle()
        {
            _trianglePoints.Clear();
            _trianglePoints.Add(new Point(5,0));
            _trianglePoints.Add(new Point(0,10));
            _trianglePoints.Add(new Point(10,10));
        }

        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            GraphicsPath gp = new GraphicsPath();
            Matrix tr1 = new Matrix();
            gp.AddPolygon(_trianglePoints.ToArray());
            tr1.Translate(Convert.ToInt32(3*x/8), Convert.ToInt32(3*y/8));
            gp.Transform(tr1);
            g.DrawPath(new Pen(new SolidBrush(color), 1), gp);
        }
    }
}
