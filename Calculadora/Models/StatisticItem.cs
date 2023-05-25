using Calculadora.Commands.StatisticCommands;
using System;
using System.Windows.Input;

namespace Calculadora.Models
{
    public class StatisticItem
    {
        public int id { get; set; }
        public double value { get; set; }
        public double dispersion { get; set; }
        public bool selected { get; set; }
        public ICommand SelectCM { get; }

        public StatisticItem(int id, double value, double dispersion)
        {
            this.id = id;
            this.value = value;
            this.dispersion = dispersion;
            selected = false;

            SelectCM = new SelectValueCommand(this);
        }

    }
}
