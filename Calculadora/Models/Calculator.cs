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
        public const string DECIMAL_SPERATOR = ",";

        public const double PI = Math.PI;
        public const double E = Math.E;
        #endregion

        #region Properties
        public bool isNumber { get; set; }
        public bool isFloat { get; set; }
        public bool isOperation { get; set; }
        public string? calculation { get; set; }
        public string? lastButtonPressed { get; set; }

        #endregion
    }
}
