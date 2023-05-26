using System.ComponentModel;

namespace Calculadora.ViewModels
{
    public class LinearAlgebraViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public bool IsEscalarProduct { get; set; }
        public bool IsVectorialProduct { get; set; }
        public bool IsMixedProduct { get; set; }
        public double EscalarResult { get; set; }
        public LinearAlgebraViewModel()
        {
            IsEscalarProduct = true;
            IsVectorialProduct = false;
            IsMixedProduct = false;

            EscalarResult = 0;

            ViewName = "Álgebra Linear";
            ViewHeight = 800;
            ViewWidth = 800;
        }

        public void SelectEscalarProduct()
        {
            IsEscalarProduct = true;
            IsVectorialProduct = false;
            IsMixedProduct = false;
        }

        public void SelectVectorialProduct()
        {
            IsEscalarProduct = false;
            IsVectorialProduct = true;
            IsMixedProduct = false;
        }

        public void SelectMixedProduct()
        {
            IsEscalarProduct = false;
            IsVectorialProduct = false;
            IsMixedProduct = true;
        }
    }
}
