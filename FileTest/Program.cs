using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileRoot = "D:\\Products\\_output\\Web\\Ataw.WebSite\\Ataw.WebSite.csproj";
            DirectoryInfo di = new DirectoryInfo(FileRoot);
            DirectoryInfo Root = di.Root;
            var _products = Root.GetDirectories("Products")[0];
            string _filePath = Path.Combine(FileRoot, ".\\..\\..\\..\\Products");
            var files = GetFileBy(_products, ".csproj");
            foreach (var file in files)
            {
                Console.WriteLine(file.FullName);
            }
            Console.ReadKey();
        }


        /// <summary>
        /// 获取文件夹下的扩展名为ExcetionName的文件
        /// </summary>
        /// <param name="dirInfo">目录</param>
        /// <param name="ExcetionName">扩展名</param>
        /// <returns></returns>
        public static List<FileInfo> GetFileBy(DirectoryInfo dirInfo, string ExcetionName)
        {
            List<FileInfo> _listFile = new List<FileInfo>();
            //文件
            FileInfo[] _files = dirInfo.GetFiles();
            foreach (var _file in _files)
            {

                if (_file.Extension == ExcetionName)
                {
                    _listFile.Add(_file);
                }
            }

            //文件夹 迭代
            DirectoryInfo[] _dirs = dirInfo.GetDirectories();

            if (_dirs.Count() > 0)
            {
                foreach (var dir in _dirs)
                {
                    if (dir.Name != ".svn" && dir.Name != "_output" && dir.Name != "packages")
                    {
                        _listFile.AddRange(GetFileBy(dir, ExcetionName));
                    }
                }
            }

            return _listFile;
        }
    }
}
