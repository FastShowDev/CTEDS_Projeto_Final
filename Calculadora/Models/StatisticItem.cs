using System;

namespace Calculadora.Models
{
    public class StatisticItem
    {
        public int id { get; set; }
        public double value { get; set; }
        public double dispersion { get; set; }
        public double standardDeviation { get; set; }

        public StatisticItem(int id, double value, double dispersion)
        {
            this.id = id;
            this.value = value;
            this.dispersion = dispersion;
            standardDeviation = 0;
        }

    }
}
