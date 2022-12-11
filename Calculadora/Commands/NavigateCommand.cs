using Calculadora.Models;
using Calculadora.Stores;
using Calculadora.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class NavigateCommand : BaseCommand
    {
        public NavigateCommand()
        {
        }

        public override void Execute(object? parameter)
        {
            var values = (object[])parameter;
            Border menu = values[0] as Border;
            NavigationStore.CurrentViewModel = values[1] as BaseViewModel;
            RadioButton radioButton = values[2] as RadioButton;

            menu.Visibility = Visibility.Hidden;
            radioButton.IsChecked = true;
            NavigationStore.CurrentViewModel.IsMenuOpen = false;

            CalculatorDisplay.ClearDisplay();
        }
    }
}
