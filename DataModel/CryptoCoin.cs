using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.DataModel
{
    public class CryptoCoin
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public double priceUsd { get; set; }

        public CryptoCoin()
        {
        }

    }
}
