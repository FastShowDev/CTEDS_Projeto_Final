using Calculadora.Commands;
using Calculadora.Database;
using Calculadora.Models;
using Calculadora.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Calculadora.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
#nullable enable
        public event PropertyChangedEventHandler? PropertyChanged;
#nullable enable

        private int _viewHeight;
        public int ViewHeight
        {
            get { return _viewHeight; }
            set {
                if (_viewHeight == value) return;
                _viewHeight = value;
                OnPropertyChanged(nameof(ViewHeight));
            }
        }


        private int _viewWidth;
        public int ViewWidth
        {
            get { return _viewWidth; }
            set {
                if (_viewWidth == value) return;
                _viewWidth = value;
                OnPropertyChanged(nameof(ViewWidth));
            }
        }


        private string _viewName = "Base";
        public string ViewName
        {
            get => _viewName; 
            set {
                if (_viewName == value) return;
                _viewName = value; 
                OnPropertyChanged(nameof(ViewName)); 
            }
        }


        private bool isMenuOpen;
        public bool IsMenuOpen
        {
            get => isMenuOpen; 
            set { 
                if (value == isMenuOpen) return;
                isMenuOpen = value; 
                OnPropertyChanged(nameof(IsMenuOpen)); 
            }
        }

        private string _errorMessage = string.Empty;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage == value) return;
                _errorMessage = value;
                HasErrorMessage = !string.IsNullOrEmpty(value);
                OnPropertyChanged(nameof(ErrorMessage));


            }
        }

        private bool _hasErrorMessage = false;
        public bool HasErrorMessage
        {
            get { return _hasErrorMessage; }
            set
            {
                _hasErrorMessage = value;
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public ICommand OpenMenu { get; }
        public ICommand CloseMenu { get; }
        public ICommand NavigateMenuCM { get; }

        public BaseViewModel()
        {
            OpenMenu = new OpenMenuCommand(this);
            CloseMenu = new CloseMenuCommand(this);
            NavigateMenuCM = new NavigateCommand();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetDisplayError()
        {
            this.ErrorMessage = string.Empty;
        }

        public virtual void SetErrorMessage(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }
}
