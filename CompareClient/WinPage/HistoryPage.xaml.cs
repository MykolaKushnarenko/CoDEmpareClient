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
using CoDEmpare.SenderObject;
using Newtonsoft.Json;
using TextGUIModule;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : UserControl
    {
        public HistoryPage()
        {
            InitializeComponent();
            UpdateHistoryList();
        }

        private async void UpdateHistoryList()
        {
            DataExchangeWithServer getHistory = new DataExchangeWithServer("GetListHistory", "GET", "", "application/json", true);
            string result = await getHistory.SendToServer();
            if (result == null) return;
            List<string> listHistory = JsonConvert.DeserializeObject<List<string>>(result);
            FileListCompil.Items.Clear();
            foreach (var desc in listHistory)
            {
                FileListCompil.Items.Add(desc);
            }
        }
    }
}
