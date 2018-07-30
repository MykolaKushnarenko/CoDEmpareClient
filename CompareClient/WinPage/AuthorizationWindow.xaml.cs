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
        private Action<BitmapImage> _setProfilImage;
        public AuthorizationWindow(Action method, Action closeMethod, Action<string> enterName, Action<BitmapImage> methodToSetProfilImage)
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
            MemoryStream read = new MemoryStream(data);
            BitmapImage enterImage = new BitmapImage();
            enterImage.BeginInit();
            enterImage.CacheOption = BitmapCacheOption.OnLoad;
            enterImage.StreamSource = read;
            enterImage.EndInit();
            _setProfilImage(enterImage);
        }
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _closeProgram();
            this.Close();
        }
    }
}
