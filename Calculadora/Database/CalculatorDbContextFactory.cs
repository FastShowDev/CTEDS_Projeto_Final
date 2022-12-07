using Microsoft.EntityFrameworkCore;

namespace Calculadora.Database
{
    public class CalculatorDbContextFactory
    {
        private readonly string _connectionString;

        public CalculatorDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CalculatorDbContext CreateDbContext()
        {
            DbContextOptions<CalculatorDbContext> options = new DbContextOptionsBuilder<CalculatorDbContext>().UseSqlite(_connectionString).Options;
            return new CalculatorDbContext(options);
        }


    }
}