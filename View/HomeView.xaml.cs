using CoinViewer.DataModel;
using CoinViewer.Services;
using CoinViewer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinViewer.View
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            CalloutService calloutService = new CalloutService();
            String endpoint = CalloutService.endpointBuilder(CalloutService.DEFAULT_SEARCH);

            string calloutResult = GetAsyncProperty(endpoint);

            List<CryptoCoin> cryptoCoins = JsonParser.parseCoins(calloutResult);

            DataGridCoins.ItemsSource = cryptoCoins;
        }

        private string GetAsyncProperty(string endpoint)
        {
            return Task.Run(() => CalloutService.performCallout(endpoint)).Result;
        }
    }
}
