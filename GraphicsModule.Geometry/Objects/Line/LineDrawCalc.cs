using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphicsModule.Geometry.Objects.Line
{
    public class LineDrawCalc
    {
        public System.Drawing.Point FrameCenter { get; set; }
        public RectangleF rc { get; set; }
        public LineDrawCalc(System.Drawing.Point frameCenter, RectangleF rc)
        {
            this.rc = rc;
            FrameCenter = frameCenter;
        }
        public List<PointF> CalculatePointsForDraw(LineOfPlane1X0Y ln1)
        {
            var pts = new List<PointF>();

            var ln = DeterminePosition.ForLineProjection(ln1, FrameCenter);

            if (ln.kx == 0)
            {
                pts.Add(new PointF((float)ln.Point0.X, rc.Top));
                pts.Add(new PointF((float)ln.Point0.X, rc.Bottom));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            if (ln.ky == 0)
            {
                pts.Add(new PointF(rc.Left, (float)ln.Point0.Y));
                pts.Add(new PointF(rc.Right, (float)ln.Point0.Y));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            //y=0
            var cvalue = (float)((rc.Top - ln.Point0.Y) * ln.kx / ln.ky + ln.Point0.X);
            if (cvalue > rc.Left && cvalue < rc.Right) pts.Add(new PointF(cvalue, rc.Top));
            //y=max
            cvalue = (float)((rc.Bottom - ln.Point0.Y) * ln.kx / ln.ky + ln.Point0.X);
            if (cvalue > rc.Left && cvalue < rc.Right) pts.Add(new PointF(cvalue, rc.Bottom));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
            //x = 0
            cvalue = (float)((rc.Left - ln.Point0.X) * ln.ky / ln.kx + ln.Point0.Y);
            if (cvalue > rc.Top && cvalue < rc.Bottom) pts.Add(new PointF(rc.Left, cvalue));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
            //x = max
            cvalue = (float)((rc.Right - ln.Point0.X) * ln.ky / ln.kx + ln.Point0.Y);
            pts.Add(new PointF(rc.Right, cvalue));
            pts = pts.OrderBy(point => point.X).ToList();
            return pts;
        }
        public List<PointF> CalculatePointsForDraw(LineOfPlane2X0Z ln2)
        {
            var pts = new List<PointF>();

            var ln = DeterminePosition.ForLineProjection(ln2, FrameCenter);

            if (ln.kx == 0)
            {
                pts.Add(new PointF((float)ln.Point0.X, rc.Top));
                pts.Add(new PointF((float)ln.Point0.X, rc.Bottom));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            if (ln.ky == 0)
            {
                pts.Add(new PointF(rc.Left, (float)ln.Point0.Y));
                pts.Add(new PointF(rc.Right, (float)ln.Point0.Y));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            //y=0
            var cvalue = (float)((rc.Top - ln.Point0.Y) * ln.kx / ln.ky + ln.Point0.X);
            if (cvalue > rc.Left && cvalue < rc.Right) pts.Add(new PointF(cvalue, rc.Top));
            //y=max
            cvalue = (float)((rc.Bottom - ln.Point0.Y) * ln.kx / ln.ky + ln.Point0.X);
            if (cvalue > rc.Left && cvalue < rc.Right) pts.Add(new PointF(cvalue, rc.Bottom));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
                //x = 0
                cvalue = (float)((rc.Left - ln.Point0.X) * ln.ky / ln.kx + ln.Point0.Y);
                if (cvalue > rc.Top && cvalue < rc.Bottom) pts.Add(new PointF(rc.Left, cvalue));
                pts = pts.OrderBy(point => point.X).ToList();
                if (!CheckListState(pts)) return pts;
                    //x = max
                    cvalue = (float)((rc.Right - ln.Point0.X) * ln.ky / ln.kx + ln.Point0.Y);
                    pts.Add(new PointF(rc.Right, cvalue));
                    pts = pts.OrderBy(point => point.X).ToList();
                    return pts;
        }
        public List<PointF> CalculatePointsForDraw(LineOfPlane3Y0Z ln3)
        {
            var pts = new List<PointF>();

            var ln = DeterminePosition.ForLineProjection(ln3, FrameCenter);

            if (ln.kx == 0)
            {
                pts.Add(new PointF((float)ln.Point0.X, rc.Top));
                pts.Add(new PointF((float)ln.Point0.X, rc.Bottom));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            if (ln.ky == 0)
            {
                pts.Add(new PointF(rc.Left, (float)ln.Point0.Y));
                pts.Add(new PointF(rc.Right, (float)ln.Point0.Y));
                pts = pts.OrderBy(point => point.X).ToList();
                return pts;
            }
            //y=0
            var cvalue = (float)((rc.Top - ln.Point0.Y) * ln.kx / ln.ky + ln.Point0.X);
            if (cvalue > rc.Left && cvalue < rc.Right) pts.Add(new PointF(cvalue, rc.Top));
            //y=max
            cvalue = (float)((rc.Bottom - ln.Point0.Y) * ln.kx / ln.ky + ln.Point0.X);
            if (cvalue > rc.Left && cvalue < rc.Right) pts.Add(new PointF(cvalue, rc.Bottom));
            pts = pts.OrderBy(point => point.X).ToList();
            if (!CheckListState(pts)) return pts;
                //x = 0
                cvalue = (float)((rc.Left - ln.Point0.X) * ln.ky / ln.kx + ln.Point0.Y);
                if (cvalue > rc.Top && cvalue < rc.Bottom) pts.Add(new PointF(rc.Left, cvalue));
                pts = pts.OrderBy(point => point.X).ToList();
                if (!CheckListState(pts)) return pts;
                    //x = max
                    cvalue = (float)((rc.Right - ln.Point0.X) * ln.ky / ln.kx + ln.Point0.Y);
                    pts.Add(new PointF(rc.Right, cvalue));
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
    }
}
