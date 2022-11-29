using Calculadora.Commands;
using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculadora.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand OpenMenu { get; }
        public ICommand CloseMenu { get; }

        public BaseViewModel()
        {
            OpenMenu = new OpenMenuCommand();
            CloseMenu = new CloseMenuCommand();

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
