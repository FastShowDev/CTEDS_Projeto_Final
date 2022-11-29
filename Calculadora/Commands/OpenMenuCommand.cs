using Calculadora.ViewModels;
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
    public class OpenMenuCommand : CommandBase
    {
        private readonly BaseViewModel _viewModel;

        public OpenMenuCommand(BaseViewModel viewModel)
        {
            _viewModel = viewModel;
            
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                Border menu = (Border)parameter;
                menu.Visibility = Visibility.Visible;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
