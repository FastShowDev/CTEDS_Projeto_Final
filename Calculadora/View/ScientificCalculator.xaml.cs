using Calculadora.Database;
using Calculadora.Models;
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

namespace Calculadora.View
{
    /// <summary>
    /// Interaction logic for ScientificCalculator.xaml
    /// </summary>
    public partial class ScientificCalculator : Window
    {
        public ScientificCalculator(Context context)
        {
            InitializeComponent();
        }
    }
}
