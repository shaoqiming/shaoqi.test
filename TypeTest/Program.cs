using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TClass);
            var dt = type.GetMembers();
            foreach (var m in dt)
            {
                Console.WriteLine("【" + m.MemberType.ToString() + "】：" + m.Name);
            }


            type.InvokeMember("getage", BindingFlags.InvokeMethod, null, new TClass(), null);

            //只通过类名和方法名动态调用方法
            string className = "";
            string MethodName = "";

            Type T1 = Type.GetType(className);
            ConstructorInfo ci = T1.GetConstructors()[0];//获取第一个构造函数
            Object obj = ci.Invoke(null);//调用构造函数 然后返回一个对象
            T1.InvokeMember(MethodName, BindingFlags.InvokeMethod, null, obj, null);//调用

            //动态的构造对象
            Assembly asm = Assembly.GetExecutingAssembly();
            asm.CreateInstance("TypeTest.TClass", true);//不区分大小写

            //动态构造对象
            ObjectHandle handler = Activator.CreateInstance(null, "TypeTest.TClass");

            Console.ReadKey();
        }
    }

    public class TClass
    {
        public string name { get; set; }
        public int age { get; set; }

        public int ages;

        public int getage()
        {
            return age;
        }

    }
}
