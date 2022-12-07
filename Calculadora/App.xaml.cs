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

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            ServiceCollection services = new();
            _navigationStore = new NavigationStore();

            services.AddDbContext<CalculatorDbContext>(options =>
            {
                options.UseSqlite("Data source = Histories.db");
            });

            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore.CurrentViewModel = new StandardCalculatorViewModel();

            MainWindow = serviceProvider.GetService<MainWindow>();
            MainWindow.DataContext = new MainViewModel();
            MainWindow.Show();


            base.OnStartup(e);

        }
    }
}
