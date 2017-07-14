using System.ComponentModel;

namespace GraphicsModule.Enums
{
    public enum PlaneCreateType
    {
        [Description("Три точки")]
        ThreePoints = 0,
        [Description("Прямая и точка")]
        LineAndPoint = 1,
        [Description("Параллельные прямые")]
        ParallelLines = 2,
        [Description("Пересекающиеся прямые")]
        CrossedLines = 3,
        [Description("Отрезок и точка")]
        SegmentAndPoint = 4,
        [Description("Параллельные отрезки")]
        ParallelSegments = 5,
        [Description("Пересекающиеся отрези")]
        CrossedSegments = 6
    }
}
