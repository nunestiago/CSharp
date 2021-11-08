using System;
using System.IO;

namespace textFiles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Write();
            Append();
            Read();
            Console.WriteLine("Done");
        }

        private const string filename = "example.txt";

        private static void Write()
        {
            StreamWriter sw = new(filename);
            sw.WriteLine("line 1");
            string s = "1233445";
            sw.WriteLine(s);
            sw.Close();
        }

        private static void Read()
        {
            StreamReader sr = new(filename);
            // string s= sr.ReadLine();

            // while (sr.ReadLine() is string s)
            // {
            //   Console.WriteLine(s);
            // }

            string s = sr.ReadToEnd();
            Console.WriteLine(s);
            sr.Close();
        }

        static void Append()
        {
            StreamWriter sw = new(filename, true);
            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine(i);
            }
            sw.Close();
        }
    }
}