using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using zamanzor.Models;
using zamanzor.Services;
using zamanzor.Stores;
using zamanzor.ViewModels;

namespace zamanzor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(new NavigationService(_navigationStore, CreateRegisterViewModel), new NavigationService(_navigationStore, CreateListingViewModel));
        }

        private RegisterViewModel CreateRegisterViewModel()
        {
            return new RegisterViewModel(new NavigationService(_navigationStore, CreateLoginViewModel), new NavigationService(_navigationStore, CreateListingViewModel));

        }

        private SellViewModel CreateSellViewModel()
        {
            return new SellViewModel(new NavigationService(_navigationStore, CreateListingViewModel));

        }
        private CartViewModel CreateCartViewModel()
        {
            return new CartViewModel(new NavigationService(_navigationStore, CreateListingViewModel));

        }

        private ListingViewModel CreateListingViewModel()
        {
            return new ListingViewModel(new NavigationService(_navigationStore, CreateLoginViewModel), new NavigationService(_navigationStore, CreateRegisterViewModel), new NavigationService(_navigationStore, CreateSellViewModel), new NavigationService(_navigationStore, CreateCartViewModel));
        }
    }
}
