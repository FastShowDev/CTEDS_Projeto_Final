using Calculadora.Commands;
using Calculadora.Database;
using Calculadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculadora.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool isMenuOpen = false;
        public bool IsMenuOpen
        {
            get { return isMenuOpen; }
            set { isMenuOpen = value; OnPropertyChanged(nameof(IsMenuOpen)); }
        }


        public ICommand OpenMenu { get; }
        public ICommand CloseMenu { get; }

        public BaseViewModel()
        {
            OpenMenu = new OpenMenuCommand(this);
            CloseMenu = new CloseMenuCommand(this);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
