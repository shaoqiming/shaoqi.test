using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingModel
{
    class MyWebRequest : IAsyncResult
    {
        private AsyncCallback _asyncCallback;

        public string Result { get; set; }

        public MyWebRequest(AsyncCallback call, object state)
        {
            this._asyncCallback = call;
        }

        //设置结果
        public void SetComplete(string result)
        {
            Result = result;
            IsCompleted = true;

            if (this._asyncCallback != null)
            {
                this._asyncCallback(this);
            }
        }

        public object AsyncState
        {
            get { throw new NotImplementedException(); }
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCompleted
        {
            get;
            private set;
        }
    }
}
