using System;
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
                try
                {
                    JsonDocument jsdoc = JsonDocument.Parse(sr.ReadToEnd());
                    JsonElement root = jsdoc.RootElement;
                    var values = root.GetProperty("Values").EnumerateArray(); //  возвращает enumerator for  json array  represented by this JsonElement. 
                    List<string> resultLis = new List<string> { };  //
                    foreach (var item in values)
                        resultLis.Add(item.ToString());

                    return resultLis.ToArray();
                }
                catch (Exception ex)
                {
                    return null;
                    //Console.WriteLine(ex.Message);
                }

            }               
        }
    }


    
           
}
  


       
            
            
       


        
    