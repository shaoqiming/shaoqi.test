using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousProgrammingModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Debug线程ID:" + Thread.CurrentThread.ManagedThreadId);
            var request = WebRequest.Create("https://github.com/");
            request.GetResponse();

            Debug.WriteLine("Debug线程ID:" + Thread.CurrentThread.ManagedThreadId);

            this.label1.Text = "执行完毕";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //应该是begin的方法 Complete的方法
            Debug.WriteLine("Debug线程ID：" + Thread.CurrentThread.ManagedThreadId);

            var request = WebRequest.Create("Https://github.com/");

            request.BeginGetResponse(new AsyncCallback(t =>
            {
                var response = request.EndGetResponse(t);
                var steam = response.GetResponseStream();//放回这个数据流

                using (StreamReader reader = new StreamReader(steam))
                {
                    StringBuilder sb = new StringBuilder();
                    while (!reader.EndOfStream)
                    {
                        var content = reader.ReadLine();
                        sb.Append(content);
                    }
                    reader.ReadLine();

                    Debug.WriteLine("【Debug】" + sb.ToString().Trim().Substring(0, 100) + "...");

                    Debug.WriteLine("=========Debug异步线程ID：" + Thread.CurrentThread.ManagedThreadId);

                    this.label1.Invoke((Action)(() => { this.label1.Text = "异步执行完成"; }));
                }



            }), null);

            Debug.WriteLine("Debug线程ID:" + Thread.CurrentThread.ManagedThreadId);
        }


        public IAsyncResult MyBeginXX(AsyncCallback callback)
        {
            var asyResult = new MyWebRequest(callback, null);

            var request = WebRequest.Create("https://github.com");

            new Thread((t) =>
            {
                using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    asyResult.SetComplete(content);//其中会调用回调函数
                }
            }).Start();

            return asyResult;
        }

        public string MyEndXX(IAsyncResult result)
        {
            MyWebRequest request = result as MyWebRequest;
            return request.Result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);

            MyBeginXX(new AsyncCallback(t =>
            {
                var result = MyEndXX(t);
                Debug.WriteLine("【Debug】" + result.Trim().Substring(0, 100) + "...");
                Debug.WriteLine("【Debug】异步线程ID:" + Thread.CurrentThread.ManagedThreadId);
            }));

            Debug.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);

            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += new DoWorkEventHandler((s1, s2) =>
            {
                Thread.Sleep(2000);
                Debug.WriteLine("【Debug】异步线程ID:" + Thread.CurrentThread.ManagedThreadId);
            });

            worker.RunWorkerAsync(this);

            Debug.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            var func = new Func<string, string>(t =>
            {
                Thread.Sleep(2000);
                return "name:" + t + DateTime.Now.ToString();
            });

            Debug.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);

            var asyncResult = func.BeginInvoke("张三", t =>
            {
                Debug.WriteLine("【Debug】异步线程ID:" + Thread.CurrentThread.ManagedThreadId);
                string str = func.EndInvoke(t);
                Debug.WriteLine(str);
                this.label1.Invoke((Action)(() => { this.label1.Text = "func执行完成"; }));
            }, null);

            Debug.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.WriteLine("【Debug】主 线程ID:" + Thread.CurrentThread.ManagedThreadId);
            //TAP
            var task1 = Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("【Debug】task1 线程ID:" + Thread.CurrentThread.ManagedThreadId);
                return "张三";
            });

            //task1.Wait();
            //var value = task1.Result;

            Console.WriteLine("【Debug】主 线程ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            Console.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);
            var num1 = await GetNumber(6);
            Thread.Sleep(2000);
            Console.WriteLine("【Debug】主线程ID:" + Thread.CurrentThread.ManagedThreadId);
            this.label1.Text = num1.ToString();
        }

        public Task<int> GetNumber(int num)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("【Debug】异步线程ID:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                return num;
            });

        }
    }
}
