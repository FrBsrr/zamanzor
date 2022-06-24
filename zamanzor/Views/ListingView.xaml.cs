using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using zamanzor.Models;
using zamanzor.Services;
using zamanzor.ViewModels;

namespace zamanzor.Views
{
    /// <summary>
    /// Interaction logic for ListingView.xaml
    /// </summary>
    public partial class ListingView : UserControl
    {

        public void uruncek()
        {
            Populate olustur = new Populate();


            //MySqlConnection conn = new MySqlConnection("Server=192.168.1.3; Database=zamanzor;Uid=root1;Pwd=root;");
            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM products", conn);
            DataTable data = new DataTable();
            adapter.Fill(data);

            conn.Close();

            if (data.Rows != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    vrapPanel.Children.Add(olustur.populate(row["id"].ToString(),
                                                            row["product_name"].ToString(),
                                                            row["product_desc"].ToString(),
                                                            row["price"].ToString(),
                                                            row["picloc"].ToString()));
                }
            }
        }

        public void uruncek(string kategori)
        {
            Populate olustur = new Populate();


            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();


            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE category_id=@category", conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@category", kategori);




            DataTable data = new DataTable();
            adapter.Fill(data);

            conn.Close();

            if (data.Rows != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    vrapPanel.Children.Add(olustur.populate(row["id"].ToString(),
                                                            row["product_name"].ToString(),
                                                            row["product_desc"].ToString(),
                                                            row["price"].ToString(),
                                                            row["picloc"].ToString()));
                }
            }
        }

        public void uruncek(string aramatext, int a)
        {
            Populate olustur = new Populate();


            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();


            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE product_name LIKE @aramatext OR product_desc LIKE @aramatext", conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@aramatext", "%" + aramatext + "%");




            DataTable data = new DataTable();
            adapter.Fill(data);

            conn.Close();

            if (data.Rows != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    vrapPanel.Children.Add(olustur.populate(row["id"].ToString(),
                                                            row["product_name"].ToString(),
                                                            row["product_desc"].ToString(),
                                                            row["price"].ToString(),
                                                            row["picloc"].ToString()));
                }
            }
        }
        public ListingView()
        {
            InitializeComponent();

            uruncek();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();

            uruncek("1");


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();

            uruncek("2");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();

            uruncek("3");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();

            uruncek("4");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();

            uruncek("5");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();

            uruncek("6");
        }

        private void LoadPage_Click(object sender, RoutedEventArgs e)
        {
            vrapPanel.Children.Clear();
            uruncek();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string arama = bar.Text;
            vrapPanel.Children.Clear();
            uruncek(arama, 1);
            bar.Text = "";



        }
    }
}
