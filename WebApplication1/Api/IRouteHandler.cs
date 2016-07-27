using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace shaoqi.mini.MVC
{
    public interface IRouteHandler
    {
        /// <summary>
        /// 获得自定一个Httphandler和HttpModule组件 进行自定义的操作
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        IHttpHandler GetHttpHandler(RequestContext requestContext);//这个RequestContext是自定义, 封装了当前的HTTP的请求和RouteData的封装
    }
}
