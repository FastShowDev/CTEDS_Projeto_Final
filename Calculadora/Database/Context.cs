using Calculadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.HasData(
                    new History
                    {
                        Id = 1,
                        fullExpression = "18+4-2+5 = 25",
                        expression = "18+4-2+5",
                        result = "25",
                    },
                    new History
                    {
                        Id = 2,
                        fullExpression = "30*3+2/2-1 = 90",
                        expression = "30*3+2/2-1",
                        result = "90",
                    });
            });

            modelBuilder.Entity<History>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
