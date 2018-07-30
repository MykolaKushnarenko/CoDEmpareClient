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
using CoDEmpare.SenderObject;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for ChangeUserInfo.xaml
    /// </summary>
    public partial class ChangeUserInfo : UserControl
    {
        private readonly Action<BitmapImage> _changeProfilImage;
        private readonly string _nameUser;
        public ChangeUserInfo(string name, Action<BitmapImage> method)
        {
            _changeProfilImage = method;
            _nameUser = name;
            InitializeComponent();
        }

        private async void ImageLoad_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog imageDialog = new OpenFileDialog()
            {
                Filter = "Image/photo (*.jpg;*.bnp;*.ico;*.img)|*.jpg;*.bnp;*.ico;*.img" + "|Все файлы (*.*)|*.* ",
                CheckFileExists = true,
                Multiselect = false
            };
            if (imageDialog.ShowDialog() == true)
            {
                byte[] data = File.ReadAllBytes(imageDialog.FileName);
                DataExchangeWithServer updateImage = new DataExchangeWithServer("ChangeUserImage", "POST", $"sendImage={JsonConvert.SerializeObject(data)}&name={_nameUser}", "application/x-www-form-urlencoded", true);
                string result = await updateImage.SendToServer();
                if (result == null) return;
                MemoryStream read = new MemoryStream(data);
                BitmapImage enterImage = new BitmapImage();
                enterImage.BeginInit();
                enterImage.CacheOption = BitmapCacheOption.OnLoad;
                enterImage.StreamSource = read;
                enterImage.EndInit();
                _changeProfilImage(enterImage);
            }
            
        }
    }
}
