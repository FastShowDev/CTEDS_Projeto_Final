using Calculadora.Models;
using Calculadora.ViewModels;

namespace Calculadora.Commands
{
    public class SquareCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;

        public SquareCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string expression = parameter as string;
                Calculator.ExecuteSquare(expression);
                _viewModel.UpdateDisplay();
                _viewModel.AddHistory(_viewModel.stringResult, _viewModel.displayContent);
            }

        }
    }
}