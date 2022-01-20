using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TESTworkElcomplus;

namespace TESTworkElcomplus
{
    public class ValuesCounter
    {
        private Dictionary<string, int> _dict = new Dictionary<string, int>(); // to store unique values and their count 

        public void SearchUnique(IValuesReader valuesreader, FileInfo file) // searching unique for adding to dictionary
        {
            string[] strArr =  valuesreader.ConvertToStringArray(file.FullName);
            Console.WriteLine(file.FullName);
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
            string result = $"Элемент со значением {res.Key} встречается наиболее часто: {res.Value} раз";
            return result;
        }
        
    }
}
