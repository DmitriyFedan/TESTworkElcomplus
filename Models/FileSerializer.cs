using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTworkElcomplus;

namespace TESTworkElcomplus
{
    public class FileSerializer
    {
        private Dictionary<string, int> _dict = new Dictionary<string, int>(); // to store unique values and their count 

        public async void SearchUnique(IDeserializer deserializer, FileInfo file) // searching unique for adding to dictionary
        {
            string[] strArr = await deserializer.StrArrayReturn(file.FullName);
            foreach (var item in strArr)
            {
                if (_dict.ContainsKey(item))
                    _dict[item]++;
                else
                    _dict.Add(item, 1);
            }
        }
        // 
        public string Resulter()  // 
        {
            KeyValuePair<string, int> res = new KeyValuePair<string, int>("", 0);

            foreach (var item in _dict)
            {
                if (item.Value > res.Value)
                    res = item;
            }
            string result = $"элемент {res.Key} встречается наибольшее число раз {res.Value}";
            return result;
        }

    }
}