using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora.Commands
{
    public class ConstClickCommand : CommandBase
    {
        private StandardCalculatorViewModel _viewModel;
        public ConstClickCommand(StandardCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(parameter != null)
            {
                string buttonName = (parameter as Button).Name;
                _viewModel.calculator.hasConst = true;
                MessageBox.Show(buttonName);

                if (buttonName == "button_pi")
                {
                    _viewModel.calculator.InsertConstInDisplay("π");
                    _viewModel.displayContent = _viewModel.calculator.displayContent;
                }
                else if(buttonName == "button_e")
                {
                    _viewModel.calculator.InsertConstInDisplay("e");
                    _viewModel.displayContent = _viewModel.calculator.displayContent;
                }
            }
            else throw new ArgumentNullException(nameof(parameter));
        }
    }
}
