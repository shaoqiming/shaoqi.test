using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XpathTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ///AtawApplicationConfig/Memcached/@Init
            string Xpath = "AtawApplicationConfig/AppName";

            XmlDocument doc = new XmlDocument();
            doc.Load("./../../Application.xml");

            XmlNode last = doc.SelectSingleNode(Xpath);

            int Count = last.ChildNodes.Count;
            for (int i = 0; i < Count; i++)
            {
                last.RemoveChild(last.ChildNodes[0]);
            }

            XmlNode node = doc.CreateElement("AppSetting");

            XmlAttribute att = doc.CreateAttribute("Key");
            att.Value="九腾汽车维修服务平台";

            node.Attributes.Append(att);
            last.AppendChild(node);

            //if (last != null)
            //{
            //    if (last.NodeType == XmlNodeType.Attribute)
            //    {
            //        XmlAttribute s2 = (XmlAttribute)last;
            //        s2.InnerText = "90";
            //    }
            //    else if (last.NodeType == XmlNodeType.Element)
            //    {
            //        XmlElement s2 = (XmlElement)last;
            //        s2.InnerText = "shaoqi";
            //    }
           
            //}
            doc.Save("./../../Application.xml");
        }
    }
}
