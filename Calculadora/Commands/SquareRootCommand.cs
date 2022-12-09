using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class SquareRootCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public SquareRootCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string expression = parameter as string;
                _viewModel.calculator.InsertSquareRootInDisplay(expression);
                _viewModel.UpdateDisplay();
                _viewModel.calculator.hasCalculate = true;
                _viewModel.AddHistory(_viewModel.stringResult, _viewModel.displayContent);
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
    }
}