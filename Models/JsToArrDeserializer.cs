using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TESTworkElcomplus
{
    public class JsToArrDeserializer : IDeserializer
    {
        async public Task<string[]> StrArrayReturn(string filePath)
        {

            if (File.Exists(filePath))  //  проверка на наличие не нужна, т.к  будем передавать файл. Убрать позже
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    //List<string> st = await JsonSerializer.DeserializeAsync<List<string>>(fs);
                    Dictionary<string, string[]> st = await JsonSerializer.DeserializeAsync<Dictionary<string, string[]>>(fs);

                    return await Task.Run(() => st["Values"]);
                }
            }
            return null;
        }
    }
}
