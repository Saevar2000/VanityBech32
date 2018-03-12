using NBitcoin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VanityBech32
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfThreads = 8;

            for (int i = 0; i < numOfThreads; i++)
            {
                var gen = new Gen();
                new Thread(gen.VanityGen).Start();
            }
            
            Console.ReadKey();
        }
    }
}
