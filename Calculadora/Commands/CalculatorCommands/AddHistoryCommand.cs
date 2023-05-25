using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Commands.CalculatorCommands
{
    public class AddHistoryCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public AddHistoryCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            return;
        }
    }
}
