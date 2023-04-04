using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Windows;
using CoinViewer.Utilities;

namespace CoinViewer.Services
{

    class CalloutService
    {
        private const string COINCAP_URL = "https://api.coincap.io/v2/";
        public const string DEFAULT_SEARCH = "assets?limit=8";
        public const string USER_SEARCH = "assets/";
        public const string MARKET_SEARCH = "/markets?limit=8";
        public const string EXCHANGES = "exchanges/";

        public static string endpointBuilder(string endpoint)
        {
            return new string(COINCAP_URL + endpoint);
        }

        public static async Task<string> performCallout(string endpoin)
        {
            HttpClient client = new HttpClient();

            try
            {
                Cache.isCallotSucces = true;
                return await client.GetStringAsync(endpoin);
            }
            catch (Exception ex) 
            { 
                Cache.isCallotSucces = false;
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        public static string GetAsyncProperty(string endpoint)
        {
            return Task.Run(() => CalloutService.performCallout(endpoint)).Result;
        }
    }
}
