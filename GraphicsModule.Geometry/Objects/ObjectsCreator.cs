using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsModule.Geometry.Helpers.ObjectsCreator;

namespace GraphicsModule.Geometry.Objects
{
    public static class ObjectsCreator
    {
        public static ObjectsCreatorPointsHelper Point3D()
        {
            return new ObjectsCreatorPointsHelper();
        }
    }
}
