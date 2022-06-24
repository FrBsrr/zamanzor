using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using zamanzor.Commands;
using zamanzor.Stores;

namespace zamanzor.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password { get; set; }
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public ICommand HomeCommand { get; }

        public LoginViewModel(Services.NavigationService registerViewNavigationService, Services.NavigationService listingViewNavigationService)
        {
            LoginCommand = new EnterLoginCommand(this, listingViewNavigationService);
            RegisterCommand = new NavigateCommand(registerViewNavigationService);
            HomeCommand = new NavigateCommand(listingViewNavigationService);
        }
    }
}
