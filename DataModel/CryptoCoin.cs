using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.DataModel
{
    class CryptoCoin
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public CryptoCoin(string symbol, string name, double price)
        {
            this.symbol = symbol;
            this.name = name;
            this.price = price;
        }
    }
}
