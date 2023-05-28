using System;

namespace Calculadora.Models
{
    public class CalculatorHistory
    {
        public int Id { get; set; }
        public string FullExpression { get; set; } = string.Empty;
        public string Expression { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;

        public CalculatorHistory()
        {

        }

        public CalculatorHistory(string expression, string result)
        {
            this.Expression = expression;
            this.Result = result;
            this.FullExpression = String.Concat(expression, "=", result);
        }


    }
}
