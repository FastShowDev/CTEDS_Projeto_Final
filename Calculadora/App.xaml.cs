using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Calculadora.Database;
using Calculadora.Models;
using Calculadora.View;
using Calculadora.ViewModels;
using Calculadora.Stores;
using System.Runtime.CompilerServices;
using Calculadora.Database.Managers;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data source = Histories.db";

        private readonly NavigationStore _navigationStore;
        private readonly HistoryManager _historyManager;

        public App()
        {
            _navigationStore = new NavigationStore();

            DbContextOptions<CalculatorDbContext> contextOptions = new DbContextOptionsBuilder<CalculatorDbContext>().UseSqlite(CONNECTION_STRING).Options;
            CalculatorDbContext context = new CalculatorDbContext(contextOptions);

            _historyManager = new HistoryManager(context);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore.CurrentViewModel = CreateStandardViewModel();

            MainWindow tela = new MainWindow();
            tela.DataContext = new MainViewModel();
            tela.Show();


            base.OnStartup(e);

        }

        private StandardCalculatorViewModel CreateStandardViewModel()
        {
            return StandardCalculatorViewModel.LoadViewModel();
        }

        private ScientificCalculatorViewModel CreateScientificViewModel()
        {
            return new ScientificCalculatorViewModel();
        }
    }
}
