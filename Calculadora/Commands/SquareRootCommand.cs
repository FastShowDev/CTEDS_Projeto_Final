using Calculadora.Models;
using Calculadora.ViewModels;
using System;

namespace Calculadora.Commands
{
    public class SquareRootCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public SquareRootCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override bool CanExecute(object? parameter)
        {
            return !CalculatorDisplay.HasErrorMessage;
        }
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                string expression = (string)parameter;
                try
                {
                    Calculator.ExecuteSquareRoot(expression);
                }
                catch(Exception e)
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
                throw new ArgumentNullException();
            }

        }
    }
}