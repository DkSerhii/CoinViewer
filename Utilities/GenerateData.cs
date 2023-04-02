using CoinViewer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.Utilities
{
    class GenerateData
    {
        public static List<CryptoCoin> generateCryptoCoin()
        {
            return new List<CryptoCoin>()
            {
                new CryptoCoin("BTC", "Bitcoin", 23521),
                new CryptoCoin("ETH", "Etherium", 3561),
                new CryptoCoin("GVN", "Govnocoin", 56981),
                new CryptoCoin("BTC", "Bitcoin", 23521),
                new CryptoCoin("ETH", "Etherium", 3561),
                new CryptoCoin("GVN", "Govnocoin", 56981),
                new CryptoCoin("BTC", "Bitcoin", 23521),
                new CryptoCoin("ETH", "Etherium", 3561)
            };
        }
    }
}
