using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculadora.Commands
{
    public class OperatorClickCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Calculator _calculator;
        public OperatorClickCommand(Calculator calculator)
        {
            _calculator = calculator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
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
