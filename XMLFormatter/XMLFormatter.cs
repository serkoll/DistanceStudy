using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

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
        
        public static void GetInfoAboutMethodFromXml(string methodName, ref string desc, ref string userParams, ref string initParams)
        {
            ReadXmlByTag(methodName, ref desc, ref userParams, ref initParams);
        }

        private static void ReadXmlByTag(string methodName, ref string desc, ref string userParams, ref string initParams)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\ProjectsVS\DistanceStudy\[MSSQL.DB]\CheckRules.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Document/Rules/PointsProectionsControl/Method");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"].Value.Equals(methodName))
                {
                    desc = node.SelectSingleNode("Description").InnerText;
                    initParams = node.LastChild.ChildNodes[0].InnerText;
                    userParams = node.LastChild.ChildNodes[1].InnerText;
                }
            }
        }
    }
}
