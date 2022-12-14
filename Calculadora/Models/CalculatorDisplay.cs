using System;
using System.Collections.Generic;

namespace Calculadora.Models
{
    public static class CalculatorDisplay
    {
        /// <summary>
        /// Valores padrões do display
        /// </summary>
        #region DISPLAY DEFAULT VALUES
        private const string DECIMAL_SEPERATOR = ",";
        private const string DEFAULT_DISPLAY = "0";
        private const string DEFAULT_RESULT = "";
        #endregion

        /// <summary>
        /// Símbolos dos operadores do display
        /// </summary>
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

        /// <summary>
        /// Tipos possíveis dos botões da calculadora
        /// </summary>
        #region BUTTONS TYPES
        private const string NUMBER_BUTTON = "number";
        private const string OPERATOR_BUTTON = "operator";
        private const string FLOAT_BUTTON = "float";
        private const string CONST_BUTTON = "const";
        private const string L_PARENTHESIS_BUTTON = "left";
        private const string R_PARENTHESIS_BUTTON = "right";
        #endregion

        /// <summary>
        /// Nome dos botões 
        /// </summary>
        #region BUTTONS NAMES
        private const string FLOAT_BUTTON_NAME = "button_float";
        #endregion

        #region PROPERTIES
        public static string displayContent { get; set; } = "0";
        public static string result { get; set; } = "";
        private static string[] values = { "number" };
        private static Stack<string> lastButtonPressed { get; } = new Stack<string>(values);
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
            if (CalculatorEngine.HasCalculate)
            {
                ClearDisplay();
                return;
            }

            int lenght = displayContent.Length - 1;
            if (lenght > 0)
            {
                displayContent = displayContent.Substring(0, lenght);
                lastButtonPressed.Pop();
            }
            else if (CalculatorEngine.HasExponentiation)
            {
                displayContent = DEFAULT_DISPLAY;
                lastButtonPressed.Pop();
                lastButtonPressed.Push(NUMBER_BUTTON);
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
            lastButtonPressed.Clear();
            lastButtonPressed.Push(NUMBER_BUTTON);
            displayContent = DEFAULT_DISPLAY;
            result = DEFAULT_RESULT;
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

            if (lastButtonPressed.Peek() == R_PARENTHESIS_BUTTON || lastButtonPressed.Peek() == CONST_BUTTON)
            {
                pressedButtonValue = PLUS_SYMBOL + pressedButtonValue;
                lastButtonPressed.Push(OPERATOR_BUTTON);
            }

            displayContent += pressedButtonValue;
            lastButtonPressed.Push(NUMBER_BUTTON);
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


        /// <summary>
        /// Método que insere o símbolo de porcentagem no display:
        /// -Permite a inserção apenas após um número, concatenando com ele.
        /// </summary>
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
                lastButtonPressed.Push(NUMBER_BUTTON);
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
            if (lastButtonPressed.Peek() == OPERATOR_BUTTON && value == R_PARENTHESIS_SYMBOL)
            {
                return;
            }

            CalculatorEngine.HasCalculate = false;
            if (lastButtonPressed.Peek() == NUMBER_BUTTON && value != R_PARENTHESIS_SYMBOL)
            {
                displayContent += "*(";
                lastButtonPressed.Push(OPERATOR_BUTTON);
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
                value = "*(";
                displayContent += value;
                lastButtonPressed.Push(OPERATOR_BUTTON);
                lastButtonPressed.Push(L_PARENTHESIS_BUTTON);
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


        /// <summary>
        /// Método que insere constantes no display:
        /// </summary>
        /// <param name="constValue">Constânte matemática a ser inserida</param>
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
                lastButtonPressed.Push(OPERATOR_BUTTON);
            }

            lastButtonPressed.Push(CONST_BUTTON);
            displayContent += constValue;
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
                result = String.Concat(symbol, L_PARENTHESIS_SYMBOL, result, R_PARENTHESIS_SYMBOL);

            }
            else
            {
                result = String.Concat(symbol, L_PARENTHESIS_SYMBOL, expression, R_PARENTHESIS_SYMBOL);
            }
        }


        public static void InsertBaseExponentiation(string expression)
        {
            result = String.Concat(expression, EXPONENT_SYMBOL);
        }


    }
}
