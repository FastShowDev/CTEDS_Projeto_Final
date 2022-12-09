using Calculadora.Stores;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class PercentageCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public PercentageCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.calculator.InsertPercentageInDisplay();
            _viewModel.UpdateDisplay();
        }
    }
}
