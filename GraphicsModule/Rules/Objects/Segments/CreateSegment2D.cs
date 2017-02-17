using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;


namespace GraphicsModule.Rules.Objects.Segments
{
    /// <summary>
    /// Создание 2Д линии
    /// </summary>
    public class CreateSegment2D : ICreate
    {
        private Segment2D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(setting, frameCenter, can.Graphics);
            }
            else
            {
                if (Analyze.PointPos.Coincidence((Point2D)strg.TempObjects[0], new Point2D(pt))) return;
                _source = new Segment2D((Point2D)strg.TempObjects[0], new Point2D(pt), can.PicBox);
                _source.SetName(strg.TempObjects[0].GetName());
                strg.AddToCollection(_source);
                _source = null;
                strg.TempObjects.Clear();
                can.Update(strg);
                strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
            }
        }
    }
}
