using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora.Commands.StatisticCommands
{
    public class SelectValueCommand : BaseCommand
    {
        StatisticItem item;
        public SelectValueCommand(StatisticItem item)
        {
            this.item = item;
        }
        public override void Execute(object? parameter)
        {
            CheckBox checkBox = parameter as CheckBox;
            item.selected = (bool) checkBox.IsChecked;
        }
    }
}
