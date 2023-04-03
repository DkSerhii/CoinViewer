using CoinViewer.DataModel;
using CoinViewer.Services;
using CoinViewer.Utilities;
using CoinViewer.View;
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

namespace CoinViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                Cache.isSearhing = true;
                Cache.searchValue = textBoxSearch.Text;

                String endpoint = CalloutService.endpointBuilder(
                    CalloutService.USER_SEARCH + Cache.searchValue);

                string calloutResult = CalloutService.GetAsyncProperty(endpoint);

                JsonParser.parseCoins(calloutResult);
            }
        }

        private void textBoxSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBoxSearch.Text = string.Empty;
        }
    }
}
