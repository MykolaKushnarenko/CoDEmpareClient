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
using System.Windows.Shapes;
using CoDEmpare.SenderObject;
using Newtonsoft.Json;
using System.Drawing;
using TextGUIModule;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private Action visibleMainWindow;
        private Action _closeProgram;
        private Action<string> _nameUserGet;
        private Action<ImageSource> _setProfilImage;
        public AuthorizationWindow(Action method, Action closeMethod, Action<string> enterName, Action<ImageSource> methodToSetProfilImage)
        {

            InitializeComponent();
            visibleMainWindow += method;
            _closeProgram += closeMethod;
            _nameUserGet += enterName;
            _setProfilImage += methodToSetProfilImage;
        }

        private void SkipButton_OnClick(object sender, RoutedEventArgs e)
        {
            visibleMainWindow();
            this.Close();
        }

        private void SinglInButtn_OnClick(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().ShowDialog();
        }

        private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            List<object> isComplite;
            DataExchangeWithServer authorization = new DataExchangeWithServer("Autification", "POST", $"login={Email.Text}&password={Password.Password}", "application/x-www-form-urlencoded", true);
            string result = await authorization.SendToServer();
            if (result == null) return;
            isComplite = JsonConvert.DeserializeObject<List<object>>(result);
            if ((bool)isComplite[0] == true)
            {
                _nameUserGet((string)isComplite[1]);
                ConvertToImage(JsonConvert.DeserializeObject<byte[]>((string)isComplite[2]));
                visibleMainWindow();
                this.Close();
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }
        }

        private void ConvertToImage(byte[] data)
        {
            if (data.Length != 0)
            {
                MemoryStream read = new MemoryStream(data);
                BitmapImage image = new BitmapImage();
                read.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = read;
                image.EndInit();
                ImageSource imageSource = image as ImageSource;
                _setProfilImage(imageSource);
            }
            

            
        }
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _closeProgram();
            this.Close();
        }
    }
}
