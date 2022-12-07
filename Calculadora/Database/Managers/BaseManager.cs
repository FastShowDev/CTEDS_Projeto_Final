using System;
namespace Calculadora.Database.Managers
{
    public class BaseManager
    {
        public CalculatorDbContext context { get; }
        public BaseManager(CalculatorDbContext context)
        {
            this.context = context;
        }
    }
}