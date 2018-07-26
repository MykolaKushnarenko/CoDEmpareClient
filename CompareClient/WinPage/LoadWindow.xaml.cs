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
using TextGUIModule;
using System.Net;
using CoDEmpare.SenderObject;
using Newtonsoft.Json;
namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private readonly string _name;
        private readonly string _description;
        private readonly string _typeCompile;
        private readonly string _path;
        private readonly bool _isSearch;
        private readonly byte[] _code;
        private readonly string _fileName;
        private List<string> _result;
        public LoadWindow(string name, string description, string type, bool isSearch, byte[] code, string Filename, ref List<string> result)
        {
            InitializeComponent();
            _name = name;
            _code = code;
            _fileName = Filename;
            _description = description;
            _result = result;
            _typeCompile = type;
            _isSearch = isSearch;
            _result = result;
            Load();
        }

        private async void Load()
        {
            AddingCodeObject sendParams = new AddingCodeObject()
            {
                Name = _name,
                Description = _description,
                CompileType = _typeCompile,
                IsSearch = _isSearch,
                FileMane = _fileName,
                Code = _code
            };
            DataExchangeWithServer getCompilName = new DataExchangeWithServer("AddCode", "POST", JsonConvert.SerializeObject(sendParams), "application/json", true);
            string result = await getCompilName.SendToServer();
            List<string> resultFromServer = JsonConvert.DeserializeObject<List<string>>(result);
            FillTheListBackResult(resultFromServer);
            this.Close();
        }

        private void FillTheListBackResult(List<string> listFromServer)
        {
            foreach (string line in listFromServer)
            {
                _result.Add(line);
            }
        }
    }
}
