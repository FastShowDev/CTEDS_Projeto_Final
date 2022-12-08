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
        public ICommand Log10ClickCM { get; }
        public ICommand LnClickCM { get; }
        public ICommand InversionClickCM { get; }
        public ICommand AbsoluteClickCM { get; }

        public ScientificCalculatorViewModel()
        {
            ViewName = "Científica";
            ConstClickCM = new ConstClickCommand(this);
            Log10ClickCM = new Log10Command(this);
            LnClickCM = new LnCommand(this);
            InversionClickCM = new InversionCommand(this);
            AbsoluteClickCM = new AbsoluteCommand(this);
        }
    }
}
