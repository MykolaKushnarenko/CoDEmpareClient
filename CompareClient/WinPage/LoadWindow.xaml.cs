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

            WebRequest request = WebRequest.Create("http://localhost:50373/Home/AddCode");
            request.Method = "POST";
            AddingCodeObject sendParams = new AddingCodeObject()
            {
                Name = _name,
                Description = _description,
                CompileType = _typeCompile,
                IsSearch = _isSearch,
                FileMane = _fileName,
                Code = _code
            };
            string s = JsonConvert.SerializeObject(sendParams);
            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sendParams));
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            using (Stream stream = await request.GetRequestStreamAsync())
            {
                await stream.WriteAsync(data, 0, data.Length);
            }


            string getAnswer = await Task.Run(() =>
            {
                string res;
                using (WebResponse responses = (WebResponse) request.GetResponse())
                {
                    using (var reader = new StreamReader(responses.GetResponseStream()))
                    {
                        res = reader.ReadToEnd();
                    }
                }

                return res;
            });
           

            List<string> resultFromServer = JsonConvert.DeserializeObject<List<string>>(getAnswer);
            FillTheListBackResult(resultFromServer);
            //AddingSubmit(l, _description, _typeCompile, _path, _isSearch);
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
