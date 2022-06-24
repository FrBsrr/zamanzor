using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zamanzor.Models;
using zamanzor.ViewModels;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;
using zamanzor.Services;

namespace zamanzor.Commands
{
    public class EnterLoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationService _listingViewNavigationService;


        public override bool CanExecute(object parameter)
        {
            return !User.LoginSuccess;
        }
        public EnterLoginCommand(LoginViewModel loginViewModel, NavigationService listingViewNavigationService)
        {
            _loginViewModel = loginViewModel;
            _listingViewNavigationService = listingViewNavigationService;
        }



        private bool _loginsuccess;

        public bool LoginSuccess
        {
            get { return _loginsuccess; }
            set { _loginsuccess = value; }
        }


        public override void Execute(object? parameter)
        {
            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();
            string Query = "SELECT* FROM users WHERE username = @username AND password = @password";
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            Login giris = new Login(_loginViewModel.Username, _loginViewModel.Password);

            cmd.Parameters.AddWithValue("@username", giris.username);
            cmd.Parameters.AddWithValue("@password", giris.password);

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read() == true)
            {
                User.LoginSuccess = true;

                User._userid = reader["id"].ToString();
                User._firstname = reader["first_name"].ToString();
                User._lastname = reader["last_name"].ToString();
                User._username = reader["username"].ToString();
                User._telephone = reader["telephone"].ToString();
                User.sell_perm = Convert.ToBoolean(reader["sell_perm"].ToString());

                MessageBox.Show("Giriş Başarılı");
                _listingViewNavigationService.Navigate();
            }
            else
            {
                User.LoginSuccess = false;
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!");
            }



            conn.Close();

        }
    }
}
