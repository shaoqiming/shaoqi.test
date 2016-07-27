using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shaoqi.mini.MVC
{
    public abstract class RouteBase
    {
        /// <summary>
        /// 判断是否与当前请求匹配  并再匹配的情况下返回封装的路由RoutData的数据 如果没有则返回Null
        /// </summary>
        /// <param name="HttpContenxt"></param>
        /// <returns></returns>
        public abstract RoutData GetRouteData(HttpContextBase HttpContenxt);
    }
}