using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using zamanzor.Models;
using zamanzor.Services;

namespace zamanzor.Views
{
    /// <summary>
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : UserControl
    {
        private int _toplam;

       
        public CartView()
        {
            InitializeComponent();

            Populate olustur = new Populate();

            

            MySqlConnection conn = new MySqlConnection("Server=192.168.1.3; Database=zamanzor;Uid=root1;Pwd=root;");

            conn.Open();

            

            foreach(string a in Cart.shoppingcart)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE id=@id", conn);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@id", a);

                DataTable data = new DataTable();
                adapter.Fill(data);

                if (data.Rows != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        vrapPanel.Children.Add(olustur.populate(row["product_name"].ToString(),
                                                                row["price"].ToString(),
                                                                row["picloc"].ToString()));

                        _toplam += Convert.ToInt32(row["price"].ToString());
                        Toplam.Text = _toplam.ToString()+ "₺";
                    }
                }
            }


            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM countries", conn);
            cmd1.CommandType = CommandType.Text;
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);

            DataTable data1 = new DataTable();
            adapter1.Fill(data1);

            if (data1.Rows != null)
            {
                foreach (DataRow row1 in data1.Rows)
                {
                    ulkebox.Items.Add(row1["country"].ToString());
                }
            }

            conn.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ulke = ulkebox.SelectedItem.ToString();
            sehirbox.Items.Clear();

            MySqlConnection conn = new MySqlConnection("Server=192.168.1.3; Database=zamanzor;Uid=root1;Pwd=root;");

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM countries where country=@country", conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@country", ulke);

            DataTable data = new DataTable();
            adapter.Fill(data);

            string aydi = data.Rows[0].ItemArray[0].ToString();

            data.Dispose();

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM cities where country_id=@country_id", conn);
            cmd1.CommandType = CommandType.Text;
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            cmd1.Parameters.AddWithValue("@country_id", aydi);

           
            DataTable data1 = new DataTable();
            adapter1.Fill(data1);

            if (data1.Rows != null)
            {
                foreach (DataRow row1 in data1.Rows)
                {
                    sehirbox.Items.Add(row1["city"].ToString());
                }
            }
            conn.Close();

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string sehir = sehirbox.SelectedItem.ToString();

            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cities where city=@city", conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@city", sehir);

            DataTable data = new DataTable();
            adapter.Fill(data);

            string aydi = data.Rows[0].ItemArray[0].ToString();

            data.Dispose();

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM towns WHERE city_id=@city_id", conn);
            cmd1.CommandType = CommandType.Text;
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            cmd1.Parameters.AddWithValue("@city_id", aydi);


            DataTable data1 = new DataTable();
            adapter1.Fill(data1);

            if (data1.Rows != null)
            {
                foreach (DataRow row1 in data1.Rows)
                {
                    ilcebox.Items.Add(row1["town"].ToString());
                }
            }
            conn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(User.LoginSuccess==true)
            {
                DBConnectionService bag = new DBConnectionService();
                MySqlConnection conn = bag._connection;

                conn.Open();

                string products = "";

                foreach(string id in Cart.shoppingcart)
                {
                    products += id + ",";
                }

                string Query = @"INSERT INTO zamanzor.shippings(user_id,product_list,total_payment,country,city,town,address_line,zipcode)
                                 VALUES (@user_id,@product_list,@total_payment,@country,@city,@town,@address_line,@zipcode)";
                
                MySqlCommand cmd = new MySqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@user_id", User._userid);
                cmd.Parameters.AddWithValue("@product_list", products);
                cmd.Parameters.AddWithValue("@total_payment", _toplam);
                cmd.Parameters.AddWithValue("@country", ulkebox.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@city", sehirbox.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@town", ilcebox.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@address_line", addressbox.Text);
                cmd.Parameters.AddWithValue("@zipcode", zipcodebox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sipariş oluşturuldu");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Lütfen önce giriş yapınız...");
            }
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("\\D");
            e.Handled = regex.IsMatch(e.Text);

            zipcodebox.MaxLength = 20;
        }
    }
}
