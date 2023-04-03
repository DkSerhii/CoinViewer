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
        public event System.EventHandler coinsToShowChanged;

        protected virtual void OnCoinsToShowChanged()
        {
            if (coinsToShowChanged != null) coinsToShowChanged(this, EventArgs.Empty);
        }

        public HomeView()
        {
            InitializeComponent();

            String endpoint = CalloutService.endpointBuilder(CalloutService.DEFAULT_SEARCH);

            string calloutResult = CalloutService.GetAsyncProperty(endpoint);

            JsonParser.parseCoins(calloutResult);

            DataGridCoins.ItemsSource = Cache.coinsToShow;


        }
    }
}
