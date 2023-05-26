using Calculadora.View;
using Calculadora.ViewModels;
using Calculadora.Models;
using System;
using System.Windows.Controls;

namespace Calculadora.Commands.LinearAlgebraCommands
{
    public class CalculateProductCommand : BaseCommand
    {
        private LinearAlgebraViewModel linearAlgebraViewModel;
        public CalculateProductCommand(LinearAlgebraViewModel linearAlgebraViewModel)
        {
            this.linearAlgebraViewModel = linearAlgebraViewModel;
        }
        public override void Execute(object? parameter)
        {
            var parameters = (object[]) parameter;

            TextBox textBox1i = (TextBox)parameters[0];
            TextBox textBox1j = (TextBox)parameters[1];
            TextBox textBox1k = (TextBox)parameters[2];

            TextBox textBox2i = (TextBox)parameters[3];
            TextBox textBox2j = (TextBox)parameters[4];
            TextBox textBox2k = (TextBox)parameters[5];

            TextBox textBox3i = (TextBox)parameters[6];
            TextBox textBox3j = (TextBox)parameters[7];
            TextBox textBox3k = (TextBox)parameters[8];

            TextBlock resultTextBlock = (TextBlock)parameters[9];

            TextBox txtVector1 = (TextBox)parameters[10];
            TextBox txtVector2 = (TextBox)parameters[11];
            TextBox txtVector3 = (TextBox)parameters[12];

            if (linearAlgebraViewModel.IsMixedProduct)
            {
            }
            else if (linearAlgebraViewModel.IsEscalarProduct)
            {

            } 
            else if (linearAlgebraViewModel.IsVectorialProduct)
            {

            }
        }
    }
}
