using Calculadora.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Calculadora.Database.Managers
{
    public class HistoryManager : BaseManager
    {
        private const int MAX_NUMBER_INSTANCES = 10;
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


        public async void DeleteFirstHistory()
        {
            context.Histories.Remove(context.Histories.First());
            await context.SaveChangesAsync();
        }


        public void MaintainHistory()
        {
            if(context.Histories.Count() > MAX_NUMBER_INSTANCES)
            {
                DeleteFirstHistory();
            }
        }


        public async void DeleteAllHistory()
        {
            await context.Histories.ExecuteDeleteAsync();
            await context.SaveChangesAsync();

        }

    }
}