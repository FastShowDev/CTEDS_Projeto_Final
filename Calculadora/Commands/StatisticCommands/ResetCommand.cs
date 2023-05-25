using Calculadora.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands.StatisticCommands
{
    public class ResetCommand : BaseCommand
    {
        private StatisticViewModel viewModel;

        public ResetCommand(StatisticViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    
        public override void Execute(object? parameter)
        {
            var parameters = (object[]) parameter;
            DataGrid dataGrid = (DataGrid) parameters[0];
            TextBox textBox = (TextBox) parameters[1];
            TextBlock averageTextBlock = (TextBlock) parameters[2];
            TextBlock deviationTextBlock = (TextBlock) parameters[3];
            TextBlock averageDeviationTextBlock = (TextBlock) parameters[4];


            try
            {
                dataGrid.Items.Clear();
                averageTextBlock.Text = String.Empty;
                deviationTextBlock.Text = String.Empty;
                averageDeviationTextBlock.Text = String.Empty;
                textBox.Text = String.Empty;
                textBox.Focus();

            } catch(Exception e) {
                MessageBox.Show(e.Message);
            }
        }
    }
}
