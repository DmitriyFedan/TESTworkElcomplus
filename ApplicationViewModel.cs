using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TESTworkElcomplus.Models;
using TESTworkElcomplus;

namespace TESTworkElcomplus
{
    internal class ApplicationViewModel
    {
        private string DirPath = @"G:\WORKED\C# projects\TESTworkElcomplus\Files";
        private string fileName = "file_1.json";
        private string fileNameX = "file_1.xml";
        private string finalyPath;
        private string finalyPathXML1;
        private string resultValue;
  
        DirectoryInfo dir;
        FileSerializer serializer;
        FileIterator fileIterator;

        public ApplicationViewModel()
        {

            finalyPath = Path.Combine(DirPath, fileName);
            finalyPathXML1 = Path.Combine(DirPath, fileNameX);
            dir = new DirectoryInfo(DirPath);
            serializer  = new FileSerializer();
            fileIterator = new FileIterator();

        }
        public string UpdateValues()
        {
            fileIterator.Separator(dir, serializer);
            Thread.Sleep(4000); //  )) 
            resultValue = serializer.Resulter();
            return resultValue;
        }
          
    }
}
