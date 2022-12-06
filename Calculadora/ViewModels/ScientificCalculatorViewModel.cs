using Calculadora.Models;
using Calculadora.Stores;
using Calculadora.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculadora.ViewModels
{
    public class ScientificCalculatorViewModel : StandardCalculatorViewModel, INotifyPropertyChanged
    {

        public ICommand ConstClickCM { get; }

        public ScientificCalculatorViewModel()
        {
            ViewName = "Científica";
            ConstClickCM = new ConstClickCommand(this);
        }
    }
}
