using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] drives = Environment.GetLogicalDrives();
            Console.WriteLine("GetLogicalDrives: {0}", String.Join(", ", drives));
            Console.ReadKey();
        }
    }
}
