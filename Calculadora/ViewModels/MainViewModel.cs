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
            ViewHeight = 650;
            ViewWidth = 450;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
