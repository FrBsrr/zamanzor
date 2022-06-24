using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using zamanzor.Commands;
using zamanzor.Models;
using System.Text.RegularExpressions;
using zamanzor.Stores;

namespace zamanzor.ViewModels
{
    public class RegisterViewModel : ViewModelBase
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



        //private string _password;

        //public string Password
        //{
        //    get
        //    {
        //        return _password;
        //    }
        //    set
        //    {
        //        _password = value;
        //        OnPropertyChanged(nameof(Password));
        //    }
        //}

        public string Password { get; set; }

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

        private string _surname;

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string _telno;

        public string Telno
        {
            get
            {
                return _telno;
            }
            set
            {
                _telno = value;
                OnPropertyChanged(nameof(Telno));
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

        public ICommand HomeCommand
        {
            get;
        }

        public RegisterViewModel(Services.NavigationService loginViewNavigationService, Services.NavigationService homeViewNavigationService)
        {
            RegisterCommand = new SubmitRegisterCommand(this, loginViewNavigationService);
            LoginCommand = new NavigateCommand(loginViewNavigationService);
            HomeCommand = new NavigateCommand(homeViewNavigationService);
        }
    }
}
