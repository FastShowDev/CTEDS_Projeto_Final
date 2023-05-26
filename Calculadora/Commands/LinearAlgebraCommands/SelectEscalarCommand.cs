using Calculadora.ViewModels;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands.LinearAlgebraCommands
{
    public class SelectEscalarCommand : BaseCommand
    {
        private LinearAlgebraViewModel linearAlgebraViewModel;
        public SelectEscalarCommand(LinearAlgebraViewModel linearAlgebraViewModel)
        {
            this.linearAlgebraViewModel = linearAlgebraViewModel;
        }
        public override void Execute(object? parameter)
        {
            //RadioButton radioButton = (RadioButton) parameter;
            //radioButton.IsChecked = true;
            linearAlgebraViewModel.SelectEscalarProduct();
        }
    }
}
