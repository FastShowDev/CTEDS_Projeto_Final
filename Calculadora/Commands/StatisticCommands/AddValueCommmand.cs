using Calculadora.ViewModels;
using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands.StatisticCommands
{
    internal class AddValueCommmand : BaseCommand
    {
        private StatisticViewModel _statisticViewModel;
        public AddValueCommmand(StatisticViewModel viewModel)
        {
            _statisticViewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            var parameters = (object[]) parameter;
            TextBox textBox = (TextBox) parameters[0];
            DataGrid dataGrid = (DataGrid) parameters[1];

            try
            {
                double value = double.Parse(textBox.Text);
                int id = _statisticViewModel.items.Count() + 1;

                StatisticItem item = new StatisticItem(id, value, 0);
                _statisticViewModel.items.Add(item);
                dataGrid.Items.Add(item);
                textBox.Text = String.Empty;
                textBox.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            

        }
    }
}
