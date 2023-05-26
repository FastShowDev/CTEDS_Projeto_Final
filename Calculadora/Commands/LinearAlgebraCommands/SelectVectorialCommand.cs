using Calculadora.ViewModels;
using System.Windows.Controls;

namespace Calculadora.Commands.LinearAlgebraCommands
{
    public class SelectVectorialCommand : BaseCommand
    {
        private LinearAlgebraViewModel linearAlgebraViewModel;
        public SelectVectorialCommand(LinearAlgebraViewModel linearAlgebraViewModel)
        {
            this.linearAlgebraViewModel = linearAlgebraViewModel;
        }
        public override void Execute(object? parameter)
        {
            RadioButton radioButton = (RadioButton)parameter;
            radioButton.IsChecked = true;
            linearAlgebraViewModel.SelectVectorialProduct();
        }
    }
}
