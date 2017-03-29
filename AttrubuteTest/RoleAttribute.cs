using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttrubuteTest
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class RoleAttribute : Attribute
    {
        private readonly string _name;

        /// <summary>
        /// 启用标示
        /// </summary>
        public bool IsEnable { get; set; }

        public RoleAttribute(string name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
