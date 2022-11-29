using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Calculadora.ViewModels;

namespace Calculadora.Commands
{
    public class CloseMenuCommand : CommandBase
    {
        public CloseMenuCommand()
        {

        }

        public override void Execute(object? parameter)
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

    }
}
