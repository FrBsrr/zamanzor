using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using zamanzor.Models;
using zamanzor.ViewModels;

namespace zamanzor.Commands
{
    public class SellCommand : CommandBase
    {
        private readonly SellViewModel _sellViewModel;

        public SellCommand(SellViewModel sellViewModel)
        {
            _sellViewModel = sellViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            if (User.sell_perm ==false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        public override void Execute(object? parameter)
        {
            
        }

    }
}
