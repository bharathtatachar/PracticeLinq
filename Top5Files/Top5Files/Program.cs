﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top5Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows\";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("****************");
            ShowlargeFilesWithLinq(path);
            Console.ReadLine();
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileComparer());
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name}:{file.Length}");
            }
        }

        private static void ShowlargeFilesWithLinq(string path)
        {
            //query syntax
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name}:{file.Length}");
            }
            Console.WriteLine("****************");
            var files = new DirectoryInfo(path).GetFiles()
                            .OrderByDescending(f => f.Length)
                            .Take(5);
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Name}:{file.Length}");
            }

        }
    }

    public class FileComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }

}
