using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculadora.Commands
{
    public class NumberClickCommand : CommandBase
    {
        private Calculator _calculator;
        private readonly BaseViewModel _viewModel;

        public NumberClickCommand(BaseViewModel viewModel,Calculator calculator)
        {
            _calculator = calculator;
            _viewModel = viewModel;
            
        }

        public override void Execute(object? parameter)
        {
            _calculator.isNumber = true;
            string objName = ((Button)parameter).Name;
            string pressedButtonValue = Convert.ToString((parameter as Button).Content);
            if (_calculator.displayContent == "0" && pressedButtonValue != _calculator.DECIMAL_SPERATOR)
            {
                _calculator.displayContent = "";
            }
            if (objName == "button_float")
            {
                _calculator.isFloat = true;
            }
            _calculator.displayContent += pressedButtonValue;
            _calculator.lastButtonPressed = "number";
        }
    }
}
