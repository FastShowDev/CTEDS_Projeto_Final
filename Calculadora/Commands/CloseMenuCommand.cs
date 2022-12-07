using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Calculadora.ViewModels;
using Calculadora.Stores;

namespace Calculadora.Commands
{
    public class CloseMenuCommand : BaseCommand
    {
        BaseViewModel _viewModel;
        public CloseMenuCommand(BaseViewModel viewModel)
        {
            _viewModel = viewModel;
        
        }
#nullable enable
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            Border menu = (Border)parameter;
            menu.Visibility = Visibility.Hidden;
            NavigationStore.CurrentViewModel.IsMenuOpen = false;

        }
#nullable enable
    }
}
