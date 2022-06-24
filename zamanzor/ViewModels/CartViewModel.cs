using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using zamanzor.Commands;
using zamanzor.Services;

namespace zamanzor.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public string filename;
        public ICommand HomeCommand
        {
            get;
        }

        public ICommand SendShipping { get; }

        public CartViewModel(Services.NavigationService homeViewNavigationService)
        {
            HomeCommand = new NavigateCommand(homeViewNavigationService);
        }
    }
}
