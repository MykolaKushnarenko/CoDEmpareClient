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
        public AuthorizationWindow(Action method)
        {
            InitializeComponent();
            visibleMainWindow += method;
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
            bool isComplite;
            DataExchangeWithServer authorization = new DataExchangeWithServer("Autification", "POST", $"login={Email.Text}&password={Password.Password}", "application/x-www-form-urlencoded", true);
            string result = await authorization.SendToServer();
            if (result == null) return;
            isComplite = JsonConvert.DeserializeObject<bool>(result);
            if (isComplite == true)
            {
                visibleMainWindow();
                this.Close();
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }
        }
    }
}
