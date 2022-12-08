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
    public class AbsoluteCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public AbsoluteCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string expression = ((TextBox)parameter).Text;
                _viewModel.calculator.InsertAbsoluteInDisplay(expression);
                _viewModel.displayContent = _viewModel.calculator.displayContent;
                _viewModel.stringResult = _viewModel.calculator.result;
                //MessageBox.Show("Resultado: " + _viewModel.calculator.result + "\nDisplay: " + _viewModel.calculator.displayContent);
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