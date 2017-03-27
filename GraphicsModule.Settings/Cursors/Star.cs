using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsModule.Configuration.Cursors
{
    public class Star:Cursor
    {
        readonly List<Point> _starPoints = new List<Point>();

        public Star()
        {
            _starPoints.Add(new Point(0, 0));
            _starPoints.Add(new Point(10, 10));
            _starPoints.Add(new Point(5, 5));
            _starPoints.Add(new Point(10, 0));
            _starPoints.Add(new Point(0, 10));
            _starPoints.Add(new Point(5, 5));
            _starPoints.Add(new Point(10,5));
            _starPoints.Add(new Point(0,5));
            _starPoints.Add(new Point(5,5));
        }

        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            GraphicsPath gp = new GraphicsPath();
            Matrix tr1 = new Matrix();
            gp.AddPolygon(_starPoints.ToArray());
            tr1.Translate(Convert.ToInt32(3*x/8), Convert.ToInt32(3*y/8));
            gp.Transform(tr1);
            g.DrawPath(new Pen(new SolidBrush(color), 1), gp);
        }
    }
}
