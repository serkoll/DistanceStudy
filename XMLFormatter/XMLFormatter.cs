using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace XMLFormatter
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
        
        public static void GetInfoAboutMethodFromXml(string methodName, ref string desc, ref string[] userParams, ref string[] initParams, ref string[] solveParams)
        {
            ReadXmlByTag(methodName, ref desc, ref userParams, ref initParams, ref solveParams);
        }

        private static void ReadXmlByTag(string methodName, ref string desc, ref string[] userParams, ref string[] initParams, ref string[] solveParams)
        {
            var doc = new XmlDocument();
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));
            doc.Load($@"{path}\[MSSQL.DB]\CheckRules.xml");
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
