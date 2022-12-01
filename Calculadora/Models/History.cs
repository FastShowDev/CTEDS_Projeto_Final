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
        public string? Expression { get; set; }
        public string? Result { get; set; }
    }
}
