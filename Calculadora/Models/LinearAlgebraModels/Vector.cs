using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class Vector
    {
        public double i { get; set; }
        public double j { get; set; }
        public double k { get; set; }
        public double module { get; set; }

        public Vector()
        {
            i = 0;
            j = 0;
            k = 0;
            module = 0;
        }
        public Vector(double i, double j, double k)
        {
            this.i = i;
            this.j = j;
            this.k = k;

            module = Math.Sqrt(i * i + j * j + k * k);
        }

        public void SetModule()
        {
            module = Math.Sqrt(i*i + j*j + k*k);
        }
    }
}
