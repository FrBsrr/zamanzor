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
    public class SellViewModel : ViewModelBase
    {
        public string filename;
        public ICommand HomeCommand
        {
            get;
        }

        public ICommand AddItemCommand { get; }

        public ICommand ChooseFile { get; }
        

        public SellViewModel(Services.NavigationService homeViewNavigationService)
        {
            HomeCommand = new NavigateCommand(homeViewNavigationService);
            AddItemCommand = new SellCommand(this);
            
        }
    }
}
