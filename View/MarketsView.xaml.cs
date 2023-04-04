using CoinViewer.DataModel;
using CoinViewer.Services;
using CoinViewer.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class MarketsView : UserControl
    {
        public MarketsView()
        {
            InitializeComponent();

            String endpoint = CalloutService.endpointBuilder(CalloutService.USER_SEARCH + 
                Cache.selectedCoin.id + CalloutService.MARKET_SEARCH);

            string calloutResult = CalloutService.GetAsyncProperty(endpoint);

            if (Cache.isCallotSucces)
            {
                JsonParser.parseMarkets(calloutResult);

                DataGridMarkets.ItemsSource = Cache.marketsToShow;
            }


            
        }

        private void DataGridMarkets_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Cache.selectedMarket = (Market)DataGridMarkets.SelectedItem;
            String googleUrl = "https://www.google.com/search?q=" + Cache.selectedMarket.exchangeId;
            Process.Start(new ProcessStartInfo
            {
                FileName = googleUrl,
                UseShellExecute = true
            });
        }
    }
}
