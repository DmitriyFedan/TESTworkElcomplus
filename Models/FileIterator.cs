﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TESTworkElcomplus.Models
{
    public class FileIterator
    {
        public async void Separator(DirectoryInfo directory, FileSerializer serializer)
        {
            JsToArrDeserializer jsDeser = new JsToArrDeserializer();
            XmlToArrDeserializer xmlDeser = new XmlToArrDeserializer();
            // 
            await Task.Run(() =>
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    switch (file.Extension.ToString())
                    {
                        case ".json":
                            serializer.SearchUnique(jsDeser, file);
                            Thread.Sleep(500);
                            break;
                        /*//  к Сожалению изначально не предусмотрел проблемы 
                         * с конкурированием потоков, а времени на исправление и поиск нового решения уже не оставалось
                         * поэтому воспользовался таким костылем с  кратковременным усыплением потока*/
                        case ".xml":
                            serializer.SearchUnique(xmlDeser, file);
                            Thread.Sleep(500);
                            break;
                        default:
                            Console.WriteLine($"Файлы с  расширением {file.Extension} не ожет быть обработан");
                            break;
                    }
                }
            });
        }
    }
}
