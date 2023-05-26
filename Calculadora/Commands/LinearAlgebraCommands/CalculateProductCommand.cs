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
        private LinearAlgebraCalculator calculator;
        public CalculateProductCommand(LinearAlgebraViewModel linearAlgebraViewModel)
        {
            this.linearAlgebraViewModel = linearAlgebraViewModel;
            calculator = new LinearAlgebraCalculator();
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

            //TextBlock resultTextBlock = (TextBlock)parameters[9];

            //TextBox txtVector1 = (TextBox)parameters[10];
            //TextBox txtVector2 = (TextBox)parameters[11];
            //TextBox txtVector3 = (TextBox)parameters[12];

            double i1 = double.Parse(textBox1i.Text);
            double j1 = double.Parse(textBox1j.Text);
            double k1 = double.Parse(textBox1k.Text);

            double i2 = double.Parse(textBox2i.Text);
            double j2 = double.Parse(textBox2j.Text);
            double k2 = double.Parse(textBox2k.Text);

            Vector vector1 = new Vector(i1, j1, k1);
            Vector vector2 = new Vector(i2, j2, k2);

            if (linearAlgebraViewModel.IsMixedProduct)
            {
                double i3 = double.Parse(textBox3i.Text);
                double j3 = double.Parse(textBox3j.Text);
                double k3 = double.Parse(textBox3k.Text);

                Vector vector3 = new Vector(i3, j3, k3);

                linearAlgebraViewModel.EscalarResult = calculator.CalculateMixedProduct(vector1, vector2, vector3);
            }
            else if (linearAlgebraViewModel.IsEscalarProduct)
            {
                linearAlgebraViewModel.EscalarResult = calculator.CalculateEscalarProduct(vector1, vector2);
            } 
            else if (linearAlgebraViewModel.IsVectorialProduct)
            {
                Vector resultVector = calculator.CalculateVectorProduct(vector1, vector2);
                linearAlgebraViewModel.VectorIResult = resultVector.i;
                linearAlgebraViewModel.VectorJResult = resultVector.j;
                linearAlgebraViewModel.VectorKResult = resultVector.k;
            }
        }
    }
}
