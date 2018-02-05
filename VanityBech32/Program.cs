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
            var p = new Program();
            p.VanityGen();
            Console.ReadLine();
        }

        void VanityGen()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string search = "bc1qsae"; 
            Key privateKey;
            BitcoinWitPubKeyAddress Bech32;

            int i = 0;

            while (true)
            {
                i++;

                privateKey = new Key(); // Generate a random private key.
                Bech32 = privateKey.PubKey.GetSegwitAddress(Network.Main);

                if (Bech32.ToString().IndexOf(search, System.StringComparison.Ordinal) != -1)
                {
                    sw.Stop();
                    Console.WriteLine($"Finished on {i} attempt and took a total of {sw.Elapsed} seconds");
                    Console.WriteLine("Address: " + Bech32);
                    Console.WriteLine("Private Key: " + privateKey.GetWif(Network.Main));
                }
            }
        }
    }
}
