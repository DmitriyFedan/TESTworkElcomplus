using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace TESTworkElcomplus
{
    internal class ValuesXmlReader : IValuesReader
    {
        public string[] ConvertToStringArray(string filePath)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filePath);
            XmlElement xRoot = xdoc.DocumentElement;
            List<string> resultList = new List<string>();
            XmlNode node = xRoot.SelectSingleNode("Values"); // берем узел содержащий Values 
            
            foreach (XmlNode childNode in node)
                if (childNode.Name == "Value")
                    resultList.Add(childNode.InnerText);
            
            return resultList.ToArray();
        }     
    }
}
