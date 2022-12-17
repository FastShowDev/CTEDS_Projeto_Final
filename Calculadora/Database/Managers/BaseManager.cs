using System;
namespace Calculadora.Database.Managers
{
    public class BaseManager
    {
        protected CalculatorDbContext context { get; }
        public BaseManager(CalculatorDbContext context)
        {
            this.context = context;
        }
    }
}