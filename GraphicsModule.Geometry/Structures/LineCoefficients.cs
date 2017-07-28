using GraphicsModule.Geometry.Objects.Points;

namespace GraphicsModule.Geometry.Structures
{
    public struct LineCoefficients
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public LineCoefficients(Point2D pt1, Point2D pt2)
        {
            B = -1;
            A = (pt2.Y - pt1.Y) / (pt2.X - pt1.X);
            C = pt1.Y - pt1.X * A;
        }
    }
}
