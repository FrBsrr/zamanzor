using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using zamanzor.Commands;
using zamanzor.Models;

namespace zamanzor.ViewModels
{
    public class ListingViewModel : ViewModelBase
    {

        private string _kaydol_Visiblity;
        public string Kaydol_Visibility
        {
            get { return _kaydol_Visiblity; }
            set
            {
                _kaydol_Visiblity = value;
                OnPropertyChanged("Giris_Visibility");
            }
        }
        private string _user_Visiblity = "Hidden";
        public string User_Visibility
        {
            get { return _user_Visiblity; }
            set
            {
                _user_Visiblity = value;
                OnPropertyChanged("Kaydol_Visibility");
            }
        }

        private string _sell_Visiblity = "Hidden";
        public string Sell_Visibility
        {
            get { return _sell_Visiblity; }
            set
            {
                _sell_Visiblity = value;
                OnPropertyChanged("Sell_Visibility");
            }
        }

        private string _name;


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ICommand RegisterCommand
        {
            get;
        }

        public ICommand LoginCommand
        {
            get;
        }
        public ICommand SellCommand
        {
            get;
        }

        public ICommand CartCommand
        {
            get;
        }
        public ListingViewModel(Services.NavigationService loginViewNavigationService, Services.NavigationService registerViewNavigationService, Services.NavigationService sellViewNavigationService, Services.NavigationService cartViewNavigationService)
        {
            RegisterCommand = new NavigateCommand(registerViewNavigationService);
            LoginCommand = new NavigateCommand(loginViewNavigationService);
            SellCommand = new NavigateCommand(sellViewNavigationService);
            CartCommand = new NavigateCommand(cartViewNavigationService);
            if(User.LoginSuccess==true)
            {
                Kaydol_Visibility = "Hidden";
                User_Visibility = "Visible";
                
                Name = User._firstname;
            }
            if(User.sell_perm==true)
            {
                Sell_Visibility = "Visible";
            }
        }

        
    }
}
