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


        // применяет объект интерфеса к полученному файцл ищет уникальные ключи добавляетих в словарь
        // если  ключ уже в словаре плюсует к их значению-счетчику
        public void SearchUnique(IValuesReader valuesreader, FileInfo file) // searching unique for adding to dictionary
        {
            string[] strArr =  valuesreader.ConvertToStringArray(file.FullName);
            if (strArr != null)
            {
                foreach (var item in strArr)
                {
                    if (_dict.ContainsKey(item))
                        _dict[item]++;
                    else
                        _dict.Add(item, 1);
                }
            }
        }
        // ищет  в словаре пару с наибольшим значением возвращает форматированную строку содержащую статистику
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
