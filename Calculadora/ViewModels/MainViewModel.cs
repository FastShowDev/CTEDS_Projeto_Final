using Calculadora.Stores;
using System.ComponentModel;

namespace Calculadora.ViewModels
{
    public class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public BaseViewModel CurrentViewModel => NavigationStore.CurrentViewModel;

        public MainViewModel()
        {
            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            ViewName = "Main";
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
