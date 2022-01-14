using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TESTworkElcomplus
{
    public class XmlToArrDeserializer : IDeserializer
    {
        private string[] XmlReader(string filePath)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filePath);
            XmlElement xRoot = xdoc.DocumentElement;
            List<string> resultList = new List<string>();
            foreach (XmlNode node in xRoot)
            {
                foreach (XmlNode childNode in node)
                    if (childNode.Name == "Value")
                        resultList.Add(childNode.InnerText);
            }
            string[] result = resultList.ToArray();
            return result;
        }
        public async Task<string[]> StrArrayReturn(string filePath)
        {
            return await Task.Run(() => XmlReader(filePath));
        }
    }
}
