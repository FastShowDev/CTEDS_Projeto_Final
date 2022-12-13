using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class Log10Command : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public Log10Command(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                string expression = ((TextBox)parameter).Text;
                Calculator.ExecuteLog10(expression);
                _viewModel.UpdateDisplay();
                _viewModel.AddHistory(_viewModel.stringResult, _viewModel.displayContent);
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
    }
}