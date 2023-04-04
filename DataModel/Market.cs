using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.DataModel
{
    public class Market
    {
        public string exchangeId { get; set; }

        public string baseSymbol { get; set; }

        public string priceUsd { get; set; }
         
        public Market() { }
    }
}
