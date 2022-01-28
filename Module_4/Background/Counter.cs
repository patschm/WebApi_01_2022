using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi
{
    public interface ICounter
    {
        int Initial {get; set;}
        void Increment();
    }

    public class Counter : ICounter
    {
        private int _counter = 0;

        public int Initial { get => _counter; set => _counter = value; }

        public void Increment()
        {
            System.Console.WriteLine($"De waarde is nu: {++_counter}");
        }
    }
}