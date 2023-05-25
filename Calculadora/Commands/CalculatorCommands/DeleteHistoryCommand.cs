using Calculadora.ViewModels;
using System.Windows.Controls;

namespace Calculadora.Commands.CalculatorCommands
{
    public class DeleteHistoryCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public DeleteHistoryCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            DataGrid dataGrid = (DataGrid)parameter;
            _viewModel.DeleteAllHistory();
            dataGrid.ItemsSource = _viewModel.GetAllHistories();
        }
    }
}
