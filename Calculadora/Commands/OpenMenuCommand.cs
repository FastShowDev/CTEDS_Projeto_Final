using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculadora.Commands
{
    public class OpenMenuCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public OpenMenuCommand()
        {

        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter != null)
            {
                Border menu = (Border)parameter;
                menu.Visibility = Visibility.Visible;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
