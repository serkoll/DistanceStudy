using System.Collections.Generic;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Lines;

namespace GraphicsModule.Geometry.Helpers.ObjectsCreator
{
    public class ObjectsCreatorLinesHelper
    {
        /// <summary>
        /// TODO: perepisat s proverkami
        /// </summary>
        /// <param name="projections"></param>
        /// <returns></returns>
        public Line3D Create(IList<ILineOfPlane> projections)
        {
            if (projections[0].GetType() == typeof(LineOfPlane1X0Y))
            {
                return projections[1].GetType() == typeof(LineOfPlane2X0Z)
                    ? new Line3D((LineOfPlane1X0Y)projections[0], (LineOfPlane2X0Z)projections[1])
                    : new Line3D((LineOfPlane1X0Y)projections[0], (LineOfPlane3Y0Z)projections[1]);
            }
            if (projections[0].GetType() == typeof(LineOfPlane2X0Z))
            {
                return projections[1].GetType() == typeof(LineOfPlane1X0Y)
                    ? new Line3D((LineOfPlane1X0Y)projections[1], (LineOfPlane2X0Z)projections[0])
                    : new Line3D((LineOfPlane2X0Z)projections[0], (LineOfPlane3Y0Z)projections[1]);
            }
            return projections[1].GetType() == typeof(LineOfPlane1X0Y)
                ? new Line3D((LineOfPlane1X0Y)projections[1], (LineOfPlane3Y0Z)projections[0])
                : new Line3D((LineOfPlane2X0Z)projections[1], (LineOfPlane3Y0Z)projections[0]);
        }
    }
}
