using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\";
            string fileName = "shaoqi.js";

            string fullpath = Path.Combine(path, fileName);
            if (!File.Exists(fullpath))
            {
                FileStream fs = File.Create(fullpath);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(fullpath);  //创建写入流
            sw.Write("ddd=ssdsd");
            sw.Flush();
            sw.Close();

            StreamReader sr = new StreamReader(fullpath, System.Text.Encoding.GetEncoding("utf-8"));
            string content = sr.ReadToEnd().ToString();
            sr.Close();

            Console.WriteLine(content);
            Console.ReadKey();
            
        }
    }
}
