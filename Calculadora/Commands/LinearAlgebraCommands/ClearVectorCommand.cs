using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands.LinearAlgebraCommands
{
    public class ClearVectorCommand : BaseCommand
    {
        private LinearAlgebraViewModel linearAlgebraViewModel;

        public ClearVectorCommand(LinearAlgebraViewModel linearAlgebraViewModel)
        {
            this.linearAlgebraViewModel = linearAlgebraViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                object[] parameters = (object[])parameter;

                TextBox textBox1i = (TextBox)parameters[0];
                TextBox textBox1j = (TextBox)parameters[1];
                TextBox textBox1k = (TextBox)parameters[2];

                TextBox textBox2i = (TextBox)parameters[3];
                TextBox textBox2j = (TextBox)parameters[4];
                TextBox textBox2k = (TextBox)parameters[5];

                TextBox textBox3i = (TextBox)parameters[6];
                TextBox textBox3j = (TextBox)parameters[7];
                TextBox textBox3k = (TextBox)parameters[8];

                textBox1i.Text = String.Empty;
                textBox1j.Text = String.Empty;
                textBox1k.Text = String.Empty;

                textBox2i.Text = String.Empty;
                textBox2j.Text = String.Empty;
                textBox2k.Text = String.Empty;

                textBox3i.Text = String.Empty;
                textBox3j.Text = String.Empty;
                textBox3k.Text = String.Empty;

                linearAlgebraViewModel.ClearValues();
            } 
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
           

        }
    }
}
