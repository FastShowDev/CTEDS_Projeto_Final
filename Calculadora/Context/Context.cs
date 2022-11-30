using Calculadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<History> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.HasData(
                    new History
                    {
                        Id = new Guid(),
                        expression = "18+4-2+5",
                        result = "25",
                    },
                    new History
                    {
                        Id = new Guid(),
                        expression = "",
                        result = "",
                    });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
