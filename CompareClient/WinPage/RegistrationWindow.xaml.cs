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
using CoDEmpare.ObjectParamsSender;
using CoDEmpare.SenderObject;
using Newtonsoft.Json;
using TextGUIModule;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private async void SinglUp_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (Password.Password == PasswordSecond.Password && Password.Password.Replace(" ", "") != ""
                && Name.Text.Replace(" ", "") != "" && Email.Text.Replace(" ", "") != "")
            {
                
                RegistrationObject sendParams = new RegistrationObject()
                {
                    Name = Name.Text,
                    EMail = Email.Text,
                    Password = Password.Password
                };

                DataExchangeWithServer registrationSend = new DataExchangeWithServer("Registration", "POST", JsonConvert.SerializeObject(sendParams), "application/json", true);
                string result = await registrationSend.SendToServer();
                if (result == null) return;
                MessageBox.Show("OK!", "Result");
                this.Close();
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
