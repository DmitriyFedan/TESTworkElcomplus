
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
   


namespace TESTworkElcomplus
{
    public class FileIterator
    {
        /*класс представляет из себя  конструкцию имеющую один метод Separator
        *этот метод принимает директорию и объект класса Valuesreader (который  в свою очередб принимает объект интерфейса
        *    и файл который нужно счbтать) 
        * в методе создатеся два reader-a  json xaml   каждый из них применяется 
        к соответсвующему файлу в методе SearchUnique
        */

        public void Separator(DirectoryInfo directory, ValuesCounter reader)
        {
         
            ValuesJsonReader jsonReader = new ValuesJsonReader();
            ValuesXmlReader xmlReader = new ValuesXmlReader();
             
            
            foreach (FileInfo file in directory.GetFiles())
            {
                Console.WriteLine(file.Name);
                switch (file.Extension.ToString())
                {
                    case ".json":
                        reader.SearchUnique(jsonReader, file);
                        break;
                    
                    case ".xml":
                        reader.SearchUnique(xmlReader, file);          
                        break;
                    default:
                        //   Вывести сообщение через messagebox //// 
                        Console.WriteLine($"Файлы с  расширением {file.Extension} не ожет быть обработан"); 
                        break;
                }
            }
                
        }
    }
}


