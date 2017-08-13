using GraphicsModule.Geometry.Helpers.ObjectsCreator;

namespace GraphicsModule.Geometry.Objects
{
    public static class ObjectsCreator
    {
        public static ObjectsCreatorPointsHelper Point3D()
        {
            return new ObjectsCreatorPointsHelper();
        }

        public static ObjectsCreatorLinesHelper Line3D()
        {
            return new ObjectsCreatorLinesHelper();
        }

        public static ObjectsCreatorSegmentsHelper Segment3D()
        {
            return new ObjectsCreatorSegmentsHelper();
        }
    }
}
