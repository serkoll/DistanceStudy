using System;
using System.Xml;

namespace DistanceStudy.Classes
{
    /// <summary>
    /// class для чтения информации из xml
    /// в xml находится информация о приложении - подсказки для пользователей
    /// </summary>
    public class LoadHelpText
    {
        public string[] HelpText { get; set; }
        public short CountOfpromts { get; set; }

        public LoadHelpText()
        {
            CountOfpromts = 0;
            HelpText = new string[100];
            var str = AppDomain.CurrentDomain.BaseDirectory;
            var reader = new XmlTextReader(str + "help.xml");
            // построчное чтение xml. текст подсказки находится в теге <HelpInformation>
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element || !reader.Name.Equals("HelpInformation")) continue;
                HelpText[CountOfpromts] = reader.ReadString();
                CountOfpromts++;
            }
            reader.Close();
        }
    }

}
