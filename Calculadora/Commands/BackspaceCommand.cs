using Calculadora.Models;
using Calculadora.ViewModels;

namespace Calculadora.Commands
{
    public class BackspaceCommand : BaseCommand
    {
        StandardCalculatorViewModel _viewModel;
        public BackspaceCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            CalculatorDisplay.BackspaceDisplay();
            _viewModel.UpdateDisplay();
        }
    }
}
