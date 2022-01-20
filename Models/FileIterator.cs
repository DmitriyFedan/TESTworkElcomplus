
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
   


namespace TESTworkElcomplus
{
    public class FileIterator
    {
        // класс представляет из себя  конструкцию имеющую один метод Separator
        // этот метод принимает директорию и объект класса FileSerializer (который  в свою очередб принимает объект интерфейса
        // десериализатор  и файл который нужно десереализовать) 
        // в методе создатеся два десериализатора  json xaml  и запускается таска которая проходит по директории
        //берет каждый файл и  в соответсвии с  расширением файла пременяет к нему соответсвующий дессериализатор


        public void Separator(DirectoryInfo directory, ValuesCounter reader)
        {
            //JsToArrDeserializer jsDeser = new JsToArrDeserializer();
            //XmlToArrDeserializer xmlDeser = new XmlToArrDeserializer();
            ValuesJsonReader jsonReader = new ValuesJsonReader();
            ValuesXmlReader xmlReader = new ValuesXmlReader();
            // 
            Console.WriteLine("in Separator");
            foreach (FileInfo file in directory.GetFiles())
            {
                Console.WriteLine(file.Name);
                switch (file.Extension.ToString())
                {
                    case ".json":
                        reader.SearchUnique(jsonReader, file);
                        //Thread.Sleep(500);
                        break;
                    /*//  к Сожалению изначально не предусмотрел проблемы 
                        * с конкурированием потоков, а времени на исправление и поиск нового решения уже не оставалось
                        * поэтому воспользовался таким костылем с  кратковременным усыплением потока*/
                    case ".xml":
                        reader.SearchUnique(xmlReader, file);
                        //Thread.Sleep(500);
                        break;
                    default:
                        ////  Вывести сообщение через messagebox //// 
                        Console.WriteLine($"Файлы с  расширением {file.Extension} не ожет быть обработан"); 
                        break;
                }
            }
                
        }
    }
}


