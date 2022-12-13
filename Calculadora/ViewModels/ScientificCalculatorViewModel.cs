using Calculadora.Commands;
using Calculadora.Database.Managers;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculadora.ViewModels
{
    public class ScientificCalculatorViewModel : StandardCalculatorViewModel, INotifyPropertyChanged
    {
        public ICommand ConstClickCM { get; }
        public ICommand Log10ClickCM { get; }
        public ICommand LnClickCM { get; }
        public ICommand AbsoluteClickCM { get; }

        public ScientificCalculatorViewModel() : base() 
        {
            ViewName = "Científica";
            ConstClickCM = new ConstClickCommand(this);
            Log10ClickCM = new Log10Command(this);
            LnClickCM = new LnCommand(this);
            AbsoluteClickCM = new AbsoluteCommand(this);
        }
    }
}
