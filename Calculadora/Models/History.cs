using System;

namespace Calculadora.Models
{
    public class History
    {
        public int Id { get; set; }
        public string FullExpression { get; set; } = string.Empty;
        public string Expression { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;

        public History()
        {

        }

        public History(string expression, string result)
        {
            this.Expression = expression;
            this.Result = result;
            this.FullExpression = String.Concat(expression, "=", result);
        }


    }
}
