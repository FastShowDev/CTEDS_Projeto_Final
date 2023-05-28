using System;

namespace Calculadora.Models.MatricesModels
{
    public class QuadraticMatrix : Matrix
    {
        public double determinant { get; set; } 
        public int order { get; set; }
        public bool IsSingular { get; set; }
        public QuadraticMatrix(int order) : base(order, order)
        {
            this.order = order;
            determinant = 0;
            IsSingular = false;
        }

        public QuadraticMatrix(int order, double standardValue) : base(order, order, standardValue)
        {
            this.order = order;
            determinant = 0;
            IsSingular = false;
            
        }

    }
}
