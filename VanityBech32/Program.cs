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
        static int i = 0;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string search = "bc1qsaev";
            Key privateKey;
            BitcoinWitPubKeyAddress Bech32;
            void VanityGen()
            {
                while (true)
                {
                    i++;

                    privateKey = new Key(); // Generate a random private key
                    Bech32 = privateKey.PubKey.GetSegwitAddress(Network.Main);

                    if (Bech32.ToString().IndexOf(search, System.StringComparison.Ordinal) != -1)
                    {
                        sw.Stop();
                        Console.WriteLine($"Finished on {i} attempt and took a total of {sw.Elapsed} seconds");
                        Console.WriteLine("Address: " + Bech32);
                        Console.WriteLine("Private Key: " + privateKey.GetWif(Network.Main));
                        Environment.Exit(0);
                    }
                }
            }

            int numOfThreads = 5;
            Thread[] ts = new Thread[numOfThreads];
            for (int i = 0; i < numOfThreads; i++)
            {
                ts[i] = new Thread(() =>
                {
                    VanityGen();
                });
                ts[i].Start();
            }

            int s5 = 0;
            List<int> s60 = new List<int>();
            void Benchmark(object state)
            {
                if (s60.Count > 12)
                {
                    s60.RemoveAt(0);
                }
                Console.WriteLine($"Attempts: {i} --- Speed 5s/60s: {(i - s5)} {s60.Sum() / 12} Time: {sw.Elapsed}");
                s60.Add(i - s5);
                s5 = i;
            }

            using (new Timer(Benchmark, null, 0, 5000))
            {
                Console.WriteLine("Started... (This might take a while)");
                Thread.Sleep(TimeSpan.FromDays(1));
            }

            Console.ReadLine();
        }

        
    }
}
