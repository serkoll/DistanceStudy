using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Analyze;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Geometry.Objects.Segments;
using GraphicsModule.Interfaces;


namespace GraphicsModule.Rules.Objects.Segments
{
    public class CreateSegment2D : ICreate
    {
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            var obj = Create(pt, frameCenter, can, settings, strg);
            if (obj == null) return;
            strg.AddToCollection(obj);
            can.Update(strg);
        }
        public Segment2D Create(Point pt, Point frameCenter, Canvas can, DrawS settings, Storage strg)
        {
            var ptOfPlane = new Point2D(pt);
            if (strg.TempObjects.Count == 0)
            {
                ptOfPlane.SetName(GraphicsControl.NmGenerator.Generate());
                strg.TempObjects.Add(ptOfPlane);
                strg.DrawLastAddedToTempObjects(settings, frameCenter, can.Graphics);
            }
            else
            {
                if (Analyze.PointPos.Coincidence((Point2D)strg.TempObjects[0], new Point2D(pt))) return null;
                var source = new Segment2D((Point2D)strg.TempObjects[0], new Point2D(pt));
                source.SetName(strg.TempObjects[0].GetName());
                strg.TempObjects.Clear();
                return source;
            }
            return null;
        }
    }
}
