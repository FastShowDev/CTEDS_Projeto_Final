using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Calculadora.Commands.StatisticCommands
{
    public class DeleteValuesCommand : BaseCommand
    {
        private StatisticViewModel viewModel;
        private StatisticCalculator statisticCalculator;
        public DeleteValuesCommand(StatisticViewModel viewModel)
        {
            this.viewModel = viewModel;
            statisticCalculator = new StatisticCalculator();
        }
        public override void Execute(object? parameter)
        {
            List<StatisticItem> newList = new List<StatisticItem>();
            var parameters = (object[]) parameter;
            DataGrid dataGrid = (DataGrid) parameters[0];
            TextBlock averageTextBlock = (TextBlock) parameters[1];
            TextBlock standardDeviationTextBlock = (TextBlock) parameters[2];
            TextBlock averageStandardDeviationTextBlock = (TextBlock) parameters[3];

            dataGrid.Items.Clear();

            int i = 1;
            foreach (StatisticItem item in viewModel.items)
            {
                if (item.selected == false)
                {
                    item.id = i;
                    newList.Add(item);
                    dataGrid.Items.Add(item);
                    i++;
                }
                 
            }

            viewModel.items = newList;
            statisticCalculator.CalculateAverageDeviation(viewModel.items);
            averageTextBlock.Text = statisticCalculator.average.ToString();
            standardDeviationTextBlock.Text = statisticCalculator.standardDevitation.ToString();
            averageStandardDeviationTextBlock.Text = statisticCalculator.averageStandardDeviation.ToString();

        }
    }
}
