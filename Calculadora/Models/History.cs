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
        public string fullExpression { get; set; }
        public string? expression { get; set; }
        public string? result { get; set; }
    }
}
