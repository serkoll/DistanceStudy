using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Objects.Lines
{
    /// <summary>Класс для задания и расчета параметров 2D прямой</summary>
    /// <remarks>Copyright © Polozkov V. Yury, 2015</remarks>
    public class Line2D : IObject
    {
        private Name _name;

        private List<PointF> pts { get; set; }

        public Line2D()
        {
            Point0 = new Point2D(0, 0);
            Point1 = new Point2D(1, 0);
            kx = 1;
            ky = 0;
            Name = new Name();
        }

        public Line2D(Point2D pt1, Point2D pt2)
        {
            if (Analyze.Analyze.PointsPosition.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            kx = pt2.X - pt1.X;
            ky = pt2.Y - pt1.Y;
            Name = new Name();
            pt1.Name = Name;
            pt2.Name = Name;
        }

        public Line2D(Point2D pt1, Point2D pt2, PictureBox pb)
        {
            if (Analyze.Analyze.PointsPosition.Coincidence(pt1, pt2)) return;
            Point0 = pt1;
            Point1 = pt2;
            kx = pt2.X - pt1.X;
            ky = pt2.Y - pt1.Y;
            CalculatePointsForDraw(pb);
        }

        public Line2D ConstructPerpendicularOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(-line.kx + pt.X, line.ky + pt.Y));
        }

        public Line2D ConstructParallelOfPointToLine(Line2D line, Point2D pt)
        {
            return new Line2D(pt, new Point2D(line.kx + pt.X, line.ky + pt.Y));
        }

        public double CalculateSlopeOfLine(Line2D line)
        {
            return line.ky / line.kx;

        }
        public void Draw(DrawSettings st, Point framecenter, Graphics g)
        {
            Point0.Draw(st, framecenter, g);
            Point1.Draw(st, framecenter, g);
            g.DrawLine(st.PenLine2D, pts[0], pts[1]);
        }
        private void CalculatePointsForDraw(PictureBox pb)
        {
            pts = new List<PointF>();

            if (Math.Abs(kx) < 0.0001)
            {
                pts.Add(new PointF((float)Point0.X, 0));
                pts.Add(new PointF((float)Point0.X, pb.Height));
            }
            if (Math.Abs(ky) < 0.0001)
            {
                pts.Add(new PointF(0, (float)Point0.Y));
                pts.Add(new PointF(pb.Width, (float)Point0.Y));
            }
            //y=0
            var x = (float)(-Point0.Y * kx / ky + Point0.X);
            if (x > 0) pts.Add(new PointF(x, 0));
            //y=max
            x = (float)((pb.Height - Point0.Y) * kx / ky + Point0.X);
            if (x < pb.Width) pts.Add(new PointF(x, pb.Height));
            if (!CheckListState(pts)) return;
            //x = 0
            var y = (float)(-Point0.X * ky / kx + Point0.Y);
            if (y > 0) pts.Add(new PointF(0, y));
            if (!CheckListState(pts)) return;
            //x = max
            y = (int)((pb.Width - Point0.X) * ky / kx + Point0.Y);
            pts.Add(new PointF(pb.Width, y));
        }
        private bool CheckListState(List<PointF> lst)
        {
            return lst.Count < 2;
        }
        public bool IsSelected(Point mscoords, float ptR, Point frameCenter, double distance)
        {
            return Analyze.Analyze.LinesPosition.IncidenceOfPoint(mscoords, this, 35 * distance);
        }
        //TODO: возможно в массив
        public Point2D Point0 { get; }

        public Point2D Point1 { get; }

        public Name Name
        {
            get
            {
                return _name;
            }
            set
            {
                Point0.Name = value;
                Point1.Name = value;
                _name = value;
            }
        }
        public double kx { get; }

        public double ky { get; }
    }
}
