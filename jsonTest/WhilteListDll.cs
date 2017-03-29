using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonTest
{
    public class DLLWhiteList
    {
        public List<DllModel> System { get; set; }
        public List<DllModel> ThirdPatry { get; set; }
        public List<ModuleDll> Module { get; set; }
        public List<DllModel> Business { get; set; }
    }

    public class ModuleDll
    {
        public List<DllModel> DllList { get; set; }
        public string ModuleName { get; set; }
    }

    public class DllModel
    {
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
        public long Size { get; set; }
    }
}
