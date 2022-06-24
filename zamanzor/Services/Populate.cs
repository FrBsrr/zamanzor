using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using zamanzor.Models;

namespace zamanzor.Services
{
    public class Populate
    {

        public WrapPanel populate(string id, string urun_adi,string urun_desc,string price,string konum)
        {

            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Background = Brushes.White;
            wrapPanel.Orientation = Orientation.Horizontal;
            wrapPanel.Height = 200;
            wrapPanel.Width = 780;
            wrapPanel.MaxHeight = 200;  
            Thickness margin;

            TextBlock aydi = new TextBlock();
            aydi.Visibility = Visibility.Hidden;
            aydi.Text = id;

            margin.Bottom = 40;
            margin.Right = 20;

            Thickness margintext;
            margintext.Bottom = 25;
            wrapPanel.Margin = margin;

            Thickness marginimage;
            marginimage.Right = 10;

            Thickness marginbuton;
            marginbuton.Top = 25;

            WrapPanel wrapPanel1 = new WrapPanel();
            wrapPanel1.Orientation = Orientation.Vertical;
            wrapPanel1.Height = 200;
            wrapPanel1.Width = 494;
            wrapPanel1.MinWidth = 494;
         
            Image urun = new Image();
            urun.Height = 200;
            urun.Width = 200;
            urun.Margin = marginimage;
            urun.Stretch= System.Windows.Media.Stretch.Fill;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            urun.Source = new BitmapImage(new Uri(projectDirectory+ @"\SourceImages\"+konum));

            TextBlock urunad = new TextBlock();
            urunad.Text=urun_adi;
            urunad.Foreground = Brushes.Magenta;
            urunad.FontSize = 22;
            urunad.Margin = margintext;

            TextBlock urundesc = new TextBlock();
            urundesc.Text = urun_desc;
            urundesc.FontSize = 16;
            urundesc.Margin = margintext;

            urunad.FontWeight= FontWeights.Bold;
           

            TextBlock fiyat = new TextBlock();
            fiyat.Text = price+ "₺";
            fiyat.FontSize = 14;
            fiyat.Foreground = Brushes.MediumTurquoise;
            fiyat.FontWeight = FontWeights.Bold;

            Button sepetbuton = new Button();
            sepetbuton.HorizontalAlignment = HorizontalAlignment.Left;
            sepetbuton.Height = 20;
            sepetbuton.Margin = marginbuton;
            sepetbuton.Content = "Sepete ekle";

            sepetbuton.Click += (ss, ee) => { Cart.shoppingcart.Add(aydi.Text); };               

            wrapPanel.Children.Add(urun);
            wrapPanel.Children.Add(wrapPanel1);
            wrapPanel.Children.Add(aydi);

            wrapPanel1.Children.Add(urunad);
            wrapPanel1.Children.Add(urundesc);

            wrapPanel1.Children.Add(fiyat);
            wrapPanel1.Children.Add(sepetbuton);


            return wrapPanel;

        }

        public WrapPanel populate(string urun_adi, string price, string konum)
        {

            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Background = Brushes.White;
            wrapPanel.Orientation = Orientation.Horizontal;
            wrapPanel.Height = 200;
            wrapPanel.Width = 780;
            wrapPanel.MaxHeight = 200;
            Thickness margin;

            

            margin.Bottom = 40;
            margin.Right = 20;

            Thickness margintext;
            margintext.Bottom = 25;
            wrapPanel.Margin = margin;

            Thickness marginimage;
            marginimage.Right = 10;

            WrapPanel wrapPanel1 = new WrapPanel();
            wrapPanel1.Orientation = Orientation.Vertical;
            wrapPanel1.Height = 200;

            Image urun = new Image();
            urun.Height = 200;
            urun.Width = 200;
            urun.Margin = marginimage;
            urun.Stretch = System.Windows.Media.Stretch.Fill;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            urun.Source = new BitmapImage(new Uri(projectDirectory + @"\SourceImages\" + konum));

            TextBlock urunad = new TextBlock();
            urunad.Text = urun_adi;
            urunad.Foreground = Brushes.Magenta;
            urunad.FontSize = 22;
            urunad.Margin = margintext;

            urunad.FontWeight = FontWeights.Bold;


            TextBlock fiyat = new TextBlock();
            fiyat.Text = price + "₺";
            fiyat.FontSize = 14;
            fiyat.Foreground = Brushes.MediumTurquoise;
            fiyat.FontWeight = FontWeights.Bold;

            wrapPanel.Children.Add(urun);
            wrapPanel.Children.Add(wrapPanel1);
            wrapPanel1.Children.Add(urunad);
            wrapPanel1.Children.Add(fiyat);
      




            return wrapPanel;

        }
    }
}
