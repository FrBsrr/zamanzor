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
using System.Text.RegularExpressions;
using zamanzor.ViewModels;

namespace zamanzor.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("\\D");
            e.Handled = regex.IsMatch(e.Text);

            telefon.MaxLength = 11;
        }

        private void NoSpaceInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-z0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
