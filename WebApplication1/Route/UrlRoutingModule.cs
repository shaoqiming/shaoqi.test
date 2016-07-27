using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shaoqi.mini.MVC
{
    public class UrlRoutingModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += OnPostResolveRequestCache;
        }

        protected virtual void OnPostResolveRequestCache(object sender, EventArgs e)
        {
            HttpContextWrapper httpContext = new HttpContextWrapper(HttpContext.Current);

            //获得再Global中添加的模板
            RoutData routeData = RouteTablet.Routes.GetRouteData(httpContext);

            if (null == routeData)
            {
                return;
            }

            RequestContext requestContext = new RequestContext
            {
                HttpContext = httpContext,
                RoutData = routeData
            };

            IHttpHandler handler = routeData.RouteHandler.GetHttpHandler(requestContext);

            httpContext.RemapHandler(handler);

        }
    }
}