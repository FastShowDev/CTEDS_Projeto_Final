using Calculadora.Database;
using Calculadora.ViewModels;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class LoadHistoryCommand : BaseCommand
    {
        private StandardCalculatorViewModel _viewModel;
        public LoadHistoryCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            DataGrid dataGrid = (DataGrid)parameter;
            dataGrid.ItemsSource = _viewModel.GetAllHistories();
        }
    }
}
