using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Formatter
{
    public static class XmlFormatter
    {
        public static string WriteAlgorithm2XmlFromCheckListBox(CheckedListBox.CheckedItemCollection methods)
        {
            var sb = new StringBuilder();
            foreach(var item in methods)
            {
                sb.Append(item).Append(";");
            }
            return sb.ToString();
        }
        
        public static void GetInfoAboutMethodFromXml(string methodName, out string desc, out string[] userParams, out string[] initParams, out string[] solveParams)
        {
            ReadXmlByTag(methodName, out desc, out userParams, out initParams, out solveParams);
        }

        private static void ReadXmlByTag(string methodName, out string desc, out string[] userParams, out string[] initParams, out string[] solveParams)
        {
            desc = string.Empty;
            userParams = new string[0];
            initParams = new string[0];
            solveParams = new string[0];
            var doc = new XmlDocument();
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));
            doc.Load($@"{path}\Data\CheckRules.xml");
            var nodes = doc.DocumentElement?.SelectNodes("/Document/Rules/PointsProectionsControl/Method");
            if (nodes == null) return;
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes == null || !node.Attributes["name"].Value.Equals(methodName)) continue;
                var selectSingleNode = node.SelectSingleNode("Description");
                if (selectSingleNode != null)
                    desc = selectSingleNode.InnerText;
                initParams = node.LastChild.ChildNodes[0].InnerText.Split(';');
                userParams = node.LastChild.ChildNodes[1].InnerText.Split(';');
                solveParams = node.LastChild.ChildNodes[2].InnerText.Split(';');
            }
        }
    }
}
