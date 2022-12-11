using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculadora.Models
{
    public static class CalculatorDisplay
    {
        #region DISPLAY DEFAULT VALUES
        private const string DECIMAL_SEPERATOR = ",";
        private const string DEFAULT_DISPLAY = "0";
        private const string DEFAULT_RESULT = "";
        #endregion

        #region SYMBOLS
        private const string PLUS_SYMBOL = "+";
        private const string MINUS_SYMBOL = "-";
        private const string TIMES_SYMBOL = "*";
        private const string DIVIDES_SYMBOL = "/";
        private const string PERCENTAGE_SYMBOL = "%";
        private const string L_PARENTHESIS_SYMBOL = "(";
        private const string R_PARENTHESIS_SYMBOL = ")";
        #endregion

        #region BUTTONS TYPES
        private const string NUMBER_BUTTON = "number";
        private const string OPERATOR_BUTTON = "operator";
        private const string FLOAT_BUTTON = "float";
        private const string CONST_BUTTON = "const";
        private const string L_PARENTHESIS_BUTTON = "left";
        private const string R_PARENTHESIS_BUTTON = "right";
        #endregion

        #region BUTTONS NAMES
        private const string FLOAT_BUTTON_NAME = "button_float";
        #endregion

        #region PROPERTIES
        public static string displayContent { get; set; } = "0";
        public static string result { get; set; } = "";
        private static string[] values = { "number" };
        public static Stack<string> lastButtonPressed { get; } = new Stack<string>(values);
        #endregion


        /// <summary>
        /// Método que aplica um backspace no display.Segue os seguintes critérios:
        /// -Caso um cálculo tenha sido acabado de ser realizado o método limpa todo o display
        /// -Caso o display tenha apenas um caracter ao chamar esse método limpa todo o display
        /// -Caso o display tenha mais de um caracter apenas remove o último caracter
        /// </summary>
        public static void BackspaceDisplay()
        {
            lastButtonPressed.Pop();

            if (CalculatorEngine.HasCalculate)
            {
                ClearDisplay();
                return;
            }

            int lenght = displayContent.Length - 1;
            if (lenght > 0)
            {
                displayContent = displayContent.Substring(0, lenght);
            }
            else
            {
                ClearDisplay();
            }
            return;
        }

        /// <summary>
        /// Método que limpa todo o display e atualiza as flags do CalculatorEngine
        /// </summary>
        /// <param>/</param>
        /// <returns></returns>
        public static void ClearDisplay()
        {
            lastButtonPressed.Clear();
            lastButtonPressed.Push(NUMBER_BUTTON);
            displayContent = DEFAULT_DISPLAY;
            result = DEFAULT_RESULT;
            CalculatorEngine.ResetFlags();
        }

        /// <summary>
        /// Método que insere um número no display e vírgula para casa decimal. Usando os seguintes critérios:
        /// 
        /// -Não permite colocar vírgulas seguidas
        /// -Caso o último caracter for um parênteses direito o símbolo de multiplicação é colocado automaticamente.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="pressedButtonValue"></param>
        /// <returns></returns>
        public static void InsertNumberInDisplay(string buttonName, string pressedButtonValue)
        {
            CalculatorEngine.HasCalculate = false;
            if (displayContent == DEFAULT_DISPLAY && pressedButtonValue != DECIMAL_SEPERATOR)
            {
                displayContent = pressedButtonValue;
                lastButtonPressed.Push(NUMBER_BUTTON);
                return;
            }

            if (buttonName == FLOAT_BUTTON_NAME)
            {
                if (lastButtonPressed.Peek() == FLOAT_BUTTON)
                {
                    return;
                }
                lastButtonPressed.Push(FLOAT_BUTTON);
                displayContent += pressedButtonValue;
                return;
            }

            if (lastButtonPressed.Peek() == R_PARENTHESIS_BUTTON)
            {
                pressedButtonValue = PLUS_SYMBOL + pressedButtonValue;
            }

            displayContent += pressedButtonValue;
            lastButtonPressed.Push(NUMBER_BUTTON);
            return;
        }

        /// <summary>
        /// Método que insere um operador no display:
        /// Caso o último botão pressionado foi um operador, ou seja, o último caracter do display for um operador aritmético atualiza para o novo operador pressionado.
        /// Caso o último botão pressionado foi um número, apenas adiciona o operador pressionado ao display.
        /// </summary>
        /// <param name="pressedButtonValue"></param>
        /// <returns></returns>
        public static void InsertOperatorInDisplay(string pressedButtonValue)
        {
            if (lastButtonPressed.Peek() == L_PARENTHESIS_BUTTON)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            if (lastButtonPressed.Peek() == OPERATOR_BUTTON)
            {
                int newDisplayLenght = displayContent.Length - 1;
                string display = displayContent.Substring(0, newDisplayLenght);
                display += pressedButtonValue;
                displayContent = display;
            }
            else
            {
                lastButtonPressed.Push(OPERATOR_BUTTON);
                displayContent += pressedButtonValue;
            }

            return;
        }


        public static void InsertPercentageInDisplay()
        {
            if (lastButtonPressed.Peek() == OPERATOR_BUTTON)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            if (lastButtonPressed.Peek() == NUMBER_BUTTON)
            {
                displayContent += PERCENTAGE_SYMBOL;
                CalculatorEngine.HasPercentage = true;
            }
        }


        public static void InsertParenthesisInDisplay(string value)
        {
            if (lastButtonPressed.Peek() == OPERATOR_BUTTON && value == R_PARENTHESIS_SYMBOL)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            if (lastButtonPressed.Peek() == NUMBER_BUTTON && value != R_PARENTHESIS_SYMBOL)
            {
                displayContent += "*(";
                lastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                return;
            }

            if (displayContent == DEFAULT_DISPLAY && value == L_PARENTHESIS_SYMBOL)
            {
                displayContent = value;
                lastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                return;
            }

            if (lastButtonPressed.Peek() == R_PARENTHESIS_BUTTON && value == L_PARENTHESIS_SYMBOL)
            {
                lastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                value = "*(";
                displayContent += value;
                return;
            }

            displayContent += value;

            if (value == L_PARENTHESIS_SYMBOL)
            {
                lastButtonPressed.Push(L_PARENTHESIS_BUTTON);
            }
            else
            {
                lastButtonPressed.Push(R_PARENTHESIS_BUTTON);
            }

        }


        public static void InsertConstInDisplay(string constValue)
        {
            if (lastButtonPressed.Peek() == FLOAT_BUTTON)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            CalculatorEngine.HasConst = true;

            if (displayContent == "0")
            {
                displayContent = constValue;
                lastButtonPressed.Push(CONST_BUTTON);
                return;
            }

            if (lastButtonPressed.Peek() != OPERATOR_BUTTON)
            {
                constValue = TIMES_SYMBOL + constValue;
            }

            lastButtonPressed.Push(CONST_BUTTON);
            displayContent += constValue;
        }


        public static void InsertSymbolInResult(string symbol, string expression)
        {
            if (CalculatorEngine.HasCalculate)
            {
                result = String.Concat(symbol, L_PARENTHESIS_SYMBOL, result, R_PARENTHESIS_SYMBOL);

            }
            else
            {
                result = String.Concat(symbol, L_PARENTHESIS_SYMBOL, expression, R_PARENTHESIS_SYMBOL);
            }
        }
    }
}
