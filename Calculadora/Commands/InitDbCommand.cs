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
    public class InitDbCommand : CommandBase
    {
        private Context test;
        private StandardCalculatorViewModel _viewModel;
        public InitDbCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            DataGrid dataGrid = (parameter as DataGrid);
            dataGrid.DataContext = _viewModel.context;
            dataGrid.ItemsSource = _viewModel.histories;
        }
    }
}
