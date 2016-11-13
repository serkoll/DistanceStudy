using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Point3DCntrl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using GeometryObjects;

namespace Formatter
{
    public static class JsonFormatter
    {
        public static void WriteObjectsToJson(Collection<IObject> coll)
        {
            var fullPath = GetPathToJsonFile();
            var guid = Guid.NewGuid();
            JArray jo = new JArray();
            List<object> listGraphObjects = new List<object>();
            foreach (var item in coll)
            {
                JObject jobj = new JObject();
                jobj.Add("Guid", Guid.NewGuid());
                jobj.Add("TypeName", item.GetType().Name);
                jo.Add(jobj);
            }
            string json = JsonConvert.SerializeObject(jo, Formatting.Indented);
            System.IO.File.WriteAllText($@"{fullPath}\GraphicObjects.json", json);
        }

        public static List<GraphicKey> GetGraphicKeysFromJson()
        {
            var fullPath = GetPathToJsonFile();
            using (StreamReader r = new StreamReader($@"{fullPath}\GraphicObjects.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<GraphicKey>>(json);
            }
        }

        private static string GetPathToJsonFile()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));
            return new Uri($@"{path}\Data\JsonObjects").LocalPath;
        }
    }
}
