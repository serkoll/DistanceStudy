using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using DbRepository.Classes.Keys;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;

namespace Formatter
{
    public static class JsonFormatter
    {
        public static void WriteObjectsToJson(IList<IObject> coll, string fileName = "GraphicObjects")
        {
            var fullPath = GetPathToJsonFile();
            List<GraphicKey> listGraphObjects = new List<GraphicKey>();
            foreach (var item in coll)
            {
                listGraphObjects.Add(new GraphicKey
                {
                    Guid = Guid.NewGuid(),
                    GraphicObject = item
                });
            }
            string json = JsonConvert.SerializeObject(listGraphObjects.ToArray(), Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });
            System.IO.File.WriteAllText($@"{fullPath}\{fileName}.json", json);
        }

        public static List<GraphicKey> GetGraphicKeysFromJson()
        {
            var fullPath = GetPathToJsonFile();
            using (StreamReader r = new StreamReader($@"{fullPath}\GraphicObjects.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<GraphicKey>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
            }
        }

        public static Collection<IObject> GetObjectsForTaskFromJson(int taskId)
        {
            var taskName = taskId.ToString();
            var fullPath = GetPathToJsonFile();
            var coll = new Collection<IObject>();
            try
            {
                using (StreamReader r = new StreamReader($@"{fullPath}\{taskName}.json"))
                {
                    string json = r.ReadToEnd();
                    var list = JsonConvert.DeserializeObject<List<GraphicKey>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    });
                    foreach (var key in list)
                    {
                        coll.Add(key.GraphicObject);
                    }
                }
            }
            catch (FileNotFoundException){}
            return coll;
        }

        public static List<GraphicKey> GetGraphicKeysForTaskFromJson(int taskId)
        {
            var taskName = taskId.ToString();
            var fullPath = GetPathToJsonFile();
            var list = new List<GraphicKey>();
            try
            {
                using (StreamReader r = new StreamReader($@"{fullPath}\{taskName}.json"))
                {
                    string json = r.ReadToEnd();
                    list = JsonConvert.DeserializeObject<List<GraphicKey>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    });
                }
            }
            catch (FileNotFoundException) { }
            return list;
        }

        public static void DeleteTaskJsonById(int taskId)
        {
            var taskName = taskId.ToString();
            var fullPath = GetPathToJsonFile();
            File.Delete($@"{fullPath}\{taskName}.json");
        }

        private static string GetPathToJsonFile()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));
            return new Uri($@"{path}\Data\JsonObjects").LocalPath;
        }
    }
}
