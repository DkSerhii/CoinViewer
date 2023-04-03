using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Windows;

namespace CoinViewer.Services
{

    class CalloutService
    {
        private const string COINCAP_URL = "https://api.coincap.io/v2/";
        public const string DEFAULT_SEARCH = "assets?limit=8";

        public static string endpointBuilder(string endpoint)
        {
            return new string(COINCAP_URL + endpoint);
        }

        public static async Task<string> performCallout(string endpoin)
        {
            HttpClient client = new HttpClient();

            try
            {
                return await client.GetStringAsync(endpoin);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
                return "";
            }
        }
    }
}
