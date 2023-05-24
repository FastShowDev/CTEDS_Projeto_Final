using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.ViewModels
{
    public class MatricesViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public MatricesViewModel()
        {
            ViewName = "Matrizes";
            ViewHeight = 900;
            ViewWidth = 900;
        }
    }
}
