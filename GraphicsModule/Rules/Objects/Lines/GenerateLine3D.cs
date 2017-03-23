using System.Drawing;
using GraphicsModule.Configuration;
using GraphicsModule.Geometry.Objects.Lines;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Rules.Objects.Lines
{
    public class GenerateLine3D : ICreate
    {
        private Line3D _source;

        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas can, DrawS setting, Storage strg)
        {
            new SelectLineOfPlane().Execute(pt, strg, can);
            if (strg.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(strg.SelectedObjects[0].GetType(), strg.SelectedObjects[1].GetType()))
                {
                    strg.SelectedObjects.Remove(strg.SelectedObjects[0]);
                    can.Update(strg);
                    return;
                }
                if ((_source = Line3D.Create(strg.SelectedObjects)) != null)
                {
                    _source.SpecifyBoundaryPoints(frameCenter, can.PlaneX0Y, can.PlaneX0Z, can.PlaneY0Z);
                    strg.Objects.Remove(strg.SelectedObjects[0]);
                    strg.Objects.Remove(strg.SelectedObjects[1]);
                    strg.SelectedObjects.Clear();
                    can.Update(strg);
                    strg.AddToCollection(_source);
                    _source = null;
                    strg.DrawLastAddedToObjects(setting, frameCenter, can.Graphics);
                }
                else
                {
                    strg.SelectedObjects.RemoveAt(strg.SelectedObjects.Count - 1);
                    can.Update(strg);
                }
            }
            else
            {
                can.Update(strg);
            }
        }
    }
}
