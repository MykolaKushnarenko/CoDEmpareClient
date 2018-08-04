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
using System.Runtime.InteropServices;
using CoDEmpare.ObjectParamsSender;
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
        //private List<string> _result;
        private ResultCompareObject _resultCompare;
        private readonly bool _compareLocal;
        public LoadWindow(string name, string description, string type, bool isSearch, byte[] code, string Filename, ref ResultCompareObject result, bool compareLocal)
        {
            InitializeComponent();
            _name = name;
            _code = code;
            _fileName = Filename;
            _description = description;
            _resultCompare = result;
            _typeCompile = type;
            _isSearch = isSearch;
            _compareLocal = compareLocal;
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
                Code = _code,
                CompareLocal = _compareLocal
                
            };
            DataExchangeWithServer getCompilName = new DataExchangeWithServer("AddCode", "POST", JsonConvert.SerializeObject(sendParams), "application/json", true);
            string result = await getCompilName.SendToServer();
            if (result == null) return;
            
            FillTheListBackResult(JsonConvert.DeserializeObject<ResultCompareObject>(result));
            this.Close();
        }

        private void FillTheListBackResult(ResultCompareObject resultFromSerrver)
        {
            _resultCompare.ChildCodeText = resultFromSerrver.ChildCodeText;
            _resultCompare.MainCodeText = resultFromSerrver.MainCodeText;
            _resultCompare.ResultCompare = resultFromSerrver.ResultCompare;
            _resultCompare.TokkingChildCode = resultFromSerrver.TokkingChildCode;
            _resultCompare.TokkingMainCode = resultFromSerrver.TokkingMainCode;
            _resultCompare.IsLocalCompare = resultFromSerrver.IsLocalCompare;
        }
    }
}
