using System;
using System.Diagnostics;
using System.IO;
using RbTreeFinder.Collection;
using RbTreeFinder.Tests;

namespace RbTreeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new CustomCollection("test1.txt");
            
            // test find method on smaller data sets
            var aaa = collection.Find("aaa");
            Assert(aaa == "aaa", "aaa string not found");
            
            var ccccc = collection.Find("bbb");
            Assert(ccccc == "ccccc", "ccccc string not found by key bbb");
            
            collection.Append("test2.txt");
            
            var zzz = collection.Find("zzz");
            Assert(zzz == "zzz", "zzz string not found");

            // test insertion on larger data sets (up to 100 000 items in each file)
            GenerateFile("file1.txt");
            collection.Append("file1.txt");
            
            GenerateFile("file2.txt");
            collection.Append("file2.txt");
        }

        static void GenerateFile(string filename)
        {
            using var writer = File.CreateText(filename);

            var tree = new RbTree<string, string>((one, two) => one.CompareTo(two));
            
            var generator = new StringGenerator();

            for (int i = 0; i < 100_000; i++)
            {
                var str = generator.GenerateString();
                
                tree.Add(str, str);
                writer.WriteLine(str);
            }
        }

        static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }
    }
}