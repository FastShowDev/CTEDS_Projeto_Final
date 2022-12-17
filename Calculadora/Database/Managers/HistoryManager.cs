using Calculadora.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Calculadora.Database.Managers
{
    public class HistoryManager : BaseManager
    {
        private const int MAX_NUMBER_INSTANCES = 10;

        private List<History> _histories;
        private readonly Lazy<Task> _initializeLazy;
        public IEnumerable<History> Histories => _histories;


        public HistoryManager(CalculatorDbContext context) : base(context)
        {
            _histories = new List<History>();
            _initializeLazy = new Lazy<Task>(Initialize);
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        private async Task Initialize()
        {
            IEnumerable<History> histories = await GetAllHistories();

            _histories.Clear();
            _histories.AddRange(histories);
        }

        public async Task<List<History>> GetAllHistories()
        {
            List<History> histories = await context.Histories.ToListAsync();
            return histories;
        }
        

        public async Task AddHistory(History history)
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