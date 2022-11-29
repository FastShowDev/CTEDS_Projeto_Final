using Calculadora.Models;
using Calculadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;

namespace Calculadora.Commands
{
    public class CalculateCommand : CommandBase
    {
        //private int[] additionIndexes;
        //private int[] subtracionIndexes;
        //private int[] multiplicationIndexes;
        //private int[] divisionIndexes;
        private List<int> operationIndexes = new List<int>{ 2, 5, 8 };
        private Calculator _calculator = new Calculator();
        private readonly BaseViewModel _viewModel;

        public CalculateCommand(BaseViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            string displayContent = "15+14-12+12";
            char[] chars = displayContent.ToArray<char>();
            MessageBox.Show(chars[2].ToString());
            ProcessOperation('+', ref chars);
            ProcessOperation('-', ref chars);

        }

        private void ProcessOperation(char _operator, ref char[] currentCalculation)
        {
            RefreshOperatorIndexes(currentCalculation);
            //currentCalculation[operationIndexes[0]] == _operator
            if (currentCalculation[operationIndexes.ElementAt(0)] == _operator)
            {
                string calculation = new string(currentCalculation);

                string numOne = calculation.Substring(0, operationIndexes.ElementAt(0));
                //Tratar caso com apenas um operador: 29 - 24 (exemplo)
                string numTwo = calculation.Substring(operationIndexes.ElementAt(0) + 1, operationIndexes.ElementAt(1) - operationIndexes.ElementAt(0) - 1);

                MessageBox.Show("Numero1: " + numOne + " Numero2: " + numTwo);
                decimal partialResult = Calculate(numOne, numTwo, _operator);

                string s_partialResult = partialResult.ToString();
                calculation = s_partialResult + calculation.Substring(operationIndexes.ElementAt(1));
                MessageBox.Show("Resultado: " + calculation);
                currentCalculation = calculation.ToCharArray();
                RefreshOperatorIndexes(currentCalculation);
            }

            //operationIndexes.Length > 1 && currentCalculation[operationIndexes[operationIndexes.Length - 1]] == _operator
            if (operationIndexes.Count > 1 && currentCalculation[operationIndexes.ElementAt(operationIndexes.Count - 1)] == _operator)
            {
                string calculation = new string(currentCalculation);

                int numberOneLength = operationIndexes.ElementAt(operationIndexes.Count - 1) - operationIndexes.ElementAt(operationIndexes.Count - 2) - 1;

                string numOne = calculation.Substring(operationIndexes.ElementAt(operationIndexes.Count - 2) + 1, numberOneLength);

                string numTwo = calculation.Substring(operationIndexes.ElementAt(operationIndexes.Count - 1) + 1);

                MessageBox.Show("Numero1: " + numOne + " Numero2: " + numTwo);
                decimal partialResult = Calculate(numOne, numTwo, _operator);

                string s_partialResult = partialResult.ToString();
                // 12 + 13 + 14 * 15
                // 12 + 13 + 210
                calculation = calculation.Substring(0, operationIndexes.ElementAt(operationIndexes.Count - 2) + 1) + s_partialResult;
                MessageBox.Show("Resultado: " + calculation);
                currentCalculation = calculation.ToCharArray();
                RefreshOperatorIndexes(currentCalculation);
            }

            MessageBox.Show("Resultado final:  " +  new string(currentCalculation));
            

        }

        private void RefreshOperatorIndexes(char[] currentCalculation)
        {
            operationIndexes.Clear();
            //operationIndexes.Append(1000);
            //MessageBox.Show(operationIndexes[0].ToString());
            //Varre procurando as posições dos operadores na string do display
            int i = 0;
            foreach (char c in currentCalculation)
            {
                switch (c)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        operationIndexes.Add(i);
                        break;

                }
                i++;
            }
        }

        private decimal Calculate(string s_numberOne, string s_numberTwo, char _operator)
        {
            decimal numberOne = Convert.ToDecimal(s_numberOne);
            decimal numberTwo = Convert.ToDecimal(s_numberTwo);

            //Faz a operação 'operator' com dois numeros passados
            switch (_operator)
            {
                case '+':
                    return numberOne + numberTwo;
                case '-':
                    return numberOne - numberTwo;
                case '*':
                    return numberOne * numberTwo;
                case '/':
                    return numberOne / numberTwo;
                default:
                    return 0;
            }
        }
    }
}
