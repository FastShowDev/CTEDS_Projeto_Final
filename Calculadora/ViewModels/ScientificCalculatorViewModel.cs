using Calculadora.Models;
using Calculadora.Stores;
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
        public ScientificCalculatorViewModel()
        {
            ViewName = "Científica";
        }
    }
}
