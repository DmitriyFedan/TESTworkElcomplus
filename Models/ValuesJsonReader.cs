using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TESTworkElcomplus
{

    internal class ValuesJsonReader : IValuesReader 
    {
        public string[] ConvertToStringArray (string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                JsonDocument jsdoc = JsonDocument.Parse(sr.ReadToEnd());
                JsonElement root = jsdoc.RootElement;
                var values = root.GetProperty("Values").EnumerateArray(); //  возвращает enumerator for  json array  represented by this JsonElement. 
                List<string> resultLis = new List<string> { };  //
                foreach (var item in values)
                    resultLis.Add(item.ToString());
                
                return resultLis.ToArray();                                                        
            }               
        }
    }


    
            //private string dirPath = @"G:\WORKED\C# projects\testwork\Files";
            ////private fileName = "file_1.json";
            ////private string fileNameX = "file_1.xml";
            //private string finalyPath = Path.Combine(dirPath, fileName);
            //string finalyPathXML1 = Path.Combine(dirPath, fileNameX);
}
  


       
            
            
       


        
    