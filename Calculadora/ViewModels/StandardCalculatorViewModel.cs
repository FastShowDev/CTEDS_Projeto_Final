using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        public StandardCalculatorViewModel()
        {
            calculator = new Calculator();
        }


    }
}
