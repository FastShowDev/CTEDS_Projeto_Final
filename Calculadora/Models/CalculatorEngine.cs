using System;
using System.Windows;

namespace Calculadora.Models
{
    public static class CalculatorEngine
    {
        #region CONSTANTS
        private static readonly double PI = Math.PI;
        private static readonly double E = Math.E;
        private static readonly string STRING_PI = Math.PI.ToString();
        private static readonly string STRING_E = Math.E.ToString();
        private static readonly string STRING_PERCENTAGE = "*0.01";
        #endregion


        #region SYMBOLS
        private static readonly string SYMBOL_E = "e";
        private static readonly string SYMBOL_PI = "π";
        private static readonly string SYMBOL_PERCENTAGE = "%";
        private static readonly string DECIMAL_SEPERATOR = ",";
        private static readonly string A_DECIMAL_SEPARATOR = ".";
        #endregion


        #region FLAGS
        public static bool HasCalculate { get; set; }
        public static bool HasConst { get; set; }
        public static bool HasPercentage { get; set; }
        #endregion

        #region AUXILIAR METHODS
        public static void ResetFlags()
        {
            HasConst = false;
            HasCalculate = false;
            HasPercentage = false;
        }
        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Método que recebe uma expressão matemática simples, contendo apenas operadores aritiméticos elementares, parênteses, 
        /// constantes matemáticas (e ou pi) e símbolos de porcentagem e faz seu cálculo.
        /// É necessário que a expressão esteja corretamente digitada, caso contrário mostra um MessageBox contendo um aviso de erro.
        /// 
        /// Exemplo de expressão correta: (10 + 3)*3 -4/3 + 5 ou (10+3)*3-4/3+5
        /// Exemplo de expressão incorreta: (10+3)*3--4/3( ou (10+3)*3 4/3++5
        /// 
        /// O cálculo é feito utilizando uma propriedade do DataTable de calcular expressões matemáticas simples
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor da expressão corretamente calculada, respeitando precedência de parênteses e operadores</returns>
        public static double CalculateExpression(string expression)
        {
            try
            {
                if (HasConst)
                {
                    expression = expression.Replace(SYMBOL_E, STRING_E);
                    expression = expression.Replace(SYMBOL_PI, STRING_PI);
                }
                if (HasPercentage)
                {
                    expression = expression.Replace(SYMBOL_PERCENTAGE, STRING_PERCENTAGE);
                }
                expression = expression.Replace(DECIMAL_SEPERATOR, A_DECIMAL_SEPARATOR);
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);

                return double.Parse((string)row["expression"]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna a raiz do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor da raiz da expressão calculada</returns>
        public static double SquareRoot(string expression)
        {
            double rooting = CalculateExpression(expression);

            try
            {
                return Math.Sqrt(rooting);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o quadrado do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor ao quadrado da expressão calculada</returns>
        public static double Square(string expression)
        {
            double value = CalculateExpression(expression);
            try
            {
                return Math.Pow(value, 2);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o logatimo de base 10 do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do log10 da expressão calculada</returns>
        public static double Log10(string expression)
        {
            double rooting = CalculateExpression(expression);

            try
            {
                return Math.Log10(rooting);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o logaritmo neperiano do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do ln da expressão calculada</returns>
        public static double Ln(string expression)
        {
            double rooting = CalculateExpression(expression);

            try
            {
                return Math.Log(rooting);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o inverso do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do inverso da expressão calculada</returns>
        public static double Inversion(string expression)
        {
            double rooting = CalculateExpression(expression);

            try
            {
                return 1 / rooting;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o módulo do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do módulo da expressão calculada</returns>
        public static double Absolute(string expression)
        {
            double rooting = CalculateExpression(expression);

            try
            {
                return Math.Abs(rooting);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }
        #endregion


    }
}
