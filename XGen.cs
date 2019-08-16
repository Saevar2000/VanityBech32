using System;
using NBitcoin;

namespace VanityBech32
{
    class XGen
    {
        public void VanityGen()
        {
            Mnemonic mnemo;
            ExtKey masterKey;
            BitcoinWitPubKeyAddress Bech32;

            while (true)
            {
                mnemo = new Mnemonic(Wordlist.English, WordCount.TwentyFour);
                masterKey = new BitcoinExtKey(mnemo.DeriveExtKey(), Network.Main);

                Bech32 = masterKey.Derive(new KeyPath("m/84'/0'/0'/0/0"))
                    .PrivateKey.PubKey.GetSegwitAddress(Network.Main);

                if (Bech32.ToString().Contains("bc1qsae"))
                {
                    Console.WriteLine($"{masterKey.ToString(Network.Main)} : {Bech32}");
                    Console.WriteLine($"{mnemo}");
                }
            }
        }
    }
}