using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsModule.Configuration.Cursors
{
    public class Envelope:Cursor
    {
         readonly List<Point> _envelopePoints = new List<Point>();

        public Envelope()
        {
            _envelopePoints.Clear();
            _envelopePoints.Add(new Point(0, 0));
            _envelopePoints.Add(new Point(10, 0));
            _envelopePoints.Add(new Point(10, 10));
            _envelopePoints.Add(new Point(0, 10));
            _envelopePoints.Add(new Point(0, 0));
            _envelopePoints.Add(new Point(10, 10));
            _envelopePoints.Add(new Point(5, 5));
            _envelopePoints.Add(new Point(10, 0));
            _envelopePoints.Add(new Point(0, 10));
            _envelopePoints.Add(new Point(5, 5));
        }

        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            GraphicsPath gp = new GraphicsPath();
            Matrix tr1 = new Matrix();
            gp.AddPolygon(_envelopePoints.ToArray());
            tr1.Translate(Convert.ToInt32(3*x/8), Convert.ToInt32(3*y/8));
            gp.Transform(tr1);
            g.DrawPath(new Pen(new SolidBrush(color), 1), gp);
        }
    }
}
