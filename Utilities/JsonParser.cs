using CoinViewer.DataModel;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows;
using System.Diagnostics;
using CoinViewer.View;

namespace CoinViewer.Utilities
{
    internal class JsonParser
    {
        public static void parseCoins(String json)
        {
            if (!Cache.isSearhing)
            {
                var serializedCoins = JsonConvert.DeserializeObject<ResponseDataCoins>(json);
                assignCoins(serializedCoins.data);
            }
            else
            {
                var serializedCoin = JsonConvert.DeserializeObject<ResponseDataCoin>(json);
                CryptoCoin[] coinArray = new CryptoCoin[] { serializedCoin.data };
                
                assignCoins(coinArray);
            }
        }

        public static void parseMarkets(String json)
        {
            var serializedMarkets = JsonConvert.DeserializeObject<ResponseDataMarkets>(json);

            assignMarkets(serializedMarkets.data);
        }

        private static void assignMarkets(Market[] markets)
        {
            List<Market> marketsList = new List<Market>();

            foreach (Market market in markets) 
            {
                marketsList.Add(market);
            }

            Cache.marketsToShow = marketsList;
        }

        private static void assignCoins(CryptoCoin[] coins)
        {
            List<CryptoCoin> cryptoCoins = new List<CryptoCoin>();

            foreach (CryptoCoin coin in coins)
            {
                if (coin.priceUsd < 10)
                {
                    coin.priceUsd = Math.Round(coin.priceUsd, 4);
                }
                else
                {
                    coin.priceUsd = Math.Round(coin.priceUsd, 2);
                }

                cryptoCoins.Add(coin);
            }
            Cache.coinsToShow = cryptoCoins;
        }
        private class ResponseDataMarkets
        {
            public Market[] data { get; set; }
        }

        private class ResponseDataCoins
        {
            public CryptoCoin[] data { get; set; }
        }

        private class ResponseDataCoin
        {
            public CryptoCoin data { get; set; }
        }
    }
}
