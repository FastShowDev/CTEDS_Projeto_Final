using Calculadora.Models;
using Calculadora.ViewModels;

namespace Calculadora.Commands
{
    public class PercentageCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public PercentageCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            CalculatorDisplay.InsertPercentageInDisplay();
            _viewModel.UpdateDisplay();
        }
    }
}
