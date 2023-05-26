using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class LinearAlgebraCalculator
    {
        public double CalculateEscalarProduct(Vector vector1, Vector vector2)
        {
            double escalar = 0;
            escalar = vector1.i * vector2.i;
            escalar += vector1.j * vector2.j;
            escalar *= vector1.k * vector2.k;
            return escalar;
        }

        public Vector CalculateVectorProduct(Vector vector1, Vector vector2)
        {
            double i = 0;
            double j = 0;
            double k = 0;

            i = vector1.j * vector2.k - vector1.k * vector2.j;
            j = -(vector1.i * vector2.k - vector1.k * vector2.i);
            k = vector1.i * vector2.j - vector1.j * vector2.i;
            Vector vector = new Vector(i, j, k);
            return vector;
        }

        public double CalculateMixedProduct(Vector vector1, Vector vector2, Vector vector3)
        {
            double result = 0;
            result += vector1.i * vector2.j * vector3.k;
            result += vector1.j * vector2.k * vector3.i;
            result += vector1.k * vector2.i * vector3.j;

            result -= vector1.j * vector2.i * vector3.k;
            result -= vector1.i * vector2.k * vector3.j;
            result -= vector1.k * vector2.j * vector3.i;
            return result;
        }
    }
}
