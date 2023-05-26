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

        private double _escalarResult;
        public double EscalarResult { 
            get { return _escalarResult; }
            set
            {
                if (value == _escalarResult) return;
                _escalarResult = value;
                OnPropertyChanged(nameof(EscalarResult));
            }
        }

        private double i;
        public double VectorIResult { 
            get { return i; }
            set
            {
                if (i == value) return;
                i = value;
                OnPropertyChanged(nameof(VectorIResult));
            }
        }

        private double j;
        public double VectorJResult { 
            get { return j; }
            set
            {
                if (j == value) return;
                j = value;
                OnPropertyChanged(nameof(VectorJResult));
            }
        }

        private double k;
        public double VectorKResult { 
            get { return k; }
            set
            {
                if (k == value) return;
                k = value;
                OnPropertyChanged(nameof(VectorKResult));
            }
        }

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
