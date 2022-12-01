using Calculadora.Database;
using Calculadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Calculadora.View
{
    /// <summary>
    /// Interaction logic for StandardCalculator.xaml
    /// </summary>
    public partial class StandardCalculator : Window
    {
        public Context myContext;
        public List<History> myHistories;
        public StandardCalculator()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            var contextOptions = new DbContextOptionsBuilder<Context>().UseSqlite("Data source = Test.db").Options;
            myContext = new Context(contextOptions);
            myHistories = myContext.Users.ToList();
        }
    }
}
