using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shaoqi.mini.MVC
{
    public class RoutDictionary : Dictionary<string, RouteBase>
    {
        public RoutData GetRouteData(HttpContextBase httpContext)
        {
            foreach (var route in this.Values)
            {
                //调用的RouteBase的GetRouteData
                RoutData routData = route.GetRouteData(httpContext);
                if (null != routData)
                {
                    return routData;
                }
            }
            return null;
        }
    }
}