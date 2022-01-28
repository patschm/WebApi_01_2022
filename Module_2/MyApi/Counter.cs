using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi
{
    public interface ICounter
    {
        int Counter {get;}
        void Increment();
    }

    public class Counter : ICounter
    {
        private int _counter = 0;

        int ICounter.Counter => _counter;

        public void Increment()
        {
            System.Console.WriteLine($"De waarde is nu: {++_counter}");
        }
    }
}