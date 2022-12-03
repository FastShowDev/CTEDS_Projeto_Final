using Calculadora.Database;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class LoadHistoryCommand : CommandBase
    {
        private StandardCalculatorViewModel _viewModel;
        public LoadHistoryCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            DataGrid dataGrid = (DataGrid)parameter;
            dataGrid.ItemsSource = _viewModel.histories;
        }
    }
}
