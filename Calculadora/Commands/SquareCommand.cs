using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Commands
{
    public class SquareCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;

        public SquareCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string expression = parameter as string;
                _viewModel.calculator.InsertSquareInDisplay(expression);
                _viewModel.UpdateDisplay();
                _viewModel.AddHistory(_viewModel.stringResult, _viewModel.displayContent);
            }

        }
    }
}