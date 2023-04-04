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
    public partial class DetailsView : UserControl
    {
        public DetailsView()
        {
            InitializeComponent();

            coin_name.Text = Cache.selectedCoin.name;

            coin_symbol.Text = Cache.selectedCoin.symbol;

            String convertedPrice = "";
            if (Cache.selectedCoin.priceUsd < 10)
            {
                convertedPrice = String.Format("{0:0.0000}", Cache.selectedCoin.priceUsd);
            }
            else
            {
                convertedPrice = String.Format("{0:0.00}", Cache.selectedCoin.priceUsd);
            }
            coin_priceUSD.Text = convertedPrice;

            String signType = "";
            if (Cache.selectedCoin.changePercent24Hr > 0)
            {
                signType = "+";
            }
            coin_change24H.Text = signType + String.Format("{0:0.00}", Cache.selectedCoin.changePercent24Hr) + "%";

            coin_rank.Text = String.Format("{0:0}", Cache.selectedCoin.rank);

            coin_supply.Text = String.Format("{0:0}", Cache.selectedCoin.supply);


            String maxSupply = "";
            if (Cache.selectedCoin.maxSupply != null)
            {
                maxSupply = coin_max_supply.Text = Cache.selectedCoin.maxSupply.Substring(0,
                Cache.selectedCoin.maxSupply.IndexOf("."));
            }
            coin_max_supply.Text = maxSupply;
        }
    }
}
