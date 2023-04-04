using CoinViewer.Services;
using CoinViewer.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoinViewer.View
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            if (!Cache.isDataLoaded)
            {
                String endpoint = CalloutService.endpointBuilder(CalloutService.DEFAULT_SEARCH);

                initializeGrid(endpoint);
                Cache.isDataLoaded = true;
            }
            else if (Cache.isDataLoaded) 
            {
                DataGridCoins.ItemsSource = Cache.coinsToShow;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && textBoxSearch.Text.Length > 0)
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

        private void DataGridCoins_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Cache.selectedCoin = (DataModel.CryptoCoin)DataGridCoins.SelectedItem;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Cache.isSearhing = false;

            String endpoint = CalloutService.endpointBuilder(CalloutService.DEFAULT_SEARCH);

            initializeGrid(endpoint);

            DataGridCoins.ItemsSource = Cache.coinsToShow;

            MessageBox.Show("Data updated!");
        }
    }
}
