using Calculadora.Commands.LinearAlgebraCommands;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculadora.ViewModels
{
    public class LinearAlgebraViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private bool _isEscalar;
        public bool IsEscalarProduct {
            get
            {
                return _isEscalar;
            }
            set
            {
                if (value == _isEscalar) return;
                _isEscalar = value;
                OnPropertyChanged(nameof(IsEscalarProduct));
            } 
        }
        private bool _isVectorial;
        public bool IsVectorialProduct {
            get
            {
                return _isVectorial;
            }
            set
            {
                if (value == _isVectorial) return;
                _isVectorial = value;
                OnPropertyChanged(nameof(IsVectorialProduct));
            } 
        }
        private bool _isMixed;
        public bool IsMixedProduct { 
            get
            {
                return _isMixed;
            }
            set
            {
                if (_isMixed == value) return;
                _isMixed = value;
                OnPropertyChanged(nameof(IsMixedProduct));
            }
        }
        public double EscalarResult { get; set; }
        public double VectorIResult { get; set; }
        public double VectorJResult { get; set; }
        public double VectorKResult { get; set; }

        public ICommand CalculateCM { get; set; }
        public ICommand SelectEscalarCM { get; set; }
        public ICommand SelectVectorialCM { get; set; }
        public ICommand SelectMixedCM { get; set; }
        public LinearAlgebraViewModel()
        {
            IsEscalarProduct = true;
            IsVectorialProduct = false;
            IsMixedProduct = false;

            EscalarResult = 0;
            VectorIResult = 0;
            VectorJResult = 0;
            VectorKResult = 0;

            CalculateCM = new CalculateProductCommand(this);
            SelectEscalarCM = new SelectEscalarCommand(this);
            SelectVectorialCM = new SelectVectorialCommand(this);
            SelectMixedCM = new SelectMixedCommand(this);

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
