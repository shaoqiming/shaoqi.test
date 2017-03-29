using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string con_file_path = "./../../SystemDll.json";
            StringBuilder sb = new StringBuilder();
            String line = "";
            //DLLWhiteList cfm = new DLLWhiteList();
            //cfm.Module = new List<ModuleDll>();
            //cfm.System = new List<DllModel>();
            //cfm.ThirdPatry = new List<DllModel>();
            //cfm.Business = new List<DllModel>();
            //for (int i = 0; i < 10; i++)
            //{
            //    DllModel model=new DllModel();
            //    model.Name=i.ToString();
            //    cfm.System.Add(model);
            //    cfm.Business.Add(model);
            //    cfm.ThirdPatry.Add(model);
            //}

            //string json = JsonConvert.SerializeObject(cfm);



            using (StreamReader sr = new StreamReader(con_file_path))
            {

                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                JsonReader reader = new JsonTextReader(sr);
                DLLWhiteList cfm = new DLLWhiteList();
                cfm = serializer.Deserialize<DLLWhiteList>(reader);

                //while ((line = sr.ReadLine()) != null)
                //{
                //    sb.Append(line);
                //}
                //line = sb.ToString();
                //var dd = JsonConvert.DeserializeObject<DLLWhiteList>(line);
            }



        }
    }
}
