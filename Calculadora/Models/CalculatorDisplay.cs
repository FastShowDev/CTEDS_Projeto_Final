using System;
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
        private const string EXPONENT_SYMBOL = "^";
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
        public static bool HasErrorMessage { get; set; }
        public static string DisplayContent { get; set; } = "0";
        public static string Result { get; set; } = "";
        private static readonly string[] Values = { "number" };
        private static Stack<string> LastButtonPressed { get; } = new Stack<string>(Values);
        private static bool HasDoubleOperator { get; set; }
        #endregion


        /// <summary>
        /// Método que aplica um backspace no display. Segue os seguintes critérios:
        /// -Caso um cálculo tenha sido acabado de ser realizado o método limpa todo o display
        /// -Caso o display tenha apenas um caracter ao chamar esse método limpa todo o display
        /// -Caso o display tenha mais de um caracter apenas remove o último caracter
        /// O método atualiza a pilha que contém todos os botões pressionados.
        /// </summary>
        public static void BackspaceDisplay()
        {
            if (HasErrorMessage)
            {
                HasErrorMessage = false;
                return;
            }

            if (CalculatorEngine.HasCalculate)
            {
                ClearDisplay();
                return;
            }

            HasDoubleOperator = false;
            int lenght = DisplayContent.Length - 1;
            if (lenght > 0)
            {
                DisplayContent = DisplayContent.Substring(0, lenght);
                LastButtonPressed.Pop();
            }
            else if (CalculatorEngine.HasExponentiation)
            {
                DisplayContent = DEFAULT_DISPLAY;
                LastButtonPressed.Pop();
                LastButtonPressed.Push(NUMBER_BUTTON);
            }
            else
            {
                ClearDisplay();
            }
            return;
        }


        /// <summary>
        /// Método que limpa todo o display e atualiza as flags da Engine da Calculadora
        /// </summary>
        public static void ClearDisplay()
        {
            LastButtonPressed.Clear();
            LastButtonPressed.Push(NUMBER_BUTTON);
            DisplayContent = DEFAULT_DISPLAY;
            Result = DEFAULT_RESULT;
            HasErrorMessage = false;
            HasDoubleOperator = false;
            CalculatorEngine.ResetFlags();
        }


        /// <summary>
        /// Método que insere um número no display e vírgula para casa decimal. Usa os seguintes critérios:
        /// -Não permite colocar vírgulas seguidas
        /// -Caso o último caracter for um parênteses direito, o símbolo de multiplicação é colocado automaticamente.
        /// -Caso o último caracter for uma constânte, o símbolo de multiplicação é colocado automaticament.
        /// </summary>
        /// <param name="buttonName">Nome do botão pressionado</param>
        /// <param name="pressedButtonValue">Valor do botão pressionado</param>
        /// <returns></returns>
        public static void InsertNumberInDisplay(string buttonName, string pressedButtonValue)
        {
            if (HasErrorMessage)
            {
                HasErrorMessage = false;
            }

            CalculatorEngine.HasCalculate = false;
            HasDoubleOperator = false;
            if (DisplayContent == DEFAULT_DISPLAY && pressedButtonValue != DECIMAL_SEPERATOR)
            {
                DisplayContent = pressedButtonValue;
                LastButtonPressed.Push(NUMBER_BUTTON);
                return;
            }

            if (buttonName == FLOAT_BUTTON_NAME)
            {
                if (LastButtonPressed.Peek() == FLOAT_BUTTON)
                {
                    return;
                }
                LastButtonPressed.Push(FLOAT_BUTTON);
                DisplayContent += pressedButtonValue;
                return;
            }

            if (LastButtonPressed.Peek() == R_PARENTHESIS_BUTTON || LastButtonPressed.Peek() == CONST_BUTTON)
            {
                pressedButtonValue = PLUS_SYMBOL + pressedButtonValue;
                LastButtonPressed.Push(OPERATOR_BUTTON);
            }

            DisplayContent += pressedButtonValue;
            LastButtonPressed.Push(NUMBER_BUTTON);
            return;
        }


        /// <summary>
        /// Método que insere um operador no display:
        /// -Caso o último botão pressionado for um parênteses esquerdo, não permite a inserção do operador.
        /// -Caso o último botão pressionado foi um operador, ou seja, o último caracter do display for um operador aritmético atualiza para o novo operador pressionado.
        /// -Caso o último botão pressionado foi um número, apenas adiciona o operador pressionado ao display.
        /// </summary>
        /// <param name="pressedButtonValue">Operador pressionado</param>
        /// <returns></returns>
        public static void InsertOperatorInDisplay(string pressedButtonValue)
        {
            if (LastButtonPressed.Peek() == L_PARENTHESIS_BUTTON)
            {
                if(pressedButtonValue == MINUS_SYMBOL)
                {
                    LastButtonPressed.Push(OPERATOR_BUTTON);
                    DisplayContent += pressedButtonValue;
                }

                return;
            }

            CalculatorEngine.HasCalculate = false;
            if (LastButtonPressed.Peek() == OPERATOR_BUTTON)
            {
                if (HasDoubleOperator)
                {
                    return;
                }

                string lastOperator = DisplayContent.Substring(DisplayContent.Length - 1, 1);
                if(lastOperator == TIMES_SYMBOL  || lastOperator == DIVIDES_SYMBOL)
                {
                    if(pressedButtonValue == MINUS_SYMBOL)
                    {
                        LastButtonPressed.Push(OPERATOR_BUTTON);
                        DisplayContent += pressedButtonValue;
                        HasDoubleOperator = true;
                        return;
                    } 
                }

                int newDisplayLenght = DisplayContent.Length - 1;
                string display = DisplayContent.Substring(0, newDisplayLenght);
                display += pressedButtonValue;
                DisplayContent = display;
            }
            else
            {
                LastButtonPressed.Push(OPERATOR_BUTTON);
                DisplayContent += pressedButtonValue;
            }

            return;
        }


        /// <summary>
        /// Método que insere o símbolo de porcentagem no display:
        /// -Permite a inserção apenas após um número, concatenando com ele.
        /// </summary>
        public static void InsertPercentageInDisplay()
        {
            if (LastButtonPressed.Peek() == OPERATOR_BUTTON)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            if (LastButtonPressed.Peek() == NUMBER_BUTTON)
            {
                DisplayContent += PERCENTAGE_SYMBOL;
                LastButtonPressed.Push(NUMBER_BUTTON);
                CalculatorEngine.HasPercentage = true;
            }
        }


        /// <summary>
        /// Método que insere parênteses no display:
        /// -Caso o último botão pressionado for um operador e o valor pressionado for parênteses direito, não permite a inserção
        /// -Caso o último botão pressionado foi um parênteses direito e o valor pressionado for um esquerdo, insere o simbolo de
        /// multiplicação automaticamente.
        /// -Caso o último número pressionado foi um número e o valor pressionado for parênteses esquerdo, insere o símbolo de
        /// multiplicação automaticamente.
        /// </summary>
        /// <param name="value"></param>
        public static void InsertParenthesisInDisplay(string value)
        {
            if (LastButtonPressed.Peek() == OPERATOR_BUTTON && value == R_PARENTHESIS_SYMBOL)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            HasDoubleOperator = false;
            if(DisplayContent == DEFAULT_DISPLAY && value == L_PARENTHESIS_SYMBOL)
            {
                LastButtonPressed.Pop();
                LastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                DisplayContent = value;
                return;
            }

            if (LastButtonPressed.Peek() == NUMBER_BUTTON && value != R_PARENTHESIS_SYMBOL)
            {
                DisplayContent += "*(";
                LastButtonPressed.Push(OPERATOR_BUTTON);
                LastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                return;
            }

            if (DisplayContent == DEFAULT_DISPLAY && value == L_PARENTHESIS_SYMBOL)
            {
                DisplayContent = value;
                LastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                return;
            }

            if (LastButtonPressed.Peek() == R_PARENTHESIS_BUTTON && value == L_PARENTHESIS_SYMBOL)
            {
                value = "*(";
                DisplayContent += value;
                LastButtonPressed.Push(OPERATOR_BUTTON);
                LastButtonPressed.Push(L_PARENTHESIS_BUTTON);
                return;
            }

            DisplayContent += value;

            if (value == L_PARENTHESIS_SYMBOL)
            {
                LastButtonPressed.Push(L_PARENTHESIS_BUTTON);
            }
            else
            {
                LastButtonPressed.Push(R_PARENTHESIS_BUTTON);
            }

        }


        /// <summary>
        /// Método que insere constantes no display:
        /// </summary>
        /// <param name="constValue">Constânte matemática a ser inserida</param>
        public static void InsertConstInDisplay(string constValue)
        {
            if (LastButtonPressed.Peek() == FLOAT_BUTTON)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            CalculatorEngine.HasConst = true;

            if (DisplayContent == "0")
            {
                DisplayContent = constValue;
                LastButtonPressed.Pop();
                LastButtonPressed.Push(CONST_BUTTON);
                return;
            }

            if (LastButtonPressed.Peek() != OPERATOR_BUTTON && LastButtonPressed.Peek() != L_PARENTHESIS_BUTTON)
            {
                constValue = TIMES_SYMBOL + constValue;
                LastButtonPressed.Push(OPERATOR_BUTTON);
            }

            LastButtonPressed.Push(CONST_BUTTON);
            DisplayContent += constValue;
        }


        /// <summary>
        /// Método auxiliar genérico para inserir o símbolo de uma função e a expressão que foi calculada dentro da função. Usado
        /// para inserir os símbolos no display após pressionar os botões de raiz, log, ln, etc. O método pode ser utilizado
        /// para adicionar símbolos personalizados como no caso de x^y, onde x^ seria o símbolo e y a expressão.
        /// </summary>
        /// <param name="symbol">Símbolo da função pressionada</param>
        /// <param name="expression">Expressão na qual á função foi calculada em cima</param>
        public static void InsertSymbolInResult(string symbol, string expression)
        {
            if (CalculatorEngine.HasCalculate)
            {
                Result = String.Concat(symbol, L_PARENTHESIS_SYMBOL, Result, R_PARENTHESIS_SYMBOL);

            }
            else
            {
                Result = String.Concat(symbol, L_PARENTHESIS_SYMBOL, expression, R_PARENTHESIS_SYMBOL);
            }
        }


        public static void InsertBaseExponentiation(string expression)
        {
            Result = String.Concat(expression, EXPONENT_SYMBOL);
        }


    }
}
