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

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string expression = parameter as string;
                Calculator.ExecuteSquareRoot(expression);
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