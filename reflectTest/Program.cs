using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "/Ataw.RightCloud.Web.dll");

            Console.WriteLine("FullName:"+ assembly.FullName);

            try
            {
                assembly.GetTypes();
            }
            catch (Exception e)
            {

                throw e;
            }
             

            Module[] modules = assembly.GetModules();

          

            Console.ReadKey();
        }
    }
}
