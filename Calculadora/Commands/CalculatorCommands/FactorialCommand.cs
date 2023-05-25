using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands.CalculatorCommands
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
            if (parameter != null)
            {
                string expression = ((TextBox)parameter).Text;
                try
                {
                    Calculator.ExecuteFactorial(expression);
                }
                catch (Exception e)
                {
                    CalculatorDisplay.ClearDisplay();
                    _viewModel.ErrorMessage = e.Message;
                    _viewModel.UpdateDisplay();
                    return;
                }
                _viewModel.UpdateDisplay();
                _viewModel.AddHistory(_viewModel.StringResult, _viewModel.DisplayContent);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
