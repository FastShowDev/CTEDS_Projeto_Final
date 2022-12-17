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
#nullable enable
        public override void Execute(object? parameter)
        {
            CalculatorDisplay.BackspaceDisplay();
            _viewModel.UpdateDisplay();
        }
    }
}
