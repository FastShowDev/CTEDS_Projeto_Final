using Calculadora.Stores;
using Calculadora.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class OpenMenuCommand : BaseCommand
    {
        BaseViewModel _viewModel;
        public OpenMenuCommand(BaseViewModel viewModel)
        {
            _viewModel = viewModel;
        }
#nullable enable
        public override bool CanExecute(object? parameter)
        {
            return !NavigationStore.CurrentViewModel.IsMenuOpen;
        }
#nullable enable
        public override void Execute(object? parameter)
        {
            Border menu = (Border)parameter;
            menu.Visibility = Visibility.Visible;
            NavigationStore.CurrentViewModel.IsMenuOpen = true;
        }
    }
}
