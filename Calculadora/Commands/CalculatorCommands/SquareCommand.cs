using Calculadora.Models;
using Calculadora.ViewModels;
using System;

namespace Calculadora.Commands.CalculatorCommands
{
    public class SquareCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;

        public SquareCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                string expression = (string)parameter;
                try
                {
                    Calculator.ExecuteSquare(expression);
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

        }
    }
}