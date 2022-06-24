using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
using zamanzor.Services;

namespace zamanzor.Views
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : UserControl
    {

        public string filename;
        public string prod_name;
        public string prod_desc;
        public int prod_price;
        public int kategori;

        public ICommand HomeCommand
        {
            get;
        }
        public SellView()
        {
            InitializeComponent();
            prodname.MaxLength = 40;


        }



        private void filebutton_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png";

    
            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
            
                filename = dlg.FileName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sourcefile = filename;
            Random rand = new Random();
            string abc = Convert.ToString(rand.Next(100000)) + ".png";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string destfile = projectDirectory + @"\SourceImages\" + abc;
            System.IO.File.Copy(sourcefile, destfile, true);

            prod_name = prodname.Text;
            prod_desc = proddesc.Text;
            if (kombobox.Text == "Elektronik") { kategori = 1; }
            else if (kombobox.Text == "Sağlık") { kategori = 2; }
            else if (kombobox.Text == "Müzik") { kategori = 3; }
            else if (kombobox.Text == "Beyaz Eşya") { kategori = 4; }
            else if (kombobox.Text == "Kitap") { kategori = 5; }
            else if (kombobox.Text == "Giyim") { kategori = 6; }

            prod_price = Convert.ToInt32(prodprice.Text);

            DBConnectionService bag = new DBConnectionService();
            MySqlConnection conn = bag._connection;

            conn.Open();
            string Query = @"INSERT INTO zamanzor.products(product_name,product_desc,price,category_id,picloc)
                             VALUES (@product_name,@product_desc,@price,@category_id,@picloc)";

            MySqlCommand cmd = new MySqlCommand(Query, conn);

            cmd = new MySqlCommand(Query, conn);


            cmd.Parameters.AddWithValue("@product_name", prod_name);
            cmd.Parameters.AddWithValue("@product_desc", prod_desc);
            cmd.Parameters.AddWithValue("@price", prod_price);
            cmd.Parameters.AddWithValue("@category_id", kategori);
            cmd.Parameters.AddWithValue("@picloc", abc);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Ekleme Başarılı");
            conn.Close();

        }
    }
}
