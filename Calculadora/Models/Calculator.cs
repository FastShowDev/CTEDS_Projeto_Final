using System;
using System.Collections.Generic;
using System.Windows;

namespace Calculadora.Models
{
    public static class Calculator
    {
        #region CONSTANTS
        private const string DECIMAL_SPERATOR = ",";
        private const double PI = Math.PI;
        private const double E = Math.E;
        #endregion

        #region FUNCTIONS SYMBOLS
        private const string SQUARE_ROOT_SYMBOL = "sqrt";
        private const string SQUARE_SYMBOL = "sqr";
        private const string LOG_SYMBOL = "log";
        private const string LN_SYMBOL = "ln";
        private const string ABSOLUTE_SYMBOL = "abs";
        private const string INVERSION_SYMBOL = "1/";
        #endregion


        public static void ExecuteCalculate(string expression)
        {
            CalculatorDisplay.result = expression;
            CalculatorDisplay.displayContent = CalculatorEngine.CalculateExpression(expression).ToString();
            CalculatorEngine.HasCalculate = true;
            return;
        }

        public static void ExecuteSquare(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Square(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(SQUARE_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }

        public static void ExecuteSquareRoot(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.SquareRoot(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(SQUARE_ROOT_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        public static void ExecuteLog10(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Log10(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(LOG_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        public static void ExecuteLn(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Ln(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(LN_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        public static void ExecuteInversion(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Inversion(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(INVERSION_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


        public static void ExecuteAbsolute(string expression)
        {
            CalculatorDisplay.displayContent = CalculatorEngine.Absolute(expression).ToString();
            CalculatorDisplay.InsertSymbolInResult(ABSOLUTE_SYMBOL, expression);
            CalculatorEngine.HasCalculate = true;
            return;
        }


    }
}
