using Calculadora.Models;
using Calculadora.ViewModels;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class OperatorClickCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;
        public OperatorClickCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if(parameter != null)
            {
                string pressedButtonValue = (parameter as Button).Content.ToString();

                if (pressedButtonValue == "(" || pressedButtonValue == ")")
                {
                    CalculatorDisplay.InsertParenthesisInDisplay(pressedButtonValue);
                    _viewModel.displayContent = CalculatorDisplay.displayContent;
                    return;
                }

                if(pressedButtonValue == "mod")
                {
                    pressedButtonValue = "%";
                }

                CalculatorDisplay.InsertOperatorInDisplay(pressedButtonValue);
                _viewModel.displayContent = CalculatorDisplay.displayContent;
            }
        }
    }
}
