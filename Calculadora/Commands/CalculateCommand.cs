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

                _viewModel.stringResult = expression;

                _viewModel.displayContent = _viewModel.calculator.CalculateExpression(expression).ToString();

                _viewModel.calculator.hasCalculate = true;
                _viewModel.calculator.hasConst = false;

                _viewModel.AddHistory(expression, _viewModel.displayContent);
                dataGrid.ItemsSource = _viewModel.GetAllHistories();

            }
            
        }
    }
}
