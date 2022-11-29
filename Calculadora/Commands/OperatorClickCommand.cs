using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculadora.Commands
{
    public class OperatorClickCommand : CommandBase
    {
        private Calculator _calculator;
        private readonly BaseViewModel _viewModel;
        public OperatorClickCommand(BaseViewModel viewModel, Calculator calculator)
        {
            _calculator = calculator;
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            string objName = ((Button)parameter).Name;
            char pressedButtonValue = Convert.ToChar((parameter as Button).Content);
            if (_calculator.lastButtonPressed == "operator")
            {
                int lastDisplayIndex = _calculator.displayContent.Length - 1;
                string display = _calculator.displayContent.Substring(0, lastDisplayIndex);
                display += pressedButtonValue;
                _calculator.displayContent = display.ToString();
            }
            else
            {
                _calculator.lastButtonPressed = "operator";
                _calculator.displayContent += pressedButtonValue;
            }
        }
    }
}
