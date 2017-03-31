using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacthEditeImgName
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(@"E:\iamge");

            var id = 0;
            foreach (FileInfo file in info.GetFiles("*.*"))
            {
                
                string xingname = @"E:\\iamge\\转换后的文件\\" + id + ".jpg";
                id++;

                if (File.Exists(xingname))
                {
                    File.Delete(xingname);
                }


                file.MoveTo(xingname);
            }
        }
    }
}
