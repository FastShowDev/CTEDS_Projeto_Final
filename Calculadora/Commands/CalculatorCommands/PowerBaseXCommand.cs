using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands.CalculatorCommands
{
    public class PowerBaseXCommand : BaseCommand
    {
        private readonly ScientificCalculatorViewModel _viewModel;
        public PowerBaseXCommand(ScientificCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                string expression = ((TextBox)parameter).Text;
                CalculatorDisplay.InsertBaseExponentiation(expression);
                CalculatorEngine.HasExponentiation = true;
                _viewModel.UpdateDisplay();
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
