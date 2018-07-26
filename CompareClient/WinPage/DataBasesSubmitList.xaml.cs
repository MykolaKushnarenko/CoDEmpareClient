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
using TextGUIModule;
using System.Net;
using CoDEmpare.SenderObject;
using Newtonsoft.Json;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for DataBasesSubmitList.xaml
    /// </summary>
    public partial class DataBasesSubmitList : UserControl
    {
        public Action<List<string>> _resultMethod;

        public DataBasesSubmitList(Action<List<string>> method)
        {
            _resultMethod = method;
            InitializeComponent();
            LoadListSubmit();
        }

        private async void LoadListSubmit()
        {
            DataExchangeWithServer getAllSubmit = new DataExchangeWithServer("GetListSubmit", "GET", "", "application/json", true);
            string result = await getAllSubmit.SendToServer();
            if (result == null) return;
            List<string> listSubm = JsonConvert.DeserializeObject<List<string>>(result);
            foreach (string submit in listSubm)
            {
                SubmitList.Items.Add(submit);
            }
        }

        private async void SubmitList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wordFromItemsList = SubmitList.SelectedValue.ToString();
            string[] get = wordFromItemsList?.Split(new char[] { '|' });
            DataExchangeWithServer getResultCompareFromSubmitList = new DataExchangeWithServer("SearchFromListSubmit", "POST", $"tagForSearch={get[get.Length - 1]}", "application/x-www-form-urlencoded", true);
            string result = await getResultCompareFromSubmitList.SendToServer();
            if (result == null) return;
            _resultMethod(JsonConvert.DeserializeObject<List<string>>(result));


        }
    }
}
