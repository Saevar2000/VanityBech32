using NBitcoin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VanityBech32
{
    class Gen
    {
        public void VanityGen()
        {
            Key privateKey;
            BitcoinWitPubKeyAddress Bech32;

            while (true)
            {
                privateKey = new Key(); // Generate a random private key.
                Bech32 = privateKey.PubKey.GetSegwitAddress(Network.Main);

                if (Bech32.ToString().Contains("bc1qsae"))
                {
                    Console.WriteLine($"{privateKey.GetWif(Network.Main)} : { Bech32}");
                }
            }
        }
    }
}
