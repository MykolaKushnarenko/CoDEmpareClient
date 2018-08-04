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
using CoDEmpare.ObjectParamsSender;

namespace CoDEmpare.WinPage
{
    /// <summary>
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : UserControl
    {
        private readonly string _mainCode;
        private readonly string _chaildCode;
        private readonly ResultCompareObject _resultFromServer;
        public ResultPage(ResultCompareObject resultFromServer)
        {
            _resultFromServer = resultFromServer;
            _mainCode = _resultFromServer.MainCodeText;
            _chaildCode = _resultFromServer.ChildCodeText;
            InitializeComponent();
            SetTextBoxes();
            Compare();
        }

        private void SetTextBoxes()
        {
            MainCodeText.Text = _mainCode;
            ChildCodeText.Text = _chaildCode;
        }

        private void Compare() => _resultFromServer.ResultCompare.ToList().ForEach(x => ResultCompareList.Items.Add(x));
    }
}
