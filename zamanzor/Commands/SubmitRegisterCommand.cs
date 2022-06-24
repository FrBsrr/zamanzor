using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zamanzor.Models;
using zamanzor.ViewModels;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using zamanzor.Stores;
using zamanzor.Services;

namespace zamanzor.Commands
{
    public class SubmitRegisterCommand : CommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly NavigationService _loginViewNavigationService;

        public override bool CanExecute(object parameter)
        {
            return !User.LoginSuccess;
        }

        public SubmitRegisterCommand(RegisterViewModel registerViewModel, NavigationService loginViewNavigationService)
        {
            _registerViewModel = registerViewModel;
            _loginViewNavigationService = loginViewNavigationService;
        }


        public override void Execute(object? parameter)
        {
            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();
            string Query = "SELECT COUNT(1) FROM users WHERE username=@username";
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            DateTime naav = DateTime.Now;




            Register kayit = new Register(_registerViewModel.Username, _registerViewModel.Password, _registerViewModel.Name,
                _registerViewModel.Surname, _registerViewModel.Telno);

            cmd.Parameters.AddWithValue("@username", kayit.username);

            int deneme = Convert.ToInt32(cmd.ExecuteScalar());

            if (deneme == 0)
            {
                byte yetki = 0;
                Query = @"INSERT INTO zamanzor.users(username,password,first_name,last_name,telephone,created, sell_perm)
                          VALUES (@username,@password,@first_name,@last_name,@telephone,@created,@sell_perm)";
                cmd = new MySqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@username", kayit.username);
                cmd.Parameters.AddWithValue("@password", kayit.password);
                cmd.Parameters.AddWithValue("@first_name", kayit.name);
                cmd.Parameters.AddWithValue("@last_name", kayit.surname);
                cmd.Parameters.AddWithValue("@telephone", kayit.telno);
                cmd.Parameters.AddWithValue("@created", naav.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sell_perm",yetki);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
                conn.Close();

                _loginViewNavigationService.Navigate();


            }

            else
            {
                MessageBox.Show("Başka kullanıcı adı seçiniz.");
                conn.Close();
            }


        }
    }
}
