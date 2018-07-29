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
using Microsoft.Win32;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for ChangeUserInfo.xaml
    /// </summary>
    public partial class ChangeUserInfo : UserControl
    {
        public ChangeUserInfo()
        {
            InitializeComponent();
        }

        private void ImageLoad_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog imageDialog = new OpenFileDialog()
            {
                Filter = "Image/photo (*.jpg;*.bnp;*.ico;*.img)|*.jpg;*.bnp;*.ico;*.img" + "|Все файлы (*.*)|*.* ",
                CheckFileExists = true,
                Multiselect = false
            };
            if (imageDialog.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imageDialog.FileName, UriKind.Relative);
                bitmapImage.EndInit();
                UserPhoto.Source = new BitmapImage(new Uri(imageDialog.FileName));
            }
            
        }
    }
}
