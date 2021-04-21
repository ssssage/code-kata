using AlgoExpert.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace AlgoExpert.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee.PrintEmployee();


            string path = @"C:\Windows";
            ShowLargeFilesWithoutLinq(path);
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            foreach (var file in query.Take(5))
            {
                System.Console.WriteLine($"{file.Name,-20} : {file.Length,10}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            //Get All csv Files  
            FileInfo[] getAllCSVFiles = di.GetFiles();
            Array.Sort(getAllCSVFiles, new FileInfoComparer());
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = getAllCSVFiles[i];
                System.Console.WriteLine($"{file.Name,-20} : {file.Length,10}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
