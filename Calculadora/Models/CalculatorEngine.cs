using System;

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
        public static bool HasExponentiation { get; set; }
        #endregion

        #region AUXILIAR METHODS
        /// <summary>
        /// Método auxiliar utilizado para resetar todas flags da calculadora
        /// </summary>
        public static void ResetFlags()
        {
            HasConst = false;
            HasCalculate = false;
            HasPercentage = false;
            HasExponentiation = false;
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

                double result = double.Parse((string)row["expression"]);

                if (result.Equals(double.NaN))
                {
                    throw new Exception();
                }
                return result;
            }
            catch { throw new Exception("Expressão inválida"); }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna a raiz do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor da raiz da expressão calculada</returns>
        public static double SquareRoot(string expression)
        {
            double rooting = CalculateExpression(expression);
            if(rooting < 0)
            {
                throw new Exception("O número não pode ser negativo!");
            }
            return Math.Sqrt(rooting);

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
            catch { throw new Exception("Expressão inválida"); }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o logatimo de base 10 do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do log10 da expressão calculada</returns>
        public static double Log10(string expression)
        {
            double argument = CalculateExpression(expression);
            if(argument <= 0)
            {
                throw new Exception("O argumento deve ser maior que zero");
            }

            try
            {
                return Math.Log10(argument);
            }
            catch { throw new Exception("Expressão inválida"); }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o logaritmo neperiano do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do ln da expressão calculada</returns>
        public static double Ln(string expression)
        {
            double argument = CalculateExpression(expression);

            if (argument <= 0)
            {
                throw new Exception("O argumento deve ser maior que zero");
            }

            try
            {
                return Math.Log(argument);
            }
            catch { throw new Exception("Expressão inválida"); }
        }


        /// <summary>
        /// Método que recebe uma expressão matemática simples e calcula essa expressão e retorna o inverso do valor calculado.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Um double contendo o valor do inverso da expressão calculada</returns>
        public static double Inversion(string expression)
        {
            double rooting = CalculateExpression(expression);
            if(rooting == 0)
            {
                throw new Exception("Não é possível dividir por zero!");
            }

            try
            {
                return 1 / rooting;
            }
            catch { throw new Exception("Expressão inválida"); }
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
            catch { throw new Exception("Expressão inválida"); }
        }


        public static int Factorial(string expression)
        {
            int number = Convert.ToInt32(CalculateExpression(expression));
            if(number < 0)
            {
                throw new Exception("O número deve ser não negativo!");
            }

            return RecursiveFactorial(number);

        }
        

        private static int RecursiveFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            return number * RecursiveFactorial(number - 1);
        }


        public static double PowerBase10(string expression)
        {
            double exponent = CalculateExpression(expression);
            try
            {
                return Math.Pow(10, exponent);
            }
            catch { throw new Exception("Expressão inválida"); }
        }


        public static double PowerBase2(string expression)
        {
            double exponent = CalculateExpression(expression);
            try
            {
                return Math.Pow(2, exponent);
            }
            catch { throw new Exception("Expressão inválida"); }
        }


        public static double PowerBaseX(string baseExpression, string exponentExpression)
        {
            double baseValue = CalculateExpression(baseExpression);
            double exponentValue = CalculateExpression(exponentExpression);
            try
            {
                return Math.Pow(baseValue, exponentValue);
            }
            catch { throw new Exception("Expressão inválida"); }
        }
        #endregion
    }
}
