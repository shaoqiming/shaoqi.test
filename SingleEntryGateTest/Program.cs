using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingleEntryGateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleEntryGate demo = new SingleEntryGate();

            var frist = demo.TryEnter();
            var seconde = demo.TryEnter();

            Console.WriteLine(frist + "....." + seconde);
            Console.ReadKey();
        }
    }

    internal sealed class SingleEntryGate
    {
        private const int NotEntered = 0;
        private const int Entered = 1;

        private int _status=9;

        // returns true if this is the first call to TryEnter(), false otherwise
        public bool TryEnter()
        {
            int oldStatus = Interlocked.Exchange(ref _status, Entered);
            return (oldStatus == NotEntered);
        }
    }
}
