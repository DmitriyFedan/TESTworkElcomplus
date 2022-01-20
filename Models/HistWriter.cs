using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTworkElcomplus.Models
{
    /// <summary>
    /// static class for writing  historydata in json file
    /// </summary>
    public static class HistWriter  

    {

        public static void HistWriting(string dirPath, string writableData)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string parentPath = Directory.GetParent(currentPath).ToString(); //  получаем 
            string histPath = Path.Combine(parentPath, "history");
            if(!Directory.Exists(histPath)) // если нет папки для хранения истории то создаем
                Directory.CreateDirectory(histPath);

            using (StreamWriter sw = new StreamWriter(Path.Combine(histPath, "hist.json"), true)) // Path.Combine(dirPath, "hist.json")
            {
                sw.WriteLine(writableData);
            }
        }
    }
}
