using Calculadora.Models;
using Calculadora.ViewModels;

namespace Calculadora.Commands.CalculatorCommands
{
    public class ClearDisplayCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public ClearDisplayCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            CalculatorDisplay.ClearDisplay();
            _viewModel.UpdateDisplay();
        }
    }
}
