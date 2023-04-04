using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.DataModel
{
    public class CryptoCoin
    {
        public string id { get; set; }

        public string symbol { get; set; }

        public string name { get; set; }

        public double priceUsd { get; set; }

        public int rank { get; set; }

        public double supply { get; set; }

        public string maxSupply { get; set; }

        public double changePercent24Hr { get; set; }

        public CryptoCoin()
        {
        }

    }
}
