using Calculadora.ViewModels;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class ClearDisplayCommand : CommandBase
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public ClearDisplayCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.displayContent = "0";
            _viewModel.stringResult = "";
            _viewModel.calculator.lastButtonPressed = "number";
        }
    }
}
