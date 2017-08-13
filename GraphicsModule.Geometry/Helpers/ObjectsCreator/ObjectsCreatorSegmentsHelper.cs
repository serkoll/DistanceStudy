using System.Collections.Generic;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects.Segments;

namespace GraphicsModule.Geometry.Helpers.ObjectsCreator
{
    public class ObjectsCreatorSegmentsHelper
    {

        /// <summary>
        /// TODO: refactor
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public Segment3D Create(IList<ISegmentOfPlane> lst)
        {
            if (lst[0].GetType() == typeof(SegmentOfPlane1X0Y))
            {
                return lst[1].GetType() == typeof(SegmentOfPlane2X0Z) ?
                    new Segment3D((SegmentOfPlane1X0Y)lst[0], (SegmentOfPlane2X0Z)lst[1]) :
                    new Segment3D((SegmentOfPlane1X0Y)lst[0], (SegmentOfPlane3Y0Z)lst[1]);
            }
            if (lst[0].GetType() == typeof(SegmentOfPlane2X0Z))
            {
                return lst[1].GetType() == typeof(SegmentOfPlane1X0Y) ?
                    new Segment3D((SegmentOfPlane1X0Y)lst[1], (SegmentOfPlane2X0Z)lst[0]) :
                    new Segment3D((SegmentOfPlane2X0Z)lst[0], (SegmentOfPlane3Y0Z)lst[1]);
            }
            return lst[1].GetType() == typeof(SegmentOfPlane1X0Y) ?
                new Segment3D((SegmentOfPlane1X0Y)lst[1], (SegmentOfPlane3Y0Z)lst[0]) :
                new Segment3D((SegmentOfPlane2X0Z)lst[1], (SegmentOfPlane3Y0Z)lst[0]);
        }
    }
}
