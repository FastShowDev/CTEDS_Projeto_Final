using System;
using System.Globalization;
using System.Windows;

namespace Calculadora.Models
{
    public class Calculator
    {
        #region CONSTANTS
        public readonly string DECIMAL_SPERATOR = ",";

        public readonly double PI = Math.PI;
        public readonly double E = Math.E;
        #endregion

        #region Properties
        public bool isNumber { get; set; }
        public bool isFloat { get; set; }
        public bool isOperation { get; set; }
        public bool canCalculate { get; set; } = false;
        public string displayContent { get; set; } = "0";
        public string? result { get; set; }
        public string? lastButtonPressed { get; set; }
        #endregion

        

        /// <summary>
        /// Método que insere um número no display.
        /// Caso o botão de casa decimal for apertado, só permite a adição de vírgula caso for a primeira vez (isFloar == false)
        /// Faz o tramento necessário caso o display tenha apenas valor zero.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="pressedButtonValue"></param>
        /// <returns>string contendo o valor atualizado do display</returns>
        public string InsertNumberInDisplay(string buttonName, string pressedButtonValue)
        {
            isNumber = true;
            if (displayContent == "0" && pressedButtonValue != DECIMAL_SPERATOR)
            {
                displayContent = "";
            }

            if (buttonName == "button_float")
            {
                if (lastButtonPressed == "float")
                {
                    return displayContent;
                }
                isFloat = true;
                lastButtonPressed = "float";
            }
            displayContent += pressedButtonValue;
            lastButtonPressed = "number";
            return displayContent;
        }


        /// <summary>
        /// Método que insere um operador no display:
        /// Caso o último botão pressionado foi um operador, ou seja, o último caracter do display for um operador aritmético atualiza para o novo operador pressionado.
        /// Caso o último botão pressionado foi um número, apenas adiciona o operador pressionado ao display.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="pressedButtonValue"></param>
        /// <returns></returns>
        public void InsertOperatorInDisplay(string buttonName, string pressedButtonValue)
        {
            if (lastButtonPressed == "operator")
            {
                int newDisplayLenght = displayContent.Length - 1;
                string display = displayContent.Substring(0, newDisplayLenght);
                display += pressedButtonValue;
                displayContent = display;
            }
            else
            {
                lastButtonPressed = "operator";
                displayContent += pressedButtonValue;
            }

            return;
        }



        /// <summary>
        /// Método que limpa o display e atualiza as flags
        /// </summary>
        public void ClearDisplay()
        {
            lastButtonPressed = "number";
            displayContent = "0";
            result = "";
            isFloat = false;
            isNumber = true;
            isOperation = false;
            canCalculate = false;
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples, contendo apenas operadores aritiméticos elementares e parênteses e faz seu cálculo.
        /// É necessário que a expressão esteja corretamente digitada, caso contrário mostra um MessageBox contendo um aviso de erro.
        /// 
        /// Exemplo de expressão correta: (10 + 3)*3 -4/3 + 5 ou (10+3)*3-4/3+5
        /// Exemplo de expressão incorreta: (10+3)*3--4/3( ou (10+3)*3 4/3++5
        /// 
        /// O cálculo é feito utilizando uma propriedade do DataTable de calcular expressões matemáticas simples
        /// Outro modo possível é utilizando o método Compute() do DataTable
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um decimal contendo o valor da expressão corretamente calculada, respeitando precedência de parênteses e operadores</returns>
        public decimal CalculateExpression(string expression)
        {
            try
            {
                expression = expression.Replace(",", ".");

                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);

                return decimal.Parse((string)row["expression"]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }

    }
}
