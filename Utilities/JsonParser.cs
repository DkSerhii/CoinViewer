using CoinViewer.DataModel;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinViewer.Utilities
{
    internal class JsonParser
    {
        public static List<CryptoCoin> parseCoins(String json)
        {
            var convertedData = JsonConvert.DeserializeObject<ResponseData>(json);
            List<CryptoCoin> cryptoCoins = new List<CryptoCoin>();

            foreach (var item in convertedData.data)
            {
                if (item.priceUsd < 10)
                {
                    item.priceUsd = Math.Round(item.priceUsd, 4);
                } 
                else
                {
                    item.priceUsd = Math.Round(item.priceUsd, 2);
                }

                cryptoCoins.Add(item);
            }
            return cryptoCoins;
        }

        private class ResponseData
        {
            public CryptoCoin[] data { get; set; }
        }
    }
}
