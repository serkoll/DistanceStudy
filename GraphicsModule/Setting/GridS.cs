using System.Drawing;

namespace GraphicsModule.Setting
{
    public class GridS
    {
        public int StepOfWidth { get; set; }
        public int StepOfHeight { get; set; }
        public int PointsSize { get; set; }
        public Color PointsColor { get; set; }
        public bool IsDraw { get; set; }
        public GridS()
        {
            StepOfWidth = 10;
            StepOfHeight = 10;
            PointsSize = 1;
            PointsColor = Color.Black;
            IsDraw = true;
        }
    }
}
