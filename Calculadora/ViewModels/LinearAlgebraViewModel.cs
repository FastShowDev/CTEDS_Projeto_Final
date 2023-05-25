using System.ComponentModel;
using System;


namespace Calculadora.ViewModels
{
    public class LinearAlgebraViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public LinearAlgebraViewModel()
        {
            ViewName = "Álgebra Linear";
            ViewHeight = 800;
            ViewWidth = 800;
        }
    }
}
