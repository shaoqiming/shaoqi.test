using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shaoqi.mini.MVC
{

    /// <summary>
    /// 实现路由机制的主要类
    /// </summary>
    public class Route : RouteBase
    {
        public IRouteHandler RouteHandler { get; set; }
        public string Url { get; set; }
        public IDictionary<string, object> DataTokens { get; set; }
        public override RoutData GetRouteData(HttpContextBase HttpContenxt)
        {
            IDictionary<string, object> variables;
            if (this.Match(HttpContenxt.Request.AppRelativeCurrentExecutionFilePath.Substring(2), out variables))
            {
                RoutData routedata = new RoutData();
                foreach (var item in variables)
                {
                    routedata.Values.Add(item.Key, item.Value);
                }

                foreach (var item in DataTokens)
                {
                    routedata.Values.Add(item.Key, item.Value);
                }

                routedata.RouteHandler = this.RouteHandler;
                return routedata;
            }

            return null;
        }

        public bool Match(string requestUrl, out IDictionary<string, object> variables)
        {
            variables = new Dictionary<string, object>();
            string[] strArray1 = requestUrl.Split('/');
            string[] strArray2 = this.Url.Split('/');

            if (strArray1.Length != strArray2.Length)
            {
                return false;
            }

            for (int i = 0; i < strArray2.Length; i++)
            {
                if (strArray2[i].StartsWith("{") && strArray2[i].EndsWith("}"))
                {
                    variables.Add(strArray2[i].Trim("{}".ToCharArray()), strArray1[i]);
                }
            }

            return false;
        }
    }
}