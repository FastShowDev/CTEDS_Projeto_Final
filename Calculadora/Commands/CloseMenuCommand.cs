using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Calculadora.Commands
{
    public class CloseMenuCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public CloseMenuCommand()
        {

        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                Border menu = (Border)parameter;
                menu.Visibility = Visibility.Hidden;
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
