using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class FactorialCommand : BaseCommand
    {
        private readonly ScientificCalculatorViewModel _viewModel;
        public FactorialCommand(ScientificCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            if(parameter != null)
            {
                string expression = ((TextBox)parameter).Text;
                Calculator.ExecuteFactorial(expression);
                _viewModel.UpdateDisplay();
                _viewModel.AddHistory(_viewModel.stringResult, _viewModel.displayContent);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
