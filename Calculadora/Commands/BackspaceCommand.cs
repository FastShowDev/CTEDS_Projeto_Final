using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _viewModel.calculator.BackspaceDisplay();
            _viewModel.UpdateDisplay();
        }
    }
}
