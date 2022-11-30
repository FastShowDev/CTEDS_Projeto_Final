using Calculadora.Commands;
using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculadora.ViewModels
{
    public class StandardCalculatorViewModel : BaseViewModel
    {
        public Calculator calculator;


        #region Properties
        private string _displayContent = "0";
        public string displayContent
        {
            get { return _displayContent; }
            set { _displayContent = value; OnPropertyChanged(nameof(displayContent)); }
        }

        private string _stringResult = "";
        public string stringResult
        {
            get { return _stringResult; }
            set { _stringResult = value; OnPropertyChanged(nameof(stringResult)); }
        }
        #endregion


        #region Commands
        public ICommand BackspaceCM { get; }
        public ICommand ClearDisplayCM { get; }
        public ICommand NumberClickCM { get; }
        public ICommand OperatorClickCM { get; }
        public ICommand CalculateCM { get; }
        #endregion


        public StandardCalculatorViewModel()
        {
            calculator = new Calculator();
            BackspaceCM = new BackspaceCommand(this);
            ClearDisplayCM = new ClearDisplayCommand(this);
            NumberClickCM = new NumberClickCommand(this);
            OperatorClickCM = new OperatorClickCommand(this);
            CalculateCM = new CalculateCommand(this);
            
            
        }


    }
}
