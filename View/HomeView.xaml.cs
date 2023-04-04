using CoinViewer.DataModel;
using CoinViewer.Services;
using CoinViewer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            String endpoint = CalloutService.endpointBuilder(CalloutService.DEFAULT_SEARCH);

            initializeGrid(endpoint);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Cache.isSearhing = true;
                Cache.searchValue = textBoxSearch.Text;

                String endpoint = CalloutService.endpointBuilder(
                    CalloutService.USER_SEARCH + Cache.searchValue);

                initializeGrid(endpoint);
            }
        }

        private void textBoxSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBoxSearch.Text = string.Empty;
        }

        private void initializeGrid(String endpoint)
        {

            string calloutResult = CalloutService.GetAsyncProperty(endpoint);

            if (Cache.isCallotSucces)
            {
                JsonParser.parseCoins(calloutResult);

                DataGridCoins.ItemsSource = Cache.coinsToShow;
            }
        }
    }
}
