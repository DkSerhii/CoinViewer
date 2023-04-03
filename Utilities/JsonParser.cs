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
            List<CryptoCoin> cryptoCoins = new List<CryptoCoin>();

            if (Cache.isSearhing == false)
            {
                var serializedData = JsonConvert.DeserializeObject<ResponseDataArray>(json);
                assignCoins(serializedData.data);
            }
            else if (Cache.isSearhing == true)
            {
                var serializedData = JsonConvert.DeserializeObject<ResponseDataSingleValue>(json);
                CryptoCoin[] coinArray = new CryptoCoin[] { serializedData.data };
                
                assignCoins(coinArray);
            }
        }

        public static void assignCoins(CryptoCoin[] coins)
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

        private class ResponseDataArray
        {
            public CryptoCoin[] data { get; set; }
        }

        private class ResponseDataSingleValue
        {
            public CryptoCoin data { get; set; }
        }
    }
}
