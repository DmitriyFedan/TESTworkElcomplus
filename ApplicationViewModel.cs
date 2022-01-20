using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TESTworkElcomplus.Models;
using TESTworkElcomplus;

namespace TESTworkElcomplus
{
    internal class ApplicationViewModel
    {
        //string DirPath =@"G:\WORKED\C# projects\TESTworkElcomplus\Files";
        public string DirPath { get; set; }
        //private string fileName = "file_1.json";
        //private string fileNameX = "file_1.xml";
        private string finalyPath;
        private string finalyPathXML1;
        private string resultValue;
        public List<string> fileNameList;
        DirectoryInfo dir;
        ValuesCounter valuesCounter;
        FileIterator fileIterator;

        public ApplicationViewModel()
        {
            //finalyPath = Path.Combine(DirPath, fileName);
            //finalyPathXML1 = Path.Combine(DirPath, fileNameX);
            fileNameList = new List<string> { };
            valuesCounter = new ValuesCounter();
            fileIterator = new FileIterator();
        }
        public string UpdateValues()
        {
            dir = new DirectoryInfo(DirPath);
            fileIterator.Separator(dir, valuesCounter);   
            resultValue = valuesCounter.Resulter();

            HistWriter.HistWriting(dir.FullName, dir.FullName); // writting data  in hist.json
            
            foreach (var file in dir.GetFiles())
                fileNameList.Add(file.Name);
            return resultValue;
        }         
    }
}
