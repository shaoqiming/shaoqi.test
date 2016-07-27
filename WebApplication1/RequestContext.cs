using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shaoqi.mini.MVC
{
    public class RequestContext
    {
        public virtual HttpContextBase HttpContext { get; set; }

        public virtual RoutData RoutData { get; set; }
    }
}