using CoinViewer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinViewer.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DetailsViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DetailsViewModel DetailsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DetailsVM = new DetailsViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            DetailsViewCommand = new RelayCommand(o =>
            {
                CurrentView = DetailsVM;
            });
        }
    }
}
