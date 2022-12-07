using Calculadora.Stores;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculadora.Commands
{
    public class NavigateCommand : BaseCommand
    {
        public NavigateCommand()
        {
        }

        public override void Execute(object? parameter)
        {
            NavigationStore.CurrentViewModel = new ScientificCalculatorViewModel();
        }
    }
}
