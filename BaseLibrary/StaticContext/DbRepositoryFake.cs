using System.Collections.Generic;
using System.Drawing;
using GeomObjects.Points;

namespace BaseLibrary.StaticContext
{
    public static class DbRepositoryFake
    {
        public static string NameTask { get; set; }
        public static string Description { get; set; }
        public static string AlghoritmCode { get; set; }
        public static int SubgroupNumber { get; set; }
        public static object[] InputParam { get; set; } = new object[1];
        public static string OuterXml { get; set; }

        public static void AddXmlToDataBase()
        {
            
        }
    }
}
