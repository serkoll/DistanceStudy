using System.Drawing;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Objects.Points;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule.Rules.Objects.Points
{
    /// <summary>
    /// Генерация 3D точки
    /// </summary>
    public class GeneratePoint3D : ICreate
    {
        private Point3D _source;
        public void AddToStorageAndDraw(Point pt, Point frameCenter, Canvas.Canvas can, DrawS setting, Storage strg)
        {
            new SelectPointOfPlane().Execute(pt, strg, can);
            if (strg.SelectedObjects.Count > 1)
            {
                if (ReferenceEquals(strg.SelectedObjects[0].GetType(), strg.SelectedObjects[1].GetType()))
                {
                    strg.SelectedObjects.Remove(strg.SelectedObjects[0]);
                    can.Update(strg);
                    return;
                }
                if ((_source = Point3D.Create(strg.SelectedObjects)) != null)
                {
                    strg.Objects.Remove(strg.SelectedObjects[0]);
                    strg.Objects.Remove(strg.SelectedObjects[1]);
                    _source.SetName(GraphicsControl.NmGenerator.Generate());
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
