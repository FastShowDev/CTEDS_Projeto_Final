﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace Calculadora.Models
{
    public static class Calculator
    {
        /// <summary>
        /// Constantes mamáticos e separadores de ponto flutuante
        /// </summary>
        #region CONSTANTS
        private const string DECIMAL_SPERATOR = ",";
        private const double PI = Math.PI;
        private const double E = Math.E;
        #endregion

        /// <summary>
        /// Constantes com os símbolos que são mostrados no display.
        /// </summary>
        #region FUNCTIONS SYMBOLS
        private const string SQUARE_ROOT_SYMBOL = "sqrt";
        private const string SQUARE_SYMBOL = "sqr";
        private const string LOG_SYMBOL = "log";
        private const string LN_SYMBOL = "ln";
        private const string ABSOLUTE_SYMBOL = "abs";
        private const string INVERSION_SYMBOL = "1/";
        private const string FACTORIAL_SYMBOL = "fact";
        private const string BASE_10_SYMBOL = "10^";
        private const string BASE_2_SYMBOL = "2^";
        #endregion


        /// <summary>
        /// Método que recebe uma expressão matemática simples, realiza seu cálculo utilizando a Engine da Calculadora
        /// e atualiza o display da calculadora (conteúdo e resultado).
        /// </summary>
        /// <param name="expression">Expressão matemática simples</param>
        public static void ExecuteCalculate(string expression)
        {
            CalculatorDisplay.result = expression;
            CalculatorDisplay.displayContent = CalculatorEngine.CalculateExpression(expression).ToString();
            CalculatorEngine.HasCalculate = true;
            return;
        }


        /// <summary>
        /// Método que executa a funcionalidade de elevar ao quadrado. Recebe uma expressão, calcula seu resultado usando a Engine e em seguida
        /// eleva ao quadrado o resultado obtido e por fim atualiza o display da calculadora.
        /// </summary>
        /// <param name="expression">Expressão que será calculada e elevada ao quadrado</param>
        public static void ExecuteSquare(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Square(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(SQUARE_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        /// <summary>
        /// Método que executa a funcionalidade de raiz quadrada. Recebe uma expressão, calcula seu resultado usando a Engine e em seguida
        /// calcula  a raiz do resultado obtido e por fim atualiza o display da calculadora. Em caso de uma expressão inválida a própria Engine
        /// faz o tratamento de excessão.
        /// </summary>
        /// <param name="expression">Expressão que será calculada e depois tirada a raiz</param>
        public static void ExecuteSquareRoot(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.SquareRoot(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(SQUARE_ROOT_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        /// <summary>
        /// Método que executa a funcionalidade de logaritmo de base 10. Recebe uma expressão, calcula seu resultado usando a Engine e em seguida
        /// calcula o log10 do resultado obtido e por fim atualiza o display da calculadora. Em caso de uma expressão inválida a Engine faz o
        /// tratamento da excessão.
        /// </summary>
        /// <param name="expression">Expressão que será calculado o log10</param>
        public static void ExecuteLog10(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Log10(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(LOG_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        /// <summary>
        /// Método que executa a funcionalidade de logaritmo neperiano. Recebe uma expressão, calcula seu resultado usando a Engine e em seguida
        /// calcula o ln do resultado obtido e por fim atualiza o display da calculadora. Em caso de uma expressão inválida a Engine faz o
        /// tratamento da excessão.
        /// </summary>
        /// <param name="expression">Expressão que será calculado o ln</param>
        public static void ExecuteLn(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Ln(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(LN_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        /// <summary>
        /// Método que executa a funcionalidade de inversão de número. Recebe uma expressão, calcula seu resultado usando a Engine e em seguida
        /// calcula o inverso do número obtido e por fim atualiza o display da calculadora. Em caso de uma expressão inválida a Engine faz o
        /// tratamento da excessão.
        /// </summary>
        /// <param name="expression">Expressão que será calculado o inverso</param>
        public static void ExecuteInversion(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Inversion(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(INVERSION_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        /// <summary>
        /// Método que executa a funcionalidade de módulo. Recebe uma expressão, calcula seu resultado usando a Engine e em seguida
        /// calcula o módulo do resultado obtido e por fim atualiza o display da calculadora.
        /// </summary>
        /// <param name="expression"></param>
        public static void ExecuteAbsolute(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Absolute(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(ABSOLUTE_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        public static void ExecuteFactorial(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Factorial(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(FACTORIAL_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }

        public static void ExecutePowerBase2(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.PowerBase2(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(BASE_2_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }

        public static void ExecutePowerBase10(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.PowerBase10(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(BASE_10_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }

        public static void ExecutePowerBaseX(string baseExpression, string exponentExpression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.PowerBaseX(baseExpression, exponentExpression).ToString();
            CalculatorDisplay.InsertSymbolInResult(baseExpression, exponentExpression);
            CalculatorEngine.HasCalculate = true;
            CalculatorEngine.HasExponentiation = false;
            return;
        }


    }
}
