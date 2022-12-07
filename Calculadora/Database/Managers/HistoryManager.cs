using Calculadora.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora.Database.Managers
{
    public class HistoryManager : BaseManager
    {
        public HistoryManager(CalculatorDbContext context) : base(context)
        {

        }

        public async Task<List<History>> GetAllHistories()
        {
            List<History> histories = await context.Histories.ToListAsync();
            return histories;
        }
        

        public async void AddHistory(History history)
        {
            context.Histories.Add(history);
            await context.SaveChangesAsync();
        }

        public async void DeleteHistory(History history)
        {
            context.Histories.Remove(history);
            await context.SaveChangesAsync();
        }
    }
}