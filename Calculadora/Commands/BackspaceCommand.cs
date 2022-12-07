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
            _viewModel.calculator.lastButtonTypePressed = "backspace";

            if (_viewModel.calculator.hasCalculate)
            {
                _viewModel.displayContent = "0";
                _viewModel.calculator.displayContent = "0";
                _viewModel.calculator.lastButtonTypePressed = "reset";
                return;
            }

            int lenght = _viewModel.displayContent.Length - 1;
            if (lenght > 0)
            {
                _viewModel.displayContent = _viewModel.displayContent.Substring(0, lenght);
                _viewModel.calculator.displayContent = _viewModel.displayContent;
            }
            else
            {
                _viewModel.displayContent = "0";
                _viewModel.calculator.displayContent = "0";
                _viewModel.calculator.lastButtonTypePressed = "reset";
            }
            return;
        }
    }
}
