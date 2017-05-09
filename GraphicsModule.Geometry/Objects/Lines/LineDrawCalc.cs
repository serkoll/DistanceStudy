using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphicsModule.Geometry.Objects.Lines
{
    //TODO: исправить логику класса, сделать статическим
    public class LineDrawCalc
    {
        public LineDrawCalc(Point frameCenter, RectangleF rc)
        {
            Rc = rc;
            FrameCenter = frameCenter;
        }
        public List<PointF> CalculatePointsForDraw(LineOfPlane1X0Y ln1)
        {
            var pts = new List<PointF>();
            
            var ln = DeterminePosition.ForLineProjection(ln1, FrameCenter);

            if (Math.Abs(ln.Kx) < Tolerance)
            {
                pts.Add(new PointF((float)ln.Point0.X, Rc.Top));
                pts.Add(new PointF((float)ln.Point0.X, Rc.Bottom));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            if (Math.Abs(ln.Ky) < Tolerance)
            {
                pts.Add(new PointF(Rc.Left, (float)ln.Point0.Y));
                pts.Add(new PointF(Rc.Right, (float)ln.Point0.Y));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            //y=0
            var cvalue = (Rc.Top - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X;
            if (cvalue > Rc.Left && cvalue < Rc.Right) pts.Add(new PointF((float)cvalue, Rc.Top));
            //y=max
            cvalue = (Rc.Bottom - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X;
            if (cvalue > Rc.Left && cvalue < Rc.Right) pts.Add(new PointF((float)cvalue, Rc.Bottom));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
            //x = 0
            cvalue = (Rc.Left - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y;
            if (cvalue > Rc.Top && cvalue < Rc.Bottom) pts.Add(new PointF(Rc.Left, (float)cvalue));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
            //x = max
            cvalue = (Rc.Right - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y;
            pts.Add(new PointF(Rc.Right, (float)cvalue));
            pts = pts.OrderBy(point => point.X).ToList();
            return pts;
        }
        public List<PointF> CalculatePointsForDraw(LineOfPlane2X0Z ln2)
        {
            var pts = new List<PointF>();

            var ln = DeterminePosition.ForLineProjection(ln2, FrameCenter);

            if (Math.Abs(ln.Kx) < Tolerance)
            {
                pts.Add(new PointF((float)ln.Point0.X, Rc.Top));
                pts.Add(new PointF((float)ln.Point0.X, Rc.Bottom));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            if (Math.Abs(ln.Ky) < Tolerance)
            {
                pts.Add(new PointF(Rc.Left, (float)ln.Point0.Y));
                pts.Add(new PointF(Rc.Right, (float)ln.Point0.Y));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            //y=0
            var cvalue = (float)((Rc.Top - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X);
            if (cvalue > Rc.Left && cvalue < Rc.Right) pts.Add(new PointF(cvalue, Rc.Top));
            //y=max
            cvalue = (float)((Rc.Bottom - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X);
            if (cvalue > Rc.Left && cvalue < Rc.Right) pts.Add(new PointF(cvalue, Rc.Bottom));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
                //x = 0
                cvalue = (float)((Rc.Left - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y);
                if (cvalue > Rc.Top && cvalue < Rc.Bottom) pts.Add(new PointF(Rc.Left, cvalue));
                pts = pts.OrderBy(point => point.X).ToList();
                if (!CheckListState(pts)) return pts;
                    //x = max
                    cvalue = (float)((Rc.Right - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y);
                    pts.Add(new PointF(Rc.Right, cvalue));
                    pts = pts.OrderBy(point => point.X).ToList();
                    return pts;
        }
        public List<PointF> CalculatePointsForDraw(LineOfPlane3Y0Z ln3)
        {
            var pts = new List<PointF>();

            var ln = DeterminePosition.ForLineProjection(ln3, FrameCenter);

            if (Math.Abs(ln.Kx) < Tolerance)
            {
                pts.Add(new PointF((float)ln.Point0.X, Rc.Top));
                pts.Add(new PointF((float)ln.Point0.X, Rc.Bottom));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            if (Math.Abs(ln.Ky) < Tolerance)
            {
                pts.Add(new PointF(Rc.Left, (float)ln.Point0.Y));
                pts.Add(new PointF(Rc.Right, (float)ln.Point0.Y));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            //y=0
            var cvalue = (float)((Rc.Top - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X);
            if (cvalue > Rc.Left && cvalue < Rc.Right) pts.Add(new PointF(cvalue, Rc.Top));
            //y=max
            cvalue = (float)((Rc.Bottom - ln.Point0.Y) * ln.Kx / ln.Ky + ln.Point0.X);
            if (cvalue > Rc.Left && cvalue < Rc.Right) pts.Add(new PointF(cvalue, Rc.Bottom));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
                //x = 0
                cvalue = (float)((Rc.Left - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y);
                if (cvalue > Rc.Top && cvalue < Rc.Bottom) pts.Add(new PointF(Rc.Left, cvalue));
                pts = pts.OrderBy(point => point.X).ToList();
                if (!CheckListState(pts)) return pts;
                    //x = max
                    cvalue = (float)((Rc.Right - ln.Point0.X) * ln.Ky / ln.Kx + ln.Point0.Y);
                    pts.Add(new PointF(Rc.Right, cvalue));
                    pts = pts.OrderBy(point => point.X).ToList();
                    return pts;
        }
        private bool CheckListState(List<PointF> lst)
        {
            if (lst.Count < 2)
            {
                return true;
            }
            lst = lst.OrderBy(point => point.X).ToList();
            return false;
        }

        public double Tolerance { get; set; } = 0.0001;
        public Point FrameCenter { get; set; }
        public RectangleF Rc { get; set; }
    }
}
