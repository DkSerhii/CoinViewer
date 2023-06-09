﻿using CoinViewer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.Utilities
{
    public class Cache
    {
        public static List<CryptoCoin> coinsToShow = new List<CryptoCoin>();
        
        public static string searchValue = "";

        public static CryptoCoin selectedCoin = new CryptoCoin();

        public static bool isSearhing = false;

        public static bool isCallotSucces = true;

        public static bool isDataLoaded = false;

        public static List<Market> marketsToShow = new List<Market>();

        public static Market selectedMarket = new Market(); 

        public static Exchange selectedExchange = new Exchange();
    }
}
