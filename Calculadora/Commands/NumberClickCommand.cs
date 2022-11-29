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
        private readonly StandardCalculatorViewModel _viewModel;

        public NumberClickCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
            
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                string buttonName = ((Button)parameter).Name;
                string pressedButtonValue = Convert.ToString((parameter as Button).Content);

                _viewModel.displayContent = _viewModel.calculator.InsertNumberInDisplay(buttonName, pressedButtonValue);
            }
            
        }
    }
}
