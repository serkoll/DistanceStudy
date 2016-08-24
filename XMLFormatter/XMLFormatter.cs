using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace XMLFormatter
{
    public static class XmlFormatter
    {
        public static string WriteAlgorithm2XmlFromCheckListBox(CheckedListBox.CheckedItemCollection methods)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in methods)
            {
                sb.Append(item).Append(";");
            }
            return sb.ToString();
        } 
        //public string WriteObject2Xml(List<object> list)
        //{
        //    if (list == null)
        //        list = new List<object>();
        //    XmlDocument doc = new XmlDocument();
        //    XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("DataBase"));
        //    foreach (var item in list)
        //    {
        //        var key = (XmlElement)el.AppendChild(doc.CreateElement(item.GetType().ToString()));
        //        switch (item.GetType().ToString())
        //        {
        //            case "GeomObjects.Points.Point3D":
        //                {
        //                    var res = (Point3D)item;
        //                    key.SetAttribute("X", $"{res.X}");
        //                    key.SetAttribute("Y", $"{res.Y}");
        //                    key.SetAttribute("Z", $"{res.Y}");
        //                    break;
        //                }
        //            case "System.String":
        //                {
        //                    var res = (string)item;
        //                    key.SetAttribute("x", $"{res}");
        //                    key.SetAttribute("y", $"{res}");
        //                    key.SetAttribute("z", $"{res}");
        //                    break;
        //                }
        //            case "System.Char":
        //                {
        //                    var res = (char)item;
        //                    key.SetAttribute("x1", $"{res}");
        //                    key.SetAttribute("y1", $"{res}");
        //                    key.SetAttribute("x2", $"{res}");
        //                    key.SetAttribute("y2", $"{res}");
        //                    break;
        //                }
        //        }
        //    }
        //    return doc.OuterXml;
        //}

        //public static List<object> WriteXml2Object(string outerXml)
        //{
        //    List<object> list = new List<object>();
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.LoadXml(outerXml);

        //    string xpath = "//DataBase";
        //    var nodes = xmlDoc.SelectNodes(xpath);
        //    XmlNode node = nodes.Item(0);
        //    foreach (XmlNode childrenNode in node.ChildNodes)
        //    {
        //        switch (childrenNode.Name)
        //        {
        //            case "System.Int32":
        //                {
        //                    var attr = childrenNode.Attributes;
        //                    foreach(var att in attr)
        //                    {
        //                        list.Add(att);
        //                    }
        //                    break;
        //                }
        //            case "System.String":
        //                {
        //                    var attr = childrenNode.Attributes;
        //                    foreach (var att in attr)
        //                    {
        //                        list.Add(att);
        //                    }
        //                    break;
        //                }
        //            case "System.Char":
        //                {
        //                    var attr = childrenNode.Attributes;
        //                    foreach (var att in attr)
        //                    {
        //                        list.Add(att);
        //                    }
        //                    break;
        //                }
        //        } 
        //    }
        //    return list;
        //}
    }
}
