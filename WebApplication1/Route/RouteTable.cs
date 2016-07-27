using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shaoqi.mini.MVC
{
    //由于同一个Web应用可以采用不同的URL的模式 注册多个基础RoutBase的路由对象 多个路由对象组成一个路由表
    public class RouteTablet
    {
        public static RoutDictionary Routes { get; private set; }

        static RouteTablet()
        {
            Routes = new RoutDictionary();
        }
    }
}