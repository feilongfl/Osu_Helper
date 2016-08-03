using System;
using System.Threading;

namespace cmdtest
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
            Thread.Sleep(100000);
        }
    }
}
