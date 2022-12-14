using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;

namespace Calculadora.Commands
{
    public class CalculateCommand : BaseCommand
    {
        private readonly StandardCalculatorViewModel _viewModel;

        public CalculateCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if(parameter != null)
            {
                var values = (object[])parameter;
                string expression = (values[0] as TextBox).Text;
                DataGrid dataGrid = values[1] as DataGrid;

                if (CalculatorDisplay.HasErrorMessage)
                {
                    CalculatorDisplay.ClearDisplay();
                    _viewModel.UpdateDisplay();
                    return;
                }

                if (CalculatorEngine.HasExponentiation)
                {
                    try
                    {
                        Calculator.ExecutePowerBaseX(CalculatorDisplay.Result, expression);
                    }
                    catch (Exception e)
                    {
                        CalculatorDisplay.ClearDisplay();
                        _viewModel.ErrorMessage = e.Message;
                        _viewModel.UpdateDisplay();
                        return;
                    }

                }
                else
                {
                    try
                    {
                        Calculator.ExecuteCalculate(expression);
                    }
                    catch (Exception e)
                    {
                        CalculatorDisplay.ClearDisplay();
                        _viewModel.ErrorMessage = e.Message;
                        _viewModel.UpdateDisplay();
                        return;
                    }
                }
                _viewModel.UpdateDisplay();

                _viewModel.AddHistory(expression, _viewModel.DisplayContent);
                dataGrid.ItemsSource = _viewModel.GetAllHistories();

            }
            
        }
    }
}
