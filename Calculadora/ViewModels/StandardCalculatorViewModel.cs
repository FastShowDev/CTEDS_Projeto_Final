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
        private Calculator calculator;

        #region Properties
        private string _displayContent = "0";
        public string DisplayContent
        {
            get { return _displayContent; }
            set { _displayContent = value; }
        }
        #endregion

        #region Commands
        //public CalculateCommand Calculate = new CalculateCommand();
        #endregion

        public StandardCalculatorViewModel()
        {
            calculator = new Calculator();
        
    }


    }
}
