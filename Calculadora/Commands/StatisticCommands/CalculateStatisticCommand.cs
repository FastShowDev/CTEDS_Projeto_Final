using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands.StatisticCommands
{
    public class CalculateStatisticCommand : BaseCommand
    {
        private StatisticViewModel statisticViewModel;
        private StatisticCalculator statisticCalculator;
        public CalculateStatisticCommand(StatisticViewModel statisticViewModel)
        {
            this.statisticViewModel = statisticViewModel;
            this.statisticCalculator = new StatisticCalculator();
        }

        public override void Execute(object? parameter)
        {
            var parameters = (object[]) parameter;
            DataGrid dataGrid = (DataGrid) parameters[0];
            TextBlock averageTextBlock = (TextBlock) parameters[1];
            TextBlock standardDeviationTextBlock = (TextBlock) parameters[2];
            TextBlock averageStandardDeviationTextBlock = (TextBlock) parameters[3];

            try
            {
                statisticCalculator.CalculateAverageDeviation(statisticViewModel.items);
                averageTextBlock.Text = statisticCalculator.average.ToString();
                standardDeviationTextBlock.Text = statisticCalculator.standardDevitation.ToString();
                averageStandardDeviationTextBlock.Text = statisticCalculator.averageStandardDeviation.ToString();

                dataGrid.Items.Clear();
                
                foreach(StatisticItem item in statisticViewModel.items)
                {
                    dataGrid.Items.Add(item);
                }
                //dataGrid.Items.Clear();
                //dataGrid.Items.Add(statisticViewModel.items);

            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
