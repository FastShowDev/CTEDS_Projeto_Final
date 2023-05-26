using Calculadora.ViewModels;
using System.Windows.Controls;

namespace Calculadora.Commands.LinearAlgebraCommands
{
    public class SelectMixedCommand : BaseCommand
    {
        private LinearAlgebraViewModel linearAlgebraViewModel;
        public SelectMixedCommand(LinearAlgebraViewModel linearAlgebraViewModel)
        {
            this.linearAlgebraViewModel = linearAlgebraViewModel;
        }
        public override void Execute(object? parameter)
        {
            //RadioButton radioButton = (RadioButton) parameter;
            //radioButton.IsChecked = true;
            linearAlgebraViewModel.SelectMixedProduct();
        }
    }
}
