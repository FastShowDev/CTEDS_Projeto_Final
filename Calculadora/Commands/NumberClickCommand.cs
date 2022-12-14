using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class NumberClickCommand : BaseCommand
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

                CalculatorDisplay.InsertNumberInDisplay(buttonName, pressedButtonValue);
                _viewModel.UpdateDisplay();
            }
            
        }
    }
}
