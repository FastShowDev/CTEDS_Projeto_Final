using System;
using System.Collections.Generic;
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
        public bool hasConst { get; set; }
        public bool hasCalculate { get; set; } = false;
        public string displayContent { get; set; } = "0";
        public string result { get; set; } = "";
        public Stack<string> buttonsTypePressed { get; }
        public string? lastButtonTypePressed { get; set; }
        #endregion

        

        /// <summary>
        /// Método que insere um número no display.
        /// Caso o botão de casa decimal for apertado, só permite a adição de vírgula caso for a primeira vez (isFloar == false)
        /// Faz o tramento necessário caso o display tenha apenas valor zero.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="pressedButtonValue"></param>
        /// <returns></returns>
        public void InsertNumberInDisplay(string buttonName, string pressedButtonValue)
        {
            MessageBox.Show("Numero: " + buttonsTypePressed.Peek());
            isNumber = true;
            hasCalculate = false;
            if (displayContent == "0" && pressedButtonValue != DECIMAL_SPERATOR)
            {
                displayContent = "";
            }

            if (buttonName == "button_float")
            {
                if (lastButtonTypePressed == "float")
                {
                    return;
                }
                isFloat = true;
                lastButtonTypePressed = "float";
                displayContent += pressedButtonValue;
                return;
            }
            if(lastButtonTypePressed == "right_parenthesis")
            {
                pressedButtonValue = "*" + pressedButtonValue;
            }

            displayContent += pressedButtonValue;
            lastButtonTypePressed = "number";
            return;
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
            MessageBox.Show("Operador: " + lastButtonTypePressed);
            if(lastButtonTypePressed == "left_parenthesis")
            {
                return;
            }


            if (lastButtonTypePressed == "operator")
            {
                int newDisplayLenght = displayContent.Length - 1;
                string display = displayContent.Substring(0, newDisplayLenght);
                display += pressedButtonValue;
                displayContent = display;
            }
            else
            {
                lastButtonTypePressed = "operator";
                displayContent += pressedButtonValue;
            }

            return;
        }


        public void InsertParenthesisInDisplay(string value)
        {
            MessageBox.Show(lastButtonTypePressed);

            if(lastButtonTypePressed == "number" && value != ")")
            {
                displayContent += "*(";
                lastButtonTypePressed = "left_parenthesis";
                return;
            }

            if(displayContent == "0" && value == "(")
            {
                displayContent = value;
                lastButtonTypePressed = "left_parenthesis";
                return;
            }

            if(lastButtonTypePressed == "operator" && value == ")")
            {
                return;
            }

            if(lastButtonTypePressed == "right_parenthesis" && value == "(")
            {
                lastButtonTypePressed = "left_parenthesis";
                value = "*(";
                displayContent += value;
                return;
            }

            displayContent += value;

            if(value == "(")
            {
                lastButtonTypePressed = "left_parenthesis";
            }
            else
            {
                lastButtonTypePressed = "right_parenthesis";
            }

        }




        public void InsertConstInDisplay(string constValue)
        {
            isFloat = true;
            hasCalculate = false;
            isNumber = true;
            MessageBox.Show(lastButtonTypePressed);
            if (lastButtonTypePressed == "float")
            {
                return;
            }

            if (displayContent == "0")
            {
                displayContent = constValue;
                lastButtonTypePressed = "const";
                return;
            }

            if(lastButtonTypePressed != "operator" || lastButtonTypePressed != "backspace")
            {
                constValue = "*" + constValue;
            }

            lastButtonTypePressed = "const";
            displayContent += constValue;
        }



        /// <summary>
        /// Método que limpa o display e atualiza as flags
        /// </summary>
        public void ClearDisplay()
        {
            lastButtonTypePressed = "number";
            displayContent = "0";
            result = "";
            isFloat = false;
            isNumber = true;
            isOperation = false;
            hasConst = false;
            hasCalculate = false;
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
                if (hasConst)
                {
                    expression = expression.Replace("e", E.ToString());
                    expression = expression.Replace("π", PI.ToString());
                }
                expression = expression.Replace(",", ".");
                MessageBox.Show(expression);
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
