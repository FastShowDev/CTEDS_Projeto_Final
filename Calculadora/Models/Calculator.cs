using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class Calculator
    {
        #region CONSTANTS
        public readonly string DECIMAL_SPERATOR = ",";

        public readonly double PI = Math.PI;
        public readonly double E = Math.E;
        #endregion

        #region Properties
        public bool isNumber { get; set; }
        public bool isFloat { get; set; }
        public bool isOperation { get; set; }
        public bool canCalculate { get; set; }
        public string displayContent { get; set; } = "0";
        public string? calculation { get; set; }
        public string? lastButtonPressed { get; set; }
        #endregion
    }
}
