using System;
using System.Threading;

namespace VanityBech32
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfThreads = 6;

            for (int i = 0; i < numOfThreads; i++)
            {
                var gen = new XGen();
                new Thread(gen.VanityGen).Start();
            }
            
            Console.ReadKey();
        }
    }
}
