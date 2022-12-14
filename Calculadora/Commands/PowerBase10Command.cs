using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class PowerBase10Command : BaseCommand
    {
        private readonly ScientificCalculatorViewModel _viewModel;
        public PowerBase10Command(ScientificCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                string expression = ((TextBox)parameter).Text;
                try
                {
                    Calculator.ExecutePowerBase10(expression);
                }
                catch (Exception e)
                {
                    CalculatorDisplay.ClearDisplay();
                    _viewModel.ErrorMessage = e.Message;
                    _viewModel.UpdateDisplay();
                    return;
                }
                _viewModel.UpdateDisplay();
                _viewModel.AddHistory(_viewModel.StringResult, _viewModel.DisplayContent);
            }
            else
            {
                throw new NullReferenceException();

            }
        }
    }
}
