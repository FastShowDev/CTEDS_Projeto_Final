using System;
using System.Collections.Generic;

namespace Calculadora.Models
{
    public class StatisticCalculator
    {
        public double sum { get; set; }
        public double average { get; set; }
        public double variance { get; set; }
        public double standardDevitation { get; set; }
        public double averageStandardDeviation { get; set; }



        private void CalculateSum(List<StatisticItem> items)
        {
            sum = 0;
            foreach(StatisticItem item in items)
            {
                sum += item.value;
            }
        }
        private void CalculateStandardAverage(List<StatisticItem> items)
        {
            CalculateSum(items);
            average = 0;
            if (items.Count > 0) average = sum / items.Count;
        }

        private void CalculateVariance(List<StatisticItem> items)
        {
            CalculateStandardAverage(items);
            double dispersion = 0;
            variance = 0;
            foreach (StatisticItem item in items)
            {
                dispersion = (item.value - average);
                item.dispersion = dispersion;
                variance += Math.Pow(dispersion, 2);
            }
            if (items.Count > 1) variance /= (items.Count - 1);
            
        }

        public void CalculateDeviation(List<StatisticItem> items)
        {
            CalculateVariance(items);
            standardDevitation = Math.Sqrt(variance);

        }

        public void CalculateAverageDeviation(List<StatisticItem> items)
        {
            CalculateDeviation(items);
            averageStandardDeviation = Math.Sqrt(standardDevitation);
        }
    }
}
