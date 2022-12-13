using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class History
    {
        public int Id { get; set; }
        public string FullExpression { get; set; } = "";
        public string Expression { get; set; } = "";
        public string Result { get; set; } = "";

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
