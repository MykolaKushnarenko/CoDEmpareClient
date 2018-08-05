using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using TextGUIModule;
using Newtonsoft.Json;
using System.Net;
using CoDEmpare.ObjectParamsSender;
using CoDEmpare.SenderObject;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for AddingSubmit.xaml
    /// </summary>
    public partial class AddingSubmit : UserControl
    {
        private Action<ResultCompareObject> _swichToResutl;
        private bool _search;
        private string _path;
        private ResultCompareObject _resultCompare;
        private List<string> _codeList;
        public AddingSubmit(Action<ResultCompareObject> methodResult, bool isSearch)
        {
            _swichToResutl = methodResult;
            _resultCompare = new ResultCompareObject();
            _codeList = new List<string>();
            _search = isSearch;
            InitializeComponent();
            PrintCompilName(CsharpLanguage.Content.ToString());
        }
        private string FileName => System.IO.Path.GetFileName(_path);
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            string name = button.Name;
            switch (name)
            {
                case "CsharpLanguage":
                    JavaLanguage.IsChecked = false;
                    CppLanguage.IsChecked = false;
                    CompilName.Items.Clear();
                    PrintCompilName(CsharpLanguage.Content.ToString());
                    break;
                case "JavaLanguage":
                    CsharpLanguage.IsChecked = false;
                    CppLanguage.IsChecked = false;
                    CompilName.Items.Clear();
                    PrintCompilName(JavaLanguage.Content.ToString());
                    break;
                case "CppLanguage":
                    CsharpLanguage.IsChecked = false;
                    JavaLanguage.IsChecked = false;
                    CompilName.Items.Clear();
                    PrintCompilName(CppLanguage.Content.ToString());
                    break;
            }
        }

        private async void PrintCompilName(string lang)
        {
            DataExchangeWithServer getCompilName = new DataExchangeWithServer("GetComipeType", "POST", $"lang={lang}", "application/x-www-form-urlencoded",true);
            string result = await getCompilName.SendToServer();
            if (result == null) return;
            List<string> typeCompl = JsonConvert.DeserializeObject<List<string>>(result);
            foreach (var typeCompil in typeCompl)
            {
                CompilName.Items.Add(typeCompil);
            }

        }
        private void AddFile_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = "Исходные коды(*.cs;*.java;*.cpp;*.c)|*.cs;*.java;*.cpp;*.c" + "|Все файлы (*.*)|*.* ",
                CheckFileExists = true,
                Multiselect = true
            };
            if (myDialog.ShowDialog() == true)
            {
                _path = myDialog.FileName;
            }

            if (_path != "" && CompilName.SelectedIndex > -1)
            {

                LoadFileToBD.Visibility = Visibility.Visible;
            }
        }

        private  void LoadFileToBD_OnClick(object sender, RoutedEventArgs e)
        {
            string typeCompiler = (string)CompilName.SelectedItem;
            string lang = "";
            if (CsharpLanguage.IsChecked == true)
            {
                lang = (string)CsharpLanguage.Content;
            }
            else if (CppLanguage.IsChecked == true)
            {
                lang = (string)CppLanguage.Content;
            }
            else if (JavaLanguage.IsChecked == true)
            {
                lang = (string)JavaLanguage.Content;
            }
            LoadWindow load = new LoadWindow(NameAuthor.Text, Description.Text, typeCompiler, _search, GetCode(), FileName, ref _resultCompare, CompareMy.IsChecked ?? true);
            load.ShowDialog();
            if (_search && !(CompareMy.IsChecked ?? true))
            {
                _swichToResutl(_resultCompare);
            }
            else if (_search && (CompareMy.IsChecked ?? true))
            {
                LoadAlgorithmReflection myAlgorithmReflection = new LoadAlgorithmReflection(_resultCompare);
                myAlgorithmReflection.LocalCompareRun();
                _swichToResutl(_resultCompare);
            }
            else
            {
                CsharpLanguage.IsChecked = true;
                NameAuthor.Text = "Имя и Фамилия";
                Description.Text = "Краткое описание";
            }
        }

        private byte[] GetCode()
        {
            StreamReader file = new StreamReader(_path);
            byte[] code = file.CurrentEncoding.GetBytes(file.ReadToEnd());
            return code;
        }
    }
}
